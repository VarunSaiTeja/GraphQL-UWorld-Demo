using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnGQL.GraphQL.Models
{
    public class CourseImplementation : BaseDataModel
    {
        public int CourseImplementationId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
        public int CourseId { get; set; }

        [ForeignKey(nameof(ImplementationId))]
        public Implementation Implementation { get; set; }
        public int ImplementationId { get; set; }

        public List<Group> Groups { get; set; }
    }
}
