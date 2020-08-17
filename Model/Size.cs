using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Size
    {
        [Key]
        public int sizeId { get; set; }
        public string sizeName { get; set; }
        [JsonIgnore]
        public List<RequestedModelSpecifications> requestedModelSpecifications { get; set; }
    }
}
