using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Kazuma.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class ShopifyPriceRule
    {
        /// <summary>
        /// The title of the price rule. This is used by the Shopify admin search to retrieve discounts. It is also displayed on the Discounts page of the Shopify admin for bulk discounts.
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// fixed_amount: Applies a discount of value as a unit of the store's currency. For example, if value is -30 and the store's currency is USD, then $30 USD is deducted when the discount is applied.
        /// percentage: Applies a percentage discount of value.For example, if value is -30, then 30% will be deducted when the discount is applied.
        /// If target_type is shipping_line, then only percentage is accepted.
        /// </summary>
        public string valuetype { get; set; }
        /// <summary>
        /// all: The price rule is valid for all customers.
        // prerequisite: The customer must either belong to one of the customer segments specified by customer_segment_prerequisite_ids,
        // or be one of the customers specified by prerequisite_customer_ids.
        /// </summary>
        public string customerselection { get; set; }

        /// <summary>
        /// The target type that the price rule applies to. Valid values:
        /// line_item: The price rule applies to the cart's line items.
        /// shipping_line: The price rule applies to the cart's shipping lines.
        /// </summary>
        public string targettype { get; set; }

        /// <summary>
        /// The target selection method of the price rule. Valid values:
        /// all: The price rule applies the discount to all line items in the checkout.
        /// entitled: The price rule applies the discount to selected entitlements only.
        /// </summary>
        public string targetselection { get; set; }

        /// <summary>
        /// The allocation method of the price rule. Valid values:
        /// each: The discount is applied to each of the entitled items. For example, for a price rule that takes $15 off, each entitled line item in a checkout will be discounted by $15.
        /// across: The calculated discount amount will be applied across the entitled items. For example, for a price rule that takes $15 off, the discount will be applied across all the entitled items.
        /// </summary>
        public string allocationmethod { get; set; }

        /// <summary>
        /// The date and time (ISO 8601 format) when the price rule starts.
        /// </summary>
        public DateTime startsat { get; set; }

        /// <summary>
        /// List of collection ids that will be a prerequisites for a Buy X Get Y discount. The entitled_collection_ids can be used only with:
        /// target_type set to line_item,
        /// target_selection set to entitled,
        /// allocation_method set to each and
        /// prerequisite_to_entitlement_quantity_ratio defined.
        /// Cannot be used in combination with prerequisite_product_ids or prerequisite_variant_ids.
        /// </summary>
        public List<long> prerequisitecollectionids { get; set; }

        /// <summary>
        /// A list of IDs of products that will be entitled to the discount. It can be used only with target_type set to line_item and target_selection set to entitled.
        /// </summary>
        public List<long> entitledproductids { get; set; }
        /// <summary>
        /// Buy/Get ratio for a Buy X Get Y discount. prerequisite_quantity defines the necessary 'buy' quantity and entitled_quantity the offered 'get' quantity.
        /// value_type set to percentage,
        /// target_type set to line_item,
        /// target_selection set to entitled,
        /// allocation_method set to each,
        /// prerequisite_product_ids or prerequisite_variant_ids or prerequisite_collection_ids defined and
        /// entitled_product_ids or entitled_variant_ids or entitled_collection_ids defined.
        /// </summary>
        public prerequisitetoentitlementquantityratio prerequisitetoentitlementquantityratio { get; set; }

        /// <summary>
        /// The number of times the discount can be allocated on the cart - if eligible. For example a Buy 1 hat Get 1 hat for free discount can be applied 
        /// 3 times on a cart having more than 6 hats, where maximum of 3 hats get discounted - if the allocation_limit is 3.
        /// Empty (null) allocation_limit means unlimited number of allocations.
        /// </summary>
        public int allocationlimit { get; set; }

    }

    public class prerequisitetoentitlementquantityratio
    {
        public int prerequisite_quantity { get; set; }
        public int entitled_quantity { get; set; }
    }
}
