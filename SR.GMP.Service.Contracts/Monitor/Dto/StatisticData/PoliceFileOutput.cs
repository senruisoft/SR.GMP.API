namespace SR.GMP.Service.Contracts.Monitor.Dto.StatisticData
{
    /// <summary>
    /// 报警文件输出模型
    /// </summary>
    public class PoliceFileOutput
    {
        /// <summary>
        /// 文件ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 警报ID
        /// </summary>
        public string POLICE_ID { get; set; }
        /// <summary>
        /// 文件内容 Base64 
        /// </summary>
        public string FILE_CONTENT { get; set; }
    }
}
