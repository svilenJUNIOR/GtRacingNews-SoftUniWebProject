using GtRaacingNews.Test;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Repository.Repositories;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
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
                .AddSingleton<IHasher, Hasher>()
                .AddSingleton<IEngine, Engine>()
                .AddSingleton<IBindService, BindService>()
                .AddSingleton<IAddService, AddService>()
                .AddSingleton<IUserService, UserService>()
                .AddSingleton<IValidator, Validator>()
                .AddSingleton<IDeleteService, DeleteService>()
                .AddSingleton<IReturnAll, ReturnAll>()
                .AddSingleton<ISqlSeeder, SqlSeeder>()
                .AddSingleton<ISqlRepository, SqlRepository>()
                .AddSingleton<IProfileService, ProfileService>()
                .AddSingleton<RoleManager<IdentityRole>, RoleManager<IdentityRole>>()
                .BuildServiceProvider();
        }

        [Test]
        public void ThrowIfArrayContainsNullField()
        {
            string[] check = new string[] { "car", "woman", null, "", "az obicham kakichki"};

            var service = serviceProvider.GetService<IValidator>();
            Assert.Catch<ArgumentNullException>(() => service.AgainstNull(check), "The form contains empty fields!");
        }

        [TearDown]
        public void TearDown() => this.context.Dispose();
    }
}