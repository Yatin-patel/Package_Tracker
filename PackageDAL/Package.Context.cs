﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PackageDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PackageTrackerDBEntities : DbContext
    {
        public PackageTrackerDBEntities()
            : base("name=PackageTrackerDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Courier> Couriers { get; set; }
        public virtual DbSet<Deliver> Delivers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Department_Karyakar> Department_Karyakar { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Receiver> Receivers { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
