using AutoMapper;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using Shopify.Admin.Domain;
using Shopify.Domain.Customer;
using System.Dynamic;

namespace Shopify.DataManager
{
    /// <summary>
    /// Servizio di comunicazione Firebase
    /// </summary>
    public class FirestoreService : IFirestoreService
    {
        private readonly FirestoreDb _firestoreDb;
        private const string _collectionInternalUser = "internal.user";
        private const string _collectionLogOperation = "operationalLogs";
        private const string _collectionNameCustomer = "Customers";
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="firestoreDb"></param>
        public FirestoreService(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

        /// <summary>
        /// Recupera un utente interno
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<InternalUser> GetInternalUser(string username, string password)
        {
            var collection = _firestoreDb.Collection(_collectionInternalUser);
            var snapshot = await collection.GetSnapshotAsync();
            Query query = collection.WhereEqualTo("username", username).WhereEqualTo("password", password);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            if (querySnapshot.Documents.Count > 0)
            {
                var internalUser = querySnapshot.Documents.SingleOrDefault()!.ConvertTo<InternalUser>();

                return internalUser;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Inserisci i log di esecuzione di una operazione
        /// </summary>
        /// <param name="operationalLog"></param>
        /// <returns></returns>
        public async Task AddALogsync(OperationalLog operationalLog)
        {
            var collection = _firestoreDb.Collection(_collectionLogOperation);
            await collection.AddAsync(operationalLog);
        }
        /// <summary>
        /// Recupera i punti di un cliente
        /// </summary>
        /// <param name="id">passare customerId di shopify</param>
        /// <returns></returns>
        public async Task<CustomerResponse> GetCustomer(string id)
        {
            var collection = _firestoreDb.Collection(_collectionNameCustomer);
            var snapshot = await collection.GetSnapshotAsync();
            Query query = collection.WhereEqualTo("customerId", id);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            if (querySnapshot.Documents.Count > 0)
            {
                var customer = querySnapshot.Documents.SingleOrDefault()!.ConvertTo<CustomerResponse>();

                return customer;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<InternalUser>> GetAllInternalUser()
        {
            var collection = _firestoreDb.Collection(_collectionInternalUser);
            var snapshot = await collection.GetSnapshotAsync();

            var internalUsers = snapshot.Documents.Select(s => s.ConvertTo<InternalUser>()).ToList();

            return internalUsers;
        }
        /// <summary>
        /// Get all logs
        /// </summary>
        /// <returns></returns>
        public async Task<List<OperationalLog>> GetLogs()
        {
            var collection = _firestoreDb.Collection(_collectionLogOperation);
            var snapshot = await collection.GetSnapshotAsync();

            var logs = snapshot.Documents.Select(s => s.ConvertTo<OperationalLog>()).ToList();

            return logs;
        }

        public async Task<List<CustomerResponse>> GetAll()
        {
            var collection = _firestoreDb.Collection(_collectionNameCustomer);
            var snapshot = await collection.GetSnapshotAsync();

            var shoeDocuments = snapshot.Documents.Select(s => s.ConvertTo<CustomerDocument>()).ToList();

            return shoeDocuments.Select(ConvertDocumentToModel).ToList();
        }
    

        public async Task AddAsync(CustomerResponse customer)
        {
            var collection = _firestoreDb.Collection(_collectionNameCustomer);
            var shoeDocument = ConvertModelToDocument(customer);

            await collection.AddAsync(shoeDocument);
        }
        public async Task UpdateAsync(CustomerResponse customer)
        {
            DocumentReference docref = _firestoreDb.Collection(_collectionNameCustomer).Document(customer.customerFBId);
            DocumentSnapshot snap = await docref.GetSnapshotAsync();

            var serializedParticipant = JsonConvert.SerializeObject(customer);
            var deserializedParticipant = JsonConvert.DeserializeObject<ExpandoObject>(serializedParticipant);

           
            if (snap.Exists)
            {
                //setting the document
                await docref.UpdateAsync(deserializedParticipant);
            }
        }

        private static CustomerResponse ConvertDocumentToModel(CustomerDocument customerDocument)
        {
            var customerResponse = new CustomerResponse();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDocument, CustomerResponse>());
            IMapper mapper = new Mapper(config);

            customerResponse = mapper.Map<CustomerResponse>(customerDocument);

            return customerResponse;
        }
        private static CustomerDocument ConvertModelToDocument(CustomerResponse customer)
        {
            var customerDocument = new CustomerDocument();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerResponse, CustomerDocument>());
            IMapper mapper = new Mapper(config);

            customerDocument = mapper.Map<CustomerDocument>(customer);

            return customerDocument;
        }
    }
}
