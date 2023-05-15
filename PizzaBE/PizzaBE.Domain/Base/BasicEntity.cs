using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Domain.Base
{
    public abstract class BasicEntity<TId>
    {
        protected BasicEntity()
        {
        }

        [Column("id")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public TId Id { get; set; } = default(TId);

    }
}
