using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pe2020.Models
{
    public class City
    {
        [SQLite.PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(5)]
   
        public string Condition { get; set; }

        [Ignore]
        public WeatherData Weather { get; set; }

        [Ignore]
        public bool Selected { get; set; }
    }
}

