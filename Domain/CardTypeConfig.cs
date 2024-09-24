namespace Shopify.Domain.Loyalty
{
    public class CardTypeConfig
    {
        /// <summary>
        /// Card Type
        /// </summary>
        public enumCardType cardType { get; set; }
        /// <summary>
        /// amount spent at Kazuama Store to have x points
        /// </summary>
        public decimal amount { get; set; }
        /// <summary>
        /// number of points calculated on the minimum cost amount
        /// </summary>
        public int points { get; set; } 
    }
}
