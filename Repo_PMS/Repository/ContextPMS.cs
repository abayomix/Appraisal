using Microsoft.EntityFrameworkCore;
using Repo_PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Repository
{
    public class ContextPMS:DbContext
    {

        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<RoleDetail> RoleDetails { get; set; }
        public DbSet<Degination> deginations { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<assesment>assesments { get; set; }
      public DbSet<QuestionSet> QuestionSets { get; set; }
       public DbSet<AssesmentReviewRatio> AssesmentReviewRatios { get; set; }
        public DbSet<AssesmentResponse> AssesmentResponses { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<FeedBack_Question> FeedBack_Questions { get; set; }

          public DbSet<Feedback> feedbacks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-TFQ9M1R;Database=OP;Integrated Security=true;");
                // need to add connection string here after that do migration.
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
