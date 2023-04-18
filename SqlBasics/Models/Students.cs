using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlBasics.Models
{
    internal class Students
    {
        public int id { get; set; }
        public string nume { get; set; }    
        public string prenume { get; set; } 
        public int varsta { get; set; }    
        public Specializare specializare { get; set; }  

    }
}
