using ApiSample.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ApiSample.Entity
{
    public static class SaveData
    {
       
        public static string Save(List<PayloadInfo> lstpayinfo)
        {
            string result = string.Empty;
            string query = string.Empty;
            SqlConnection con = new SqlConnection(GetConString.ConString());
            con.Open();
            SqlTransaction transaction= con.BeginTransaction();
            foreach (PayloadInfo info in lstpayinfo)
            {
                DataInfo dinfo = info.Data;
                query += "INSERT INTO PayLoad(Temperature, Humidity, Occupancy) values ('" + dinfo.Temperature + "','" + dinfo.Humidity + "','" + dinfo.Occupancy + "')";
            }
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Transaction = transaction;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    result = "Success";
                else
                    result = "Fail";               
                transaction.Commit();
                con.Close();
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                con.Close();
                result = ex.Message;
            }
            return result;
        }
    }
}
