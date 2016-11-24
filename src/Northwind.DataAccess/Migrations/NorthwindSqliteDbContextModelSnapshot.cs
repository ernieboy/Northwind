using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Northwind.DataAccess;

namespace Northwind.DataAccess.Migrations
{
    [DbContext(typeof(NorthwindSqliteDbContext))]
    partial class NorthwindSqliteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Northwind.Models.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("blob");

                    b.HasKey("CategoryId")
                        .HasName("sqlite_autoindex_Categories_1");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Northwind.Models.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("City")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ContactName")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ContactTitle")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Fax")
                        .HasColumnType("varchar(24)");

                    b.Property<string>("Guid");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(24)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Region")
                        .HasColumnType("varchar(15)");

                    b.HasKey("CustomerId")
                        .HasName("sqlite_autoindex_Customers_1");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Northwind.Models.CustomerCustomerDemo", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("CustomerTypeId")
                        .HasColumnName("CustomerTypeID")
                        .HasColumnType("varchar(10)");

                    b.HasKey("CustomerId", "CustomerTypeId")
                        .HasName("sqlite_autoindex_CustomerCustomerDemo_1");

                    b.ToTable("CustomerCustomerDemo");
                });

            modelBuilder.Entity("Northwind.Models.CustomerDemographics", b =>
                {
                    b.Property<string>("CustomerTypeId")
                        .HasColumnName("CustomerTypeID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CustomerDesc")
                        .HasColumnType("text");

                    b.HasKey("CustomerTypeId")
                        .HasName("sqlite_autoindex_CustomerDemographics_1");

                    b.ToTable("CustomerDemographics");
                });

            modelBuilder.Entity("Northwind.Models.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("BirthDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("City")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Extension")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("HireDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("HomePhone")
                        .HasColumnType("varchar(24)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("blob");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Region")
                        .HasColumnType("varchar(15)");

                    b.Property<long?>("ReportsTo")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("TitleOfCourtesy")
                        .HasColumnType("varchar(25)");

                    b.HasKey("EmployeeId")
                        .HasName("sqlite_autoindex_Employees_1");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Northwind.Models.EmployeeTerritory", b =>
                {
                    b.Property<long>("EmployeeId")
                        .HasColumnName("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("TerritoryId")
                        .HasColumnName("TerritoryID")
                        .HasColumnType("varchar(20)");

                    b.HasKey("EmployeeId", "TerritoryId")
                        .HasName("sqlite_autoindex_EmployeeTerritories_1");

                    b.ToTable("EmployeeTerritories");
                });

            modelBuilder.Entity("Northwind.Models.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasColumnType("varchar(5)");

                    b.Property<long?>("EmployeeId")
                        .HasColumnName("EmployeeID")
                        .HasColumnType("int");

                    b.Property<double?>("Freight")
                        .HasColumnType("float(26)");

                    b.Property<string>("OrderDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("RequiredDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("ShipAddress")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("ShipCity")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("ShipCountry")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("ShipName")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ShipPostalCode")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ShipRegion")
                        .HasColumnType("varchar(15)");

                    b.Property<long?>("ShipVia")
                        .HasColumnType("int");

                    b.Property<string>("ShippedDate")
                        .HasColumnType("timestamp");

                    b.HasKey("OrderId")
                        .HasName("sqlite_autoindex_Orders_1");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Northwind.Models.OrderDetails", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnName("OrderID")
                        .HasColumnType("int");

                    b.Property<long>("ProductId")
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.Property<double?>("Discount")
                        .HasColumnType("float(13)");

                    b.Property<long?>("Quantity")
                        .HasColumnType("int");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float(26)");

                    b.HasKey("OrderId", "ProductId")
                        .HasName("sqlite_autoindex_Order Details_1");

                    b.ToTable("Order Details");
                });

            modelBuilder.Entity("Northwind.Models.Products", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.Property<long?>("CategoryId")
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.Property<long>("Discontinued")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("QuantityPerUnit")
                        .HasColumnType("varchar(20)");

                    b.Property<long?>("ReorderLevel")
                        .HasColumnType("int");

                    b.Property<long?>("SupplierId")
                        .HasColumnName("SupplierID")
                        .HasColumnType("int");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float(26)");

                    b.Property<long?>("UnitsInStock")
                        .HasColumnType("int");

                    b.Property<long?>("UnitsOnOrder")
                        .HasColumnType("int");

                    b.HasKey("ProductId")
                        .HasName("sqlite_autoindex_Products_1");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Northwind.Models.Region", b =>
                {
                    b.Property<long>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("RegionDescription")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("RegionId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("Northwind.Models.Shipper", b =>
                {
                    b.Property<long>("ShipperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ShipperID")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(24)");

                    b.HasKey("ShipperId")
                        .HasName("sqlite_autoindex_Shippers_1");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("Northwind.Models.Supplier", b =>
                {
                    b.Property<long>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SupplierID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("City")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ContactName")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ContactTitle")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Fax")
                        .HasColumnType("varchar(24)");

                    b.Property<string>("HomePage")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(24)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Region")
                        .HasColumnType("varchar(15)");

                    b.HasKey("SupplierId")
                        .HasName("sqlite_autoindex_Suppliers_1");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Northwind.Models.Territory", b =>
                {
                    b.Property<string>("TerritoryId")
                        .HasColumnName("TerritoryID")
                        .HasColumnType("varchar(20)");

                    b.Property<long>("RegionId")
                        .HasColumnName("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("TerritoryDescription")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("TerritoryId")
                        .HasName("sqlite_autoindex_Territories_1");

                    b.ToTable("Territories");
                });
        }
    }
}
