using System;

namespace SmartDeviceProjectTest.Models
{
    public enum BarCodeValue
    {
        
    }
    public class ScanDataItem
    {
        public int Id { get; set; }
        /// <summary>
        /// Id приходящий
        /// </summary>
        public string SourceElementID { get; set; }
        /// <summary>
        /// ID задания к которому присвоено сканирование
        /// </summary>
        public int? ScanJobID { get; set; }
        /// <summary>
        /// Штрих-код
        /// </summary>
        public string BarCodeValue { get; set; }
        /// <summary>
        /// Тип штриз-кода
        /// </summary>
        public BarCodeValue ScanType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContainerNum { get; set; }
        /// <summary>
        /// Средства пакетирования
        /// </summary>
        public int? ContainerID { get; set; }

        /// <summary>
        /// Дата и время сканирования
        /// </summary>
        public DateTime ScanTime { get; set; }
    }
}
