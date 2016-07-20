using System.Data.Entity;

namespace TPC
{
    public class DataContext : DbContext
    {
        public DbSet<BillingDetail> BillingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillingDetail>()
            .Property(p => p.BillingDetailId)
            .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            // DatabaseGeneratedOption.None
            #region notes
            /*
                The reason we got this exception is because DbContext.SaveChanges() internally invokes SaveChanges method of its internal ObjectContext. 
                ObjectContext's SaveChanges method on its turn by default calls AcceptAllChanges after it has performed the database modifications. 
                AcceptAllChanges method merely iterates over all entries in ObjectStateManager and invokes AcceptChanges on each of them. 
                Since the entities are in Added state, AcceptChanges method replaces their temporary EntityKey with a regular EntityKey based on the primary key values (i.e. BillingDetailId) that come back from the database and that's where the problem occurs since both the entities have been assigned the same value for their primary key by the database (i.e. on both BillingDetailId = 1) and the problem is that ObjectStateManager cannot track objects of the same type (i.e. BillingDetail) with the same EntityKey value hence it throws. 
                If you take a closer look at the TPC's SQL schema above, you'll see why the database generated the same values for the primary keys: the BillingDetailId column in both BankAccounts and CreditCards table has been marked as identity.
            */

            #endregion
            // http://weblogs.asp.net/manavi/inheritance-mapping-strategies-with-entity-framework-code-first-ctp5-part-3-table-per-concrete-type-tpc-and-choosing-strategy-guidelines


            modelBuilder.Entity<BankAccount>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("BankAccounts");

            }).HasKey(k => k.BillingDetailId);

            modelBuilder.Entity<CreditCard>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("CreditCards");
            }).HasKey(k => k.BillingDetailId);
        }
    }
}
