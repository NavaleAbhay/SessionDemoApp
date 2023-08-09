
namespace SessionDemo.Models{
    
    [Serializable] 
    public class Cart{
        public List<Item> Items=new List<Item>();
        public Cart(){ 
        }
    }
}