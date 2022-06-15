using GtRaacingNews.Test;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GTRaacingNews.Test
{
    public class Tests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDataBase context;

        [SetUp]
        public async Task Setup()
        {
            context = new InMemoryDataBase();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => context.CreateContext())
                .AddSingleton<SqlDBContext, SqlDBContext>()
                .AddSingleton<IAddService, AddService>()
                .BuildServiceProvider();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TearDown]
        public void TearDown() => this.context.Dispose();
    }
}