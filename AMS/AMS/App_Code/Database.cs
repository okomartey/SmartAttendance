using System;
using System.Web.Configuration;


public class Database
{
    public static string ConnectionString
    {
        get
        {
            return WebConfigurationManager.ConnectionStrings["attendance"].ConnectionString;
        }
	}
}
