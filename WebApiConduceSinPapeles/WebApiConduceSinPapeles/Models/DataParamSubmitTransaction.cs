﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConduceSinPapeles.Models
{
    public class DataParamSubmitTransaction
    {
        public String GateId { get; set; }
        public String StageId { get; set; }
        public String TvKey { get; set; }
        public String EqId { get; set; }
        public String IsoType { get; set; }
        public String OnChassisId { get; set; }

    }
}