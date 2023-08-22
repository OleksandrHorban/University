using System.ComponentModel.DataAnnotations;

namespace ForumDAL.Entities
{
    public class Discussion
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Theme { get; set; }
        public int UserId { get; set; }
        public int? Likes { get; set; }
        
    }
}
