using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiConduceSinPapeles.ArgoBasicService;
using System.Text;

namespace WebApiConduceSinPapeles.Services
{
    public class NavisConnect
    {
        /// <summary>
        /// Constructor Navis Connect
        /// </summary>
        public NavisConnect() { }


        public string executeGenericInvokeCREATE_TRUCK_VISIT(String GateId, String StageId, String LaneId, String TruckingLicenseNbr, String TruckingCoId, String DriveLicenseNbr, String GosTvKey, String BatNbr, String TimesTamp)
        {

            string myXml = string.Format(ConnectionAndSettings.CREATE_TRUCK_VISIT, GateId, StageId, LaneId, TruckingLicenseNbr, TruckingCoId, DriveLicenseNbr, GosTvKey, BatNbr, TimesTamp);

            string rs = string.Empty;
            try
            {
                genericInvoke arg = new genericInvoke();
                ScopeCoordinateIdsWsType scope = new ScopeCoordinateIdsWsType();
                scope.operatorId = "HIT";
                scope.complexId = "SANTO_DOMINGO";
                scope.facilityId = "HAINA_TERMINAL";
                scope.yardId = "HITYRD";

                arg.scopeCoordinateIdsWsType = scope;
                arg.xmlDoc = myXml;

                //
                ExtendedGenericWebservice n4WebService = new ExtendedGenericWebservice();

                byte[] bcred = System.Text.Encoding.ASCII.GetBytes(ConnectionAndSettings.User + ":" + ConnectionAndSettings.Password);

                string b64cred = Convert.ToBase64String(bcred);

                n4WebService.SetRequestHeader("Authorization", "Basic " + b64cred);
                n4WebService.Timeout = -1;

                genericInvokeResponse response = n4WebService.genericInvoke(arg);

                ResponseType commonResponse = response.genericInvokeResponse1.commonResponse;
                string status = commonResponse.Status;

                MessageType[] messageCollection = commonResponse.MessageCollector;

                StringBuilder message = new StringBuilder();
                foreach (MessageType mType in messageCollection)
                {
                    message.AppendLine(mType.Message);
                }


                /*--
                //Status                
                if (ResponEstatus.OK.Equals(status))
                {
                    String msg = String.Format("La Unidad {0} Aplico {1} Correctamente", UnitNbr, Action);
                    //
                    rs = String.Format("OK|{0}", msg);
                    //
                    //executeTransaction(UnitNbr, Action, Nota, "COMPLETADO", "OK", msg);
                }
                else if (ResponEstatus.INFO.Equals(status))
                {
                    rs = String.Format("INFO|{0}", message.ToString());
                    //
                    //executeTransaction(UnitNbr, Action, Nota, "PENDIENTE", "INFO", message.ToString());
                }
                else if (ResponEstatus.WARNINGS.Equals(status))
                {
                    rs = String.Format("WARNINGS|{0}", message.ToString());
                    //
                    //executeTransaction(UnitNbr, Action, Nota, "PENDIENTE", "WARNINGS", message.ToString());
                }
                else if (ResponEstatus.ERRORS.Equals(status))
                {
                    rs = String.Format("ERRROS|{0}", message.ToString());
                    //
                    //executeTransaction(UnitNbr, Action, Nota, "PENDIENTE", "ERRROS", message.ToString());
                }
                --*/

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return rs;
        }






    }
}