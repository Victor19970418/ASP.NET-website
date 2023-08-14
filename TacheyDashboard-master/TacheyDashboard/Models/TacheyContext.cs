using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class TacheyContext : DbContext
    {
        public TacheyContext()
        {
        }

        public TacheyContext(DbContextOptions<TacheyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnswerLike> AnswerLikes { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<CategoryDetail> CategoryDetails { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseBuyed> CourseBuyeds { get; set; }
        public virtual DbSet<CourseCategory> CourseCategories { get; set; }
        public virtual DbSet<CourseChapter> CourseChapters { get; set; }
        public virtual DbSet<CourseScore> CourseScores { get; set; }
        public virtual DbSet<CourseUnit> CourseUnits { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<PersonalUrl> PersonalUrls { get; set; }
        public virtual DbSet<Point> Points { get; set; }
        public virtual DbSet<PointOwner> PointOwners { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionLike> QuestionLikes { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketOwner> TicketOwners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=bs2021spring.database.windows.net;Database=Tachey;User Id=bs; Password=g5gyuv6m*mn@; Trusted_Connection=False; MultipleActiveResultSets=True;Integrated Security=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.HasComment("留言");

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.AnswerContent)
                    .HasMaxLength(4000)
                    .HasComment("問題內容");

                entity.Property(e => e.AnswerDate)
                    .HasColumnType("date")
                    .HasComment("提問時間");

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("CourseID");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(128)
                    .HasColumnName("MemberID")
                    .HasComment("會員編號");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("QuestionID")
                    .HasComment("問題編號");
            });

            modelBuilder.Entity<AnswerLike>(entity =>
            {
                entity.HasKey(e => new { e.QuestionId, e.AnswerId, e.CourseId, e.MemberId });

                entity.ToTable("AnswerLike");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(128)
                    .HasColumnName("CourseID");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(128)
                    .HasColumnName("MemberID");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.Name, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId, "IX_RoleId");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<CategoryDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId);

                entity.ToTable("CategoryDetail");

                entity.HasComment("課程分類細項 ");

                entity.Property(e => e.DetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("DetailID")
                    .HasComment("細項編號");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasComment("分類編號");

                entity.Property(e => e.DetailEngName).HasMaxLength(40);

                entity.Property(e => e.DetailName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasComment("細項名稱");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.HasComment("課程");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(128)
                    .HasColumnName("CourseID")
                    .HasComment("課程編號");

                entity.Property(e => e.CategoryDetailsId)
                    .HasColumnName("CategoryDetailsID")
                    .HasDefaultValueSql("((10001))")
                    .HasComment("細項編號");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasDefaultValueSql("((1))")
                    .HasComment("分類編號");

                entity.Property(e => e.CourseLevel)
                    .HasMaxLength(100)
                    .HasComment("課程適合的門檻");

                entity.Property(e => e.CoursePerson)
                    .HasMaxLength(4000)
                    .HasComment("課程適合的族群");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasComment("開課日期");

                entity.Property(e => e.CreateFinish)
                    .HasDefaultValueSql("((0))")
                    .HasComment("開課狀態(完成與否)");

                entity.Property(e => e.CreateVerify)
                    .HasDefaultValueSql("((0))")
                    .HasComment("審核狀態(完成與否)");

                entity.Property(e => e.CustomUrl).HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .HasComment("課程描述");

                entity.Property(e => e.Effect)
                    .HasMaxLength(4000)
                    .HasComment("學習成效");

                entity.Property(e => e.Introduction)
                    .HasMaxLength(4000)
                    .HasComment("課程介紹");

                entity.Property(e => e.LecturerIdentity)
                    .HasMaxLength(50)
                    .HasComment("開課身份");

                entity.Property(e => e.MarketingImageUrl)
                    .HasMaxLength(4000)
                    .HasColumnName("MarketingImageURL")
                    .HasComment("行銷照片網址");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("MemberID")
                    .HasComment("會員編號");

                entity.Property(e => e.OriginalPrice)
                    .HasColumnType("money")
                    .HasComment("課程定價");

                entity.Property(e => e.PreOrderPrice)
                    .HasColumnType("money")
                    .HasComment("預購價格");

                entity.Property(e => e.PreviewVideo).HasMaxLength(4000);

                entity.Property(e => e.Title)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("(N'無')")
                    .HasComment("課程標題");

                entity.Property(e => e.TitlePageImageUrl)
                    .HasMaxLength(4000)
                    .HasColumnName("TitlePageImageURL")
                    .HasComment("課程封面照片網址");

                entity.Property(e => e.Tool)
                    .HasMaxLength(4000)
                    .HasComment("上課工具(軟體，材料)");

                entity.Property(e => e.TotalMinTime).HasComment("課程長度");
            });

            modelBuilder.Entity<CourseBuyed>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.ToTable("CourseBuyed");

                entity.HasComment("購買的課程");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(128)
                    .HasColumnName("CourseID")
                    .HasComment("課程編號");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("MemberID")
                    .HasComment("會員編號");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .HasComment("訂單編號");
            });

            modelBuilder.Entity<CourseCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("CourseCategory");

                entity.HasComment("課程分類");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID")
                    .HasComment("分類編號");

                entity.Property(e => e.CategoryEngName).HasMaxLength(40);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasComment("分類名稱");
            });

            modelBuilder.Entity<CourseChapter>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.ChapterId })
                    .HasName("PK_CourseChapter_1");

                entity.ToTable("CourseChapter");

                entity.HasComment("課程章節");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(128)
                    .HasColumnName("CourseID")
                    .HasComment("課程編號");

                entity.Property(e => e.ChapterId)
                    .HasColumnName("ChapterID")
                    .HasComment("章節編號");

                entity.Property(e => e.ChapterName)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("(N'無')")
                    .HasComment("章節名稱");
            });

            modelBuilder.Entity<CourseScore>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.MemberId })
                    .HasName("PK_CourseScore_1");

                entity.ToTable("CourseScore");

                entity.HasComment("課程評價 ");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(128)
                    .HasColumnName("CourseID")
                    .HasComment("課程編號");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(128)
                    .HasColumnName("MemberID")
                    .HasComment("會員編號");

                entity.Property(e => e.Score).HasComment("評價分數");

                entity.Property(e => e.ScoreContent)
                    .HasMaxLength(4000)
                    .HasComment("內容");

                entity.Property(e => e.ScoreDate)
                    .HasColumnType("date")
                    .HasComment("評價日期");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasComment("標題");

                entity.Property(e => e.ToTachey)
                    .HasMaxLength(4000)
                    .HasComment("給Tachey的建議");

                entity.Property(e => e.ToTeacher)
                    .HasMaxLength(4000)
                    .HasComment("對老師說的話");
            });

            modelBuilder.Entity<CourseUnit>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.UnitId });

                entity.ToTable("CourseUnit");

                entity.HasComment("課程單元");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(128)
                    .HasColumnName("CourseID");

                entity.Property(e => e.UnitId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UnitID")
                    .HasComment("單元編號");

                entity.Property(e => e.ChapterId)
                    .HasColumnName("ChapterID")
                    .HasDefaultValueSql("((0))")
                    .HasComment("課程章節");

                entity.Property(e => e.CourseUrl)
                    .HasMaxLength(4000)
                    .HasColumnName("CourseURL")
                    .HasDefaultValueSql("((0))")
                    .HasComment("課程網址");

                entity.Property(e => e.Ps)
                    .HasMaxLength(4000)
                    .HasColumnName("PS")
                    .HasComment("老師的話");

                entity.Property(e => e.UnitName)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("(N'無')")
                    .HasComment("單元名稱");
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HwkId);

                entity.ToTable("Homework");

                entity.HasComment("作業成果");

                entity.Property(e => e.HwkId)
                    .ValueGeneratedNever()
                    .HasColumnName("HwkID")
                    .HasComment("作業編號");

                entity.Property(e => e.HwkLike).HasComment("愛心數");

                entity.Property(e => e.HwkPhoto)
                    .HasMaxLength(80)
                    .HasComment("作業封面圖片網址");

                entity.Property(e => e.HwkUrl)
                    .HasMaxLength(80)
                    .HasComment("作業網址(codepen)");

                entity.Property(e => e.Hwkchapter)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasComment("章節編號");

                entity.Property(e => e.Hwkdescription)
                    .HasMaxLength(80)
                    .HasComment("作業描述");

                entity.Property(e => e.Hwkname)
                    .HasMaxLength(80)
                    .HasComment("作業名稱");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("MemberID")
                    .HasComment("會員編號");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Invoice");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(128)
                    .HasColumnName("OrderID");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceNum).HasMaxLength(50);

                entity.Property(e => e.InvoiceType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.HasComment("會員資料");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(128)
                    .HasColumnName("MemberID")
                    .HasComment("會員編號");

                entity.Property(e => e.About)
                    .HasMaxLength(80)
                    .HasComment("關於我");

                entity.Property(e => e.Account)
                    .HasMaxLength(30)
                    .HasComment("會員帳號(E-mail)");

                entity.Property(e => e.Address)
                    .HasMaxLength(80)
                    .HasComment("地址");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasComment("生日");

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .HasComment("城市");

                entity.Property(e => e.CountryRegion)
                    .HasMaxLength(10)
                    .HasComment("國家/地區");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasComment("會員信箱");

                entity.Property(e => e.EmailStatus).HasComment("信箱驗證狀態");

                entity.Property(e => e.Expertise)
                    .HasMaxLength(80)
                    .HasComment("自己的專長");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(80)
                    .HasComment("Facebook 綁定");

                entity.Property(e => e.Google)
                    .HasMaxLength(80)
                    .HasComment("Google 綁定");

                entity.Property(e => e.Interest)
                    .HasMaxLength(4000)
                    .HasComment("個人興趣");

                entity.Property(e => e.InterestContent)
                    .HasMaxLength(80)
                    .HasComment("感興趣的事物");

                entity.Property(e => e.Introduction)
                    .HasMaxLength(200)
                    .HasComment("個人介紹");

                entity.Property(e => e.JoinTime)
                    .HasColumnType("datetime")
                    .HasComment("加入時間");

                entity.Property(e => e.Language)
                    .HasMaxLength(10)
                    .HasComment("語言");

                entity.Property(e => e.Like)
                    .HasMaxLength(4000)
                    .HasComment("個人喜好");

                entity.Property(e => e.Line)
                    .HasMaxLength(80)
                    .HasComment("Line 綁定");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(N'匿名')")
                    .HasComment("會員名稱");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasComment("會員密碼");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .HasComment("電話號碼");

                entity.Property(e => e.Photo)
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("(N'/Assets/img/photo.png')")
                    .HasComment("頭貼網址");

                entity.Property(e => e.Point).HasComment("個人總積分");

                entity.Property(e => e.PostalCode).HasComment("郵遞區號");

                entity.Property(e => e.Profession)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(N'職業行業')")
                    .HasComment("職業");

                entity.Property(e => e.Sex)
                    .HasMaxLength(6)
                    .HasComment("性別");

                entity.Property(e => e.Theme)
                    .HasMaxLength(80)
                    .HasComment("主題圖片網址");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(128)
                    .HasColumnName("OrderID");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(128)
                    .HasColumnName("MemberID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderStatus).HasMaxLength(128);

                entity.Property(e => e.PayDate).HasColumnType("datetime");

                entity.Property(e => e.PayMethod).HasMaxLength(128);

                entity.Property(e => e.TicketId)
                    .HasMaxLength(128)
                    .HasColumnName("TicketID");

                entity.Property(e => e.UsePoint).HasMaxLength(128);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.CourseId });

                entity.ToTable("Order_Detail");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(128)
                    .HasColumnName("OrderID");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(128)
                    .HasColumnName("CourseID");

                entity.Property(e => e.BuyMethod).HasMaxLength(128);

                entity.Property(e => e.CourseName).HasMaxLength(128);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.CourseId });

                entity.ToTable("Owner");

                entity.HasComment("收藏的課");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(128)
                    .HasColumnName("MemberID")
                    .HasComment("會員編號");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(128)
                    .HasColumnName("CourseID")
                    .HasComment("課程編號");
            });

            modelBuilder.Entity<PersonalUrl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PersonalUrl");

                entity.HasComment("個人網站連結");

                entity.Property(e => e.BehanceUrl)
                    .HasMaxLength(80)
                    .HasComment("Behance 個人網址");

                entity.Property(e => e.BlogUrl)
                    .HasMaxLength(80)
                    .HasComment("個人部落格網址");

                entity.Property(e => e.FbUrl)
                    .HasMaxLength(80)
                    .HasComment("Facebook 個人頁面網址");

                entity.Property(e => e.GoogleUrl)
                    .HasMaxLength(80)
                    .HasComment("Google 個人頁面網址");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("MemberID")
                    .HasComment("會員編號");

                entity.Property(e => e.PinterestUrl)
                    .HasMaxLength(80)
                    .HasComment("Pinterest 個人網址");

                entity.Property(e => e.YouTubeUrl)
                    .HasMaxLength(80)
                    .HasComment("YouTube 個人頻道");
            });

            modelBuilder.Entity<Point>(entity =>
            {
                entity.ToTable("Point");

                entity.HasComment("積分");

                entity.Property(e => e.PointId)
                    .HasColumnName("PointID")
                    .HasComment("積分編號");

                entity.Property(e => e.Deadline)
                    .HasMaxLength(30)
                    .HasComment("有效期限");

                entity.Property(e => e.GetTime)
                    .HasMaxLength(30)
                    .HasComment("取得日期");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(128)
                    .HasColumnName("MemberID")
                    .HasComment("會員編號");

                entity.Property(e => e.PointName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasComment("積分名稱");

                entity.Property(e => e.PointNum).HasComment("積分數");

                entity.Property(e => e.Status).HasComment("使用狀態");
            });

            modelBuilder.Entity<PointOwner>(entity =>
            {
                entity.HasKey(e => new { e.PointId, e.MemberId });

                entity.ToTable("PointOwner");

                entity.Property(e => e.PointId).HasColumnName("PointID");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(128)
                    .HasColumnName("MemberID");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.HasComment("問題");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("QuestionID")
                    .HasComment("問題編號");

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("CourseID")
                    .HasComment("課程編號");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("MemberID")
                    .HasComment("會員編號");

                entity.Property(e => e.QuestionContent)
                    .HasMaxLength(4000)
                    .HasComment("問題內容");

                entity.Property(e => e.QuestionDate)
                    .HasColumnType("date")
                    .HasComment("提問時間");
            });

            modelBuilder.Entity<QuestionLike>(entity =>
            {
                entity.HasKey(e => new { e.QuestionId, e.CourseId, e.MemberId });

                entity.ToTable("QuestionLike");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(128)
                    .HasColumnName("CourseID");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(128)
                    .HasColumnName("MemberID");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.CourseId });

                entity.ToTable("ShoppingCart");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(128)
                    .HasColumnName("MemberID");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(128)
                    .HasColumnName("CourseID");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.TicketId)
                    .HasMaxLength(128)
                    .HasColumnName("TicketID");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 1)");

                entity.Property(e => e.PayMethod).HasMaxLength(50);

                entity.Property(e => e.ProductType).HasMaxLength(50);

                entity.Property(e => e.Send).HasMaxLength(50);

                entity.Property(e => e.SendDate).HasColumnType("datetime");

                entity.Property(e => e.TicketName).HasMaxLength(128);

                entity.Property(e => e.TicketStatus).HasMaxLength(128);

                entity.Property(e => e.Ticketdate).HasColumnType("datetime");

                entity.Property(e => e.UseTime).HasMaxLength(50);
            });

            modelBuilder.Entity<TicketOwner>(entity =>
            {
                entity.HasKey(e => new { e.TicketId, e.MemberId });

                entity.ToTable("TicketOwner");

                entity.Property(e => e.TicketId)
                    .HasMaxLength(128)
                    .HasColumnName("TicketID");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(128)
                    .HasColumnName("MemberID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
