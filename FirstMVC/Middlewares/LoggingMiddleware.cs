using FirstMVC.Models.Db;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVC.Middlewares
{
	public class LoggingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IBlogRepository _repository;

		/// <summary>
		///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
		/// </summary>
		public LoggingMiddleware(RequestDelegate next, IBlogRepository repository)
		{
			_next = next;
			_repository = repository;
		}

		/// <summary>
		///  Необходимо реализовать метод Invoke  или InvokeAsync
		/// </summary>
		public async Task InvokeAsync(HttpContext context)
		{
			LogConsole(context);
			await LogBase(context);
			//await LogFile(context);

			// Передача запроса далее по конвейеру
			await _next.Invoke(context);
		}

		private void LogConsole(HttpContext context)
		{
			// Для логирования данных о запросе используем свойста объекта HttpContext
			Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
		}

		private async Task LogFile(HttpContext context)
		{
			// Строка для публикации в лог
			string logMessage = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";

			// Путь до лога (опять-таки, используем свойства IWebHostEnvironment)
			string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "RequestLog.txt");

			// Используем асинхронную запись в файл
			await File.AppendAllTextAsync(logFilePath, logMessage);
		}

		private async Task LogBase(HttpContext context)
		{
			var request = new Request()
			{
				Id = Guid.NewGuid(),
				Date = DateTime.Now,
				Url = string.Format($"http://{context.Request.Host.Value + context.Request.Path}")
			};

			await _repository.AddRequest(request);
		}
	}
}
