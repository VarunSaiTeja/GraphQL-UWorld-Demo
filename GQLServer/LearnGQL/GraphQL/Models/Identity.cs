using HotChocolate;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnGQL.GraphQL.Models
{
    [Table("Users")]
    public class Identity
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [GraphQLIgnore]
        public string Password { get; set; }

        public bool TwoStepVerificationEnabled { get; set; }

        public bool LockoutEnabled { get; set; }

        public DateTime? LockoutEnd { get; set; }
    }
}
