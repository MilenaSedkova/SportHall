using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthMicroService.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string name { get; set; } = null!;
        public string? surname { get; set; }
        public string email { get; set; } = null!;
        public string passwordHash { get; set; } = null!;
        public string role { get; set; } = null!;
        public bool isActive { get; set; } = true;
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
