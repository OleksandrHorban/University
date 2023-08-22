using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFCollections.DAL.Entities
{
    public class CoinsCatalog
    {
        [Key]
        public int CoinId { get; set; }
        public string? Name { get; set; }

        public string? Country { get; set; }
        public int GraduationYear { get; set; }

        public int Par { get; set; }

        public string? Description { get; set; }
    }
}
