using System;

namespace LearnGQL.GraphQL.Models
{
    public class BaseDataModel
    {
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
