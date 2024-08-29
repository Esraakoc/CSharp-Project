using EK.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EK.DataAccess
{
    public partial class AppDbContext : DbContext
    {
         
        public AppDbContext()
        {
        } 

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //.......//
        public async Task<List<IssueWithStatus>> GetIssuesWithStatusAsync()
        {
            var query = @"
        SELECT I.*, C.description AS STATUS, T.user_id AS Assignedto 
        FROM EK_Issues I   
        LEFT JOIN EK_TaskLogs T ON I.task_id = T.task_id  AND T.status IN (0, 1, 2)
        LEFT JOIN EK_ComboDesc C ON C.field_name = 'STATUS' AND T.status = C.combo_id
        WHERE I.isDeleted = 0"; 

            return await this.IssuesWithStatus
                .FromSqlRaw(query)
                .ToListAsync();
        }

        //.......//
        public async Task<List<UserRoleWithRoleName>> GetUserRolesWithRoleNamesAsync()
        {
            var query = @"
                SELECT UR.user_id, R.role_name
                FROM EK_UserRoles UR
                JOIN EK_Roles R ON UR.role_id = R.role_id";

            return await this.UserRolesWithRoleNames
                .FromSqlRaw(query)
                .ToListAsync();
        } 
        //........//
        public DbSet<IssueWithStatus> IssuesWithStatus { get; set; } = default!;
        public DbSet<UserRoleWithRoleName> UserRolesWithRoleNames { get; set; } = default!;

        public virtual DbSet<EkComboDesc> EkComboDescs { get; set; } = null!;
        public virtual DbSet<EkIssue> EkIssues { get; set; } = null!;
        public virtual DbSet<EkRole> EkRoles { get; set; } = null!;
        public virtual DbSet<EkTaskLog> EkTaskLogs { get; set; } = null!;
        public virtual DbSet<EkUser> EkUsers { get; set; } = null!;
        public virtual DbSet<EkUserRole> EkUserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=10.132.102.130;Database=PROJECTDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //....ROLE..//
            modelBuilder.Entity<UserRoleWithRoleName>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.RoleName).HasColumnName("role_name");
            });


            //.WithStatus..//
            modelBuilder.Entity<IssueWithStatus>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.TaskId).HasColumnName("task_id");
                entity.Property(e => e.BegDate).HasColumnName("beg_date");
                entity.Property(e => e.Createdby).HasColumnName("createdby");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.EndDate).HasColumnName("end_date");
                entity.Property(e => e.FirstRecDate).HasColumnName("first_rec_date");
                entity.Property(e => e.TaskName).HasColumnName("task_name");
                entity.Property(e => e.Timestamp).HasColumnName("timestamp");
                entity.Property(e => e.Watcher).HasColumnName("watcher");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.Assignedto).HasColumnName("assignedto");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            OnModelCreatingPartial(modelBuilder);
            //..//
            modelBuilder.Entity<EkComboDesc>(entity =>
            {
                entity.HasKey(e => new { e.ComboId, e.TableName, e.FieldName })
                    .HasName("PK__EK_Combo__3683B5312A751DFF");

                entity.ToTable("EK_ComboDesc");

                entity.Property(e => e.ComboId).HasColumnName("combo_id");

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .HasColumnName("table_name");

                entity.Property(e => e.FieldName)
                    .HasMaxLength(50)
                    .HasColumnName("field_name");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<EkIssue>(entity =>
            {
             
                entity.HasKey(e => e.TaskId);
                
                entity.ToTable("EK_Issues");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BegDate)
                    .HasColumnType("datetime")
                    .HasColumnName("beg_date");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(15)
                    .HasColumnName("createdby");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.FirstRecDate)
                    .HasColumnType("datetime")
                    .HasColumnName("first_rec_date");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(100)
                    .HasColumnName("task_name");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.Watcher)
                    .HasMaxLength(15)
                    .HasColumnName("watcher");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted");
            });

            modelBuilder.Entity<EkRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("EK_Roles");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("role_name");

                entity.HasMany(d => d.EkUserRoles)
                    .WithOne(p => p.EkRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EK_UserRoles_Roles");
            });

            modelBuilder.Entity<EkTaskLog>(entity =>
            {
                entity.ToTable("EK_TaskLogs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Notification).HasColumnName("notification");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.UserId)
                    .HasMaxLength(15)
                    .HasColumnName("user_id");
                
                entity.Property(e => e.LogDate)
                    .HasColumnType("datetime")
                   .HasColumnName("log_date");

                entity.Property(e => e.Comment)
                 .HasMaxLength(200)
                 .HasColumnName("comment");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.EkTaskLogs)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_EK_TaskLogs_EK_Issue");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EkTaskLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_EK_TaskLogs_EK_Users");
            });
           
            modelBuilder.Entity<EkUser>(entity =>
            {
                entity.HasKey(e => e.UserId); 

                entity.ToTable("EK_Users");

                entity.Property(e => e.UserId)
                    .HasMaxLength(15)
                    .HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.HasMany(d => d.EkTaskLogs)
                     .WithOne(p => p.User)
                     .HasForeignKey(d => d.UserId)
                     .HasConstraintName("FK_EK_TaskLogs_EK_Users");

                entity.HasMany(d => d.UserRoles)
                    .WithOne(p => p.EkUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EK_UserRoles_Users");
            });

            modelBuilder.Entity<EkUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("EK_UserRoles");

                entity.Property(e => e.UserId)
                    .HasMaxLength(15)
                    .HasColumnName("user_id");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id");

                entity.HasOne(d => d.EkUser)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EK_UserRoles_Users");

                entity.HasOne(d => d.EkRole)
                    .WithMany(p => p.EkUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EK_UserRoles_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
