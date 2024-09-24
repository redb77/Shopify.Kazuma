


namespace Shopify.Admin.Domain.Loyalty
{


    public class DiscountCodeResponse
    {
        public Discount_Code discount_code { get; set; }
    }

    public class Discount_Code
    {
        public long id { get; set; }
        public long price_rule_id { get; set; }
        public string code { get; set; }
        public int usage_count { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

}
