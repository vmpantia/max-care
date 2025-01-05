namespace MC.Web.Contracts
{
    public interface IApiService
    {
        Task<TData> GetAsync<TData>(string uri) where TData : class;
        Task<TData> PostAsync<TData>(string uri, object data) where TData : class;
    }
}
