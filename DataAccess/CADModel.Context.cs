﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CADEntities : DbContext
    {
        public CADEntities()
            : base("name=CADEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<BusinessUnitReview> BusinessUnitReviews { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PersonInfo> PersonInfoes { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
