using System.ComponentModel.DataAnnotations;

namespace ForumDAL.Entities
{
    public class Definition
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Theme { get; set; }

        public string? Problem { get; set; }

        public int? UserId { get; set; }
    }
}
