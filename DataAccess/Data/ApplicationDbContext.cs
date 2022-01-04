using Duende.IdentityServer.EntityFramework.Options; // TODO: Remove? Requires license?
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccess.Data;

// TODO: Can IApplicationDbContext be used instead of ApplicationDbContext in Program.cs?
public interface IApplicationDbContext
{
}

/*public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }*/
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Food> Foods => Set<Food>();
    public DbSet<MeasurementType> MeasurementTypes => Set<MeasurementType>();
    public DbSet<GroceryDepartment> GroceryDepartments => Set<GroceryDepartment>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Store> Stores => Set<Store>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MeasurementType>()
            .HasData(typeof(MeasurementTypes)
                        .GetEnumerations<MeasurementTypeEnum>()
                        .Select(x => new MeasurementType(x.Id, x.Name))
                        .ToArray());

        modelBuilder.Entity<GroceryDepartment>()
            .HasData(
                new GroceryDepartment(1, "Produce", true),
                new GroceryDepartment(2, "Dry Goods", false),
                new GroceryDepartment(3, "Beverages", false),
                new GroceryDepartment(4, "Baking", false),
                new GroceryDepartment(5, "Frozen", true),
                new GroceryDepartment(6, "Dairy", true),
                new GroceryDepartment(7, "Bakery", false),
                new GroceryDepartment(8, "Meat", true),
                new GroceryDepartment(9, "Deli", true),
                new GroceryDepartment(10, "Seafood", true),
                new GroceryDepartment(11, "Household", false),
                new GroceryDepartment(12, "Health & Beauty", false),
                new GroceryDepartment(13, "Pet", false),
                new GroceryDepartment(14, "Alcohol", false),
                new GroceryDepartment(15, "Other", false),
                new GroceryDepartment(16, "Unknown", false)
                );

        modelBuilder.Entity<Store>()
            .HasData(
                new Store(1, "Costco", "https://www.costco.ca/"),
                new Store(2, "Super Store", "https://www.realcanadiansuperstore.ca/"),
                new Store(3, "Amazon", "https://www.amazon.ca/"),
                new Store(4, "Best Buy", "https://www.bestbuy.ca/en-ca"),
                new Store(5, "Canadian Tire", "https://www.canadiantire.ca/en.html"),
                new Store(6, "Home Depot", "https://www.homedepot.ca/en/home.html"),
                new Store(7, "American Eagle", "https://www.ae.com/ca/en"),
                new Store(8, "Marks", "https://www.sportchek.ca/"),
                new Store(9, "Sport Chek", "https://www.sportchek.ca/"),
                new Store(10, "Shoppers Drug Mart", "https://www1.shoppersdrugmart.ca/en/home"),
                new Store(11, "Petland", "https://www.petland.ca/"),
                new Store(12, "PetSmart", "https://www.petsmart.ca/")
            );
    }
}
