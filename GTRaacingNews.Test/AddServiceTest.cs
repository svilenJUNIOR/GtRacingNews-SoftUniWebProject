using GtRaacingNews.Test;
using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Repository.Repositories;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GTRaacingNews.Test
{
    public class AddServiceTest
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
                .AddSingleton<IBindService, BindService>()
                .AddSingleton<IDeleteService, DeleteService>()
                .AddSingleton<IReturnAll, ReturnAll>()
                .AddSingleton<ISqlSeeder, SqlSeeder>()
                .AddSingleton<IValidator, Validator>()
                .AddSingleton<ISqlRepository, SqlRepository>()
                .AddSingleton<IMongoRepository, MongoRepository>()
                .AddSingleton<IMongoSeeder, MongoSeeder>()
                .AddSingleton<IProfileService, ProfileService>()
                .AddSingleton<IUserService, UserService>()
                .BuildServiceProvider();
        }

        [Test]
        public void ThrowIfMethodFailesToAddNewTeam()
        {
           
        }

        [TearDown]
        public void TearDown() => this.context.Dispose();
    }
}