using Shopify.Admin.Domain;
using Shopify.Domain.Customer;

namespace Shopify.DataManager
{
    public interface IFirestoreService
    {
        public Task<InternalUser> GetInternalUser(string username, string password);
        public Task<List<InternalUser>> GetAllInternalUser();
        public Task<List<OperationalLog>> GetLogs();
        public Task AddALogsync(OperationalLog operationalLog);


        public Task AddAsync(CustomerResponse customerResponse);
        public Task<CustomerResponse> GetCustomer(string id);
        public Task<List<CustomerResponse>> GetAll();

    }
}
