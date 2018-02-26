using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace webservice
{
    public class SelectUser
    {
        public class DbConnection
        {
            public MySqlConnection MyConn = new MySqlConnection("Server=localhost;user id=root;password=;database=crudasp;");
            public MySqlCommand MyCommand;
            public MySqlDataReader MyReader;
            public MySqlDataAdapter MyAdapter;
        }
        DbConnection dbConn = new DbConnection();


        public EntityA GetUser(int id)
        {
            EntityA user = null;
            try
            {
                string SQL = string.Empty;
                SQL += "SELECT * FROM employee WHERE ID=" + id;

                dbConn.MyConn.Open();
                using (dbConn.MyCommand = new MySqlCommand(SQL, dbConn.MyConn))
                {
                    using (dbConn.MyReader = dbConn.MyCommand.ExecuteReader())
                    {
                        if (dbConn.MyReader.HasRows)
                        {
                            if (dbConn.MyReader.Read())
                            {
                                user = new EntityA();
                                user.id = Convert.ToInt32(dbConn.MyReader["ID"]);
                                user.FirstName = dbConn.MyReader["FirstName"].ToString();
                                user.LastName = dbConn.MyReader["LastName"].ToString();
                                user.EmailID = dbConn.MyReader["EmailID"].ToString();
                                user.City = dbConn.MyReader["City"].ToString();
                                user.Country = dbConn.MyReader["Country"].ToString();
                              


                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            finally { dbConn.MyConn.Close(); }
            return (user);
        }






    }
}