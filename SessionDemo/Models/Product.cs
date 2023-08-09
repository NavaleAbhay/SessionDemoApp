using System.ComponentModel;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace SessionDemo.Models
{
    [Serializable]
    public class Product
    {
        public int ID { get; set; }

        [DisplayName("Item Name")]
        public string ProductName { get; set; }

        [DisplayName("Unit Price")]
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }
           public string Description { get; set; }


        [DisplayName("TotalAmount")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
    }
}
