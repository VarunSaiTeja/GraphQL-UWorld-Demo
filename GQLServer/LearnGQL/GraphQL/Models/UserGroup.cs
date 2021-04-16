using System.ComponentModel.DataAnnotations.Schema;

namespace LearnGQL.GraphQL.Models
{
    public class UserGroup
    {
        public Role Role { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}
