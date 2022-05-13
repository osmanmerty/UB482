using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UB482
{
    class Data
    {
        StreamWriter writer;
        public Data()
        {
            string path = "am" + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".csv";
            writer = new StreamWriter(path);
            AddHeader();
        }
        

        public static string header, gnss, length, year, month,
            day, minute, second, rtkStatus, headingStatus,
            numGpsStatus, numGloStatus, numBdsStatus, baselineN,
            baselineE, baselineU, baselineNStd, baselineEsStd, baselineUStd,
            heading, gpsPitch, gpsRoll, gpsSpeed, velN, velE, velUP, xigVx,
            xigVy, xigVz, latitude, longitude, roverHei, ecefX, ecefY, ecefZ,
            xigLat, xigLon, xigAlt, xigEcefX, xigEcefY, xigEcefZ, baseLat, baseLon,
            baseAlt, secLat, secLon, secAlt, gpsWeekSecond, diffage, speedHeading,
            undulation, remainFloat3, remainFloat4, numGalStatus, remainChar2,
            remainChar3, remainChar4, crc; 

        public string[] datas = new string[]
        {
            gnss, length, year, month,
            day, minute, second, rtkStatus, headingStatus,
            numGpsStatus, numGloStatus, numBdsStatus, baselineN,
            baselineE, baselineU, baselineNStd, baselineEsStd, baselineUStd,
            heading, gpsPitch, gpsRoll, gpsSpeed, velN, velE, velUP, xigVx,
            xigVy, xigVz, latitude, longitude, roverHei, ecefX, ecefY, ecefZ,
            xigLat, xigLon, xigAlt, xigEcefX, xigEcefY, xigEcefZ, baseLat, baseLon,
            baseAlt, secLat, secLon, secAlt, gpsWeekSecond, diffage, speedHeading,
            undulation, remainFloat3, remainFloat4, numGalStatus, remainChar2,
            remainChar3, remainChar4, crc
        };

        private string[] logString = new string[]
        {
            gnss, length, year, month,
            day, minute, second, rtkStatus, headingStatus,
            numGpsStatus, numGloStatus, numBdsStatus,
            heading, gpsPitch, gpsRoll, gpsSpeed, velN, velE, velUP, xigVx,
            xigVy, xigVz, latitude, longitude, roverHei, ecefX, ecefY, ecefZ,
            xigLat, xigLon, xigAlt, xigEcefX, xigEcefY, xigEcefZ, secLat,
            secLon, secAlt, gpsWeekSecond, diffage, speedHeading,
            undulation, numGalStatus
        };

        public async void LogDataAsync()
        {
            await Task.Run(() =>
            {
                foreach (var singleData in logString)
                {
                    writer.Write(singleData);
                }
                writer.WriteLine();
            });
        }

        public void AddHeader()
        {
            string header = "gnss,length,year,month,day,minute,second,rtkStat,headingStat,numGpsStatus,numGloStatus,numBdsStatus,heading,gpsPitch,gpsRoll,gpsSpeed,VelN,velE,velUp,xigVx,xigVy,xigVz,latitude,longitude,roverHei,ecefX,ecefY,ecefZ,xigLat,xigLon,xigAlt,xigEcefX,xigEcefY,xigEcefZ,secLat,secLon,secAlt,gpsWeekSec,diffage,speedHeading,undulation,galStat";
            writer.WriteLine(header);
        }
        
        public void CloseFile()
        {
            writer.Close();
        }
    }
}
