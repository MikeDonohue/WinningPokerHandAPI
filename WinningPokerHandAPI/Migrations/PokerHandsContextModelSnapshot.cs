﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WinningPokerHandAPI.DbContexts;

namespace WinningPokerHandAPI.Migrations
{
    [DbContext(typeof(PokerHandsContext))]
    partial class PokerHandsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WinningPokerHandAPI.DataObjects.Entities.Card", b =>
                {
                    b.Property<Guid>("HandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CardId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("HandId", "CardId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            HandId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            CardId = "2C"
                        },
                        new
                        {
                            HandId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            CardId = "3C"
                        },
                        new
                        {
                            HandId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            CardId = "4C"
                        },
                        new
                        {
                            HandId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            CardId = "5C"
                        },
                        new
                        {
                            HandId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            CardId = "6C"
                        });
                });

            modelBuilder.Entity("WinningPokerHandAPI.DataObjects.Entities.PokerHand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PokerHands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            DateCreated = new DateTimeOffset(new DateTime(2021, 3, 26, 22, 0, 16, 771, DateTimeKind.Unspecified).AddTicks(3481), new TimeSpan(0, -4, 0, 0, 0)),
                            PlayerName = "Berry"
                        });
                });

            modelBuilder.Entity("WinningPokerHandAPI.DataObjects.Entities.Card", b =>
                {
                    b.HasOne("WinningPokerHandAPI.DataObjects.Entities.PokerHand", "PokerHand")
                        .WithMany("Cards")
                        .HasForeignKey("HandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PokerHand");
                });

            modelBuilder.Entity("WinningPokerHandAPI.DataObjects.Entities.PokerHand", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
