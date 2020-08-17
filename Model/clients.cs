using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class clients
    {
        [Key]
        public int clientId { get; set; }

        public string clientName { get; set; }
        [JsonIgnore]
        public virtual List<Requests> requests { get; set; }
    }
}
