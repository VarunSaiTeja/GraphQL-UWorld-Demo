using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnGQL.GraphQL.Models
{
    public class Implementation : BaseDataModel
    {
        public int ImplementationId { get; set; }
        
        public string Name { get; set; }
        
        public bool IsActive { get; set; }
        
        [ForeignKey(nameof(SchoolId))]
        public School School { get; set; }
        public int SchoolId { get; set; }
    }
}
