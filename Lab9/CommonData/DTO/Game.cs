using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData.DTO
{
    public class Game : DTOBase
    {
        public string Title { get; set; }

        public string CreatorCompany { get; set; }

        public int Year { get; set; }

        public int AgeRate { get; set; }
    }
}
