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
        /// 
        /// </summary>
        ///
        
        private void executeTransaction(String UnitNbr, String Action, String Nota, String Estatus, String EstatusNavis, String MensajeeNavis)
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

                        _DbCommand.CommandText = "[dbo].[CreateTransaccionWebApiHPUDPH]";

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@UnitNbr", SqlDbType = SqlDbType.VarChar, Value = UnitNbr });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Action", SqlDbType = SqlDbType.VarChar, Value = Action });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Nota", SqlDbType = SqlDbType.VarChar, Value = Nota });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = Estatus });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@EstatusNavis", SqlDbType = SqlDbType.VarChar, Value = EstatusNavis });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@MensajeeNavis", SqlDbType = SqlDbType.VarChar, Value = MensajeeNavis });

                        if (Estatus.Equals("COMPLETADO"))
                        {
                            _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@FechaActualizacion", SqlDbType = SqlDbType.DateTime, Value = DateTime.Now });

                        }
                        else
                        {
                            _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@FechaActualizacion", SqlDbType = SqlDbType.DateTime, Value = DBNull.Value });

                        }

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