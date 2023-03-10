// <auto-generated />
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Data.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Data.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CityFK");

                    b.Property<string>("address");

                    b.Property<string>("birthdate");

                    b.Property<string>("company");

                    b.Property<string>("email");

                    b.Property<string>("fullname");

                    b.Property<string>("image");

                    b.Property<string>("phonep");

                    b.Property<string>("phonew");

                    b.Property<string>("profile");

                    b.HasKey("ContactId");

                    b.HasIndex("CityFK")
                        .HasName("IX_Contacts_CityFK");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Data.Models.Contact", b =>
                {
                    b.HasOne("Data.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityFK")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
