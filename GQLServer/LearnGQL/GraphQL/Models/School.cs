using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnGQL.GraphQL.Models
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }

#nullable enable
        [ForeignKey(nameof(ParentSchoolId))]
        public School? ParentSchool { get; set; }

        public int? ParentSchoolId { get; set; }
#nullable disable
        public List<Implementation> Implementations { get; set; }
    }
}
