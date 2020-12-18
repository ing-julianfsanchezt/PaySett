using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PaySettCompany.Entities
{
    [DataContract]
    public class ProductsList
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public float TotalCost { get; set; }

    }
}
