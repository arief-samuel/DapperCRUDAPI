using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUDAPI.Models
{
    public class Product
    {
        [Key]
        public int PoductId { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public Double Price { get; set; }

    }
}
