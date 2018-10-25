using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using AdHocDesktop.Core;

[WebService(Namespace = "http://www.cte.cju.edu.tw/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class MemberShipService : System.Web.Services.WebService
{
    static AdHocDesktop_SortedDictionary userTable = new AdHocDesktop_SortedDictionary();

    public MemberShipService()
    {        
        //InitializeComponent();         
    }

    [WebMethod]
    public bool LoginUser(string identifier, string id, string pw)
    {
        if (MemberShipManager.LoginUser(id, pw))
        {
            userTable[id] = identifier;
            return true;
        }
        else
        {
            return false;
        }
    }

    [WebMethod]
    public bool LogoutUser(string id)
    {
        if (userTable.ContainsKey(id))
        {
            userTable.Remove(id);
            return true;
        }
        else
        {
            return true;
        }
    }

    [WebMethod]
    public AdHocDesktop_SortedDictionary GetUsers()
    {
        return userTable;
    }

    [WebMethod]
    public bool IsExistUser(string id)
    {
        return userTable.ContainsKey(id);
    }
    
}
