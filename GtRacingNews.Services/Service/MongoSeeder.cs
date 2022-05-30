using GtRacingNews.Data.DataModels.MongoModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace GtRacingNews.Services.Service
{
    public class MongoSeeder : IMongoSeeder
    {
        private readonly IMongoRepository mongoRepository;
        public MongoSeeder(IMongoRepository mongoRepository)
            => this.mongoRepository = mongoRepository;

        public async Task SeedDriver()
        {
            var collection = mongoRepository.GettAll<BsonDocument>("Drivers");

            var Json = await File.ReadAllTextAsync(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\MongoSeederData\Driver.json");

            var drivers = JsonConvert.DeserializeObject<List<Driver>>(Json);

            foreach (var driver in drivers)
            {
                var bson = driver.ToBsonDocument();
                var document = BsonDocument.Create(bson);

                await collection.InsertOneAsync(document);
            }
        }

        public async Task SeedChampionship()
        {
            var collection = mongoRepository.GettAll<BsonDocument>("Championships");

            var Json = await File.ReadAllTextAsync(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\MongoSeederData\Championship.json");

            var Championships = JsonConvert.DeserializeObject<List<Championship>>(Json);

            foreach (var Championship in Championships)
            {
                var bson = Championship.ToBsonDocument();
                var document = BsonDocument.Create(bson);

                await collection.InsertOneAsync(document);
            }
        }

        public async Task SeedComments()
        {
            var collection = mongoRepository.GettAll<BsonDocument>("Comments");

            var json = await File.ReadAllTextAsync(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\MongoSeederData\Comment.json");

            var comments = JsonConvert.DeserializeObject<List<Comment>>(json);

            foreach (var comment in comments)
            {
                var bson = comment.ToBsonDocument();
                var document = BsonDocument.Create(bson);

                await collection.InsertOneAsync(document);
            }
        }

        public async Task SeedNews()
        {
            var collection = mongoRepository.GettAll<BsonDocument>("News");

            var json = await File.ReadAllTextAsync(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\MongoSeederData\News.json");

            var newss = JsonConvert.DeserializeObject<List<News>>(json);

            foreach (var news in newss)
            {
                var bson = news.ToBsonDocument();
                var document = BsonDocument.Create(bson);

                await collection.InsertOneAsync(document);
            }
        }

        public async Task SeedProfiles()
        {
            var collection = mongoRepository.GettAll<BsonDocument>("Profiles");

            var json = await File.ReadAllTextAsync(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\MongoSeederData\Profile.json");

            var profiles = JsonConvert.DeserializeObject<List<Profile>>(json);

            foreach (var profile in profiles)
            {
                var bson = profile.ToBsonDocument();
                var document = BsonDocument.Create(bson);

                await collection.InsertOneAsync(document);
            }
        }

        public async Task SeedRaces()
        {
            var collection = mongoRepository.GettAll<BsonDocument>("Races");

            var json = await File.ReadAllTextAsync(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\MongoSeederData\Race.json");

            var races = JsonConvert.DeserializeObject<List<Race>>(json);

            foreach (var race in races)
            {
                var bson = race.ToBsonDocument();
                var document = BsonDocument.Create(bson);

                await collection.InsertOneAsync(document);
            }
        }

        public async Task SeedTeams()
        {
            var collection = mongoRepository.GettAll<BsonDocument>("Teams");

            var json = await File.ReadAllTextAsync(@"C:\Users\svile\OneDrive\Desktop\programing\Csharp\PROJECTS\GtRacingNews-SoftUniWebProject\GtRacingNews.Common\MongoSeederData\Team.json");

            var teams = JsonConvert.DeserializeObject<List<Team>>(json);

            foreach (var team in teams)
            {
                var bson = team.ToBsonDocument();
                var document = BsonDocument.Create(bson);

                await collection.InsertOneAsync(document);
            }
        }
    }
}
