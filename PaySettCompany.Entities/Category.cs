using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PaySettCompany.Entities
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public int categoryCode { get; set; }
        [DataMember]
        public string categoryName { get; set; }
        [DataMember]
        public List<Product> Products { get; set; }
    }
}
