using Google.Cloud.Firestore;
using Newtonsoft.Json;
using ShopifySharp;

namespace Shopify.Domain.Customer
{


    /// <summary>
    /// Details of a Customer
    /// </summary>
    [FirestoreData]
    public class CustomerDocument : Error
    {
        [FirestoreDocumentId]
        public string customerFBId { get; set; }
        /// <summary>
        /// customerToken
        /// </summary>
        [FirestoreProperty]
        public string customerToken { get; set; }
        /// <summary>
        /// number
        /// </summary>
        [FirestoreProperty]
        public string customerId { get; set; }
        /// <summary>
        /// string or null <email>
        /// </summary>
        [FirestoreProperty]
        public string? email { get; set; }
        /// <summary>
        /// string or null <email>
        /// </summary>
        [FirestoreProperty]
        public string? phone { get; set; }
        /// <summary>
        /// string or null
        /// </summary>
        [FirestoreProperty]
        public string? firstName { get; set; }
        /// <summary>
        /// string or null <email>
        /// </summary>
        [FirestoreProperty]
        public string? lastName { get; set; }
        /// <summary>
        /// string or null(?<month>0[1-9]|1[012])\-(?<day>0[1-9]|[12][0...Show pattern
        ///Birthday in MM-DD format
        /// </summary>
        [FirestoreProperty]
        public string? birthday { get; set; }
        /// <summary>
        /// Is reward program available for the customer?
        /// </summary>
        [FirestoreProperty]
        public bool? isRewardProgramAvailable { get; set; }

        /// <summary>
        /// List of card points
        /// </summary>
        [FirestoreProperty]
        public List<PointsDocument>? points { get; set; }

        /// <summary>
        /// Is the customer allowed to earn tier
        /// </summary>
        [FirestoreProperty]
        public bool? isAllowedToEarnTier { get; set; }

        /// <summary>
        /// Is referral program available for the customer?
        /// </summary>
        [FirestoreProperty]
        public bool? isReferralProgramAvailable { get; set; }
        /// <summary>
        /// string or null
        /// </summary>
        [FirestoreProperty]
        public string? referralLink { get; set; }
        /// <summary>
        /// Whether the customer has consented to receive marketing material by email.
        /// </summary>
        [FirestoreProperty]
        public bool? acceptsEmailMarketing { get; set; }
        /// <summary>
        /// Whether the customer has consented to receive marketing material by sms.
        /// </summary>
        [FirestoreProperty]
        public bool? acceptsSmsMarketing { get; set; }

        /// <summary>
        /// Array of discount codes
        /// </summary>
        [FirestoreProperty]
        public List<DiscountCodeDocument>? discountCodes { get; set; }

    }


    [FirestoreData]
    public class CardTypeDocument
    {
        [FirestoreProperty]
        public int eCardType { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
    }
    [FirestoreData]
    public class PointsDocument
    {
        [FirestoreProperty]
        public CardTypeDocument CardType { get; set; }
        [FirestoreProperty]
        public int pointsBalance { get; set; }
        /// <summary>
        /// string or null <date-time>
        /// </summary>
        [FirestoreProperty]
        public string? pointsExpiresAt { get; set; }
    }

    /// <summary>
    /// Current customer tier
    /// </summary>
    public class CurrenttierDocument
    {
        public int? id { get; set; }
        public string? title { get; set; }
        public string? image { get; set; }
        public DateTime? achievedAt { get; set; }
    }
    [FirestoreData]
    public class DiscountCodeDocument
    {
        /// <summary>
        /// The amount of the discount.
        /// </summary>
        [FirestoreProperty]
        public double Amount { get; set; }

        /// <summary>
        /// The discount code.
        /// </summary>
        [FirestoreProperty]
        public string Code { get; set; }

    }


}