using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuitTest
{
    public class ClassModel
    {
        public int id { get; set; }
        public int category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }
        public string[] tags { get; set; }
        public string createdAt { get; set; }
    }

    public class Model3
    {
        public int id { get; set; }
        public int category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }
        public string createdAt { get; set; }
    }

    public class model3Temp : ClassModel
    {
        public List<items> items { get; set; }
    }

    public class items
    {
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }

    }
}
