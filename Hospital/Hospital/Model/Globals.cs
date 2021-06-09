using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows;

public static class Globals
{
    public static OracleConnection globalConnection = null;

    public static void ThrowException(Exception exp)
    {
        var st = new StackTrace();
        var sf = st.GetFrame(1);
        Trace.WriteLine(sf.GetFileName() + " " + sf.GetMethod().Name + " ERROR: " + exp.ToString());
        globalConnection.Close();
    }
    public static void QuickTrace(string content)
    {
        Trace.WriteLine(content);
    }
    public static void ShowErrorBox(string content)
    {
        MessageBox.Show(content, "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
    }
    public static void ShowInfoBox(string content, string title = "Obaveštenje")
    {
        MessageBox.Show(content, title, MessageBoxButton.OK, MessageBoxImage.Information);
    }

    public static bool made = true;
    public static void SetGlobalConnection()
    {
        if (made)
        {
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            if (globalConnection == null || globalConnection.State == ConnectionState.Closed)
            {
                globalConnection = new OracleConnection(conString);
                try
                {
                    globalConnection.Open();
                }
                catch (Exception exp)
                {
                    ThrowException(exp);
                }
            }
            made = false;
        }
    }
}

