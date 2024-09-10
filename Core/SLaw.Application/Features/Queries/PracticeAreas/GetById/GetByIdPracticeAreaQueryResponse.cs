using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLaw.Application.Features.Queries.PracticeAreas.GetById
{
    public class GetByIdPracticeAreaQueryResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }
    }
}
