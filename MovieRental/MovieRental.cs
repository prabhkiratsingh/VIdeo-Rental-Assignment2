using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MovieRental1;
namespace MovieRental
{
    public partial class MovieRental : Form
    {
        string CustId = "0";
        string MovieId = "0";
        Int16 ReturnMovieId = 0;
        public MovieRental()
        {
            InitializeComponent();
          //  BindData();
        }
       // Bind Data to DataGridView
            private void BindData()
            {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-C5LARM44\\SQLEXPRESS; Initial Catalog=Database; User Id=User; Password=12345;"))
            {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from UserD", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            }
            dataGridView2.DataSource = dt;
            }
            

        private void button9_Click(object sender, EventArgs e)
        {
             //  MovieRental1.customerDal da = new MovieRental1.customerDal();

            dataGridView2.DataSource = MovieRental1.customerDal.GetCustomer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = customerDal.GetMovie().Tables[0];
            dataGridView3.DataSource = customerDal.Getrentals().Tables[0];
            dataGridView1.DataSource = customerDal.GetCustomer().Tables[0];
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnadcustomer_Click(object sender, EventArgs e)
        { 
            try
            {
            customerDal.Addcustomer(txtName.Text, txtLastname.Text, txtAddress.Text, txtPhone.Text);
            dataGridView1.DataSource = customerDal.GetCustomer().Tables[0];
            CustomerTextClean();
             MessageBox.Show("Record Added Successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdatecustomer_Click(object sender, EventArgs e)
        {
            try
            {
                customerDal.Updatecustomer(Convert.ToInt16(CustId), txtName.Text, txtLastname.Text, txtAddress.Text, txtPhone.Text);
                dataGridView1.DataSource = customerDal.GetCustomer().Tables[0];
                CustomerTextClean();
                MessageBox.Show("Record updated Successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void btndeletecustomer_Click(object sender, EventArgs e)
        {
            try
            {
                customerDal.Deletecustomer(Convert.ToInt16(CustId));
                dataGridView1.DataSource = customerDal.GetCustomer().Tables[0];
                CustomerTextClean();
              
                MessageBox.Show("Record Deleted Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnadmovies_Click(object sender, EventArgs e)
        {
            try{
                double rent = 0.00;
                if (Convert.ToInt16(txtreleaseddate.Text)+5 >= DateTime.Now.Year)
                {
                    rent = 5.00;
                }
                else
                {
                    rent = 2.00;
                }

                customerDal.Addmovies(txtRating.Text, txttitle.Text, txtreleaseddate.Text, rent, txtCopy.Text,txtPlot.Text, txtgenere.Text);
            dataGridView2.DataSource = customerDal.GetMovie().Tables[0];
            MovieTextClean();
            MessageBox.Show("Record Added Successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
             {
               
                customerDal.UpdateMovie(Convert.ToInt16(MovieId), txtRating.Text,txttitle.Text, txtAddress.Text,txtreleaseddate.Text, Convert.ToDouble( txtRentleCost.Text), txtCopy.Text,txtPlot.Text, txtgenere.Text);
                dataGridView2.DataSource = customerDal.GetMovie().Tables[0];
                MovieTextClean();
                MessageBox.Show("Record updated Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CustomerTextClean()
        {
            txtName.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private void MovieTextClean()
        {
            txttitle.Text = string.Empty;
            txtRating.Text = string.Empty;
            txtreleaseddate.Text = string.Empty;
            txtRentleCost.Text = string.Empty;
            txtgenere.Text = string.Empty;
            txtCopy.Text = string.Empty;
            txtPlot.Text = string.Empty;
            txtid.Text = string.Empty;
        }

        private void btndeletemovies_Click(object sender, EventArgs e)
        {
            try
            {
                customerDal.Deletemovie(Convert.ToInt16(MovieId));
                dataGridView2.DataSource = customerDal.GetMovie().Tables[0];
                txttitle.Text = string.Empty;
                MovieTextClean();
                MessageBox.Show("Record Deleted Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            txtName.Text = row.Cells[1].Value.ToString();
            txtLastname.Text = row.Cells[2].Value.ToString();
            txtAddress.Text = row.Cells[3].Value.ToString();
            txtPhone.Text = row.Cells[4].Value.ToString();

             CustId = row.Cells[0].Value.ToString();
            

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[rowIndex];
            txtid.Text = MovieId = row.Cells[0].Value.ToString();
            txtRating.Text = row.Cells[1].Value.ToString();


            txttitle.Text = row.Cells[2].Value.ToString();
            txtreleaseddate.Text = row.Cells[3].Value.ToString();
            txtRentleCost.Text = row.Cells[4].Value.ToString();
            txtCopy.Text = row.Cells[5].Value.ToString();
            txtPlot.Text = row.Cells[6].Value.ToString();
            txtgenere.Text = row.Cells[7].Value.ToString();
           
          
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }


        private void btnissuemovies_Click(object sender, EventArgs e)
        {
            try{
            customerDal.Addrental(MovieId,CustId,DateTime.Today);
            dataGridView3.DataSource = customerDal.Getrentals().Tables[0];
           // MovieTextClean();
            MessageBox.Show("Record Added Successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnreturnmovies_Click(object sender, EventArgs e)
        {
            try
            {
                if (ReturnMovieId > 0)
                {
                    customerDal.UpdateRentals(Convert.ToInt16(ReturnMovieId), DateTime.Today.Date);
                    dataGridView3.DataSource = customerDal.Getrentals().Tables[0];
                    MessageBox.Show("Record Updated Successfully!");
                    ReturnMovieId = 0;
                }
                else
                {
                    MessageBox.Show("Please select Record in Movie Rental");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[rowIndex];
            ReturnMovieId = Convert.ToInt16( row.Cells[0].Value.ToString());
          
        }

        private void rbOutRented_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView3.DataSource = customerDal.GetOutrentals().Tables[0];
        }

        private void rbAllRented_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView3.DataSource = customerDal.Getrentals().Tables[0];
        }

    }
}
