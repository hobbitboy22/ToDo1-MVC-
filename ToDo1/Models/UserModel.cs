using System.ComponentModel.DataAnnotations;

namespace ToDo1.Models
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(50)]
        public string Fname { get; set; }

        [Required, StringLength(50)]
        public string Lname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }

    }
}
