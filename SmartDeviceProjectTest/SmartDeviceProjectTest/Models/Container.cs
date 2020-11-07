using System;
namespace SmartDeviceProjectTest.Models
{
    public class Container
    {
        public int Id { get; set; }
        public int? ScanJobId { get; set; }
        public Int64 SourceElementID { get; set; }
        /// <summary>
        /// Номер средства пакетирования
        /// </summary>
        public string ContainerNum { get; set; }
    }
}
