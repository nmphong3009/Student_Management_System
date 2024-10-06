using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IEntityBase<TId>
    {
        TId Id { get; set; }
    }
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
