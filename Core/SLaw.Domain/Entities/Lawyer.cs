using SLaw.Domain.Entities.Common;

namespace SLaw.Domain.Entities
{
    public class Lawyer : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Title { get; set; }

        public string CellPhone { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
