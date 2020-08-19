using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class DesignersInvolved
    {
      public int designersInvolvedId { get; set; }

     public int DesignerId { get; set; }
        [ForeignKey(nameof(DesignerId))]
        [InverseProperty(nameof(Designers.designersInvolved))]
        public virtual Designers designer { get; set; }

       // public List<DesignersInvolved> designersInvolved { get; set; }
    }
}
