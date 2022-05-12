using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UB482
{
    class Data
    {
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
    }
}
