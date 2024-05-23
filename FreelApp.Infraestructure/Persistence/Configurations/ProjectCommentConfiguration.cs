using FreelApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Infraestructure.Persistence.Configurations
{
    public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder
            .HasKey(p => p.Id);

            builder
                .HasOne(pc => pc.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(pc => pc.idProject)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(pc => pc.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(pc => pc.idUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
