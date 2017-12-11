using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConduceSinPapeles.Models
{
    public class DataParamTruckVisit
    {
        //GateId, StageId, LaneId, TruckingLicenseNbr, TruckingCoId, DriveLicenseNbr, GosTvKey, BatNbr, TimesTamp
        public String GateId { get; set; }
        public String StageId { get; set; }
        public String TruckingLicenseNbr { get; set; }
        public String TruckingCoId { get; set; }
        public String DriverLicenseNbr { get; set; }
        public String GosTvKey { get; set; }
        public String BatNbr { get; set; }
        public String TimesTamp { get; set; }

    }
}