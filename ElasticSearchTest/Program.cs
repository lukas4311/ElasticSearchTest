using System;

namespace ElasticSearchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing elasticsearch!");

            ElasticSearchManager elasticSearchManager = new ElasticSearchManager();
            elasticSearchManager.InsertCompany();
            elasticSearchManager.SearchCompany();
        }
    }
}
