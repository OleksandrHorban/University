using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFCollections.DAL.Entities
{
    public class BillsCatalog
    {
        [Key]
        public int BillID { get; set; }
        public string? Name { get; set; }

        public string? Country { get; set; }

        public int GraduationYear { get; set; }

        public string? TypeOfSecurity { get; set; }
        public string? Description { get; set; }
    }
}
