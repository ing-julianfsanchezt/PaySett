using System.Runtime.Serialization;

namespace PaySettCompany.Entities
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public float UnitCost { get; set; }

    }
}
