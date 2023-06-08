using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFCollections.DAL.Entities
{
    public class AnotherCatalog
    {
        [Key]
        public int AnotherID { get; set; }
        
        public string? Name { get; set;}

        public string? Type { get; set; }

        public string? Location { get; set; }
        public string? Description { get; set;}
    }
}
