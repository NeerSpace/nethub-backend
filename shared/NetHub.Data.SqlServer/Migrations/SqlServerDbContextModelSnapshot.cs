﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetHub.Data.SqlServer.Context;

#nullable disable

namespace NetHub.Data.SqlServer.Migrations
{
    [DbContext(typeof(SqlServerDbContext))]
    partial class SqlServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ArticleSetId")
                        .HasColumnType("bigint");

                    b.Property<string>("BanReason")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("Banned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Html")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)");

                    b.Property<long?>("LastContributorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Published")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(130)
                        .HasColumnType("nvarchar(130)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleSetId");

                    b.HasIndex("LanguageCode");

                    b.HasIndex("LastContributorId");

                    b.ToTable("Articles", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.ArticleContributor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("ArticleContributors", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.ArticleSet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("OriginalArticleLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("ArticleSets", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.ArticleSetResource", b =>
                {
                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ArticleSetId")
                        .HasColumnType("bigint");

                    b.HasKey("ResourceId");

                    b.HasIndex("ArticleSetId");

                    b.ToTable("ArticleSetResources", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.ArticleSetTag", b =>
                {
                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.Property<long>("ArticleSetId")
                        .HasColumnType("bigint");

                    b.HasKey("TagId", "ArticleSetId");

                    b.HasIndex("ArticleSetId");

                    b.ToTable("ArticleSetTags", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.ArticleSetVote", b =>
                {
                    b.Property<long>("ArticleSetId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Vote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArticleSetId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ArticleSetVotes", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppDevice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<short>("AttemptCount")
                        .HasColumnType("smallint");

                    b.Property<string>("Browser")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("BrowserVersion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)");

                    b.Property<DateTime?>("LastAttempt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("AppDevices", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AppRoles", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AppRoleClaims", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppToken", b =>
                {
                    b.Property<string>("Value")
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<long?>("DeviceId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Value");

                    b.HasIndex("DeviceId");

                    b.HasIndex("UserId");

                    b.ToTable("AppTokens", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProfilePhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Registered")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("PhotoId");

                    b.ToTable("AppUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AccessFailedCount = 0,
                            Email = "admin@nethub.com.ua",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@NETHUB.COM.UA",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEB6q8zmDNgdgsRyUZqwiyAUvSm7H2m9d0T3DZ+GpiD3PTbr43iJuV57jP/ektgkgxQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "745B8028-E31C-4548-A813-941EC4C9D33B",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "Permissions",
                            ClaimValue = "*",
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ProviderDisplayName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserLogins", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppUserRole", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUserRoles", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Language", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<Guid?>("FlagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<byte>("Order")
                        .HasColumnType("tinyint");

                    b.HasKey("Code");

                    b.HasIndex("FlagId")
                        .IsUnique()
                        .HasFilter("[FlagId] IS NOT NULL");

                    b.ToTable("Languages", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<byte[]>("Bytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Mimetype")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.SavedArticle", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SavedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("SavedArticles", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Tags", (string)null);
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.Article", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Articles.ArticleSet", "ArticleSet")
                        .WithMany("Articles")
                        .HasForeignKey("ArticleSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHub.Data.SqlServer.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHub.Data.SqlServer.Entities.Identity.AppUser", "LastContributor")
                        .WithMany()
                        .HasForeignKey("LastContributorId");

                    b.Navigation("ArticleSet");

                    b.Navigation("Language");

                    b.Navigation("LastContributor");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.ArticleContributor", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Articles.Article", "Article")
                        .WithMany("Contributors")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHub.Data.SqlServer.Entities.Identity.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.ArticleSet", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Identity.AppUser", "Author")
                        .WithMany("ArticleSets")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.ArticleSetResource", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Articles.ArticleSet", "ArticleSet")
                        .WithMany("Images")
                        .HasForeignKey("ArticleSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHub.Data.SqlServer.Entities.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleSet");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.ArticleSetTag", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Articles.ArticleSet", "ArticleSet")
                        .WithMany("Tags")
                        .HasForeignKey("ArticleSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHub.Data.SqlServer.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleSet");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.ArticleSetVote", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Articles.ArticleSet", "ArticleSet")
                        .WithMany()
                        .HasForeignKey("ArticleSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHub.Data.SqlServer.Entities.Identity.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ArticleSet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppRoleClaim", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Identity.AppRole", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppToken", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Identity.AppDevice", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId");

                    b.HasOne("NetHub.Data.SqlServer.Entities.Identity.AppUser", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppUser", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Resource", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");

                    b.OwnsOne("NetHub.Data.SqlServer.Entities.UsernameChange", "UsernameChanges", b1 =>
                        {
                            b1.Property<long>("AppUserId")
                                .HasColumnType("bigint");

                            b1.Property<byte>("Count")
                                .HasColumnType("tinyint");

                            b1.Property<DateTime?>("LastTime")
                                .HasColumnType("datetime2");

                            b1.HasKey("AppUserId");

                            b1.ToTable("AppUsers");

                            b1.WithOwner()
                                .HasForeignKey("AppUserId");

                            b1.HasData(
                                new
                                {
                                    AppUserId = 1L,
                                    Count = (byte)0
                                });
                        });

                    b.Navigation("Photo");

                    b.Navigation("UsernameChanges")
                        .IsRequired();
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppUserClaim", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Identity.AppUser", "User")
                        .WithMany("UserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppUserLogin", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppUserRole", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Identity.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHub.Data.SqlServer.Entities.Identity.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Language", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Resource", "Flag")
                        .WithOne()
                        .HasForeignKey("NetHub.Data.SqlServer.Entities.Language", "FlagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Flag");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.SavedArticle", b =>
                {
                    b.HasOne("NetHub.Data.SqlServer.Entities.Articles.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NetHub.Data.SqlServer.Entities.Identity.AppUser", "User")
                        .WithMany("SavedArticles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.Article", b =>
                {
                    b.Navigation("Contributors");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Articles.ArticleSet", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Images");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppRole", b =>
                {
                    b.Navigation("RoleClaims");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("NetHub.Data.SqlServer.Entities.Identity.AppUser", b =>
                {
                    b.Navigation("ArticleSets");

                    b.Navigation("SavedArticles");

                    b.Navigation("Tokens");

                    b.Navigation("UserClaims");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
