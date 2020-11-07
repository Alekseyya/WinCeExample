using System;
using System.Collections.Generic;

namespace SmartDeviceProjectTest.Models
{
    public enum ScanJobType
    {
        /// <summary>
        /// Получение почты от АОПП
        /// </summary>
        ReceivingMailAOPP = 1,
        /// <summary>
        /// Запланировано на рейс (Прямой перегруз)
        /// </summary>
        FlightScheduled = 2,
        /// <summary>
        /// Запланировано на рейс от АОПП
        /// </summary>
        ScheduledFlightAOPP = 3,
        /// <summary>
        /// Почта отправлена от АОПП
        /// </summary>
        MailSentAOPP = 4,
        /// <summary>
        /// Почта отправлена (Прямой перегруз) 
        /// </summary>
        MailSentDirectTransshipment = 5,
        /// <summary>
        /// Возвращено с рейса (от АОПП)
        /// </summary>
        ReturnedFlightAOPP = 6,
        /// <summary>
        /// Возвращено с рейса (Прямой перегруз
        /// </summary>
        ReturnedFlightDirectTransfer = 7,
        /// <summary>
        /// Передача возврата в АОПП
        /// </summary>
        PassingReturnAOPP = 8,
        /// <summary>
        /// Получение импортной почты
        /// </summary>
        ReceiveImportMail = 11,
        /// <summary>
        /// Получение почты (Прямой перегруз)
        /// </summary>
        ReceivingMailDirectTransfer = 12


    }

    public enum ScanJobSource
    {

    }
    public enum ScanJobConfirmStatus
    {
        /// <summary>
        /// Не подтвержден
        /// </summary>
        NotConfirmed = 0
    }
    public class ScanJob
    {
        public int Id { get; set; }
        /// <summary>
        /// ID - в табилице приходящей
        /// </summary>
        public int SourceElementId { get; set; }
        /// <summary>
        /// Дата и время создания задания
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// ID рейса
        /// </summary>
        public int IdFlight { get; set; }
        /// <summary>
        /// Тип задания по справочнику заданий
        /// </summary>
        public ScanJobType JobType { get; set; }
        /// <summary>
        /// Код аэропорта
        /// </summary>
        public string AirportCode { get; set; }
        /// <summary>
        ///Источние задания по справочнику заданий
        /// </summary>
        public ScanJobSource JobSource { get; set; }
        /// <summary>
        /// Код авиакомпании
        /// </summary>
        public string AviaCode { get; set; }
        /// <summary>
        /// Номер рейса
        /// </summary>
        public string FlightNum { get; set; }
        /// <summary>
        /// Дата рейса
        /// </summary>
        public DateTime FlightDate { get; set; }
        /// <summary>
        /// Откуда
        /// </summary>
        public string FlightFrom { get; set; }
        /// <summary>
        /// Куда
        /// </summary>
        public string FlightTo { get; set; }
        /// <summary>
        /// Плановое количество емкостей
        /// </summary>
        public int PlanContainersTotalNum { get; set; }
        /// <summary>
        /// Плановый вес всех емкостей гр
        /// </summary>
        public decimal PlanContainsTotalWidth { get; set; }
        /// <summary>
        /// Статус задания
        /// </summary>
        public ScanJobConfirmStatus ConfirmStatus { get; set; }

        public List<Container> Containers { get; set; }
    }
}
