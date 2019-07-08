using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Angular.Template.DataEntity
{
    public abstract class EntityBase
    {
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
