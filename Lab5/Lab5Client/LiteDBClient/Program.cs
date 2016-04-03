using LiteDBClient.MovieRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Filmweb filmweb = new Filmweb();
                filmweb.StartUsing();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Wystąpił błąd {0} o treści {1}", ex.GetType().ToString(), ex.Message));
            }
        }
    }
}
