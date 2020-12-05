﻿// <auto-generated />
using System;
using Barayand.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Barayand.DAL.Migrations
{
    [DbContext(typeof(BarayandContext))]
    [Migration("20200812095442_AddDynamicPagesContentTable")]
    partial class AddDynamicPagesContentTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Barayand.Models.Entity.AttrAnswerModel", b =>
                {
                    b.Property<int>("X_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("X_Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("X_CatAttrId")
                        .HasColumnType("int");

                    b.Property<bool>("X_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("X_Sort")
                        .HasColumnType("int");

                    b.Property<bool>("X_Status")
                        .HasColumnType("bit");

                    b.HasKey("X_Id");

                    b.ToTable("AttributeAnswer");
                });

            modelBuilder.Entity("Barayand.Models.Entity.AttributeModel", b =>
                {
                    b.Property<int>("A_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("A_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("A_SortField")
                        .HasColumnType("int");

                    b.Property<bool>("A_Status")
                        .HasColumnType("bit");

                    b.Property<string>("A_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("A_Type")
                        .HasColumnType("int");

                    b.Property<bool>("A_UseInSearch")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("A_Id");

                    b.ToTable("Attribute");
                });

            modelBuilder.Entity("Barayand.Models.Entity.AuthenticationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AllowdUrls")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("SiteKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteSecret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Authentication");
                });

            modelBuilder.Entity("Barayand.Models.Entity.BrandModel", b =>
                {
                    b.Property<int>("B_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("B_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("B_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("B_Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B_Seo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("B_SortField")
                        .HasColumnType("int");

                    b.Property<bool>("B_Status")
                        .HasColumnType("bit");

                    b.Property<string>("B_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("B_Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Barayand.Models.Entity.CatAttrRelationModel", b =>
                {
                    b.Property<int>("X_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("X_AttrId")
                        .HasColumnType("int");

                    b.Property<int>("X_CatId")
                        .HasColumnType("int");

                    b.Property<bool>("X_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("X_Status")
                        .HasColumnType("bit");

                    b.HasKey("X_Id");

                    b.ToTable("CategoryAttribute");
                });

            modelBuilder.Entity("Barayand.Models.Entity.ColorModel", b =>
                {
                    b.Property<int>("C_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("C_HexColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("C_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("C_Status")
                        .HasColumnType("bit");

                    b.Property<string>("C_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("C_Id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("Barayand.Models.Entity.DynamicPagesContent", b =>
                {
                    b.Property<int>("D_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("PageContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("D_Id");

                    b.ToTable("DynamicPagesContent");
                });

            modelBuilder.Entity("Barayand.Models.Entity.ProductCategoryModel", b =>
                {
                    b.Property<int>("PC_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PC_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PC_Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PC_OrderField")
                        .HasColumnType("int");

                    b.Property<int>("PC_ParentId")
                        .HasColumnType("int");

                    b.Property<string>("PC_Seo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PC_Status")
                        .HasColumnType("bit");

                    b.Property<string>("PC_Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("PC_Id");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Barayand.Models.Entity.ProductLabelModel", b =>
                {
                    b.Property<int>("L_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<bool>("L_DisplayOnProduct")
                        .HasColumnType("bit");

                    b.Property<string>("L_HexCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("L_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("L_Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("L_Seo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("L_Status")
                        .HasColumnType("bit");

                    b.Property<string>("L_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("L_Id");

                    b.ToTable("ProductLabel");
                });

            modelBuilder.Entity("Barayand.Models.Entity.StoreModel", b =>
                {
                    b.Property<int>("S_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("S_CityId")
                        .HasColumnType("int");

                    b.Property<int>("S_KeeperId")
                        .HasColumnType("int");

                    b.Property<int>("S_ProvinceId")
                        .HasColumnType("int");

                    b.Property<bool>("S_Status")
                        .HasColumnType("bit");

                    b.Property<string>("S_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("S_Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Barayand.Models.Entity.UserModel", b =>
                {
                    b.Property<int>("U_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("U_Avatar")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("U_Email")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("U_Family")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("U_Gender")
                        .HasColumnType("bit");

                    b.Property<string>("U_Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("U_Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("U_Phone")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("U_Post")
                        .HasColumnType("int");

                    b.Property<int>("U_Status")
                        .HasColumnType("int");

                    b.Property<string>("U_Username")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("verify_code")
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.HasKey("U_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Barayand.Models.Entity.WarrantyModel", b =>
                {
                    b.Property<int>("W_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<bool>("W_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("W_Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("W_Seo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("W_SortField")
                        .HasColumnType("int");

                    b.Property<bool>("W_Status")
                        .HasColumnType("bit");

                    b.Property<string>("W_Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("W_Id");

                    b.ToTable("Warranty");
                });
#pragma warning restore 612, 618
        }
    }
}
