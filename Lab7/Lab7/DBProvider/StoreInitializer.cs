using Lab7.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.DBProvider
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var books = new List<Book>
            {
                new Book() {BookTitle = "Christine", ISBN="1231"},
                new Book() {BookTitle = "Lśneinie", ISBN="14356"},

            };
            books.ForEach(i => context.Books.Add(i));
            context.SaveChanges();

            var genres = new List<Author>()
            {
                new Author() { AuthorName="Stephen", AuthorSurname="King"},
                new Author() { AuthorName="Glen", AuthorSurname="Cook" }
            };
            genres.ForEach(g => context.Authors.Add(g));
            context.SaveChanges();
        }
    }
}