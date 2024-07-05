using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.DTO
{
    public class WeatherResult
    {
        public string name { get; set; }
        public int timezone { get; set; }
        public Coord coord { get; set; }
        public Main main { get; set; }
    }
    public class Coord
    {
        public int lon { get; set; }
        public int lat { get; set; }
    }


    public class Main
    {
        public decimal temp { get; set; }
        public decimal humidity { get; set; }
    }
}
