namespace Shopify.Admin.Domain.Loyalty
{
    /// <summary>
    /// Oggetto DiscountCodeRequest
    /// </summary>
    public class DiscountCodeRequest
    {
        /// <summary>
        /// discount code
        /// </summary>
        public string DiscountCode { get; set; }
        /// <summary>
        /// Internal UserId restituito in fase di login
        /// </summary>
        public string InternalUserId { get; set; }
        /// <summary>
        /// Operation Origin Type.
        /// I possibili valori sono:
        /// 1: APP (operazione effettuata da app)
        /// 2: SHOPIFY (operazione effettuata da sito web)
        /// </summary>
        public eOperationOrigin OperationOrigin { get; set; }
    }
}
