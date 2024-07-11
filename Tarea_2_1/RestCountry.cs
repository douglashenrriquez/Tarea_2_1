using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_2_1
{
    public class RestCountry
    {
        public Name name { get; set; }
        public Flags flags { get; set; }
        public int population { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public IDictionary<string, string> languages { get; set; }
        public IDictionary<string, Currency> currencies { get; set; }
        public List<double> latlng { get; set; }
    }

    public class Name
    {
        public string common { get; set; }
    }

    public class Flags
    {
        public string svg { get; set; }
    }

    public class Currency
    {
        public string name { get; set; }
        public string symbol { get; set; }
    }

}
