using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Requests
    {
        [Key]
        public int requestId { get; set; }
        public string requestType { get; set; }
        public string classification { get; set; }
        public string requestDate { get; set; }
        public string designerObservations { get; set; }

        public string commercialObservation { get; set; }
        public string technical_consideration { get; set; }
        public string status { get; set; }
        public string image { get; set; }
        public string other { get; set; }
        public string market { get; set; }
        public string suitibility { get; set; }
        public int clientId { get; set; }
        [ForeignKey(nameof(clientId))]
        [InverseProperty(nameof(clients.requests))]
        public virtual clients client { get; set; }

        public int surfaceId { get; set; }
        [ForeignKey(nameof(surfaceId))]
        [InverseProperty(nameof(Surface.requests))]
        public virtual Surface surface { get; set; }

        public List<RequestedModelSpecifications> requestedModelSpecifications { get; set; }

        public List<DesignersInvolved> designersInvolved { get; set; }
    }
}
