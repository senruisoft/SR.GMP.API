using Microsoft.EntityFrameworkCore;
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
        public DbSet<GMP_ALARM_RECORD_DATA> GMP_ALARM_RECORD_DATA { get; set; }
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

            modelBuilder.Entity<GMP_ALARM_RECORD_DATA>().HasKey(t => new { t.ALARM_RECORD_ID, t.MONITOR_ITEM_CODE });

            modelBuilder.Entity<GMP_MONITOR_ITEM>().HasData(
                new GMP_MONITOR_ITEM { ID = 1, ITEM_NAME = "静脉压", ITEM_CODE = "VENOUS_PRESSURE" },
                new GMP_MONITOR_ITEM { ID = 2, ITEM_NAME = "动脉压", ITEM_CODE = "ARTERIAL_PRESSURE" },
                new GMP_MONITOR_ITEM { ID = 3, ITEM_NAME = "跨膜压", ITEM_CODE = "TRANS_PRESSURE" },
                new GMP_MONITOR_ITEM { ID = 4, ITEM_NAME = "血流量", ITEM_CODE = "BLOOD_FLOW" },
                new GMP_MONITOR_ITEM { ID = 5, ITEM_NAME = "体温", ITEM_CODE = "BODY_TEMPERATURE" },
                new GMP_MONITOR_ITEM { ID = 6, ITEM_NAME = "收缩压", ITEM_CODE = "SYSTOLIC_BLOOD_PRESSURE" },
                new GMP_MONITOR_ITEM { ID = 7, ITEM_NAME = "舒张压", ITEM_CODE = "STRETCH_PRESSURE" },
                new GMP_MONITOR_ITEM { ID = 8, ITEM_NAME = "心率", ITEM_CODE = "HEART_RATE" },
                new GMP_MONITOR_ITEM { ID = 9, ITEM_NAME = "电导率", ITEM_CODE = "ELECTRICAL_CONDUCTIVITY" });

            #region 监控首页视图
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

            #region 概括页面视图
            modelBuilder.Entity<PatientGeneralView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_PatientGeneralInfo");
            });

            modelBuilder.Entity<PatientBasicTreatView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_PatientBasicTreatInfo");
            });

            modelBuilder.Entity<DeviceTreatDataView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_DeviceTreatDataInfo");
            });

            modelBuilder.Entity<MonitorDataView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_MonitorDataInfo");
            });

            modelBuilder.Entity<TreatOrderView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_TreatOrderInfo");
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
