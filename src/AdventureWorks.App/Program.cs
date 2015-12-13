using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AdventureWorks.App
{
    public class Program
    {
		
		public static  IConfiguration Configuration { get; set; } 
		public static AzureSqlConfig AzureConfig { get; set; }
        public static void Main(string[] args)
        {
			var builder = new ConfigurationBuilder();
			builder.AddUserSecrets();
			Configuration = builder.Build();
			AzureConfig = new AzureSqlConfig {
				Server = Configuration["Server"],
				Database = Configuration["Database"],
				Username = Configuration["Username"],
				Password = Configuration["Password"]
			};
			
			string sqlConnectionString = $"Server=tcp:{AzureConfig.Server},1433;Database={AzureConfig.Database};User ID={AzureConfig.Username};Password={AzureConfig.Password};Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
			
			Console.WriteLine($"Connection string: {sqlConnectionString}");
			Console.WriteLine("Press any key to exit ...");
            Console.Read();
        }
    }
	
	public class AzureSqlConfig
	{
		public string Server { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Database { get; set; }
	}
}
