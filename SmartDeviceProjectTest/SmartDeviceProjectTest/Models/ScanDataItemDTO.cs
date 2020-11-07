using System;

namespace SmartDeviceProjectTest.Models
{
    public class ScanDataItemDTO
    {
        public Int64 ID_SCANDATAITEM { get; set; }
        public int ID_SCANDATA { get; set; }
        public int BLOCKED { get; set; }
        public string SKEY { get; set; }
        public string SKEY_TYPE { get; set; }
        public string CONTAINER { get; set; }
        public DateTime SCDATE { get; set; }
        public DateTime SCTIME { get; set; }
    }
}
