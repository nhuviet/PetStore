using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pet_Store_BE.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Pet_Store_BE.Models
{

    public class DBEntities : IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("dbo.Customer");
        }
    }
}
