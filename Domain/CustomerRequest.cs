namespace Shopify.Domain.Customer
{
    /// <summary>
    /// Ojbect customer request
    /// </summary>
    public class CustomerRequest
    {
        /// <summary>
        /// First name
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// Last Nmae
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Phone number of customer
        /// </summary>
        public string? Phone { get; set; }
    }
}
