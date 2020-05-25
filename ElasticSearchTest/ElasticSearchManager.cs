using ElasticSearchTest.Models;
using Nest;
using System;
using System.Linq;

namespace ElasticSearchTest
{
    public class ElasticSearchManager
    {
        private readonly ElasticClient ElasticClient;

        public ElasticSearchManager()
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("company");
            this.ElasticClient = new ElasticClient(settings);
        }

        public void InsertCompany()
        {
            Company company = new Company
            {
                Id = 1,
                CompanyNumber = "1234134",
                Name = "Neco s.r.o"
            };

            IndexResponse indexResponse = this.ElasticClient.IndexDocument(company);
        }

        public Company SearchCompany()
        {
            ISearchResponse<Company> searchResponse = this.ElasticClient.Search<Company>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                     .Match(m => m
                        .Field(f => f.Name)
                        .Query("Neco s.r.o")
                     )
                )
            );

            return searchResponse.Documents.FirstOrDefault();
        }
    }
}
