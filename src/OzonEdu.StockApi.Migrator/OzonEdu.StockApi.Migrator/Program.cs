using FluentMigrator.Runner;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
	.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json")
	.AddEnvironmentVariables()
	.Build();

var connectionString = configuration.GetSection("DatabaseConnectionOptions:ConnectionString").Get<string>();

//Контейнер с необходимым сервисом для запуска миграций
var services = new ServiceCollection()
	.AddFluentMigratorCore() //регистрирует Fluent Migrator и все сервисы для него
	.ConfigureRunner(
		r =>
					r.AddPostgres() //Конфигурируя, указываем что работаем с Postgres
						.WithGlobalConnectionString(connectionString) //Указываем глобально строку подключения
						.ScanIn(typeof(Program).Assembly) //Указываем где необходимо искать миграцию, аргумент - сборка
						.For.Migrations());

//Штука, которая рулит всем этим делом
var serviceProvider = services.BuildServiceProvider();

using (serviceProvider.CreateScope())
{
	var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
	runner.MigrateUp();
}