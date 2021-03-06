// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserApi.DAL.DataContext;

namespace UserApi.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210803142552_make-City-nullable")]
    partial class makeCitynullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserApi.DAL.Entities.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateChanged")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("UserApi.DAL.Entities.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateChanged")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PhoneNumberType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CityId");

                    b.HasIndex("PersonID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("UserApi.DAL.Entities.Person", b =>
                {
                    b.HasOne("UserApi.DAL.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("UserApi.DAL.Entities.Person", null)
                        .WithMany("ConnectedPeople")
                        .HasForeignKey("PersonID");

                    b.Navigation("City");
                });

            modelBuilder.Entity("UserApi.DAL.Entities.Person", b =>
                {
                    b.Navigation("ConnectedPeople");
                });
#pragma warning restore 612, 618
        }
    }
}
