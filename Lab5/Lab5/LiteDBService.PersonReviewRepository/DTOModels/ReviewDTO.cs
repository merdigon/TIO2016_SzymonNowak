using LiteDBService.DBProvider.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBService.PersonReviewRepository.DTOModels
{
    public class ReviewDTO :BaseDTO
    {
        public string Content { get; set; }
        public int Score { get; set; }
        public int AuthorID { get; set; }
        public int MovieId { get; set; }
    }
}
