﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JiuQinSys.Modle
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JiuQinEntities : DbContext
    {
        public JiuQinEntities()
            : base("name=JiuQinEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<QuoteOrderMain> QuoteOrderMain { get; set; }
        public virtual DbSet<QuoteOrderSub> QuoteOrderSub { get; set; }
        public virtual DbSet<PrepareOrderMain> PrepareOrderMain { get; set; }
        public virtual DbSet<PrepareOrderSub> PrepareOrderSub { get; set; }
        public virtual DbSet<AssessmentOrderMain> AssessmentOrderMain { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<ContactPhone> ContactPhone { get; set; }
        public virtual DbSet<PartPrepareOrderSub> PartPrepareOrderSub { get; set; }
        public virtual DbSet<StockChangeLog> StockChangeLog { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
