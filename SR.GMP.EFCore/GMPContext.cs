﻿using Microsoft.EntityFrameworkCore;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.DataEntity.BaseEntity;
using SR.GMP.DataEntity.Dictionary;
using SR.GMP.DataEntity.System;
using SR.GMP.DataEntity.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            #region 测试数据
            modelBuilder.Entity<SYS_INST>().HasData(new SYS_INST
            {
                CODE = "0010",
                NAME = "仁济医院",
                ID = new Guid("a2241873-49ba-4672-92e9-a3825a0e8362")
            });

            modelBuilder.Entity<SYS_INST_CENTER>().HasData(new SYS_INST_CENTER
            {
                CODE = "0010",
                NAME = "仁济东院",
                INST_ID = new Guid("a2241873-49ba-4672-92e9-a3825a0e8362"),
                ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8362"),
                EXT_ID = "cd20937a-24b2-455c-91c9-0df498c581b2",
            });

            modelBuilder.Entity<SYS_INST_CENTER>().HasData(new SYS_INST_CENTER
            {
                CODE = "0010",
                NAME = "仁济西院",
                INST_ID = new Guid("a2241873-49ba-4672-92e9-a3825a0e8362"),
                ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8363"),
                EXT_ID = "0010",
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
                ITEM_NAME = "高血压",
                ITEM_CODE = "高血压",
            });

            modelBuilder.Entity<GMP_ALARM_ITEM>().HasData(new GMP_ALARM_ITEM
            {
                ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"),
                ITEM_NAME = "报警项目1",
                PRIORITY =  DataEntity.DictEnum.PriorityEnum.中,
                CENT_ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8362"),
            });

            modelBuilder.Entity<GMP_ALARM_ITEM>().HasData(new GMP_ALARM_ITEM
            {
                ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"),
                ITEM_NAME = "报警项目2",
                PRIORITY = DataEntity.DictEnum.PriorityEnum.高,
                CENT_ID = new Guid("b2241873-49ba-4672-92e9-a3825a0e8363"),
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
            #endregion

            #region 视图模型映射
            modelBuilder.Entity<MonitorViewData>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_HD_MONITORING");
            });

            modelBuilder.Entity<EventViewData>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_HD_EVENT");
            });

            modelBuilder.Entity<BaseCountView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_BaseCountInfo");
            });

            modelBuilder.Entity<EquipmentCountView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_EquipmentCountInfo");
            });

            modelBuilder.Entity<OnlineTreatmentStatsView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_OnlineTreatmentStatsInfo");
            });

            modelBuilder.Entity<TreatmenCountView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_YearNewPatientCountInfo");
            });

            modelBuilder.Entity<TreatmentStatsView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_YearNewPatientMonthlyCountInfo");
            });


            #endregion
        }

        /// <summary>
        /// 保存创建信息和修改信息
        /// </summary>
        private void Save() 
        {
            //添加操作
            ChangeTracker.Entries().Where(e => e.Entity is IHasCreationInfo && e.State == EntityState.Added).ToList()
                .ForEach(e => ((IHasCreationInfo)e.Entity).CREATE_AT = DateTime.Now);

            //修改操作
            ChangeTracker.Entries().Where(e => e.Entity is IHasModificationInfo && e.State == EntityState.Modified).ToList()
              .ForEach(e => ((IHasModificationInfo)e.Entity).MODIFY_AT = DateTime.Now);
        }

        public override int SaveChanges()
        {
            Save();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Save();
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
