using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualStore.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products (Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "Values ('Smartphone XYZ', 699.99, 'Latest model with advanced features', 50, 'http://example.com/images/smartphone_xyz.jpg', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Products");
        }
    }
}
