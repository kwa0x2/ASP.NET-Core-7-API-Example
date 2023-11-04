using NettaSec.ASP.NET.Web.Repository.IRepositories;
using NettaSec.ASP.NET.Web.Repository.Repositories;
using Npgsql;
using System.Data;

namespace NettaSec.ASP.NET.Web.API.Settings
{
    public static class ServiceRegistration
    {

        public static void Configurations(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddScoped<IDbConnection, NpgsqlConnection>(serviceProvider =>
            {
                var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                return conn;
            });

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }


    }


}