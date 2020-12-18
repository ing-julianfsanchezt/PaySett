using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PaySettCompany.Entities
{
    [DataContract]
    public class Purchase
    {
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string MadeBy { get; set; }
        [DataMember]
        public List<Category> Category { get; set; }
    }
}
