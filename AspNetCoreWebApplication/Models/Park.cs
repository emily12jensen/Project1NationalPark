using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Models
{
    public class Park
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int Date { get; set; }

        public string Image { get; set; }
    }
}
