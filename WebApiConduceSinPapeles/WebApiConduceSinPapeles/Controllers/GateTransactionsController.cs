using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Text;
using Newtonsoft.Json;
using WebApiConduceSinPapeles.Models;
using WebApiConduceSinPapeles.Services;

namespace WebApiConduceSinPapeles.Controllers
{
    public class GateTransactionsController : ApiController
    {
        //POST: api/Create_Truck_Visit
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Create_Truck_Visit([FromBody]DataParamTruckVisit param)
        {
            
            String result = String.Empty;
            ResponseMsg response = null;
            try
            {
                NavisConnect service = new NavisConnect();
                result = service.executeGenericInvokeCREATE_TRUCK_VISIT(param.GateId, param.StageId, param.LaneId, param.TruckingLicenseNbr, param.TruckingCoId, param.DriverLicenseNbr, param.GosTvKey, param.BatNbr, param.TimesTamp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            String[] arg = result.Split('|');

            if (arg.Length == 2)
            {

                //
                if (arg[0].Equals("OK"))
                {
                    response = new ResponseMsg() { Status = "OK", Codigo = "0", Message = arg[1] };
                }
                else
                {
                    response = new ResponseMsg() { Status = "OK", Codigo = "1", Message = arg[1] };
                }

            }
            
            return Ok(response);
        }
        
        //POST: api/Create_Truck_Visit
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Submit_Transaction([FromBody]DataParamSubmitTransaction param)
        {

            String result = String.Empty;
            ResponseMsg response = null;
            try
            {
                NavisConnect service = new NavisConnect();
                result = service.executeGenericInvokeSUBMIT_TRANSACTION(param.TvKey, param.GosTvKey, param.EqId, param.IsoType, param.OnChassisId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            String[] arg = result.Split('|');

            if (arg.Length == 2)
            {

                //
                if (arg[0].Equals("OK"))
                {
                    response = new ResponseMsg() { Status = "OK", Codigo = "0", Message = arg[1] };
                }
                else
                {
                    response = new ResponseMsg() { Status = "OK", Codigo = "1", Message = arg[1] };
                }

            }

            return Ok(response);
        }

        //POST: api/Stage_Done
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Stage_Done([FromBody]DataParamTruckVisit param)
        {

            String result = String.Empty;
            ResponseMsg response = null;
            try
            {
                NavisConnect service = new NavisConnect();
                result = service.executeGenericInvokeSTAGE_DONE(param.GateId, param.StageId, param.LaneId, param.TruckingLicenseNbr, param.TruckingCoId, param.DriverLicenseNbr, param.GosTvKey, param.BatNbr, param.TimesTamp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            String[] arg = result.Split('|');

            if (arg.Length == 2)
            {

                //
                if (arg[0].Equals("OK"))
                {
                    response = new ResponseMsg() { Status = "OK", Codigo = "0", Message = arg[1] };
                }
                else
                {
                    response = new ResponseMsg() { Status = "OK", Codigo = "1", Message = arg[1] };
                }

            }

            return Ok(response);
        }


    }
}