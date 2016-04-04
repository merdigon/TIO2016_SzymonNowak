using LiteDBService.DBProvider;
using LiteDBService.DBProvider.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBService.AuthorRepository.DTOModels
{
    public class AuthorDTO : BaseDTO
    {
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
    }
}
