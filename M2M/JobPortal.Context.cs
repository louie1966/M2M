﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace M2M
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JobPortalContainer : DbContext
    {
        public JobPortalContainer()
            : base("name=JobPortalContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<JobPost> JobPosts { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<JobTag> JobTags { get; set; }
    }
}
