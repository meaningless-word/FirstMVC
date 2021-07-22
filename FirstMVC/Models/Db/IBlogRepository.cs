using System.Threading.Tasks;

namespace FirstMVC.Models.Db
{
	public interface IBlogRepository
	{
		Task AddUser(User user);

		Task<User[]> GetUsers();
	}
}
