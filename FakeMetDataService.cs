using System;
using System.Linq;
using System.Threading;
using Weather.eklima.met.no;

namespace Weather
{
    public class FakeMetDataService
    {
        static no_met_metdata_StationProperties[] stations = {
            new no_met_metdata_StationProperties { stnr = 100, department = "OSLO", name = "Oslo" },
            new no_met_metdata_StationProperties { stnr = 101, department = "OSLO", name = "Blindern" },
            new no_met_metdata_StationProperties { stnr = 102, department = "OSLO", name = "Frognerseteren" },
            new no_met_metdata_StationProperties { stnr = 103, department = "OSLO", name = "Grorud" },
            new no_met_metdata_StationProperties { stnr = 104, department = "OSLO", name = "Kikut" },
            new no_met_metdata_StationProperties { stnr = 110, department = "HORDALAND", name = "Bergen" },
            new no_met_metdata_StationProperties { stnr = 111, department = "HORDALAND", name = "Odda" },
            new no_met_metdata_StationProperties { stnr = 112, department = "HORDALAND", name = "Finse" },
            new no_met_metdata_StationProperties { stnr = 113, department = "HORDALAND", name = "Rosendal" },
            new no_met_metdata_StationProperties { stnr = 114, department = "HORDALAND", name = "Voss" },
            new no_met_metdata_StationProperties { stnr = 115, department = "HORDALAND", name = "Leirvik" },
            new no_met_metdata_StationProperties { stnr = 116, department = "HORDALAND", name = "Stord" },
            new no_met_metdata_StationProperties { stnr = 120, department = "AKERSHUS", name = "Asker" },
            new no_met_metdata_StationProperties { stnr = 121, department = "AKERSHUS", name = "Drøbak" },
            new no_met_metdata_StationProperties { stnr = 122, department = "AKERSHUS", name = "Lillestrøm" },
            new no_met_metdata_StationProperties { stnr = 123, department = "AKERSHUS", name = "Oppegård" },
            new no_met_metdata_StationProperties { stnr = 124, department = "AKERSHUS", name = "Ås" },
            new no_met_metdata_StationProperties { stnr = 125, department = "AKERSHUS", name = "Oppegård" },
            new no_met_metdata_StationProperties { stnr = 126, department = "AKERSHUS", name = "Sandvika" },
            new no_met_metdata_StationProperties { stnr = 127, department = "AKERSHUS", name = "Ski" },
            new no_met_metdata_StationProperties { stnr = 128, department = "AKERSHUS", name = "Sørum" },
            new no_met_metdata_StationProperties { stnr = 129, department = "AKERSHUS", name = "Vestby" },
            new no_met_metdata_StationProperties { stnr = 130, department = "TROMS", name = "Bjarkøy" },
            new no_met_metdata_StationProperties { stnr = 131, department = "TROMS", name = "Borkenes" },
            new no_met_metdata_StationProperties { stnr = 132, department = "TROMS", name = "Finnsnes" },
            new no_met_metdata_StationProperties { stnr = 133, department = "TROMS", name = "Gratangen" },
            new no_met_metdata_StationProperties { stnr = 134, department = "TROMS", name = "Harstad" },
            new no_met_metdata_StationProperties { stnr = 135, department = "TROMS", name = "Karlsøy" },
            new no_met_metdata_StationProperties { stnr = 136, department = "TROMS", name = "Skjervøy" },
            new no_met_metdata_StationProperties { stnr = 137, department = "TROMS", name = "Sørreisa" },
            new no_met_metdata_StationProperties { stnr = 138, department = "TROMS", name = "Tromsø" },
        };

        internal no_met_metdata_Metdata getMetData(string timeseriesType, string v1, string from, string v2, string selectedStation, string elements, string v3, string v4, string v5)
        {
            return new no_met_metdata_Metdata
            {
                created = DateTime.Now,
                timeStamp = new no_met_metdata_TimeStamp[0],
                type = ""
            };
        }

        public no_met_metdata_StationProperties[] getStationsProperties(string a, string b)
        {
            Thread.Sleep(3000);
            return stations;
        }

        public no_met_metdata_CountyTypes[] getCountyTypes(string a, string b)
        {
            Thread.Sleep(500);
            return new []{
                new no_met_metdata_CountyTypes { countyID = 1, countyName = "OSLO" },
                new no_met_metdata_CountyTypes { countyID = 2, countyName = "HORDALAND" },
                new no_met_metdata_CountyTypes { countyID = 3, countyName = "AKERSHUS" },
                new no_met_metdata_CountyTypes { countyID = 4, countyName = "TROMS" },
            };
        }
    }
}