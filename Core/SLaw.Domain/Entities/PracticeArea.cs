using SLaw.Domain.Entities.Common;

namespace SLaw.Domain.Entities
{
    public class PracticeArea : BaseEntity
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }
    }
}
