﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using todo.Models;

namespace todo.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20181108141256_wine")]
    partial class wine
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("todo.Models.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsComplete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");

                    b.HasData(
                        new { Id = 1, IsComplete = false, Name = "walk dog" },
                        new { Id = 2, IsComplete = false, Name = "walk cat" },
                        new { Id = 3, IsComplete = false, Name = "do the dishes" },
                        new { Id = 4, IsComplete = false, Name = "drink beer" },
                        new { Id = 5, IsComplete = false, Name = "drink wine" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
