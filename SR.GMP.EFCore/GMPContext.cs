using Microsoft.EntityFrameworkCore;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.DataEntity.BaseEntity;
using SR.GMP.DataEntity.Dictionary;
using SR.GMP.DataEntity.System;
using SR.GMP.DataEntity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.GMP.EFCore
{
    public class GMPContext : DbContext
    {
        public GMPContext(DbContextOptions<GMPContext> options) : base(options)
        {
        }

        #region 预警维护表
        public DbSet<GMP_ALARM_ITEM> GMP_ALARM_ITEM { get; set; }
        public DbSet<GMP_ALARM_ITEM_RULE> GMP_ALARM_ITEM_RULE { get; set; }
        public DbSet<GMP_ALARM_RULE_CONFIG> GMP_ALARM_RULE_CONFIG { get; set; }
        public DbSet<GMP_ALARM_RECORD> GMP_ALARM_RECORD { get; set; }
        #endregion

        #region 系统字典表
        public DbSet<GMP_EVENT_ITEM> GMP_EVENT_ITEM { get; set; }
        public DbSet<GMP_MONITOR_ITEM> GMP_MONITOR_ITEM { get; set; }
        #endregion

        #region 系统表
        public DbSet<SYS_INST> SYS_INST { get; set; }
        public DbSet<SYS_INST_CENTER> SYS_INST_CENTER { get; set; }
        public DbSet<SYS_USER> SYS_USER { get; set; }
        public DbSet<SYS_DICT_CATEGORY> SYS_DICT_CATEGORY { get; set; }
        public DbSet<SYS_DICT_ITEM> SYS_DICT_ITEM { get; set; }

        //public virtual DbSet<PatientInfo> PatientInfo { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SYS_INST>().HasData(new SYS_INST
            {
                CODE = "0010",
                NAME = "苏北人民医院",
                ID = new Guid("a2241873-49ba-4672-92e9-a3825a0e8362")
            });

            modelBuilder.Entity<SYS_INST_CENTER>().HasData(new SYS_INST_CENTER
            {
                CODE = "0010",
                NAME = "苏北人民医院中心",
                INST_ID = new Guid("a2241873-49ba-4672-92e9-a3825a0e8362"),
                ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8362"),
            });

            modelBuilder.Entity<SYS_USER>().HasData(new SYS_USER
            {
                ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"),
                ACCOUNT = "admin",
                NAME = "admin",
                PWD = "123456",
            });

            modelBuilder.Entity<GMP_MONITOR_ITEM>().HasData(new GMP_MONITOR_ITEM
            {
                ID = 1,
                ITEM_NAME = "舒张压",
                ITEM_CODE = "SYSTOLIC_BLOOD_PRESSURE",
            });

            modelBuilder.Entity<GMP_EVENT_ITEM>().HasData(new GMP_EVENT_ITEM
            {
                ID = 1,
                ITEM_NAME = "头晕",
                ITEM_CODE = "touyun",
            });

            modelBuilder.Entity<GMP_ALARM_ITEM>().HasData(new GMP_ALARM_ITEM
            {
                ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"),
                ITEM_NAME = "报警项目1",
                PRIORITY =  DataEntity.DictEnum.PriorityEnum.中,
                CENT_ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8362"),
            });

            modelBuilder.Entity<GMP_ALARM_ITEM_RULE>().HasData(new GMP_ALARM_ITEM_RULE
            {
                ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"),
                ITEM_ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"),
                RULE_TYPE = DataEntity.DictEnum.AlarmRuleEnum.监测数据,
                MONITOR_ITEM_CODE = "VENOUS_PRESSURE",
                LOGIC_TYPE = DataEntity.DictEnum.AlarmLogicEnum.and,
                SORT_NUM = 0,
            },
            new GMP_ALARM_ITEM_RULE
            {
                ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"),
                ITEM_ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"),
                RULE_TYPE = DataEntity.DictEnum.AlarmRuleEnum.监测数据,
                MONITOR_ITEM_CODE = "ARTERIAL_PRESSURE",
                LOGIC_TYPE = DataEntity.DictEnum.AlarmLogicEnum.and,
                SORT_NUM = 0,
            });

            modelBuilder.Entity<GMP_ALARM_RULE_CONFIG>().HasData(new GMP_ALARM_RULE_CONFIG
            {
                ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"),
                RULE_ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"),
                MAX_VALUE = 120,
                MIN_VALUE = 100
            }, new GMP_ALARM_RULE_CONFIG
            {
                ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8314"),
                RULE_ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"),
                MAX_VALUE = 90,
            }, new GMP_ALARM_RULE_CONFIG
            {
                ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"),
                RULE_ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"),
                MIN_VALUE = 100
            });


            modelBuilder.Entity<MonitorViewData>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_HD_MONITORING");
            });
        }

        public override int SaveChanges()
        {
            //添加操作
            ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is IHasCreationInfo).ToList()
                .ForEach(e => ((IHasCreationInfo)e.Entity).CREATE_AT = DateTime.Now);

            //修改操作
            ChangeTracker.Entries().Where(e => e.State == EntityState.Modified && e.Entity is IHasModificationInfo).ToList()
                .ForEach(e => ((IHasModificationInfo)e.Entity).MODIFY_AT = DateTime.Now);


            return base.SaveChanges();
        }
    }
}
