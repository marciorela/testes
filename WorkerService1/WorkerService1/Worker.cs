using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                //
                // First access the connection string.
                // ... This may be autogenerated in Visual Studio.
                //
                string connectionString = "Server=localhost;userid=root;pwd=sasasa;port=3306;database=notes2";

                //
                // In a using statement, acquire the SqlConnection as a resource.
                //
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    //
                    // Open the SqlConnection.
                    //
                    con.Open();
                    //
                    // This code uses an SqlCommand based on the SqlConnection.
                    //

                    string FileName = @"d:\worker1.txt";
                    using (MySqlCommand command = new MySqlCommand("SELECT ID, DESCRICAO FROM CATEGORIAS", con))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            Funcoes.AppendToFile(FileName, DateTimeOffset.Now.ToString());
                            while (reader.Read())
                            {
                                Funcoes.AppendToFile(FileName, reader.GetInt32(0) + " - " + reader.GetString(1));
                            }
                            Funcoes.AppendToFile(FileName, "");

                        }
                    }

                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
