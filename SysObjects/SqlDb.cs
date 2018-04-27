using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace JiuQinSys
{
    public interface IDb : IDisposable
    {
        bool HasTransaction { get; }
        void BeginTransaction();
        void Commit();
        void Execute(string query);
        void Execute(DbCommand cmd);
        DataTable ReadDataTable(string query);// params int[] args);
        DataTable ReadDataTable(DbCommand cmd);
        void Update(string query, DataTable dt);
        void Update(DbCommand cmd, DataTable dt);
        DbCommand CreateDbCommand();
        DbParameter CreateDbParameter();

        DbCommand CreateDbCommand(string q);
        DbParameter CreateDbParameter(string n, object v);

        DataTable GetSchemaTable(string tableName);

    }

    public class SqlDb : IDisposable, IDb
    {

        public SqlDb(string cnn)
        {
            _cnn = new SqlConnection();
            _cnn.ConnectionString = cnn;
            _cnn.Open();
        }

        private SqlConnection _cnn;
        public SqlConnection SqlConnection
        {
            get { return _cnn; }
        }


        public bool HasTransaction
        {
            get { return _tran != null; }
        }

        SqlTransaction _tran;

        public void BeginTransaction()
        {
            if (_cnn.State != ConnectionState.Open) _cnn.Open();
            if (_tran == null)
                _tran = _cnn.BeginTransaction();

        }
        public void Commit()
        {
            if (_tran != null)
            {
                _tran.Commit();
                _tran.Dispose();
            }
            _tran = null;
        }
        public void Rollback()
        {
            if (_tran == null)
            {
                _tran.Rollback();
                _tran.Dispose();
            }
            _tran = null;
        }
        public void Execute(StringBuilder query)
        {
            Execute(query.ToString());
        }
        public void Execute(string query)
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                if (_tran != null) cmd.Transaction = _tran;
                cmd.Connection = _cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }

        }


        public void Execute(SqlCommand cmd)
        {

            if (cmd == null)
            {
                throw new ArgumentNullException("cmd");
            }

            if (_tran != null) cmd.Transaction = _tran;
            if (cmd.Connection == null) { cmd.Connection = _cnn; }
            if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
            cmd.ExecuteNonQuery();

        }


        public SqlDataReader Read(SqlCommand cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException("cmd");
            }


            if (_tran != null) cmd.Transaction = _tran;
            if (cmd.Connection == null) { cmd.Connection = _cnn; }
            if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;


        }

        public SqlDataReader Read(string query)
        {

            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Connection = _cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                if (_tran != null) cmd.Transaction = _tran;
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
        }



        public DataSet ReadDataSet(string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, _cnn))
            {
                return ReadDataSet(cmd);
            }

        }

        public DataSet ReadDataSet(string query, string tablename)
        {

            using (SqlCommand cmd = new SqlCommand(query, _cnn))
            {
                return ReadDataSet(cmd, tablename);
            }
        }

        public DataSet ReadDataSet(SqlCommand cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException("cmd");
            }

            if (_tran != null) cmd.Transaction = _tran;
            if (cmd.Connection == null) { cmd.Connection = _cnn; }
            if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                return readDataSet(da, string.Empty);
            }
        }


        public DataSet ReadDataSet(SqlCommand cmd, string tablename)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException("cmd");
            }
            if (tablename == null)
            {
                throw new ArgumentNullException("tablename");
            }

            if (cmd.Connection == null) { cmd.Connection = _cnn; }
            if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
            if (_tran != null) cmd.Transaction = _tran;
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                return readDataSet(da, tablename);

            }
        }

        public DataTable ReadDataTable(SqlCommand cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException("cmd");
            }

            if (cmd.Connection == null) { cmd.Connection = _cnn; }
            if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
            if (_tran != null) cmd.Transaction = _tran;
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable())
                {
                    dt.Locale = CultureInfo.InvariantCulture;
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable ReadDataTable(StringBuilder query)
        {
            using (SqlCommand cmd = new SqlCommand(query.ToString(), _cnn))
            {
                return ReadDataTable(cmd);
            }
        }
        public DataTable ReadDataTable(string query)//, params int[] args)
        {
            using (SqlCommand cmd = new SqlCommand(query, _cnn))
            {
                //if (args.Length > 0) cmd.CommandTimeout = args[0];
                return ReadDataTable(cmd);
            }
        }

        public void Update(SqlCommand cmd, DataTable dt)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException("cmd");
            }
            if (dt == null)
            {
                throw new ArgumentNullException("dt");
            }

            update(cmd, dt);

        }

        public void Update(StringBuilder query, DataTable dt)
        {
            Update(query.ToString(), dt);
        }
        public void Update(string query, DataTable dt)
        {
            using (SqlCommand cmd = new SqlCommand(query, _cnn))
            {
                Update(cmd, dt);
            }
        }


        private void update(SqlCommand cmd, DataTable dt)
        {
            if (cmd.Connection == null) { cmd.Connection = _cnn; }
            if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
            if (_tran != null) cmd.Transaction = _tran;
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                using (SqlCommandBuilder cb = new SqlCommandBuilder(da))
                {
                    da.Update(dt);
                }
            }
        }
        public void InsertInto(string tableName, DataTable dt)
        {
            //                List<string> sql = new List<string>();
            //                sql.Add(string.Format(@"
            //INSERT INTO {0}
            //(
            //
            //", tableName));
            //                List<string> d = new List<string>();
            //                foreach (DataColumn c in dt.Columns)
            //                {
            //                    d.Add(c.ColumnName);
            //                }
            //                sql.Add(string.Format(@"
            //{0}
            //)
            //VALUES
            //", string.Join(",", d.ToArray())));

            //                foreach (DataRow row in dt.Rows)
            //                {
            //                    List<string> v = new List<string>();
            //                    foreach (DataColumn c in dt.Columns)
            //                    {
            //                        if(!row.is
            //                    }


            //                }
            //                Execute(string.Join(" ", sql.ToArray()));

            SqlBulkCopy bulkCopy =
       new SqlBulkCopy
       (_cnn,
       SqlBulkCopyOptions.TableLock |
       SqlBulkCopyOptions.FireTriggers
                //|           SqlBulkCopyOptions.UseInternalTransaction
       ,
       null
       );

            // set the destination table name
            bulkCopy.DestinationTableName = tableName;

            // write the data in the "dataTable"
            bulkCopy.WriteToServer(dt);

        }

        private DataSet readDataSet(SqlDataAdapter da, string tablename)
        {

            using (DataSet ds = new DataSet())
            {
                ds.Locale = CultureInfo.InvariantCulture;

                if (string.IsNullOrEmpty(tablename)) da.Fill(ds);
                else da.Fill(ds, tablename);
                return ds;
            }

        }


        #region Dispose
        private bool disposed;// = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {

            if (!this.disposed)
            {
                if (disposing)
                {
                    if (_cnn != null)
                    {
                        if (_cnn.State != ConnectionState.Closed) _cnn.Close();
                        _cnn.Dispose();
                    }
                    _cnn = null;

                    if (_tran != null) _tran.Dispose();
                    _tran = null;

                }
            }
            disposed = true;
        }
        ~SqlDb()
        {
            Dispose(false);
        }
        #endregion





        #region IDb Members




        #endregion

        #region IDb Members


        public DbCommand CreateDbCommand()
        {
            return new SqlCommand();
        }

        public DbParameter CreateDbParameter()
        {
            return new SqlParameter();
        }

        public DbCommand CreateDbCommand(string q)
        {
            return new SqlCommand(q);
        }
        public DbParameter CreateDbParameter(string n, object v)
        {
            return new SqlParameter(n, v);
        }


        public void Execute(DbCommand cmd)
        {
            Execute(cmd as SqlCommand);
        }
        public DataTable ReadDataTable(DbCommand cmd)
        {
            return ReadDataTable(cmd as SqlCommand);
        }
        public void Update(DbCommand cmd, DataTable dt)
        {
            Update(cmd as SqlCommand, dt);
        }

        #endregion


        public DataTable GetSchemaTable(string tableName)
        {
            using (IDataReader dr = Read(string.Format("select top 1 * from {0}", tableName)))
            {
                return dr.GetSchemaTable();
            }
        }
    }
}
