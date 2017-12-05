using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiConduceSinPapeles.ArgoBasicService;
using System.Text;
using System.Xml;
using Newtonsoft.Json;

namespace WebApiConduceSinPapeles.Services
{
    public class NavisConnect
    {
        /// <summary>
        /// Constructor Navis Connect
        /// </summary>
        public NavisConnect() { }

        /// <summary>
        /// CREATE TRUCK VISIT
        /// </summary>
        /// <param name="GateId"></param>
        /// <param name="StageId"></param>
        /// <param name="LaneId"></param>
        /// <param name="TruckingLicenseNbr"></param>
        /// <param name="TruckingCoId"></param>
        /// <param name="DriveLicenseNbr"></param>
        /// <param name="GosTvKey"></param>
        /// <param name="BatNbr"></param>
        /// <param name="TimesTamp"></param>
        /// <returns>String Truck Visit Id</returns>
        public string executeGenericInvokeCREATE_TRUCK_VISIT(String GateId, String StageId, String LaneId, String TruckingLicenseNbr, String TruckingCoId, String DriveLicenseNbr, String GosTvKey, String BatNbr, String TimesTamp)
        {

            string myXml = string.Format(ConnectionAndSettings.CREATE_TRUCK_VISIT, GateId, StageId, LaneId, TruckingLicenseNbr, TruckingCoId, DriveLicenseNbr, GosTvKey, BatNbr, TimesTamp);
            String Request = string.Format("GateId:{0},StageId:{1},LaneId:{2},TruckingLicenseNbr:{3},TruckingCoId:{4},DriveLicenseNbr:{5},GosTvKey:{6},BatNbr:{7},TimesTamp:{8}", GateId, StageId, LaneId, TruckingLicenseNbr, TruckingCoId, DriveLicenseNbr, GosTvKey, BatNbr, TimesTamp);
            String Response = string.Empty;
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

                // To convert an XML node contained in string xml into a JSON string   
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(response.genericInvokeResponse1.commonResponse.QueryResults[0].Result);
                
                Response = JsonConvert.SerializeXmlNode(doc);
                
                //XmlNodeList elemList = doc.GetElementsByTagName("truck-visit");

                //string value = elemList[0].InnerXml;

                String TvKey = doc.GetElementsByTagName("truck-visit").Item(0).Attributes["tv-key"].Value;
              
                string msg = string.Empty;

                //Status                
                if (ResponEstatus.OK.Equals(status))
                {
                    rs = String.Format("OK|{0}", TvKey);

                    DbServices.saveTransactionLog(Request, Response, "OK");                    
                }
                else if (ResponEstatus.INFO.Equals(status))
                {
                    rs = String.Format("INFO|{0}", message.ToString());
                    //
                    DbServices.saveTransactionLog(Request, Response, "INFO");
                }
                else if (ResponEstatus.WARNINGS.Equals(status))
                {
                    rs = String.Format("WARNINGS|{0}", message.ToString());
                    //
                    DbServices.saveTransactionLog(Request, Response, "WARNINGS");

                }
                else if (ResponEstatus.ERRORS.Equals(status))
                {
                    rs = String.Format("ERRROS|{0}", message.ToString());
                    //
                    DbServices.saveTransactionLog(Request, Response, "ERRROS");
                }
                
            }
            catch (Exception ex)
            {
                DbServices.saveTransactionLog(Request, ex.Message, "ERRROS");
            }

            return rs;
        }






    }
}