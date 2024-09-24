using Google.Cloud.Firestore;

namespace Shopify.Admin.Domain
{
    [FirestoreData]
    public class InternalUser
    {
        [FirestoreDocumentId]
        public string id { get; set; }
        [FirestoreProperty]
        public string username { get; set; }
        [FirestoreProperty]
        public string password { get; set; }
        [FirestoreProperty]
        public string displayName { get; set; }

    }
}
