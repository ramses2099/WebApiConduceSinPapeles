﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiConduceSinPapeles.ArgoBasicService;
using System.Net;


namespace WebApiConduceSinPapeles.Services
{
    public class ExtendedGenericWebservice : ArgoService
    {

        private String _headerName;
        private String _headerValue;
        //
        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest req = (HttpWebRequest)base.GetWebRequest(uri);
            if (null != _headerName)
            {
                req.Headers.Add(_headerName, _headerValue);
            }
            return (WebRequest)req;

        }
        //
        public void SetRequestHeader(String headerName, String headerValue)
        {

            this._headerName = headerName;
            this._headerValue = headerValue;
        }
    }


}