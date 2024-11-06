using Google.Cloud.Firestore;

namespace Shopify.Kazuma.Domain
{
    [FirestoreData]
    public class VersionInfo
    {
        [FirestoreProperty]
        public string version { get; set; }
        [FirestoreProperty]
        public bool forceDownload { get; set; }
    }
}
