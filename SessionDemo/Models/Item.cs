using  SessionDemo.Models;
namespace SessionDemo.Models
{
    [Serializable] 
    public class Item
    {
       //public int ProductID{get;set;}
       public Product theProduct{get;set;}
       //public int ID{get;set;}
       public int Quantity{get;set;}
        public Item(){    }
    }
}