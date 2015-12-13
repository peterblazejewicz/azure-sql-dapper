using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Collections.Generic;

namespace AdventureWorks.App
{
    public class Program
    {

        public static IConfiguration Configuration { get; set; }
        public static AzureSqlConfig AzureConfig { get; set; }
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets();
            Configuration = builder.Build();
            AzureConfig = new AzureSqlConfig
            {
                Server = Configuration["Server"],
                Database = Configuration["Database"],
                Username = Configuration["Username"],
                Password = Configuration["Password"]
            };

            string sqlConnectionString = $"Server=tcp:{AzureConfig.Server},1433;Database={AzureConfig.Database};User ID={AzureConfig.Username};Password={AzureConfig.Password};Trusted_Connection=False;Encrypt=False;Connection Timeout=30;MultipleActiveResultSets=False;";

            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                Console.WriteLine($"ConnectionStatus: {connection.State}");
				
                if (connection.State == ConnectionState.Open)
                {
                    IEnumerable<Address> addresses = connection.Query<Address>(@"SELECT TOP 6 * FROM SalesLT.Address;");

                    foreach (Address address in addresses)
                    {
                        Console.WriteLine($"{address.AddressLine1}, {address.City}");
                    }
                }

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine($"ConnectionStatus: {connection.State}");
                }
            }

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }

    public class AzureSqlConfig
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
    }

    public class Address
    {

        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string CountryRegion { get; set; }
    }
}
