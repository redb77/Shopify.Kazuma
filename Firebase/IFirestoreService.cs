using Shopify.Admin.Domain;
using Shopify.Domain.Customer;
using Shopify.Kazuma.Domain;

namespace Shopify.DataManager
{
    public interface IFirestoreService
    {
        public Task<InternalUser> GetInternalUser(string username, string password);
        public Task<List<InternalUser>> GetAllInternalUser();
        public Task<List<OperationalLog>> GetLogs();
        public Task AddALogsync(OperationalLog operationalLog);


        public Task AddAsync(CustomerResponse customerResponse);
        public Task UpdateAsync(CustomerResponse customer);
        public Task<CustomerResponse> GetCustomer(string id);
        public Task<List<CustomerResponse>> GetAll();
        public Task<VersionInfo> GetCurrentVersion();
    }
}
