using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrowser
{
    public class Car
    {
        public Car() { }

        public Car(string url, string name, string description)
            => (Url, Name, Description) = (url, name, description);

        public string Url { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
