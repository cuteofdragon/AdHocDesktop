using System;
using System.Collections.Generic;
using System.Text;

//using MemberShipService = AdHocDesktop.Core.localhost.MemberShipService;
using MemberShipService = AdHocDesktop.Core.server.MemberShipService;

namespace AdHocDesktop.Core
{
    public class WebServiceManager
    {
        static MemberShipService.MemberShipService memberShipService = new MemberShipService.MemberShipService();

        public static MemberShipService.MemberShipService MemberShipService
        {
            get
            {
                return memberShipService;
            }            
        }
    }
}
