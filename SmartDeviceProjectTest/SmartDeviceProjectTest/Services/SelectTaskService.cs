using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SmartDeviceProjectTest.Models;
using System.Data.SQLite;
using System.Data;
using System.Data.SqlServerCe;
using System.Reflection;
using System.IO;
using SmartDeviceProjectTest.Extensions;
using Rebex.Net;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SmartDeviceProjectTest.Services
{
    public class SelectTaskService
    {
        private readonly string _dbConnection;
        private readonly Settings _settings;
        public SelectTaskService()
        {
            _settings = GetSettings("settings.json");
            _dbConnection = GetPathDateSource(_settings.Database);
        }

        public List<ScanJob> SendRequest() {
            var creator = new HttpRequestCreator();

            // specify enabled TLS/SSL versions
            // TLS 1.2, 1.1 and 1.0 are enabled by default, SSL 3.0 has to be enabled explicitly (if needed uncomment the following line):
            //creator.Settings.SslAllowedVersions |= TlsVersion.SSL30;

            // register request creator to handle HTTP and HTTPS requests
            // (replaces .NET's default HttpWebRequest)
            creator.Register();
            creator.Settings.SslAcceptAllCertificates = true;
            //creator.ValidatingCertificate += new EventHandler(validateCertificate);

            // now you can use WebRequest as usual - it will use our HttpRequestCreator
            WebRequest httpWebRequest = WebRequest.Create(_settings.ApiUrl);
            string authInfo = _settings.User + ":" + _settings.Pass;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            httpWebRequest.Headers["Authorization"] = "Basic " + authInfo;
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            var response = (WebResponse)httpWebRequest.GetResponse();
            string text;
            var listJobs = new List<ScanJob>();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
                var jobsJson = JObject.Parse(text).SelectToken("JOBS");
                var scanJobsDTO = JsonConvert.DeserializeObject<List<ScanJobDTO>>(jobsJson.ToString());
                foreach (var scanJobDTO in scanJobsDTO)
                {
                    scanJobDTO.PLAN_TOTAL_COUNT = new Random().Next(0, 50);
                    scanJobDTO.PLAN_TOTAL_WEIGHT = new Random().Next(0, 100);
                    listJobs.Add(MappingScanJob(scanJobDTO));
                }                 
            }
            return listJobs;
        }

        public ScanJob MappingScanJob(ScanJobDTO dto)
        {
            var containers = new List<Container>();
            foreach (var container in dto.Containers)
                containers.Add(MappingContainer(container));
            var job = new ScanJob(){
                AirportCode = dto.AIRPORT_CODE,
                JobType = ConverToJobType(dto.JOB_TYPE),
                JobSource = ConvertToJobSource(dto.JOB_SOURCE),
                ConfirmStatus = ConvertToConfirmStatus(dto.CONFIRM_STATUS),
                AviaCode = dto.AVIA,
                FlightNum = dto.RNUM,
                FlightDate = dto.RDATE,
                PlanContainersTotalNum = dto.PLAN_TOTAL_COUNT.HasValue ? dto.PLAN_TOTAL_COUNT.Value : 0,
                PlanContainsTotalWidth = dto.PLAN_TOTAL_WEIGHT.HasValue ? dto.PLAN_TOTAL_WEIGHT.Value : 0,
                SourceElementId = dto.ID_JOB,
                Containers = containers
            };
            return job;
        }

        public void Insert(List<ScanJob> scanJobs)
        {
            using (var connection = new SQLiteConnection(_dbConnection))
            {
                connection.Open();
                var sqlDelete = "DELETE FROM ScanJob";
                var sqlResetID = "DELETE FROM SQLITE_SEQUENCE WHERE name='ScanJob'";
                var insertQuery = "INSERT INTO ScanJob (SourceElementId, FlightNum, FlightDate, PlanContainersTotalNum, PlanContainsTotalWidth, JobType, ConfirmStatus, JobSource)" +
                                      " VALUES (@SourceElementId, @FlightNum, @FlightDate, @PlanContainersTotalNum, @PlanContainsTotalWidth, @JobType, @ConfirmStatus, @JobSource)";
                var insertQueryContainer = "INSERT INTO Container (ScanJobId, SourceElementID, ContainerNum) VALUES (last_insert_rowid(),@SourceElementID, @ContainerNum);";
                
                
                //Удаление данных
                using (var cmd = new SQLiteCommand(sqlDelete, connection))
                { cmd.ExecuteNonQuery(); }
                using (var cmd = new SQLiteCommand(sqlResetID, connection))
                { cmd.ExecuteNonQuery(); }

                using (var cmd = new SQLiteCommand("DELETE FROM Container", connection))
                { cmd.ExecuteNonQuery(); }
                using (var cmd = new SQLiteCommand("DELETE FROM SQLITE_SEQUENCE WHERE name='Container'", connection))
                { cmd.ExecuteNonQuery(); }


                foreach (var scanJob in scanJobs)
                {
                    using (var cmd = new SQLiteCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@SourceElementId", scanJob.SourceElementId);
                        cmd.Parameters.AddWithValue("@FlightNum", scanJob.FlightNum);
                        cmd.Parameters.AddWithValue("@FlightDate", scanJob.FlightDate);
                        cmd.Parameters.AddWithValue("@PlanContainersTotalNum", scanJob.PlanContainersTotalNum);
                        cmd.Parameters.AddWithValue("@PlanContainsTotalWidth", scanJob.PlanContainsTotalWidth);
                        cmd.Parameters.AddWithValue("@JobType", scanJob.JobType);
                        cmd.Parameters.AddWithValue("@ConfirmStatus", scanJob.ConfirmStatus);
                        cmd.Parameters.AddWithValue("@JobSource", scanJob.JobSource);
                        cmd.ExecuteNonQuery();
                    }
                    try
                    {
                        foreach (var container in scanJob.Containers)
                        {
                            using (var cmd = new SQLiteCommand(insertQueryContainer, connection))
                            {
                                cmd.Parameters.AddWithValue("@SourceElementId", container.SourceElementID);
                                cmd.Parameters.AddWithValue("@ContainerNum", container.ContainerNum);
                                cmd.ExecuteNonQuery();
                            }
                        }    
                    }
                    catch (SQLiteException e)
                    {
                        Console.WriteLine(e.Message);
                    }               
                }
            }

        }

        public Container MappingContainer(ContainerDTO dto)
        {
            return new Container() { 
                SourceElementID = dto.CONTAINER_ID,
                ContainerNum = dto.CONTAINER
            };
        }

        public ScanJobConfirmStatus ConvertToConfirmStatus(int value)
        {
            return (ScanJobConfirmStatus)value;
        }


        public ScanJobSource ConvertToJobSource(int value)
        {
            return (ScanJobSource)value;
        }

        public ScanJobType ConverToJobType(int value)
        {
            return (ScanJobType)value;
        }

        private string GetPath(string file)
        {
            var str = Assembly.GetExecutingAssembly().GetName().CodeBase.ToString();
            var pos = str.LastIndexOf("\\");
            var sdfPath = str.Substring(0, pos);
            sdfPath = sdfPath + "\\" + file;
            return sdfPath;
        }

        private string GetPathDateSource(string file)
        {
            var str = Assembly.GetExecutingAssembly().GetName().CodeBase.ToString();
            var pos = str.LastIndexOf("\\");
            var sdfPath = str.Substring(0, pos);
            sdfPath = sdfPath + "\\" + file;
            var strConection = string.Format("Data Source = {0};", sdfPath);
            return strConection;
        }

        private Settings GetSettings(string fileName)
        {
            var path = GetPath(fileName);
            var text = string.Empty;
            try
            {
                using (var sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return JsonConvert.DeserializeObject<Settings>(text);
        }

        public List<ScanJob> GetSQLite()
        {   var scanJobs = new List<ScanJob>();
            try
            {
                scanJobs = GetData("SELECT * FROM ScanJob");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return scanJobs;
        }

        public List<ScanJob> GetByFlightNum(string flightNum) 
        {
            return GetData("SELECT * FROM ScanJob WHERE FlightNum = " + flightNum);
        }

        public List<ScanJob> GetByContainerNum(string containerNum)
        {
            var scanJobs = GetData("SELECT * FROM ScanJob");
            var scanJobsTmp = new List<ScanJob>();
            foreach (var scanJob in scanJobs)
            {
                foreach (var container in scanJob.Containers)
                {
                    if (container.ContainerNum == containerNum)
                    {
                        scanJobsTmp.Add(scanJob);
                        continue;
                    }
                }               
            }            
            return scanJobsTmp;
        }

        private List<Container> GetContainesByJobId(int jobId) {
            try
            {
                var sql = "select * from Container where ScanJobId = " + jobId.ToString();
                var listContainers = new List<Container>();
                using (var c = new SQLiteConnection(_dbConnection))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                listContainers.Add(new Container
                                {
                                    Id = Convert.ToInt32(rdr["Id"]),
                                    SourceElementID = Convert.ToInt64(rdr["SourceElementID"].ToString()),
                                    ContainerNum = rdr["ContainerNum"].ToString(),
                                    ScanJobId = (int)rdr["ScanJobId"]
                                });
                            }
                            return listContainers;
                        }
                    }
                    return listContainers;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private List<ScanJob> GetData(string sql)
        {
            try
            {
                var scanJob = new ScanJob();
                var listJobs = new List<ScanJob>();
                using (var c = new SQLiteConnection(_dbConnection))
                {
                    c.Open();                   
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {                                
                                //todo Переписать со swich
                                //записывать в правильном формате
                                var containers = GetContainesByJobId(Convert.ToInt32(rdr["Id"]));
                                listJobs.Add(new ScanJob
                                {
                                    Id = Convert.ToInt32(rdr["Id"]),
                                    SourceElementId = (int)rdr["SourceElementId"],
                                    FlightNum = rdr["FlightNum"].ToString(),
                                    Created = rdr["Created"] is DBNull == false ? Convert.ToDateTime(rdr["Created"]) : DateTime.MinValue,
                                    FlightDate = rdr["FlightDate"] is DBNull == false ? Convert.ToDateTime(rdr["FlightDate"]): DateTime.MinValue,
                                    IdFlight = rdr["IdFlight"] is DBNull == false ? (int) rdr["IdFlight"] : 0,
                                    JobType = CovertToStartEnum( rdr["JobType"] is DBNull == false ? (int)rdr["JobType"] : 0),
                                    AirportCode = rdr["AirportCode"].ToString(),
                                    PlanContainersTotalNum = rdr["PlanContainersTotalNum"] is DBNull == false ? (int)rdr["PlanContainersTotalNum"] : 0,
                                    PlanContainsTotalWidth = rdr["PlanContainsTotalWidth"] is DBNull == false ? Convert.ToDecimal(rdr["PlanContainsTotalWidth"]) : 0,
                                    Containers = containers
                                });
                            }
                            return listJobs;
                        }
                    }
                    return listJobs;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public ScanJobType CovertToStartEnum(int value)
        {
            return (ScanJobType)value;
        }
    }
}
