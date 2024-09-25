using Google.Cloud.Firestore;
using Shopify.Domain.Customer;

namespace Shopify.Domain.ShopifyStoreFront
{
    public class CustomerShopifyModelResponse
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Customer customer { get; set; }
    }


    
    public class Customer
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string didsplayName { get; set; }
        public string email { get; set; }
        public string? phone { get; set; }
        public bool? acceptsMarketing { get; set; }
        public Defaultaddress defaultAddress { get; set; }
    }

    public class Defaultaddress
    {
        public string? address1 { get; set; }
        public string? address2 { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string? province { get; set; }
        public string? zip { get; set; }
    }

   


}
