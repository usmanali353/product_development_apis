using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Colors
    {
        [Key]
        public int colorId { get; set; }
        public string colorName { get; set; }
        [JsonIgnore]
        public List<RequestedModelSpecifications> requestedModelSpecifications { get; set; }
    }
}
