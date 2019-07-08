using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net.Angular.Template.DataEntity
{
    public interface IEntityFields
    {
        [NotMapped]
        Guid Identity { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
        bool IsDeleted { get; set; }
    }
}
