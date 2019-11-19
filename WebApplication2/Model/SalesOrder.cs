using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class SalesOrder
    {
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string DocNum { get; set; }
        public string DocDate { get; set; }

        public string DocTotal { get; set; }
    }
}
