using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Surface
    {
        [Key]
        public int surfaceId { get; set; }

        public string surfaceName { get; set; }
        [JsonIgnore]
        public virtual List<Requests> requests { get; set; }
    }
}
