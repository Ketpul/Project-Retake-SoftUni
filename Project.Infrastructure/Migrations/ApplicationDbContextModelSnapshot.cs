﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Infrastructure.Data.SeedDb;

#nullable disable

namespace Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Project.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EMPRSID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "df7c92db-9dec-4483-9b0c-39836de8f44a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a7f367fd-8d4b-47f9-b115-d12549490cbf",
                            EMPRSID = 0,
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Adminov",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEH1EkfRHU1Xye6oD/YX1u9hBkqD69NuyDVraM3CCUHkQvumLZd0gm+tyPud3roRXjg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1d96e483-3f3f-42d8-90ed-ba2ca704d160",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "4bc18388-81ca-42ee-a068-f0a4a4c3fb2d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "147a036b-0339-4cbe-8994-ebca002ac193",
                            EMPRSID = 0,
                            Email = "Guest@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Guest",
                            LastName = "Guestov",
                            LockoutEnabled = false,
                            NormalizedEmail = "GUEST@GMAIL.COM",
                            NormalizedUserName = "GUEST",
                            PasswordHash = "AQAAAAEAACcQAAAAEKMdn5ElaLIGo2ZYEzn4Dvr4DvzFp13xWr+UR6UciGgVhbu7TkXeBo5S+0URMANw9g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5d633a71-9db7-4ed2-9bd6-1c0f1286a21b",
                            TwoFactorEnabled = false,
                            UserName = "Guest"
                        });
                });

            modelBuilder.Entity("Project.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Name = "Други"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Бар"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Рибен"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Кафе"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Бързо хранене"
                        });
                });

            modelBuilder.Entity("Project.Infrastructure.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("info")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Project.Infrastructure.Data.Models.FavoriteRestaurants", b =>
                {
                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RestaurantId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoritesRestaurants");
                });

            modelBuilder.Entity("Project.Infrastructure.Data.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("End")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("Start")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Project.Infrastructure.Data.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("AvgRating")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("GoogleMaps")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RegionalCity")
                        .HasColumnType("int");

                    b.Property<string>("RestaurateurId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Address = "Кюстендил Център, ул. „Власина“ 2, 2500 Кюстендил",
                            AvgRating = 0,
                            CategoryId = 5,
                            Description = " Предлага места на открито · Има камина · Предлага отлични коктейли",
                            GoogleMaps = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2951.9002932955864!2d22.671783916236077!3d42.28065170000001!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14aa9cfc7e03709d%3A0xa6b37a649c56b81b!2z0J_QuNGG0LDRgNC40Y8g0KDQvtGP0Ls!5e0!3m2!1sbg!2sbg!4v1713623330862!5m2!1sbg!2sbg",
                            ImageUrl1 = "https://roterm.biz/images/obekti/royal-1.jpg",
                            ImageUrl2 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2qGZwFhxwCnAA8ErQG3exX7PVnCGVZq-U6qVo0rMeBA&s",
                            ImageUrl3 = "https://cdn.oink.bg/gallery/15315/045b7f2e-c039-4f44-9576-0d61c54b5b19_large.webp",
                            Name = "Пицария Роял",
                            RegionalCity = 9,
                            RestaurateurId = "df7c92db-9dec-4483-9b0c-39836de8f44a"
                        },
                        new
                        {
                            Id = 1,
                            Address = "Кюстендил Център, бул. „България“ 28, 2503 Кюстендил",
                            AvgRating = 0,
                            CategoryId = 5,
                            Description = "ПОВЕЧЕ ЗА НАС\r\n\r\nРесторант Приятели работи в центъра на областния град Кюстендил.\r\nЗад името Friends стои екип от ентусиасти, които година след година реализираха и надграждаха проекта на своите мечти.\r\nВсичко започна през 2012 г.\r\n\r\nКазвам се Станислав Георгиев и съм собственик и главен готвач на ресторант Friends.\r\n",
                            GoogleMaps = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d23616.55298788181!2d22.68615055!3d42.277047800000005!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14aa9cf5e3236eeb%3A0x9a4ffe6baa68477a!2z0J_RgNC40Y_RgtC10LvQuCAo0KTRgNC10L3QtNGBKQ!5e0!3m2!1sbg!2sbg!4v1713217046402!5m2!1sbg!2sbg",
                            ImageUrl1 = "https://lh3.googleusercontent.com/p/AF1QipM2zoyHecvZnoBOMs7hrypki4o9wge9_vdev1a-=s680-w680-h510",
                            ImageUrl2 = "https://lh3.googleusercontent.com/p/AF1QipM_nG-VVbAPbj9kg8IuWxoF_rS-aLIypvrKRiQV=s680-w680-h510",
                            ImageUrl3 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS55kTuymY_1Xwndx-VRxFdHU4pQ9gkz9eYRINNCdeREA&s",
                            Name = "Friends Restaurant",
                            RegionalCity = 9,
                            RestaurateurId = "df7c92db-9dec-4483-9b0c-39836de8f44a"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Кюстендил Център, бул. „България“ 28, 2503 Кюстендил",
                            AvgRating = 0,
                            CategoryId = 1,
                            Description = "ХРАНА ЗА ВКЪЩИ. ВХОД. ХОТЕЛ. ВХОД. ХРАНА ЗА ВКЪЩИ. ВХОД. ХОТЕЛ. ВХОД. ХРАНА ЗА ВКЪЩИ. ВХОД. seperator-21. ХОТЕЛ.",
                            GoogleMaps = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3941.284954862589!2d22.702939286824954!3d42.26512612570832!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14aa9c99be2ebca1%3A0xd59065bfc6a2a121!2z0KLQuNGF0LjRj9GCINC60YrRgg!5e0!3m2!1sbg!2sbg!4v1713218733870!5m2!1sbg!2sbg",
                            ImageUrl1 = "https://lh5.googleusercontent.com/p/AF1QipPBob7pnM7wo1zv1XHGQu31IZFdgAxSIho8Zwab=w408-h271-k-no",
                            ImageUrl2 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS9AcvE24PY9wfYJ7Wcu7B5Sfz-s1XqmLaoHf8YGcRN2g&s",
                            ImageUrl3 = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/264186573.jpg?k=d0329018a1f3f0ce46ad6eb784f91854739a39fb7021f40a585a2c8a3bafba33&o=&hp=1",
                            Name = "Тихият кът",
                            RegionalCity = 9,
                            RestaurateurId = "df7c92db-9dec-4483-9b0c-39836de8f44a"
                        });
                });

            modelBuilder.Entity("Project.Infrastructure.Data.Models.RestaurateurRequest", b =>
                {
                    b.Property<string>("RestaurateurId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("RestaurateurId");

                    b.ToTable("RestaurateursRequests");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Project.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Project.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Project.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project.Infrastructure.Data.Models.FavoriteRestaurants", b =>
                {
                    b.HasOne("Project.Infrastructure.Data.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Project.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project.Infrastructure.Data.Models.Reservation", b =>
                {
                    b.HasOne("Project.Infrastructure.Data.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Project.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project.Infrastructure.Data.Models.Restaurant", b =>
                {
                    b.HasOne("Project.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Restaurants")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Project.Infrastructure.Data.Models.RestaurateurRequest", b =>
                {
                    b.HasOne("Project.Infrastructure.Data.Models.ApplicationUser", "Restaurateur")
                        .WithMany()
                        .HasForeignKey("RestaurateurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Restaurateur");
                });

            modelBuilder.Entity("Project.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Restaurants");
                });
#pragma warning restore 612, 618
        }
    }
}
