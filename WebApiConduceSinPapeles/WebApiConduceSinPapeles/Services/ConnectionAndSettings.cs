using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConduceSinPapeles.Services
{
    public class ConnectionAndSettings
    {
        //
        public static string User { get { return System.Web.Configuration.WebConfigurationManager.AppSettings["User"].ToString(); } }
        //
        public static string Password { get { return System.Web.Configuration.WebConfigurationManager.AppSettings["Password"].ToString(); } }
        //
        public static string ConnectionString { get { return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["N4EDIConnectionString"].ToString(); } }
        //
        public const String CREATE_TRUCK_VISIT = @"<gate>
	                                                <create-truck-visit>
		                                                <gate-id>{0}</gate-id>
		                                                <stage-id>{1}</stage-id>
		                                                <truck license-nbr=""{2}"" trucking-co-id=""{3}""/>
		                                                <driver license-nbr=""{4}""/>
		                                                <truck-visit gos-tv-key=""{5}"" bat-nbr=""{6}""/>
		                                                <timestamp>{7}</timestamp>
	                                                </create-truck-visit>
                                                </gate>";
        //
        public const String SUBMIT_TRANSACTION = @"<gate>
                                                    <submit-transaction>
                                                        <gate-id>{0}</gate-id>
                                                        <stage-id>{1}</stage-id>
                                                        <truck-visit tv-key=""{2}""/>
                                                        <truck-transaction tran-type=""DI"">
                                                            <container eqid = ""{3}"" type=""{4}"" on-chassis-id=""{5}""/>
                                                            <chassis eqid = ""{6}"" type=""{7}""/>
                                                        </truck-transaction>
                                                    </submit-transaction>
                                                </gate>";
        //
        public const String STAGE_DONE = @"<gate>
	                                            <stage-done>
		                                            <gate-id>{0}</gate-id>
		                                            <stage-id>{1}</stage-id>
		                                            <truck-visit tv-key=""{2}"" gos-tv-key=""{3}""/>
	                                            </stage-done>
                                          </gate>";


        
    }
}