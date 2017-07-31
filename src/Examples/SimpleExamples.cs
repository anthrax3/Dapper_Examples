using Dapper;
using Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Examples
{
    public static class SimpleExamples
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static void BasicQuery()
        {
            Console.WriteLine("BasicQuery()");

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var dinosaurList = db.Query<DinosaurModel>("SELECT * FROM Dinosaurs");

                foreach (var dinosaur in dinosaurList)
                {
                    Console.WriteLine($"-> {dinosaur.DinosaurName} ({dinosaur.DinosaurId})");
                }
            }
        }
    }
}