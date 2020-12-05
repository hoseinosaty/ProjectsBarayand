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
    [Migration("20200920143156_AddTypeFieldToProductTable")]
    partial class AddTypeFieldToProductTable
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

                    b.Property<string>("PageOtherSetting")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageSeo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("D_Id");

                    b.ToTable("DynamicPagesContent");
                });

            modelBuilder.Entity("Barayand.Models.Entity.GalleryCategoryModel", b =>
                {
                    b.Property<int>("GC_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("GC_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GC_Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GC_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("GC_Seo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GC_SortField")
                        .HasColumnType("int");

                    b.Property<bool>("GC_Status")
                        .HasColumnType("bit");

                    b.Property<string>("GC_Titles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GC_Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("GC_Id");

                    b.ToTable("GalleryCategory");
                });

            modelBuilder.Entity("Barayand.Models.Entity.ImageGalleryModel", b =>
                {
                    b.Property<int>("IG_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("IG_CatId")
                        .HasColumnType("int");

                    b.Property<string>("IG_ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("IG_SortField")
                        .HasColumnType("int");

                    b.Property<bool>("IG_Status")
                        .HasColumnType("bit");

                    b.Property<string>("IG_Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("IG_Id");

                    b.ToTable("ImageGallery");
                });

            modelBuilder.Entity("Barayand.Models.Entity.NoticesCategoryModel", b =>
                {
                    b.Property<int>("NC_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("NC_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NC_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NC_Seo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NC_SeoUrl")
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<int>("NC_SortField")
                        .HasColumnType("int");

                    b.Property<bool>("NC_Status")
                        .HasColumnType("bit");

                    b.Property<string>("NC_Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("NC_Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("NC_Id");

                    b.ToTable("NoticesCategory");
                });

            modelBuilder.Entity("Barayand.Models.Entity.NoticesModel", b =>
                {
                    b.Property<int>("N_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("N_Attachment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("N_CId")
                        .HasColumnType("int");

                    b.Property<string>("N_Content")
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<DateTime>("N_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("N_Image")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<bool>("N_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("N_Media")
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<int>("N_MediaType")
                        .HasColumnType("int");

                    b.Property<string>("N_Seo")
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<string>("N_ShamsiDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("N_Sort")
                        .HasColumnType("int");

                    b.Property<bool>("N_Status")
                        .HasColumnType("bit");

                    b.Property<string>("N_Summary")
                        .HasColumnType("nvarchar(2500)")
                        .HasMaxLength(2500);

                    b.Property<string>("N_Sup")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("N_Title")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("N_Type")
                        .HasColumnType("int");

                    b.Property<string>("N_Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("N_Id");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("Barayand.Models.Entity.ProductAttributeModel", b =>
                {
                    b.Property<int>("X_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("X_AId")
                        .HasColumnType("int");

                    b.Property<int>("X_AnswerId")
                        .HasColumnType("int");

                    b.Property<string>("X_AnswerTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("X_PId")
                        .HasColumnType("int");

                    b.HasKey("X_Id");

                    b.ToTable("ProductAttributeAnswer");
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

                    b.Property<int>("PC_Type")
                        .HasColumnType("int");

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

            modelBuilder.Entity("Barayand.Models.Entity.ProductLabelRelationModel", b =>
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

                    b.Property<int>("X_LabelId")
                        .HasColumnType("int");

                    b.Property<int>("X_Pid")
                        .HasColumnType("int");

                    b.HasKey("X_Id");

                    b.ToTable("ProductLabelRelation");
                });

            modelBuilder.Entity("Barayand.Models.Entity.ProductModel", b =>
                {
                    b.Property<int>("P_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("P_AvailableCount")
                        .HasColumnType("int");

                    b.Property<int>("P_BrandId")
                        .HasColumnType("int");

                    b.Property<string>("P_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("P_Description")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(5000);

                    b.Property<string>("P_DetailsSubTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("P_DetailsTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("P_Discount")
                        .HasColumnType("float");

                    b.Property<int>("P_DiscountType")
                        .HasColumnType("int");

                    b.Property<int>("P_EndLevelCatId")
                        .HasColumnType("int");

                    b.Property<string>("P_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("P_ImgGallery")
                        .HasColumnType("nvarchar(2500)")
                        .HasMaxLength(2500);

                    b.Property<bool>("P_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("P_ListTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("P_MainCatId")
                        .HasColumnType("int");

                    b.Property<double>("P_Price")
                        .HasColumnType("float");

                    b.Property<int>("P_SaleCount")
                        .HasColumnType("int");

                    b.Property<string>("P_Seo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("P_Status")
                        .HasColumnType("bit");

                    b.Property<string>("P_TechnicalInfo")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(5000);

                    b.Property<string>("P_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("P_Type")
                        .HasColumnType("int");

                    b.Property<string>("P_Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("P_Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Barayand.Models.Entity.RelatedProductModel", b =>
                {
                    b.Property<int>("PR_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("PR_PId")
                        .HasColumnType("int");

                    b.Property<int>("PR_RId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("PR_Id");

                    b.ToTable("RelatedProduct");
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

            modelBuilder.Entity("Barayand.Models.Entity.VideoGalleryModel", b =>
                {
                    b.Property<int>("VG_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("VG_CatId")
                        .HasColumnType("int");

                    b.Property<string>("VG_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VG_IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("VG_Keywords")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("VG_Seo")
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<int>("VG_SortField")
                        .HasColumnType("int");

                    b.Property<bool>("VG_Status")
                        .HasColumnType("bit");

                    b.Property<string>("VG_Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("VG_UrlType")
                        .HasColumnType("int");

                    b.Property<string>("VG_VideoImage")
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<string>("VG_VideoUrl")
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.HasKey("VG_Id");

                    b.ToTable("VideoGallery");
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
