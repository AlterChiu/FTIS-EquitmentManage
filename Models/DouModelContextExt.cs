using System;
using System.Data.Entity;
using System.Linq;

namespace DouImp.Models
{
    public class DouModelContextExt : Dou.Models.ModelContextBase<User, Role>
    {
        public DouModelContextExt() : base("name=DouModelContextExt")
        {
            Database.SetInitializer<DouModelContextExt>(null);
        }
        
        public virtual DbSet<eqEquip> eqEquip { get; set; }
        public virtual DbSet<eqPlace> eqPlace { get; set; }
        public virtual DbSet<eqTypeA> eqTypeA { get; set; }
        public virtual DbSet<eqTypeB> eqTypeB { get; set; }
        public virtual DbSet<cmmEmp> cmmEmp { get; set; }
        public virtual DbSet<cmmDep> CmmDep { get; set; }


    }


    public class FtisModelContext : DbContext
    {
        public FtisModelContext()
            : base("name=FtisModelContext")
        {
        }
        
    }


    public class OtherDBContext : DbContext
    {
        public OtherDBContext()
            : base("name=FtisModelContext")
        {
        }
        public virtual DbSet<cmmDep> cmmDep { get; set; }

    }


    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}