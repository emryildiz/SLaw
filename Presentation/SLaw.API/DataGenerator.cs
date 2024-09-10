using SLaw.Domain.Entities;
using SLaw.Persistence.Contexts;

namespace SLaw.API
{
    public class DataGenerator
    {
        public static void Generate(SLawDbContext dbContext)
        {
            if (dbContext.AboutUs.FirstOrDefault() is null)
            {
                dbContext.AboutUs.Add(new AboutUs()
                {
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus ac urna bibendum, porttitor lacus sed, pharetra ligula. Mauris venenatis augue felis, non rhoncus neque interdum vitae. Morbi in sem ut neque placerat volutpat ultricies luctus nisl. Maecenas at orci rhoncus, elementum eros in, pretium urna. Cras sit amet dictum ante. Ut tristique non nulla id blandit. Nam malesuada metus dui, bibendum sagittis tortor tristique et. Proin euismod diam eu nibh maximus viverra. Nulla suscipit diam sit amet ligula pellentesque, egestas malesuada ex ullamcorper. Integer facilisis leo nulla, sit amet convallis eros consectetur id. Vestibulum volutpat nulla maximus interdum gravida. Mauris dolor dolor, tempor vitae consectetur eget, fermentum et dui. Nam pulvinar dui odio, nec hendrerit mauris volutpat non. Quisque enim metus, pulvinar non accumsan sodales, fringilla eu velit. Aenean sodales felis mi. Nunc in urna sapien. Aliquam interdum eu erat eu condimentum. Donec suscipit nunc nisi, in feugiat tellus blandit vitae. Nunc a erat id nibh scelerisque porta tempor vel diam. Quisque mattis, nibh id blandit dignissim, sapien arcu vulputate purus, ac maximus libero velit sed nisi. Etiam ac ullamcorper leo. Etiam id consequat nulla. Suspendisse sed sollicitudin sem. Aenean eget odio ut elit ornare maximus."
                });
            }

            dbContext.SaveChanges();
        }
    }
}
