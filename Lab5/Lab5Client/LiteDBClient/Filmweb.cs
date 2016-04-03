using LiteDBClient.MovieRepository;
using LiteDBClient.PersonReviewRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBClient
{
    public class Filmweb
    {
        Person User { get; set; }

        MovieRepositoryServiceClient MovieRepo { get; set; }
        PersonReviewRepositoryServiceClient PersonReviewRepo { get; set; } 

        public Filmweb()
        {
            MovieRepo = new MovieRepositoryServiceClient();
            PersonReviewRepo = new PersonReviewRepositoryServiceClient();
            InitFilmweb();
        }

        private void InitFilmweb()
        {
            try
            {
                if (MovieRepo.ReadAllMovies().Count() == 0)
                {
                    MovieRepo.CreateMovie(new Movie()
                    {
                        ReleaseYear = 1992,
                        Title = "Sharkonado"
                    });
                    MovieRepo.CreateMovie(new Movie()
                    {
                        ReleaseYear = 2001,
                        Title = "Naga broń"
                    });
                    MovieRepo.CreateMovie(new Movie()
                    {
                        ReleaseYear = 2016,
                        Title = "Deadpool"
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Wystąpił błąd {0} o treści {1}", ex.GetType().ToString(), ex.Message));
            }
        }

        public void StartUsing()
        {
            bool serviceOnline = true;

            if(User == null)
                User = new Person();

            Console.WriteLine("Podaj swoje imie:");
            User.Name = Console.ReadLine();
            Console.WriteLine("Podaj swoje nazwisko:");
            User.Surname = Console.ReadLine();

            if ((User = PersonReviewRepo.ReadPersonByNameAndSurname(User.Name, User.Surname)) == null)
            {
                User.Id = PersonReviewRepo.CreatePerson(User);
            }
            else
            {
                Console.WriteLine(string.Format("Witaj ponownie, {0} {1}", User.Name, User.Surname));
            }

            while (serviceOnline)
            {
                switch (ShowMenuAndGetMenuOption())
                {
                    case 'a':
                        AddReview();
                        break;
                    case 'b':
                        EditReview();
                        break;
                    case 'c':
                        DeleteReview();
                        break;
                    case 'd':
                        ShowReviewsForMovie();
                        break;
                    case 'e':
                        AddNewMovie();
                        break;
                    case 'f':
                        serviceOnline = false;
                        break;
                }
            }
        }

        public char ShowMenuAndGetMenuOption()
        {
            try
            {
                Console.WriteLine("a) Dodanie recenzji.");
                Console.WriteLine("b) Edycja recenzji.");
                Console.WriteLine("c) Usunięcie recenzji.");
                Console.WriteLine("d) Zobacz recenzję dla filmu.");
                Console.WriteLine("e) Dodaj film.");
                Console.WriteLine("f) Zakończ");
                return Console.ReadKey().KeyChar;
            }
            finally
            {
                Console.WriteLine();
            }
        }

        public void ShowReviewsForMovie()
        {            
            int movieNr;
            if ((movieNr = ShowMoviesAndGetMovieNumber()) > 0)
            {
                List<Review> reviews = PersonReviewRepo.ReadReviewForMovie(movieNr).ToList();
                if (reviews.Count() > 0)
                {
                    float averageScore = reviews.Sum(p => p.Score) / reviews.Count();
                    Console.WriteLine(string.Format("Średnia ocena dla tego filmu: {0}", averageScore));
                    foreach (Review review in reviews)
                    {
                        Console.WriteLine(string.Format("{0} {1} napisał:", (review.Author == null ? string.Empty : review.Author.Name), (review.Author == null ? string.Empty : review.Author.Surname)));
                        Console.WriteLine(string.Format("\"{0}\"", review.Content));
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Brak recenzji dla wybranego filmu");
                }
            }
        }

        public void AddNewMovie()
        {
            Movie movie = new Movie();
            Console.WriteLine("Podaj tytuł filmu:");
            movie.Title = Console.ReadLine();
            Console.WriteLine("Podaj rok produkcji filmu:");
            int year;
            string yearLine = Console.ReadLine();
            while (!Int32.TryParse(yearLine, out year) && year > 1900)
            {
                Console.WriteLine("Wpisana linijka nie jest rokiem! Spróbuj ponownie.");
                yearLine = Console.ReadLine();
            }
            movie.ReleaseYear = year;
            MovieRepo.CreateMovie(movie);
        }

        public void EditReview()
        {
            Review review;
            if ((review = ShowUsersReviewAndGetReview()) != null)
            {
                Console.WriteLine("Obecna treść recenzji:");
                Console.WriteLine(review.Content);
                Console.WriteLine("Wpisz nową treść:");
                review.Content = Console.ReadLine();
                Console.WriteLine(string.Format("Obecna ocena to {0}, podaj nową:", review.Score));
                int grade;
                string gradeLine = Console.ReadLine();
                while (!Int32.TryParse(gradeLine, out grade))
                {
                    Console.WriteLine("Wpisana linijka nie jest oceną! Spróbuj ponownie.");
                    gradeLine = Console.ReadLine();
                }
                review.Score = (grade > 100 ? 100 : (grade < 0 ? 0 : grade));

                PersonReviewRepo.UpdateReview(review);
            }
            else
                Console.WriteLine("Brak recenzji o takim numerze!");
        }

        public void DeleteReview()
        {
            Review review;
            if ((review = ShowUsersReviewAndGetReview()) != null)
            {
                Console.WriteLine(string.Format("Czy na pewno chcesz usunąć recenzję o numerze {0}? N/T", review.Id));
                char option = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (option)
                {
                    case 'T':
                    case 't':
                        if (PersonReviewRepo.DeleteReview(review))
                            Console.WriteLine("Recenzja usunięta");
                        else
                            Console.WriteLine("Recenzja nie została usunięta");
                        break;
                    default:
                        Console.WriteLine("Anulowano.");
                        break;
                }
            }
            else
                Console.WriteLine("Brak recenzji o takim numerze!");
        }

        public void AddReview()
        {
            int movieNr;
            if ((movieNr = ShowMoviesAndGetMovieNumber()) > 0)
            {
                Review newReview = new Review();
                Console.WriteLine("Wpisz swoją recenzję. Naciśniecie Enter kończy wpisywanie.");
                newReview.Content = Console.ReadLine();
                Console.WriteLine("Wpisz swoją ocenę.");
                int grade;
                string gradeLine = Console.ReadLine();
                while (!Int32.TryParse(gradeLine, out grade))
                {
                    Console.WriteLine("Wpisana linijka nie jest oceną! Spróbuj ponownie.");
                    gradeLine = Console.ReadLine();
                }
                newReview.Score = (grade > 100 ? 100 : (grade < 0 ? 0 : grade));
                newReview.MovieId = movieNr;
                newReview.Author = User;
                if (PersonReviewRepo.CreateReview(newReview) > 0)
                    Console.WriteLine("Utworzono pozytywnie recenzje");
            }
            else
                Console.WriteLine("Brak filmu o takim numerze!");
        }

        public Review ShowUsersReviewAndGetReview()
        {
            List<Review> reviewList = PersonReviewRepo.ReadReviewForUser(User.Id).ToList();
            Console.WriteLine("Lista Twoich recenzji:");
            foreach (Review review in reviewList)
            {
                Console.WriteLine(string.Format("{0}. Score: {1}/100:", review.Id, review.Score));
                Console.WriteLine(string.Format("\"{0}\"", review.Content));
            }
            int reviewNr;
            if (Int32.TryParse(Console.ReadLine(), out reviewNr))
            {
                return reviewList.Where(p => p.Id == reviewNr).FirstOrDefault();
            }
            return null;
        }

        public int ShowMoviesAndGetMovieNumber()
        {
            List<Movie> movieList = MovieRepo.ReadAllMovies().ToList();
            Console.WriteLine("Lista filmów:");
            foreach (Movie movie in movieList)
            {
                Console.WriteLine(string.Format("{0}. \"{1}\", {2};", movie.Id, movie.Title, movie.ReleaseYear));
            }
            int movieNr;
            if (Int32.TryParse(Console.ReadLine(), out movieNr))
            {
                if (movieList.Where(p => p.Id == movieNr).Count() == 1)
                {
                    return movieNr;
                }
            }
            return 0;
        }
    }
}
