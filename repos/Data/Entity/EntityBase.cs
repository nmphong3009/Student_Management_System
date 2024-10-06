using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data
{
    [Serializable]
    public class EntityBase<TId> : IEntityBase<TId>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public virtual TId Id { get; set; }
    }

    public abstract class DeleteEntity<TId> : EntityBase<TId>, ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
