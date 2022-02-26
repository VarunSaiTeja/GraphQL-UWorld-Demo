using HotChocolate.AspNetCore.Authorization;
using System.Collections.Generic;

namespace LearnGQL.Entities
{
    public class Course : BaseDataModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public bool IsActive { get; set; }
        [Authorize]
        public bool HasUnitTests { get; set; }

        public List<Group> Groups { get; set; }
    }
}
