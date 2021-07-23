using System.Threading.Tasks;

namespace FirstMVC.Models.Db
{
	public interface IBlogRepository
	{
		Task AddUser(User user);
		Task AddRequest(Request request);
		Task<User[]> GetUsers();
		Task<Request[]> GetRequests();
	}
}
