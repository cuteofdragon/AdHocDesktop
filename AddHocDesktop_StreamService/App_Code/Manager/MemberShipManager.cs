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
public class MemberShipManager
{
    public static bool LoginUser(string id, string pw)
    {
        using (SqlConnection connection = DatabaseManager.MemberShip)
        {
            using (SqlCommand command = new SqlCommand("LoginUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AccountID", id));
                command.Parameters.Add(new SqlParameter("@AccountPW", pw));
                connection.Open();
                object obj = command.ExecuteScalar();
                
                return obj != null;
            }
        }
    }
}
