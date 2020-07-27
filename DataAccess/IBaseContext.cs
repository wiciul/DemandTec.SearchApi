namespace DataAccess
{
    using System.Threading.Tasks;

    public interface IBaseContext
    {
        Task<int> SaveChangesAsync();
    }
}
