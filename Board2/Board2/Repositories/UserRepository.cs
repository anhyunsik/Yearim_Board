using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;


namespace Board2.Repositories
{
    public class UserRepository
    {
        // 공통으로 사용될 커넥션 개체
        private SqlConnection con;

        public UserRepository()
        {
            con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        private DataSet GetUserInfoStoreProcedure(string ID2, string password2)
        {
            string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "ahs23", "board_DB", "oh5451", "yearim!!");
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("LoginConfirm", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", ID2);
                cmd.Parameters.AddWithValue("@UserPassword", password2);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }

            return ds;
        }
        public string GetUserId(string ID2, string password2)
        {
            string connectString = string.Format("Server={0};Database={1};Uid ={2};Pwd={3};", "ahs23", "board_DB", "oh5451", "yearim!!");
            string User_Id = string.Empty;
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("LoginConfirm", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", ID2);
                cmd.Parameters.AddWithValue("@UserPassword", password2);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
                DataRow dr = ds.Tables[0].Rows[0];
                User_Id = dr["User_Id"].ToString();

            }

            return User_Id;
        }
        public bool IsCorrectUser(string ID, string password)
        {//로그인 검증
            bool result = false;

            try
            {
                //GetUserInfoStoreProcedure();
                //Console.WriteLine("테스트:" + GetUserInfoStoreProcedure().Tables[0].Rows[0]);


                if (GetUserInfoStoreProcedure(ID, password).Tables[0].Rows.Count > 0)
                {
                    result = true;
                    //return true;
                }
                else
                {
                    result = false;
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return result;
            }
        }
        public int BoardID_param(int board_id)
        {
            int PboardID = board_id;

            return PboardID;
        }
    }
}