using LiteDBService.DBProvider.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBService.PersonReviewRepository.DTOModels
{
    public class PersonDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
