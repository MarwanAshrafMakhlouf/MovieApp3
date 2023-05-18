    using mvc.Models;

namespace mvc.Models
{
    public class PeopleRoles
    {
        public int personId { get; set; }
        public virtual People person { get; set; }
        public int roleId { get; set; }
        public virtual Roles role { get; set; }
    }
}
