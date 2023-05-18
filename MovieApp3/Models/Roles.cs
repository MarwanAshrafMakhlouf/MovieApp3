using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public string Role { get; set; }
        public ICollection<PeopleRoles> PeopleRoles { get; set; }
    }
}
