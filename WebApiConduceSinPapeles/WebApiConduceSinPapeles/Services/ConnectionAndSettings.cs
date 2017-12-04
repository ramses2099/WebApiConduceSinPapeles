﻿using System;
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
		                                                <lane-id>{2}</lane-id>
		                                                <truck license-nbr=""{3}"" trucking-co-id=""{4}""/>
		                                                <driver license-nbr=""{5}""/>
		                                                <truck-visit gos-tv-key=""{6}"" bat-nbr=""{7}""/>
		                                                <timestamp>{8}</timestamp>
	                                                </create-truck-visit>
                                                </gate>";
        //
        public const String SUBMIT_TRANSACTION = @"<gate>
                                                    <submit-transaction>
                                                        <gate-id>{0}</gate-id>
                                                        <stage-id>{1}</stage-id>
                                                        <lane-id>{3}</lane-id>
                                                        <truck-visit tv-key=""{4}""/>
                                                        <truck-transaction tran-type=""DI"">
                                                            <container eqid = ""{5}"" type=""{6}"" on-chassis-id=""{7}""/>
                                                            <chassis eqid = ""{8}"" type=""{9}""/>
                                                        </truck-transaction>
                                                    </submit-transaction>
                                                </gate>";
        //
        public const String STAGE_DONE = @"<gate>
	                                            <stage-done>
		                                            <gate-id>{0}</gate-id>
		                                            <stage-id>{1}</stage-id>
		                                            <lane-id>{2}</lane-id>
		                                            <truck-visit gos-tv-key=""{3}"" tv-key=""{4}""/>
	                                            </stage-done>
                                          </gate>";


        
    }
}