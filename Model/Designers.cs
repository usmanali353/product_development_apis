using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Designers
    {
        [Key]
        public int designerId { get; set; }

        public string designerName { get; set; }
        [JsonIgnore]
        public List<DesignersInvolved> designersInvolved { get; set; }
    }
}
