using SLaw.Domain.Entities.Common;

namespace SLaw.Domain.Entities
{
    public class ContactForm : BaseEntity
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }
    }
}
