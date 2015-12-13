using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Collections.Generic;
using AdventureWorks.App.Models;
using Newtonsoft.Json;

namespace AdventureWorks.App
{
    public class Program
    {


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

            string sqlConnectionString = $@"Server=tcp:{AzureConfig.Server},1433;
							Database={AzureConfig.Database};
							User ID={AzureConfig.Username};
							Password={AzureConfig.Password};
							Trusted_Connection=False;
							Encrypt=False;
							Connection Timeout=30;
							MultipleActiveResultSets=False;";

            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                Console.WriteLine($"ConnectionStatus: {connection.State}");

                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Addresses");
                    IEnumerable<Address> addresses = connection.Query<Address>(@"SELECT TOP 6 * FROM SalesLT.Address;");
                    foreach (Address address in addresses)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(address, Formatting.Indented));
                    }

                    Console.WriteLine("Products");
                    var products = connection.Query<Product, ProductModel, Product>(@"SELECT TOP 5 * FROM SalesLT.Product 
						INNER JOIN SalesLT.ProductModel 
						ON SalesLT.Product.ProductModelId = SalesLT.ProductModel.ProductModelId;",
                        (p, m) => { p.Model = m; return p; },
                        splitOn: "ProductModelId");
                    foreach (Product product in products)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(product, Formatting.Indented));
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

        static IConfiguration Configuration { get; set; }
        static AzureSqlConfig AzureConfig { get; set; }
    }

}
