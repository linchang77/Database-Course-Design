using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Climate> Climates { get; set; }

    public virtual DbSet<FinancialSituation> FinancialSituations { get; set; }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<GuideOrder> GuideOrders { get; set; }

    public virtual DbSet<GuidePhoneNumber> GuidePhoneNumbers { get; set; }

    public virtual DbSet<GuideRegion> GuideRegions { get; set; }

    public virtual DbSet<GuideSalaryRecord> GuideSalaryRecords { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelOrder> HotelOrders { get; set; }

    public virtual DbSet<HotelRoom> HotelRooms { get; set; }

    public virtual DbSet<OrderDatum> OrderData { get; set; }

    public virtual DbSet<ScenicSpot> ScenicSpots { get; set; }

    public virtual DbSet<ScenicSpotOrder> ScenicSpotOrders { get; set; }

    public virtual DbSet<ScenicSpotTicket> ScenicSpotTickets { get; set; }

    public virtual DbSet<TourGroup> TourGroups { get; set; }

    public virtual DbSet<TourItinerary> TourItineraries { get; set; }

    public virtual DbSet<TourOrder> TourOrders { get; set; }

    public virtual DbSet<TransactionRecord> TransactionRecords { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPhoneNumber> UserPhoneNumbers { get; set; }

    public virtual DbSet<VehicleOrder> VehicleOrders { get; set; }

    public virtual DbSet<VehicleSchedule> VehicleSchedules { get; set; }

    public virtual DbSet<VehicleTicket> VehicleTickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("DATA SOURCE=123.60.14.84:1521/ORCL;TNS_ADMIN=C:\\\\\\\\Users\\\\\\\\LQS\\\\\\\\Oracle\\\\\\\\network\\\\\\\\admin;PERSIST SECURITY INFO=True;USER ID=SYSTEM;PASSWORD=summer_Dt514");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("ADMIN_ID_AS_PK_OF_ADMIN");

            entity.ToTable("ADMIN");

            entity.HasIndex(e => e.AdminName, "ADMIN_NAME_UNIQUE").IsUnique();

            entity.Property(e => e.AdminId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ADMIN_ID");
            entity.Property(e => e.AdminName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ADMIN_NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityName).HasName("CITY_NAME_AS_PK_OF_CITY");

            entity.ToTable("CITY");

            entity.Property(e => e.CityName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CITY_NAME");
            entity.Property(e => e.CityIntroduction)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("CITY_INTRODUCTION");
            entity.Property(e => e.Province)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PROVINCE");
        });

        modelBuilder.Entity<Climate>(entity =>
        {
            entity.HasKey(e => e.CityName).HasName("CITY_NAME_AS_PK_OF_CLIMATE");

            entity.ToTable("CLIMATE");

            entity.Property(e => e.CityName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CITY_NAME");
            entity.Property(e => e.TodayTemperature)
                .HasColumnType("NUMBER(3,1)")
                .HasColumnName("TODAY_TEMPERATURE");
            entity.Property(e => e.TodayWeather)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TODAY_WEATHER");
            entity.Property(e => e.TomorrowTemperature)
                .HasColumnType("NUMBER(3,1)")
                .HasColumnName("TOMORROW_TEMPERATURE");
            entity.Property(e => e.TomorrowWeather)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TOMORROW_WEATHER");

            entity.HasOne(d => d.CityNameNavigation).WithOne(p => p.Climate)
                .HasForeignKey<Climate>(d => d.CityName)
                .HasConstraintName("CITY_NAME_AS_FK_OF_CLIMATE_REFERENCING_CITY");
        });

        modelBuilder.Entity<FinancialSituation>(entity =>
        {
            entity.HasKey(e => e.FinancialRecordId).HasName("FINANCIAL_RECORD_ID_AS_PK_OF_FINANCIAL_SITUATION");

            entity.ToTable("FINANCIAL_SITUATION");

            entity.Property(e => e.FinancialRecordId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("FINANCIAL_RECORD_ID");
            entity.Property(e => e.Expence)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(12,2)")
                .HasColumnName("EXPENCE");
            entity.Property(e => e.FinancialRecordCategory)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("FINANCIAL_RECORD_CATEGORY");
            entity.Property(e => e.FinancialRecordDescription)
                .HasMaxLength(150)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("FINANCIAL_RECORD_DESCRIPTION");
            entity.Property(e => e.Income)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(12,2)")
                .HasColumnName("INCOME");
            entity.Property(e => e.Profit)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(12,2)")
                .HasColumnName("PROFIT");
            entity.Property(e => e.RecordingDate)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("RECORDING_DATE");
        });

        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.GuideId).HasName("GUIDE_ID_AS_PK_OF_GUIDE");

            entity.ToTable("GUIDE");

            entity.Property(e => e.GuideId)
                .HasPrecision(4)
                .ValueGeneratedOnAdd()
                .HasColumnName("GUIDE_ID");
            entity.Property(e => e.GuideFree)
                .HasPrecision(1)
                .HasColumnName("GUIDE_FREE");
            entity.Property(e => e.GuideGender)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GUIDE_GENDER");
            entity.Property(e => e.GuideIntroduction)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("GUIDE_INTRODUCTION");
            entity.Property(e => e.GuideName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GUIDE_NAME");
            entity.Property(e => e.GuidePerformanceLevel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GUIDE_PERFORMANCE_LEVEL");
            entity.Property(e => e.GuidePrice)
                .HasColumnType("NUMBER(6,2)")
                .HasColumnName("GUIDE_PRICE");
            entity.Property(e => e.GuideSalary)
                .HasColumnType("NUMBER(20)")
                .HasColumnName("GUIDE_SALARY");
            entity.Property(e => e.GuideSeniority)
                .HasColumnType("INTERVAL YEAR(2) TO MONTH")
                .HasColumnName("GUIDE_SENIORITY");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.TravelGroup)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TRAVEL_GROUP");

            entity.HasMany(d => d.Groups).WithMany(p => p.Guides)
                .UsingEntity<Dictionary<string, object>>(
                    "GuidingTour",
                    r => r.HasOne<TourGroup>().WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("GROUP_ID_AS_FK_OF_GUIDING_TOUR_REFERENCING_TOUR_GROUP"),
                    l => l.HasOne<Guide>().WithMany()
                        .HasForeignKey("GuideId")
                        .HasConstraintName("GUIDE_ID_AS_FK_OF_GUIDING_TOUR_REFERENCING_GUIDE"),
                    j =>
                    {
                        j.HasKey("GuideId", "GroupId").HasName("GUIDE_ID_AND_GROUP_ID_AS_PK_OF_GUIDING_TOUR");
                        j.ToTable("GUIDING_TOUR");
                        j.IndexerProperty<byte>("GuideId")
                            .HasPrecision(4)
                            .HasColumnName("GUIDE_ID");
                        j.IndexerProperty<byte>("GroupId")
                            .HasPrecision(4)
                            .HasColumnName("GROUP_ID");
                    });
        });

        modelBuilder.Entity<GuideOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("ORDER_ID_AS_PK_OF_GUIDE_ORDER");

            entity.ToTable("GUIDE_ORDER");

            entity.Property(e => e.OrderId)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.GuideId)
                .HasPrecision(4)
                .HasColumnName("GUIDE_ID");
            entity.Property(e => e.Service)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SERVICE");
            entity.Property(e => e.ServiceBeginDate)
                .HasColumnType("DATE")
                .HasColumnName("SERVICE_BEGIN_DATE");
            entity.Property(e => e.ServiceEndDate)
                .HasColumnType("DATE")
                .HasColumnName("SERVICE_END_DATE");

            entity.HasOne(d => d.Guide).WithMany(p => p.GuideOrders)
                .HasForeignKey(d => d.GuideId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("GUIDE_ID_AS_FK_OF_GUIDE_ORDER_REFERENCING_GUIDE");

            entity.HasOne(d => d.Order).WithOne(p => p.GuideOrder)
                .HasForeignKey<GuideOrder>(d => d.OrderId)
                .HasConstraintName("ORDER_ID_AS_FK_OF_GUIDE_ORDER_REFERENCING_ORDER_DATA");
        });

        modelBuilder.Entity<GuidePhoneNumber>(entity =>
        {
            entity.HasKey(e => new { e.GuidePhoneNumber1, e.GuideId }).HasName("GUIDE_ID_AND_GUIDE_PHONE_NUMBER_AS_PK_OF_GUIDE_PHONE_NUMBER");

            entity.ToTable("GUIDE_PHONE_NUMBER");

            entity.Property(e => e.GuidePhoneNumber1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GUIDE_PHONE_NUMBER");
            entity.Property(e => e.GuideId)
                .HasPrecision(4)
                .HasColumnName("GUIDE_ID");

            entity.HasOne(d => d.Guide).WithMany(p => p.GuidePhoneNumbers)
                .HasForeignKey(d => d.GuideId)
                .HasConstraintName("GUIDE_ID_AS_FK_OF_GUIDE_PHONE_NUMBER_REFERENCING_GUIDE");
        });

        modelBuilder.Entity<GuideRegion>(entity =>
        {
            entity.HasKey(e => new { e.GuideId, e.GuidedRegion }).HasName("GUIDE_ID_AND_GUIDED_REGION_AS_PK_OF_GUIDE_REGION");

            entity.ToTable("GUIDE_REGION");

            entity.Property(e => e.GuideId)
                .HasPrecision(4)
                .HasColumnName("GUIDE_ID");
            entity.Property(e => e.GuidedRegion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GUIDED_REGION");

            entity.HasOne(d => d.Guide).WithMany(p => p.GuideRegions)
                .HasForeignKey(d => d.GuideId)
                .HasConstraintName("GUIDE_ID_AS_FK_OF_GUIDE_REGION_REFERENCING_GUIDE");
        });

        modelBuilder.Entity<GuideSalaryRecord>(entity =>
        {
            entity.HasKey(e => new { e.GuideId, e.SalaryPaidDate }).HasName("GUIDE_ID_AND_SALARY_PAID_DATE_AS_PK_OF_GUIDE_SALARY_RECORD");

            entity.ToTable("GUIDE_SALARY_RECORD");

            entity.Property(e => e.GuideId)
                .HasPrecision(4)
                .HasColumnName("GUIDE_ID");
            entity.Property(e => e.SalaryPaidDate)
                .HasColumnType("DATE")
                .HasColumnName("SALARY_PAID_DATE");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.SalaryAmount)
                .HasPrecision(6)
                .HasColumnName("SALARY_AMOUNT");

            entity.HasOne(d => d.Guide).WithMany(p => p.GuideSalaryRecords)
                .HasForeignKey(d => d.GuideId)
                .HasConstraintName("GUIDE_ID_AS_FK_OF_GUIDE_SALARY_RECORD_REFERENCING_GUIDE");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("HOTEL_ID_AS_PK_OF_HOTEL");

            entity.ToTable("HOTEL");

            entity.Property(e => e.HotelId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("HOTEL_ID");
            entity.Property(e => e.CityName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CITY_NAME");
            entity.Property(e => e.HotelGrade)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HOTEL_GRADE");
            entity.Property(e => e.HotelIntroduction)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("HOTEL_INTRODUCTION");
            entity.Property(e => e.HotelLocation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HOTEL_LOCATION");
            entity.Property(e => e.HotelName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HOTEL_NAME");

            entity.HasOne(d => d.CityNameNavigation).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.CityName)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("CITY_NAME_AS_FK_OF_HOTEL_REFERENCING_CITY");
        });

        modelBuilder.Entity<HotelOrder>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.HotelId, e.RoomNumber }).HasName("ORDER_ID_AND_HOTEL_ID_AND_ROOM_NUMBER_AS_PK_OF_HOTEL_ORDER");

            entity.ToTable("HOTEL_ORDER");

            entity.Property(e => e.OrderId)
                .HasPrecision(10)
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.HotelId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("HOTEL_ID");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROOM_NUMBER");
            entity.Property(e => e.CheckInDate)
                .HasColumnType("DATE")
                .HasColumnName("CHECK_IN_DATE");
            entity.Property(e => e.CheckOutDate)
                .HasColumnType("DATE")
                .HasColumnName("CHECK_OUT_DATE");

            entity.HasOne(d => d.Order).WithMany(p => p.HotelOrders)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("ORDER_ID_AS_FK_OF_HOTEL_ORDER_REFERENCING_ORDER_DATA");

            entity.HasOne(d => d.HotelRoom).WithMany(p => p.HotelOrders)
                .HasForeignKey(d => new { d.RoomNumber, d.HotelId })
                .HasConstraintName("ROOM_NUMBER_AND_HOTEL_ID_AS_FK_OF_HOTEL_ORDER_REFERENCING_HOTEL_ROOM");
        });

        modelBuilder.Entity<HotelRoom>(entity =>
        {
            entity.HasKey(e => new { e.RoomNumber, e.HotelId }).HasName("ROOM_NUMBER_AND_HOTEL_ID_AS_PK_OF_HOTEL_ROOM");

            entity.ToTable("HOTEL_ROOM");

            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROOM_NUMBER");
            entity.Property(e => e.HotelId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("HOTEL_ID");
            entity.Property(e => e.RoomClear)
                .HasPrecision(1)
                .HasColumnName("ROOM_CLEAR");
            entity.Property(e => e.RoomPrice)
                .HasColumnType("NUMBER(6,2)")
                .HasColumnName("ROOM_PRICE");
            entity.Property(e => e.RoomType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ROOM_TYPE");

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelRooms)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("HOTEL_ID_AS_FK_OF_HOTEL_ROOM_REFERENCING_HOTEL");
        });

        modelBuilder.Entity<OrderDatum>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("ORDER_ID_AS_PK_OF_ORDER_DATA");

            entity.ToTable("ORDER_DATA");

            entity.Property(e => e.OrderId)
                .HasPrecision(10)
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.OrderDate)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ORDER_DATE");
            entity.Property(e => e.OrderType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDER_TYPE");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER(8,2)")
                .HasColumnName("PRICE");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.UserId)
                .HasPrecision(8)
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.OrderData)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("USER_ID_AS_FK_OF_ORDER_DATA_REFERENCING_USERS");
        });

        modelBuilder.Entity<ScenicSpot>(entity =>
        {
            entity.HasKey(e => e.ScenicSpotId).HasName("SCENIC_SPOT_ID_AS_PK_OF_SCENIC_SPOT");

            entity.ToTable("SCENIC_SPOT");

            entity.Property(e => e.ScenicSpotId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SCENIC_SPOT_ID");
            entity.Property(e => e.CityName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CITY_NAME");
            entity.Property(e => e.ScenicSpotGrade)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SCENIC_SPOT_GRADE");
            entity.Property(e => e.ScenicSpotIntroduction)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("SCENIC_SPOT_INTRODUCTION");
            entity.Property(e => e.ScenicSpotLocation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SCENIC_SPOT_LOCATION");
            entity.Property(e => e.ScenicSpotName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SCENIC_SPOT_NAME");

            entity.HasOne(d => d.CityNameNavigation).WithMany(p => p.ScenicSpots)
                .HasForeignKey(d => d.CityName)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("CITY_NAME_AS_FK_OF_SCENIC_SPOT_REFERENCING_CITY");
        });

        modelBuilder.Entity<ScenicSpotOrder>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ScenicSpotId, e.TicketType }).HasName("ORDER_ID_AND_SCENIC_SPOT_ID_AND_TICKET_TYPE_AS_PK_OF_SCENIC_SPOT_ORDER");

            entity.ToTable("SCENIC_SPOT_ORDER");

            entity.Property(e => e.OrderId)
                .HasPrecision(10)
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.ScenicSpotId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SCENIC_SPOT_ID");
            entity.Property(e => e.TicketType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TICKET_TYPE");
            entity.Property(e => e.TicketNumber)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TICKET_NUMBER");

            entity.HasOne(d => d.Order).WithMany(p => p.ScenicSpotOrders)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("ORDER_ID_AS_FK_OF_SCENIC_SPOT_ORDER_REFERENCING_USERS");

            entity.HasOne(d => d.ScenicSpotTicket).WithMany(p => p.ScenicSpotOrders)
                .HasForeignKey(d => new { d.ScenicSpotId, d.TicketType })
                .HasConstraintName("SCENIC_SPOT_ID_AND_TICKET_TYPE_AS_FK_OF_SCENIC_SPOT_ORDER_REFERENCING_SCENIC_SPOT_TICKET");
        });

        modelBuilder.Entity<ScenicSpotTicket>(entity =>
        {
            entity.HasKey(e => new { e.ScenicSpotId, e.TicketType }).HasName("SCENIC_SPOT_ID_AND_TICKET_TYPE_AS_PK_OF_SCENIC_SPOT_TICKET");

            entity.ToTable("SCENIC_SPOT_TICKET");

            entity.Property(e => e.ScenicSpotId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SCENIC_SPOT_ID");
            entity.Property(e => e.TicketType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TICKET_TYPE");
            entity.Property(e => e.TicketPrice)
                .HasColumnType("NUMBER(6,2)")
                .HasColumnName("TICKET_PRICE");
            entity.Property(e => e.TicketRemaining)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TICKET_REMAINING");

            entity.HasOne(d => d.ScenicSpot).WithMany(p => p.ScenicSpotTickets)
                .HasForeignKey(d => d.ScenicSpotId)
                .HasConstraintName("SCENIC_SPOT_ID_AS_FK_OF_SCENIC_SPOT_TICKET_REFERENCING_SCENIC_SPOT");
        });

        modelBuilder.Entity<TourGroup>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("GROUP_ID_AS_PK_OF_TOUR_GROUP");

            entity.ToTable("TOUR_GROUP");

            entity.HasIndex(e => e.GroupName, "GROUP_NAME_UNIQUE").IsUnique();

            entity.Property(e => e.GroupId)
                .HasPrecision(4)
                .ValueGeneratedOnAdd()
                .HasColumnName("GROUP_ID");
            entity.Property(e => e.EndDate)
                .HasColumnType("DATE")
                .HasColumnName("END_DATE");
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GROUP_NAME");
            entity.Property(e => e.GuideId)
                .HasPrecision(4)
                .HasColumnName("GUIDE_ID");
            entity.Property(e => e.StartDate)
                .HasColumnType("DATE")
                .HasColumnName("START_DATE");

            entity.HasOne(d => d.Guide).WithMany(p => p.TourGroups)
                .HasForeignKey(d => d.GuideId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("GUIDE_ID_AS_FK_OF_TOUR_GROUP_REFERENCING_GUIDE");

            entity.HasMany(d => d.Users).WithMany(p => p.Groups)
                .UsingEntity<Dictionary<string, object>>(
                    "TourMember",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("USER_ID_AS_FK_OF_TOUR_MEMBER_REFERENCING_USERS"),
                    l => l.HasOne<TourGroup>().WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("GROUP_ID_AS_FK_OF_TOUR_MEMBER_REFERENCING_TOUR_GROUP"),
                    j =>
                    {
                        j.HasKey("GroupId", "UserId").HasName("GROUP_ID_AND_USER_ID_AS_PK_OF_TOUR_MEMBER");
                        j.ToTable("TOUR_MEMBER");
                        j.IndexerProperty<byte>("GroupId")
                            .HasPrecision(4)
                            .HasColumnName("GROUP_ID");
                        j.IndexerProperty<int>("UserId")
                            .HasPrecision(8)
                            .HasColumnName("USER_ID");
                    });
        });

        modelBuilder.Entity<TourItinerary>(entity =>
        {
            entity.HasKey(e => e.ItineraryId).HasName("ITINERARY_ID_AS_PK_OF_TOUR_ITINERARY");

            entity.ToTable("TOUR_ITINERARY");

            entity.Property(e => e.ItineraryId)
                .HasPrecision(2)
                .HasColumnName("ITINERARY_ID");
            entity.Property(e => e.Activities)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ACTIVITIES");
            entity.Property(e => e.GroupId)
                .HasPrecision(4)
                .HasColumnName("GROUP_ID");
            entity.Property(e => e.ItineraryDate)
                .HasColumnType("DATE")
                .HasColumnName("ITINERARY_DATE");
            entity.Property(e => e.ItineraryDuration)
                .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                .HasColumnName("ITINERARY_DURATION");
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LOCATION");

            entity.HasOne(d => d.Group).WithMany(p => p.TourItineraries)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("GROUP_ID_AS_FK_OF_TOUR_ITINERARY_REFERENCING_TOUR_GROUP");
        });

        modelBuilder.Entity<TourOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("ORDER_ID_AS_PK_OF_TOUR_ORDER");

            entity.ToTable("TOUR_ORDER");

            entity.Property(e => e.OrderId)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.GroupId)
                .HasPrecision(4)
                .HasColumnName("GROUP_ID");
            entity.Property(e => e.OrderNumber)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ORDER_NUMBER");

            entity.HasOne(d => d.Group).WithMany(p => p.TourOrders)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("GROUP_ID_AS_FK_OF_TOUR_ORDER_REFERENCING_TOUR_GROUP");

            entity.HasOne(d => d.Order).WithOne(p => p.TourOrder)
                .HasForeignKey<TourOrder>(d => d.OrderId)
                .HasConstraintName("ORDER_ID_AS_FK_OF_TOUR_ORDER_REFERENCING_ORDER_DATA");
        });

        modelBuilder.Entity<TransactionRecord>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("TRANSACTION_ID_AS_PK_OF_TRANSACTION_RECORD");

            entity.ToTable("TRANSACTION_RECORD");

            entity.Property(e => e.TransactionId)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("TRANSACTION_ID");
            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(12,2)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.TransactionCategory)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TRANSACTION_CATEGORY");
            entity.Property(e => e.TransactionMethod)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("TRANSACTION_METHOD");
            entity.Property(e => e.TransactionObject)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("TRANSACTION_OBJECT");
            entity.Property(e => e.TransactionStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TRANSACTION_STATUS");
            entity.Property(e => e.TransactionTime)
                .HasPrecision(0)
                .HasColumnName("TRANSACTION_TIME");
            entity.Property(e => e.UserId)
                .HasPrecision(4)
                .HasColumnName("USER_ID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("USER_ID_AS_PK_OF_USER");

            entity.ToTable("USERS");

            entity.Property(e => e.UserId)
                .HasPrecision(8)
                .HasColumnName("USER_ID");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PASSWORD");
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PROFILE_PICTURE");
            entity.Property(e => e.RegistrationTime)
                .HasPrecision(0)
                .ValueGeneratedOnAdd()
                .HasColumnName("REGISTRATION_TIME");
            entity.Property(e => e.UserGender)
                .HasMaxLength(4)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .IsFixedLength()
                .HasColumnName("USER_GENDER");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("USER_NAME");
        });

        modelBuilder.Entity<UserPhoneNumber>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.PhoneNumber }).HasName("USER_ID_AND_PHONE_NUMBER_AS_PK_OF_USER_PHONE_NUMBER");

            entity.ToTable("USER_PHONE_NUMBER");

            entity.Property(e => e.UserId)
                .HasPrecision(8)
                .HasColumnName("USER_ID");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PHONE_NUMBER");

            entity.HasOne(d => d.User).WithMany(p => p.UserPhoneNumbers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("USER_ID_AS_FK_OF_USER_PHONE_NUMBER_REFERENCING_USERS");
        });

        modelBuilder.Entity<VehicleOrder>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.TicketId }).HasName("ORDER_ID_AND_TICKET_ID_AS_PK_OF_VEHICLE_ORDER");

            entity.ToTable("VEHICLE_ORDER");

            entity.Property(e => e.OrderId)
                .HasColumnType("NUMBER(20)")
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.TicketId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TICKET_ID");
            entity.Property(e => e.TicketNumber)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TICKET_NUMBER");

            entity.HasOne(d => d.Ticket).WithMany(p => p.VehicleOrders)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("TICKET_ID_AS_FK_OF_VEHICLE_ORDER_REFERENCING_VEHICLE_TICKET");
        });

        modelBuilder.Entity<VehicleSchedule>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("VEHICLE_ID_AS_PK_OF_VEHICLE_SCHEDULE");

            entity.ToTable("VEHICLE_SCHEDULE");

            entity.Property(e => e.VehicleId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VEHICLE_ID");
            entity.Property(e => e.ArrivalCity)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ARRIVAL_CITY");
            entity.Property(e => e.ArrivalTime)
                .HasPrecision(0)
                .HasColumnName("ARRIVAL_TIME");
            entity.Property(e => e.DepartureCity)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPARTURE_CITY");
            entity.Property(e => e.DepartureTime)
                .HasPrecision(0)
                .HasColumnName("DEPARTURE_TIME");
            entity.Property(e => e.VehicleType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VEHICLE_TYPE");

            entity.HasOne(d => d.ArrivalCityNavigation).WithMany(p => p.VehicleScheduleArrivalCityNavigations)
                .HasForeignKey(d => d.ArrivalCity)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ARRIVAL_CITY_AS_FK_OF_VEHICLE_SCHEDULE_REFERENCING_CITY");

            entity.HasOne(d => d.DepartureCityNavigation).WithMany(p => p.VehicleScheduleDepartureCityNavigations)
                .HasForeignKey(d => d.DepartureCity)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("DEPARTURE_CITY_AS_FK_OF_VEHICLE_SCHEDULE_REFERENCING_CITY");
        });

        modelBuilder.Entity<VehicleTicket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("TICKET_ID_AS_PK_OF_VEHICLE_TICKET");

            entity.ToTable("VEHICLE_TICKET");

            entity.Property(e => e.TicketId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TICKET_ID");
            entity.Property(e => e.TicketArrivalCity)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TICKET_ARRIVAL_CITY");
            entity.Property(e => e.TicketArrivalTime)
                .HasPrecision(0)
                .HasColumnName("TICKET_ARRIVAL_TIME");
            entity.Property(e => e.TicketDepartureCity)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TICKET_DEPARTURE_CITY");
            entity.Property(e => e.TicketDepartureTime)
                .HasPrecision(0)
                .HasColumnName("TICKET_DEPARTURE_TIME");
            entity.Property(e => e.TicketPrice)
                .HasColumnType("NUMBER(6,2)")
                .HasColumnName("TICKET_PRICE");
            entity.Property(e => e.TicketRemaining)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TICKET_REMAINING");
            entity.Property(e => e.TicketType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TICKET_TYPE");
            entity.Property(e => e.VehicleId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VEHICLE_ID");

            entity.HasOne(d => d.TicketArrivalCityNavigation).WithMany(p => p.VehicleTicketTicketArrivalCityNavigations)
                .HasForeignKey(d => d.TicketArrivalCity)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("TICKET_ARRIVAL_CITY_AS_FK_OF_VEHICLE_TICKET_REFERENCING_CITY");

            entity.HasOne(d => d.TicketDepartureCityNavigation).WithMany(p => p.VehicleTicketTicketDepartureCityNavigations)
                .HasForeignKey(d => d.TicketDepartureCity)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("TICKET_DEPARTURE_CITY_AS_FK_OF_VEHICLE_TICKET_REFERENCING_CITY");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.VehicleTickets)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("VEHICLE_ID_AS_FK_OF_VEHICLE_TICKET_REFERENCING_TRAIN_SCHEDULE");
        });
        modelBuilder.HasSequence("LOGMNR_DIDS$");
        modelBuilder.HasSequence("LOGMNR_EVOLVE_SEQ$");
        modelBuilder.HasSequence("LOGMNR_SEQ$");
        modelBuilder.HasSequence("LOGMNR_UIDS$").IsCyclic();
        modelBuilder.HasSequence("MVIEW$_ADVSEQ_GENERIC");
        modelBuilder.HasSequence("MVIEW$_ADVSEQ_ID");
        modelBuilder.HasSequence("ROLLING_EVENT_SEQ$");
        modelBuilder.HasSequence("SEQ_FOR_FINANCIAL_RECORD_ID");
        modelBuilder.HasSequence("SEQ_FOR_GUIDE_ID");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
