using System;
using System.Collections.Generic;

namespace SmartDeviceProjectTest.Models
{
    public class ScanJobDTO
    {
        public int ID_JOB { get; set; }
        public int JOB_TYPE { get; set; }
        public DateTime JOB_CREATEDATE { get; set; }
        public string AIRPORT_CODE { get; set; }
        public int JOB_SOURCE { get; set; }
        public Int64 ID_FLIGHT { get; set; }
        public string AVIA { get; set; }
        public string RNUM { get; set; }
        public DateTime RDATE { get; set; }
        public string RFROM { get; set; }
        public string RTO { get; set; }
        public int? PLAN_TOTAL_COUNT { get; set; }
        public decimal? PLAN_TOTAL_WEIGHT { get; set; }
        public int CONFIRM_STATUS { get; set; }
        public List<ContainerDTO> Containers { get; set; }
    }
}
