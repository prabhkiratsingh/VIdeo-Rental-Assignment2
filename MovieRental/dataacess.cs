using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MovieRental2;
namespace MovieRental1
{
    public class customerDal
    {

        //System.Configuration.ConfigurationManager.AppSettings["database"].ToString();

        //static string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Prabh dahbawalia\\Downloads\\VideoRental_V2\\VideoRental.mdf;Integrated Security = True";
        static string sc = "Data Source=LAPTOP-C5LARM44\\SQLEXPRESS.Video Rental.dbo; Initial Catalog=Video Rental; User Id=sa; Password=JaiMahakal1;";
// laptop-c5larm44\sqlexpress.Video Rental.dbo

        public static DataSet GetCustomer()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("GetCustomers", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds, "Customer");
            return ds;
        }
        public static DataSet GetMovie()
        {
           SqlConnection con = new SqlConnection(ConnectionString);
           SqlDataAdapter da = new SqlDataAdapter("GetMovies", con);
           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           da.Fill(ds, "Movies");
           return ds;
        }
        public static DataSet Getrentals()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("Getrentals", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds, "RentedMovies");
            return ds;
        }
       // [GetOutRentals]
        public static DataSet GetOutrentals()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("GetOutRentals", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds, "RentedOutMovies");
            return ds;
        }
        public static Customer GetCustomerID(int CustID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getcustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Custid", CustID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Customer b = new Customer();
                    b.FirstName = dr["FirstName"].ToString();
                    b.LastName = dr["LastName"].ToString();
                    b.Address = dr["Address"].ToString();
                  b.Phone = Double.Parse(dr["Phone"].ToString());
                    return b;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public static Movies Getmovie(int Moviesid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getmovies", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Moviesid", Moviesid);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Movies b = new  Movies();
                    b.Rating = dr["Rating"].ToString();
                    b.Title = dr["Title"].ToString();
                    b.Year = dr["Year"].ToString();
                    b.Rental_Cost = Double.Parse(dr[" Rental_Cost"].ToString());
                    b.copies = dr["copies"].ToString();
                    b.Genre = Double.Parse(dr["Genre"].ToString());
                    return b;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public static RentedMovies Getrental(int RMID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getrental", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rentalid", RMID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    RentedMovies b = new RentedMovies();
                    b.MovieIDFK = dr["MovieIDFK"].ToString();
                    b.CustIDFK = dr["CustIDFK"].ToString();
                    b.DateRented = dr["DateRented"].ToString();
                    b.DateReturned = Double.Parse(dr["DateReturned"].ToString());
                    return b;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }


        // add data 

        public static string Addcustomer(string FirstName, string LastName, string Address, string Phone)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("addcustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.ExecuteNonQuery();
                return null; // success    
            }
            catch (Exception ex)
            {
                return ex.Message; // return error message   
            }
            finally
            {
                con.Close();
            }
        }

        public static string Addmovies(string Rating, string Title, string Year, double Rental_Cost, string copies,string Plot, string Genre)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("addmovies", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rating", Rating);
                cmd.Parameters.AddWithValue("@Title", Title);
                cmd.Parameters.AddWithValue("@Year", Year);
                cmd.Parameters.AddWithValue("@Rental_Cost", Rental_Cost);
                cmd.Parameters.AddWithValue("@Copies", copies);
                cmd.Parameters.AddWithValue("@Genre  ", Genre);
                cmd.Parameters.AddWithValue("@Plot  ", Plot);
                cmd.ExecuteNonQuery();
                return null; // success    
            }
            catch (Exception ex)
            {
                return ex.Message; // return error message   
            }
            finally
            {
                con.Close();
            }
        }


        public static string Addrental(string MovieIDFK, string CustIDFK, DateTime DateRented)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Addrentals", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MovieIDFK ", MovieIDFK);
                cmd.Parameters.AddWithValue("@CustIDFK", CustIDFK);
                cmd.Parameters.AddWithValue("@DateRented", DateRented);
             
                cmd.ExecuteNonQuery();
                return null; // success    
            }
            catch (Exception ex)
            {
                return ex.Message; // return error message   
            }
            finally
            {
                con.Close();
            }
        }


        // delete data

        public static string Deletecustomer(int CustID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustID", CustID);
                cmd.ExecuteNonQuery();
                return null; // success    
            }
            catch (Exception ex)
            {
                return ex.Message; // return error message   
            }
            finally
            {
                con.Close();
            }
        }


        public static string Deletemovie(int MovieID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteMovie", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MovieID", MovieID);
                cmd.ExecuteNonQuery();
                return null; // success    
            }
            catch (Exception ex)
            {
                return ex.Message; // return error message   
            }
            finally
            {
                con.Close();
            }
        }

        public static string Deleterental(int RMID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteRental", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RMID", RMID);
                cmd.ExecuteNonQuery();
                return null; // success    
            }
            catch (Exception ex)
            {
                return ex.Message; // return error message   
            }
            finally
            {
                con.Close();
            }
        }


        //update data 

        public static string Updatecustomer(int CustID, string FirstName, string LastName,string Address,string Phone) 
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updatecustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustId", CustID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.ExecuteNonQuery();
                return null; // success    
            }
            catch (Exception ex)
            {
                return ex.Message; // return error message   
            }
            finally
            {
                con.Close();
            }
        }
        public static string UpdateMovie(int MovieID, string Rating, string Title, string Address, string Year, double Rental_Cost, string copies, string Plot, string Genre)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateMovies", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MovieID", MovieID);
                cmd.Parameters.AddWithValue("@Rating", Rating);
                cmd.Parameters.AddWithValue("@Title ", Title);
                cmd.Parameters.AddWithValue("@Year", Year);
                cmd.Parameters.AddWithValue("@Rental_Cost", Rental_Cost);
                cmd.Parameters.AddWithValue("@Copies", copies);
                cmd.Parameters.AddWithValue("@Plot", Plot);
                cmd.Parameters.AddWithValue("@Genre", Genre);
                cmd.ExecuteNonQuery();
                return null; // success    
            }
            catch (Exception ex)
            {
                return ex.Message; // return error message   
            }
            finally
            {
                con.Close();
            }
        }
        public static string UpdateRentals(int RMID,DateTime returndate)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateRentedMovies", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RMID", RMID);
                cmd.Parameters.AddWithValue("@DateReturned", returndate);
                
                cmd.ExecuteNonQuery();
                return null; // success    
            }
            catch (Exception ex)
            {
                return ex.Message; // return error message   
            }
            finally
            {
                con.Close();
            }
        }


    }
}