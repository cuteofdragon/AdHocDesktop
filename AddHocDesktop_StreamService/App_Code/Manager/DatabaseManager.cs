using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DatabaseManager
/// </summary>
public class DatabaseManager
{
    public static SqlConnection MemberShip
    {
        get
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MemberShip"].ConnectionString);
        }
    }
}
