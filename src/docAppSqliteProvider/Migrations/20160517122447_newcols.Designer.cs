using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using docAppSqliteProvider;

namespace docAppSqliteProvider.Migrations
{
    [DbContext(typeof(docAppContext))]
    [Migration("20160517122447_newcols")]
    partial class newcols
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("docAppDomain.Model.AppointmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AppointmentDate");

                    b.Property<string>("AppointmentTime");

                    b.Property<string>("ContactNumber");

                    b.Property<string>("Email");

                    b.Property<bool>("EstablishedPatient");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("InsuranceOption");

                    b.Property<string>("LastName");

                    b.Property<string>("Reason");

                    b.Property<DateTime>("UpdatedTimestamp");

                    b.HasKey("Id");
                });
        }
    }
}
