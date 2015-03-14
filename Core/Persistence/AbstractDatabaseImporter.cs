using System;
using System.Collections.Generic;
using System.Data.OleDb;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public abstract class AbstractDatabaseImporter : ISongImporter
    {
        public List<Song> ImportFromFile(String path)
        {
            var list = new List<Song>();

            // Requires Microsoft Access 2010 Runtime
            // See http://www.microsoft.com/en-us/download/details.aspx?id=10910

            var dbProvider = "Microsoft.ACE.OLEDB.12.0";

            var strAccessConn = "Provider=" + dbProvider + ";Data Source=" + path;

            OleDbConnection myAccessConn = null;
            OleDbDataReader aReader = null;

            try
            {
                myAccessConn = new OleDbConnection(strAccessConn);
                myAccessConn.Open();

                var aCommand = new OleDbCommand(getSelectQuery(), myAccessConn);
                aReader = aCommand.ExecuteReader();

                // Iterate throuth the database
                while (aReader.Read())
                {
                    list.Add(readRecord(aReader));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                // Close the reader
                if (aReader != null)
                {
                    aReader.Close();
                }

                // Close the connection Its important.
                if (myAccessConn != null)
                {
                    myAccessConn.Close();
                }
            }

            return list;
        }

        protected abstract Song readRecord(OleDbDataReader aReader);
        protected abstract string getSelectQuery();
    }
}