using HotChocolate.Data;
using LearnGQL.GraphQL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnGQL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public Role Role { get; set; }

        [NotMapped]
        [IdentityResolver]
        public Identity Identity { get; set; }

        [UseFiltering]
        public List<UserGroup> Groups { get; set; }

        [ForeignKey(nameof(SchoolId))]
        public School School { get; set; }
        public int SchoolId { get; set; }
    }

    public enum Role
    {
        District, Campus, Faculty, Student
    }
}
