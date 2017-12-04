using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;


namespace WebApiConduceSinPapeles.Services
{
    public class DbServices
    {


        /// <summary>
        /// Save Transaction Log
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="Response"></param>
        /// <param name="Estatus"></param>
        public static void saveTransactionLog(String Request, String Response, String Estatus)
        {

            try
            {

                using (SqlConnection connetion = new SqlConnection(ConnectionAndSettings.ConnectionString))
                {

                    if (connetion.State == System.Data.ConnectionState.Closed)
                    {
                        connetion.Open();
                    }

                    using (SqlCommand _DbCommand = new SqlCommand())
                    {
                        _DbCommand.Connection = connetion;

                        _DbCommand.CommandType = CommandType.StoredProcedure;

                        _DbCommand.CommandText = "dbo.CreateTransaccionWebApiConduceSinPapel";

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Request", SqlDbType = SqlDbType.VarChar, Value = Request });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Response", SqlDbType = SqlDbType.VarChar, Value = Response });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = Estatus });
                                             
                        _DbCommand.ExecuteNonQuery();
                    }

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        



    }
}