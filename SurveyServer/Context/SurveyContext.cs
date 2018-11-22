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

        public virtual DbSet<Entity_Answer> Answers { get; set; }
        public virtual DbSet<Entity_Question> Questions { get; set; }
        public virtual DbSet<Entity_Reply> Replies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //TODO: To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS2017;Database=Survey;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity_Answer>(entity =>
            {
                entity.ToTable("table_answer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.ReplyContent)
                    .IsRequired()
                    .HasColumnName("reply_content")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReplyId).HasColumnName("reply_id");

                entity.Property(e => e.SessionNumber).HasColumnName("session_number");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TableAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionID");

                entity.HasOne(d => d.Reply)
                    .WithMany(p => p.TableAnswer)
                    .HasForeignKey(d => d.ReplyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReplyID");
            });

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
                    .WithMany(p => p.TableReply)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_reply_question_id");
            });
        }
    }
}
