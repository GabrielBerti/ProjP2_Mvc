//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class aluno_curso
    {
        public string ra_aluno { get; set; }
        public int id_curso { get; set; }
        public int id { get; set; }
    
        public virtual aluno aluno { get; set; }
        public virtual curso curso { get; set; }
    }
}
