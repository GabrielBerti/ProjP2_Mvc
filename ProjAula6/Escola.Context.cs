﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjAula6
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class projP2Entities : DbContext
    {
        public projP2Entities()
            : base("name=projP2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aluno> aluno { get; set; }
        public virtual DbSet<aluno_curso> aluno_curso { get; set; }
        public virtual DbSet<aluno_disciplina> aluno_disciplina { get; set; }
        public virtual DbSet<curso> curso { get; set; }
        public virtual DbSet<curso_disciplina> curso_disciplina { get; set; }
        public virtual DbSet<disciplina> disciplina { get; set; }
    }
}