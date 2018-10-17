using Microsoft.EntityFrameworkCore;
using SurveyServer.Context.Survey.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyServer.Context
{
    public partial class SurveyContext : DbContext
    {
        public SurveyContext()
        {
        }

        public SurveyContext(DbContextOptions<SurveyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entity_Question> TableQuestion { get; set; }
        public virtual DbSet<Entity_Reply> TableReply { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //TODO: To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS2017;Database=Survey;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity_Question>(entity =>
            {
                entity.ToTable("table_question");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<Entity_Reply>(entity =>
            {
                entity.ToTable("table_reply");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Reply)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_reply_question_id");
            });
        }
    }
}
