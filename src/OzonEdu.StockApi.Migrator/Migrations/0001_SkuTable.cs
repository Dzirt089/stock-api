using FluentMigrator;

namespace OzonEdu.StockApi.Migrator.Migrations
{
	[Migration(1)]
	public class SkuTable : Migration
	{
		public override void Down()
		{
			Execute.Sql("DROP TABLE if exists skus;");
		}

		public override void Up()
		{
			Execute.Sql(@"
                CREATE TABLE if not exists skus(
                    id BIGSERIAL PRIMARY KEY,
                    name TEXT NOT NULL,
                    item_type_id INT NOT NULL,
                    clothing_size INT);"
			);
		}
	}
}
