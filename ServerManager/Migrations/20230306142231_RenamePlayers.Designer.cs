// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServerManager.Data.Context;

#nullable disable

namespace ServerManager.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230306142231_RenamePlayers")]
    partial class RenamePlayers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ServerManager.Data.User.UserDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Group")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("sm_user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Group = 1,
                            Name = "admin",
                            Password = "xW2PqVk+e29mqX3T2aZAYPuBl5e4SKVeKDXfvU9XC9g="
                        });
                });

            modelBuilder.Entity("ServerManagerCore.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.Property<string>("SteamId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("sm_players");
                });

            modelBuilder.Entity("ServerManagerCore.Models.ServerAdminInfoDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RconAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("RconPass")
                        .HasColumnType("longtext");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServerId")
                        .IsUnique();

                    b.ToTable("sm_serverAdminInfo");
                });

            modelBuilder.Entity("ServerManagerCore.Models.ServerDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("IpAddress")
                        .HasColumnType("longtext");

                    b.Property<bool>("Launched")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Path")
                        .HasColumnType("longtext");

                    b.Property<int>("TypeServer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("sm_server");
                });

            modelBuilder.Entity("ServerManagerCore.Models.ServerPublicInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("IP")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Map")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ServerId")
                        .IsUnique();

                    b.ToTable("sm_serverPublicInfo");
                });

            modelBuilder.Entity("ServerManagerCore.Models.Player", b =>
                {
                    b.HasOne("ServerManagerCore.Models.ServerDto", "Server")
                        .WithMany("Players")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("ServerManagerCore.Models.ServerAdminInfoDto", b =>
                {
                    b.HasOne("ServerManagerCore.Models.ServerDto", "Server")
                        .WithOne("AdminInfo")
                        .HasForeignKey("ServerManagerCore.Models.ServerAdminInfoDto", "ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("ServerManagerCore.Models.ServerPublicInfo", b =>
                {
                    b.HasOne("ServerManagerCore.Models.ServerDto", "Server")
                        .WithOne("ServerPublicInfo")
                        .HasForeignKey("ServerManagerCore.Models.ServerPublicInfo", "ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("ServerManagerCore.Models.ServerDto", b =>
                {
                    b.Navigation("AdminInfo")
                        .IsRequired();

                    b.Navigation("Players");

                    b.Navigation("ServerPublicInfo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
