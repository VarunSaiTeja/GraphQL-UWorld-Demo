using HotChocolate.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnGQL.Entities
{
    public class Group : BaseDataModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
        public int CourseId { get; set; }

        [ForeignKey(nameof(SchoolId))]
        public School School { get; set; }
        public int SchoolId { get; set; }

        [ForeignKey(nameof(ImplementationId))]
        public Implementation Implementation { get; set; }
        public int ImplementationId { get; set; }

        [ForeignKey(nameof(CourseImplementationId))]
        public CourseImplementation CourseImplementation { get; set; }
        public int CourseImplementationId { get; set; }

        [ForeignKey(nameof(LeadFacultyId))]
        public User LeadFaculty { get; set; }
        public int LeadFacultyId { get; set; }

        [UseFiltering]
        public List<UserGroup> Users { get; set; }
    }
}
