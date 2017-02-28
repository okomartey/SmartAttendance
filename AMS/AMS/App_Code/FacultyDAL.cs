using System;
using System.Data;
using System.Data.SqlClient;

public class FacultyDAL
{
    public static string Login(string fcode, string pwd)
    {
        SqlConnection con = new SqlConnection(Database.ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select fname from faculty where fcode = @fcode and pwd = @pwd", con);
            cmd.Parameters.Add("@fcode", SqlDbType.VarChar, 10).Value = fcode;
            cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 10).Value = pwd;
            Object fname = cmd.ExecuteScalar();
            if (fname == null)
                return null;
            else
                return fname.ToString();
        }
        catch (Exception ex)
        {
            return null;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }
    //  returns null on sccess, error message on failure
    public static String ChangePassword(string fcode,string oldpwd, string newpwd)
    {
        SqlConnection con = new SqlConnection(Database.ConnectionString);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update faculty set pwd = @newpwd where fcode = @fcode and pwd = @oldpwd", con);
            cmd.Parameters.Add("@fcode", SqlDbType.VarChar, 10).Value = fcode;
            cmd.Parameters.Add("@oldpwd", SqlDbType.VarChar, 10).Value = oldpwd;
            cmd.Parameters.Add("@newpwd", SqlDbType.VarChar, 10).Value = newpwd;
            int rows = cmd.ExecuteNonQuery();
            if (rows == 1)
                return null; // success
            else
                return "Sorry! Invalid Old Password";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }
}
