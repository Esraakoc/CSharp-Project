using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EK.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.DataAccess.EFCore.Config
{
    public class TaskConfig : IEntityTypeConfiguration<EkIssue>
    {
        public void Configure(EntityTypeBuilder<EkIssue> builder)
        {
            builder.HasData(
               new EkIssue() { TaskId = 1, TaskName = "frontend", Description = "good", Createdby = "akoc", Watcher = "ayilmaz" }
               );
        }
    }
}
