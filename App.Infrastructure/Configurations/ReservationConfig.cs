using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Collections.Specialized.BitVector32;

namespace App.Infrastructure.Configurations
{
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasOne(e => e.Client).WithMany(e => e.Reservations).HasForeignKey(e => e.IdClient);
            builder.HasOne(e => e.Pack).WithMany(e => e.Reservations).HasForeignKey(e => e.IdPack);
            builder.HasKey(e => new { e.IdClient, e.IdPack });
        }
    }
}
