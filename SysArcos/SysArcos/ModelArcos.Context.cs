﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SysArcos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ARCOS_Entities : DbContext
    {
        public ARCOS_Entities()
            : base("name=ARCOS_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ASSISTENCIA> ASSISTENCIA { get; set; }
        public virtual DbSet<ASSISTIDO> ASSISTIDO { get; set; }
        public virtual DbSet<CATEGORIA_PRODUTO> CATEGORIA_PRODUTO { get; set; }
        public virtual DbSet<DOACAO> DOACAO { get; set; }
        public virtual DbSet<DOADOR> DOADOR { get; set; }
        public virtual DbSet<ENTIDADE> ENTIDADE { get; set; }
        public virtual DbSet<ESTOQUE> ESTOQUE { get; set; }
        public virtual DbSet<EVENTO> EVENTO { get; set; }
        public virtual DbSet<FORNECEDOR> FORNECEDOR { get; set; }
        public virtual DbSet<FORNECIMENTO> FORNECIMENTO { get; set; }
        public virtual DbSet<FORNECIMENTO_ITENS> FORNECIMENTO_ITENS { get; set; }
        public virtual DbSet<PRODUTO> PRODUTO { get; set; }
        public virtual DbSet<RECURSO> RECURSO { get; set; }
        public virtual DbSet<TIPO_EVENTO> TIPO_EVENTO { get; set; }
        public virtual DbSet<TIPO_RECURSO> TIPO_RECURSO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<VOLUNTARIADO> VOLUNTARIADO { get; set; }
        public virtual DbSet<VOLUNTARIAR> VOLUNTARIAR { get; set; }
        public virtual DbSet<VOLUNTARIO> VOLUNTARIO { get; set; }
        public virtual DbSet<CONFIG_SERVIDOR> CONFIG_SERVIDOR { get; set; }
        public virtual DbSet<RECUPERACAO_SENHA> RECUPERACAO_SENHA { get; set; }
    }
}
