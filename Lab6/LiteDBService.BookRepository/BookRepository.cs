using LiteDB;
using LiteDBService.DBProvider;
using LiteDBService.DBProvider.BaseObjects;
using LiteDBService.BookRepository.DTOModels;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBService.BookRepository
{
    public class BookRepository : RepositoryBase<Book, BookDTO>
    {        
        public BookRepository()
            : base(@"C:\tmp\book", "books") { }

        public override Book Map(BookDTO model)
        {
            if(model==null)
                return null;
            return new Book()
            {
                Id = model.Id,
                BookTitle = model.BookTitle,
                ISBN = model.ISBN
            };
        }

        public override BookDTO InverseMap(Book model)
        {
            if (model == null)
                return null;
            return new BookDTO()
            {
                Id = model.Id,
                BookTitle = model.BookTitle,
                ISBN = model.ISBN
            };
        }
    }
}
