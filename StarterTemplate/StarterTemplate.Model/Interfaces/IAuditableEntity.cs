using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterTemplate.Model
{
    public interface IAuditableEntity
    {
        DateTime CreatedDateTime { get; set; }

        long CreatedBy { get; set; }

        DateTime UpdatedDateTime { get; set; }

        long UpdatedBy { get; set; }
    }
}
