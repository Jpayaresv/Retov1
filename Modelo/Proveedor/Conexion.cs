using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Proveedor
{
    public class Conexion
    {
        private string _connectionString;
        private string _provider;
        public IDbConnection ObjConn { get; set; }

        public string sQuery;
        public Conexion()
        {
        }

        public Conexion(string connectionString, string provider)
        {
            _connectionString = connectionString;
            _provider = provider;
        }
        // Only inherited classes can call this.
        public IDbConnection GetOpenConnection()
        {
            if (_provider.Equals("Npgsql"))
                ObjConn = new NpgsqlConnection(_connectionString);
            else
                ObjConn = new NpgsqlConnection(_connectionString);
            ObjConn.Open();
            return ObjConn;
        }
        public bool Actualizar(string strTabla, string strCampo, string strCondicion)
        {
            if (string.IsNullOrEmpty(strCondicion))
                return false;
            else
                sQuery = "UPDATE " + strTabla + " SET " + strCampo + " WHERE " + strCondicion + "";

            return ObjConn.Execute(sQuery) > 0;
        }
        public bool ExistenRegistros(string strTabla, string strCampo, string strCondicion)
        {
            if (string.IsNullOrEmpty(strCondicion))
                sQuery = "SELECT " + strCampo + " FROM " + strTabla + "";
            else
                sQuery = "SELECT " + strCampo + " FROM " + strTabla + " WHERE " + strCondicion + "";

            return ObjConn.Query(sQuery).Any();

        }
        public DateTime CargarCampoDatetime(string strTabla, string strCampo, string strCondicion)
        {
            if (string.IsNullOrEmpty(strCondicion))
                sQuery = "SELECT " + strCampo + " FROM " + strTabla + "";
            else
                sQuery = "SELECT " + strCampo + " FROM " + strTabla + " WHERE " + strCondicion + "";

            var resul = ObjConn.Query<DateTime?>(sQuery).FirstOrDefault();
            if (resul == null)
                resul = DateTime.Now;
            return (DateTime)resul;
        }

        public string CargarCampoStr(string strTabla, string strCampo, string strCondicion)
        {
            if (string.IsNullOrEmpty(strCondicion))
                sQuery = "SELECT " + strCampo + " FROM " + strTabla + "";
            else
                sQuery = "SELECT " + strCampo + " FROM " + strTabla + " WHERE " + strCondicion + "";

            return ObjConn.Query<string>(sQuery).FirstOrDefault();
        }
        public int CargarCampoInt(string strTabla, string strCampo, string strCondicion)
        {
            if (string.IsNullOrEmpty(strCondicion))
                sQuery = "SELECT " + strCampo + " FROM " + strTabla + "";
            else
                sQuery = "SELECT " + strCampo + " FROM " + strTabla + " WHERE " + strCondicion + "";

            if (!int.TryParse(ObjConn.Query<string>(sQuery).FirstOrDefault(), out int resul))
                resul = 0;

            return resul;
        }
        public double CargarCampoDbl(string strTabla, string strCampo, string strCondicion)
        {
            if (string.IsNullOrEmpty(strCondicion))
                sQuery = "SELECT " + strCampo + " FROM " + strTabla + "";
            else
                sQuery = "SELECT " + strCampo + " FROM " + strTabla + " WHERE " + strCondicion + "";

            if (!double.TryParse(ObjConn.Query<string>(sQuery).FirstOrDefault(), out double resul))
                resul = 0;
            return resul;
        }
        public long CargarCampoLng(string strTabla, string strCampo, string strCondicion)
        {
            if (string.IsNullOrEmpty(strCondicion))
                sQuery = "SELECT " + strCampo + " FROM " + strTabla + "";
            else
                sQuery = "SELECT " + strCampo + " FROM " + strTabla + " WHERE " + strCondicion + "";

            if (!long.TryParse(ObjConn.Query<string>(sQuery).FirstOrDefault(), out long resul))
                resul = 0;
            return resul;
        }
        public bool CreateTable(string tablename, string newtablename)
        {
            var sQueryl = "select case when exists((select 1 from information_schema.tables where table_name = '" + newtablename + "')) then 1 else 0 end as value";
            if (ObjConn.Query<int>(sQueryl).FirstOrDefault() == 0)
            {
                try
                {

                    sQueryl = "CREATE TABLE " + newtablename + " (LIKE " + tablename + " INCLUDING ALL  )";
                    ObjConn.Execute(sQueryl);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
        public bool ExisteTabla(string strTableName)
        {
            string sQueryl;
            bool exists;
            try
            {
                // ANSI SQL way.  Works in PostgreSQL, MSSQL, MySQL.  
                sQueryl = "select case when exists((select 1 from information_schema.tables where table_name = '" + strTableName + "')) then 1 else 0 end";
                exists = ObjConn.Query<int>(sQueryl).FirstOrDefault() == 1;
            }
            catch
            {
                try
                {
                    // Other RDBMS.  Graceful degradation
                    exists = true;
                    sQueryl = "select 1 from " + strTableName + " where 1 = 0";
                    exists = ObjConn.Query<int>(sQueryl).FirstOrDefault() == 1;
                }
                catch
                {
                    exists = false;
                }
            }
            return exists;
        }
        public bool EjecutarConsulta(string Query)
        {
            return ObjConn.Execute(Query) > 0;
        }
        public bool ExisteColumna(string strTableName, string strColumnName)
        {
            bool exists;
            try
            {
                // ANSI SQL way.  Works in PostgreSQL, MSSQL, MySQL.  
                sQuery = "select case when exists((select * from information_schema.columns where table_name = '" + strTableName + "' and column_name = '" + strColumnName + "')) then 1 else 0 end";
                exists = ObjConn.Query<int>(sQuery).FirstOrDefault() == 1;
            }
            catch
            {
                try
                {
                    // Other RDBMS.  Graceful degradation
                    exists = true;
                    sQuery = "select " + strColumnName + " from " + strTableName + " where 1 = 0";
                    exists = ObjConn.Query<int>(sQuery).FirstOrDefault() == 1;
                }
                catch
                {
                    exists = false;
                }
            }
            return exists;
        }

        public int TraerConsecutivo(string strTabla)
        {
            if (!ExistenRegistros("adconsecutivos", "valor", " codigo = 'tbl_con" + strTabla + "'"))
            {
                sQuery = "INSERT INTO adconsecutivos (codigo, valor) VALUES ('tbl_con" + strTabla + "', 0)";
                ObjConn.Execute(sQuery);
            }
            int valor = CargarCampoInt("adconsecutivos", "valor", "codigo = 'tbl_con" + strTabla + "'") + 1;
            if (Actualizar("adconsecutivos", "valor = " + valor, "codigo = 'tbl_con" + strTabla + "'"))
            {
                return valor;
            }
            return 0;
        }
    }
}
