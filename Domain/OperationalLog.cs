using Google.Cloud.Firestore;

namespace Shopify.Admin.Domain
{
    [FirestoreData]
    public class OperationalLog
    {
        [FirestoreDocumentId]
        public string Id { get; set; }
        [FirestoreProperty]
        public string InternalUserId { get; set; }
        [FirestoreProperty]
        public string OperationType { get; set; }
        [FirestoreProperty]
        public eOperationOrigin OperationOrigin { get; set; }
    }
    [FirestoreData]
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
