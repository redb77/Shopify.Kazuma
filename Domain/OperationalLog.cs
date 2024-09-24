namespace Shopify.Admin.Domain
{
    public class OperationalLog
    {
        public string Id { get; set; }
        public string InternalUserId { get; set; }
        public string OperationType { get; set; }
        public eOperationOrigin OperationOrigin { get; set; }
    }
    public enum eOperationOrigin
    {
        APP=1,
        SHOPIFY=2
    }



    public class OperationalLogModel
    {
        public string Id { get; set; }
        public InternalUser InternalUser { get; set; }
        public string OperationType { get; set; }
        public eOperationOrigin OperationOrigin { get; set; }
    }
   
}
