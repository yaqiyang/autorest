
namespace Petstore.Models
{
    using System.Linq;

    public partial class Order
    {
        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        public Order() { }

        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        /// <param name="status">Order Status. Possible values include:
        /// 'placed', 'approved', 'delivered'</param>
        public Order(long? id = default(long?), long? petId = default(long?), int? quantity = default(int?), System.DateTime? shipDate = default(System.DateTime?), string status = default(string), bool? complete = default(bool?))
        {
            Id = id;
            PetId = petId;
            Quantity = quantity;
            ShipDate = shipDate;
            Status = status;
            Complete = complete;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public long? Id { get; private set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "petId")]
        public long? PetId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "shipDate")]
        public System.DateTime? ShipDate { get; set; }

        /// <summary>
        /// Gets or sets order Status. Possible values include: 'placed',
        /// 'approved', 'delivered'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "complete")]
        public bool? Complete { get; set; }

    }
}
