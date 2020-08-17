using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class DesignTopology
    {
        [Key]
       public int designTopologyId { get; set;}
       public string DesignTopologyName { get; set;}
        [JsonIgnore]
        public List<RequestedModelSpecifications> requestedModelSpecifications { get; set; }
    }
}
