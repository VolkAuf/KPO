﻿// <auto-generated />
using System;
using AllDeductedDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AllDeductedDatabaseImplement.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Customer", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("UserId");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    b.Property<int>("HoursCount")
                        .HasColumnType("integer")
                        .HasColumnName("hours_count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("ThreadId")
                        .HasColumnType("integer")
                        .HasColumnName("thread_id");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ThreadId");

                    b.ToTable("discipline");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CuratorName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("curator_name");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("ThreadId")
                        .HasColumnType("integer")
                        .HasColumnName("thread_id");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ThreadId");

                    b.ToTable("group");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("date_create");

                    b.Property<int>("ProviderId")
                        .HasColumnType("integer")
                        .HasColumnName("provider_id");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.OrderGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("OrderId");

                    b.ToTable("order_group");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.OrderStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer")
                        .HasColumnName("student_id");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("StudentId");

                    b.ToTable("order_student");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Provider", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("UserId");

                    b.ToTable("provider");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("patronymic");

                    b.Property<int>("ProviderId")
                        .HasColumnType("integer")
                        .HasColumnName("provider_id");

                    b.Property<int?>("ThreadId")
                        .HasColumnType("integer")
                        .HasColumnName("thread_id");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.HasIndex("ThreadId");

                    b.ToTable("student");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.StudyingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Course")
                        .HasColumnType("integer")
                        .HasColumnName("course");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("enrollment_date");

                    b.Property<int>("ProviderId")
                        .HasColumnType("integer")
                        .HasColumnName("provider_id");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer")
                        .HasColumnName("student_id");

                    b.Property<string>("StudyingBase")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("studying_base");

                    b.Property<string>("StudyingForm")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("studying_form");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("studying_status");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Thread", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("faculty");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("thread");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Mail")
                        .HasColumnType("text")
                        .HasColumnName("mail");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Customer", b =>
                {
                    b.HasOne("AllDeductedDatabaseImplement.Models.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("AllDeductedDatabaseImplement.Models.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Discipline", b =>
                {
                    b.HasOne("AllDeductedDatabaseImplement.Models.Customer", "Customer")
                        .WithMany("Disciplines")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllDeductedDatabaseImplement.Models.Thread", "Thread")
                        .WithMany("Disciplines")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Thread");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Group", b =>
                {
                    b.HasOne("AllDeductedDatabaseImplement.Models.Customer", "Customer")
                        .WithMany("Groups")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllDeductedDatabaseImplement.Models.Thread", "Thread")
                        .WithMany("Groups")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Thread");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("AllDeductedDatabaseImplement.Models.Provider", "Provider")
                        .WithMany("Orders")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.OrderGroup", b =>
                {
                    b.HasOne("AllDeductedDatabaseImplement.Models.Group", "Group")
                        .WithMany("OrderGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllDeductedDatabaseImplement.Models.Order", "Order")
                        .WithMany("OrderGroups")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.OrderStudent", b =>
                {
                    b.HasOne("AllDeductedDatabaseImplement.Models.Order", "Order")
                        .WithMany("OrderStudents")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllDeductedDatabaseImplement.Models.Student", "Student")
                        .WithMany("OrderStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Provider", b =>
                {
                    b.HasOne("AllDeductedDatabaseImplement.Models.User", "User")
                        .WithOne("Provider")
                        .HasForeignKey("AllDeductedDatabaseImplement.Models.Provider", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Student", b =>
                {
                    b.HasOne("AllDeductedDatabaseImplement.Models.Provider", "Provider")
                        .WithMany("Students")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllDeductedDatabaseImplement.Models.Thread", "Thread")
                        .WithMany("Students")
                        .HasForeignKey("ThreadId");

                    b.Navigation("Provider");

                    b.Navigation("Thread");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.StudyingStatus", b =>
                {
                    b.HasOne("AllDeductedDatabaseImplement.Models.Provider", "Provider")
                        .WithMany("StudentStatuses")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllDeductedDatabaseImplement.Models.Student", "Student")
                        .WithOne("StudyingStatus")
                        .HasForeignKey("AllDeductedDatabaseImplement.Models.StudyingStatus", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Thread", b =>
                {
                    b.HasOne("AllDeductedDatabaseImplement.Models.Customer", "Customer")
                        .WithMany("Threads")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Customer", b =>
                {
                    b.Navigation("Disciplines");

                    b.Navigation("Groups");

                    b.Navigation("Threads");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Group", b =>
                {
                    b.Navigation("OrderGroups");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Order", b =>
                {
                    b.Navigation("OrderGroups");

                    b.Navigation("OrderStudents");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Provider", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Students");

                    b.Navigation("StudentStatuses");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Student", b =>
                {
                    b.Navigation("OrderStudents");

                    b.Navigation("StudyingStatus");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.Thread", b =>
                {
                    b.Navigation("Disciplines");

                    b.Navigation("Groups");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("AllDeductedDatabaseImplement.Models.User", b =>
                {
                    b.Navigation("Customer");

                    b.Navigation("Provider");
                });
#pragma warning restore 612, 618
        }
    }
}
