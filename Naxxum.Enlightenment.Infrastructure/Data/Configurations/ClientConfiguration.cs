using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Naxxum.Enlightenment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxum.Enlightenment.Infrastructure.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            // Configure the ID property
            builder.HasKey(e => e.IdClient);

            // Optional: configure the name of the ID property
            builder.Property(e => e.IdClient)
                 .HasColumnName("IdClient");

        }






    }
}