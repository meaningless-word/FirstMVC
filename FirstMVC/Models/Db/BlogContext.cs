using Microsoft.EntityFrameworkCore;

namespace FirstMVC.Models.Db
{
	/// <summary>
	/// Класс контекста, предоставляющий доступ к сущностям базы данных
	/// </summary>
	public class BlogContext : DbContext
	{
		/// Ссылка на таблицу Users
		public DbSet<User> Users { get; set; }

		/// Ссылка на таблицу UserPosts
		public DbSet<UserPost> UserPosts { get; set; }

		public DbSet<Request> Requests { get; set; }

		// Логика взаимодействия с таблицами в БД
		public BlogContext(DbContextOptions<BlogContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			// для установки соответствия сущности к таблице базы данных
			builder.Entity<Request>().ToTable("Requests");
		}
	}
}
