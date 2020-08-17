using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication2.Model
{
    public class RequestedModelSpecifications
    {
        [Key]
        public int specificationsId { get; set; }
        public double thickness { get; set; }
        public int colorId { get; set; }
        [ForeignKey(nameof(colorId))]
        [InverseProperty(nameof(Colors.requestedModelSpecifications))]
        public virtual Colors colors { get; set; }

        public int sizeId { get; set; }
        [ForeignKey(nameof(sizeId))]
        [InverseProperty(nameof(Size.requestedModelSpecifications))]
        public virtual Size size { get; set; }

        public int DesignTopologyId { get; set; }

        [ForeignKey(nameof(DesignTopologyId))]
        [InverseProperty(nameof(DesignTopology.requestedModelSpecifications))]
        public virtual DesignTopology designTopology { get; set; }
    }
}
