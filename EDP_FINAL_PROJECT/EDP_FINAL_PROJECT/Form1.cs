using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EDP_FINAL_PROJECT_G3_IT_B
{
    public partial class Form1 : Form
    {

        SqlConnection cs = new SqlConnection("Data Source=DAVID-PC\\SQLEXPRESS;Initial Catalog=edir;Integrated Security=True");
        BindingSource tblNamesBS = new BindingSource();
        BindingSource tblNamesBSS = new BindingSource();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbmembers.Visible = false;
            panel1.Visible = false;
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
          SqlDataAdapter sda = new SqlDataAdapter("Select count(*) From tbladmins where aname=' "+ txtaname.Text+ "' and apass=' "+txtapass.Text+"' ",cs );
           //da.SelectCommand = new SqlCommand("Select count(*) From tbladmins where aname=' " + txtaname.Text + "' and apass=' " + txtapass.Text + "' ", cons);
            DataTable dt = new DataTable();

           sda.Fill(dt);
           //tblNamesBS.DataSource = ds.Tables[0][0];
            ds.ToString();
            if(dt.Rows[0][0].ToString() == "1")
            {
               
                MessageBox.Show("error!!!!cheack your username and password");

            }

            else
                 {

                     panel1.Visible = true;
                     tbmembers.Visible = true;
                     MessageBox.Show("login succesful!");

                  
                 }
          
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            tblNamesBS.MoveLast();
            dgupdate();
        }

        private void dgupdatea()
        {
            dgg.ClearSelection();
            dgg.Rows[tblNamesBSS.Position].Selected = true;

        }


        private void dgupdate()
        {
            dg.ClearSelection();
            dg.Rows[tblNamesBS.Position].Selected = true;

        }



        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void tpadmin_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            tbmembers.Visible = false;
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            //cs.Open();
            //MessageBox.Show(cs.State.ToString());
            //cs.Close();
            try
            {
                da.InsertCommand = new SqlCommand("INSERT INTO tblmembers VALUES (@fname,@lname,@id,@nationality,@fsize,@housenum)", cs);
                da.InsertCommand.Parameters.Add("@fname", SqlDbType.VarChar).Value = txtffname.Text;
                da.InsertCommand.Parameters.Add("@lname", SqlDbType.VarChar).Value = txtllname.Text;
                da.InsertCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = txtiid.Text;
                da.InsertCommand.Parameters.Add("@nationality", SqlDbType.VarChar).Value = txtnat.Text;
                da.InsertCommand.Parameters.Add("@fsize", SqlDbType.VarChar).Value = txtfsize.Text;
                da.InsertCommand.Parameters.Add("@housenum", SqlDbType.VarChar).Value = txthnum.Text;
                cs.Open();
                da.InsertCommand.ExecuteNonQuery();
                cs.Close();
                txtffname.Text = " ";
                txtllname.Text = " ";
                txtiid.Text = " ";
                txtnat.Text = " ";
                txtfsize.Text = " ";
                txtfsize.Text = " ";
                txthnum.Text = " ";
                MessageBox.Show("member added succesfully");
            }
            catch
            {
                MessageBox.Show("error please try to input corect data");
            }

           

        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                da.SelectCommand = new SqlCommand("SELECT * FROM tblmembers", cs);
                ds.Clear();
                da.Fill(ds);
                dg.DataSource = ds.Tables[0];
                tblNamesBS.DataSource = ds.Tables[0];
                txtffname.DataBindings.Add(new Binding("Text", tblNamesBS, "fname"));
                txtllname.DataBindings.Add(new Binding("Text", tblNamesBS, "lname"));
                txtiid.DataBindings.Add(new Binding("Text", tblNamesBS, "id"));
                txtnat.DataBindings.Add(new Binding("Text", tblNamesBS, "nationality"));
                txtfsize.DataBindings.Add(new Binding("Text", tblNamesBS, "fsize"));
                txthnum.DataBindings.Add(new Binding("Text", tblNamesBS, "housenum"));
               
            }
            catch
            {
                MessageBox.Show("error ocured while retriving data");
            }
        }

        private void btnmfirst_Click(object sender, EventArgs e)
        {
            tblNamesBS.MoveFirst();
            dgupdate();
        }

        private void btnmprevious_Click(object sender, EventArgs e)
        {
            tblNamesBS.MovePrevious();
            dgupdate();
        }

        private void btnmnext_Click(object sender, EventArgs e)
        {
            tblNamesBS.MoveNext();
            dgupdate();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                int x;
                da.UpdateCommand = new SqlCommand("UPDATE tblmembers SET fname=@fname,lname=@lname,nationality=@nationality,fsize=@fsize,housenum=@housenum WHERE id=@id", cs);
                da.UpdateCommand.Parameters.Add("@fname", SqlDbType.VarChar).Value = txtffname.Text;
                da.UpdateCommand.Parameters.Add("@lname", SqlDbType.VarChar).Value = txtllname.Text;

                da.UpdateCommand.Parameters.Add("@nationality", SqlDbType.VarChar).Value = txtnat.Text;
                da.UpdateCommand.Parameters.Add("@fsize", SqlDbType.VarChar).Value = txtfsize.Text;
                da.UpdateCommand.Parameters.Add("@housenum", SqlDbType.VarChar).Value = txthnum.Text;
                da.UpdateCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = txtiid.Text;
                cs.Open();


                x = da.UpdateCommand.ExecuteNonQuery();
                cs.Close();
                if (x >= 1)
                {
                    MessageBox.Show("Record updated");
                }
                else
                {
                    MessageBox.Show("No record has been updated");
                }
                ds.Clear();
            }
            catch
            {
                MessageBox.Show("error ocured cannot update the value");
            }
            }
       

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogr;
            dialogr = MessageBox.Show("Are you sure you want to Delete the date?\nthere is no option to undo the deletion process", "Deletion confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogr == DialogResult.Yes)
            {
                da.DeleteCommand = new SqlCommand("DELETE FROM tblmembers WHERE ID=@id", cs);
                da.DeleteCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = txtiid.Text;
                cs.Open();
                da.DeleteCommand.ExecuteNonQuery();
                cs.Close();
                ds.Clear();
                da.Fill(ds);
             
            }
            else
            {
                MessageBox.Show("Recored deletion has been canceled");
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
           
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtffname.Clear();
            txtiid.Clear();
            txtllname.Clear();
            ds.Clear();
            txtnat.Clear();
            txtfsize.Clear();
            txtfsize.Clear();
            txthnum.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int x;
                da.UpdateCommand = new SqlCommand("UPDATE tbladmins SET apass=@apass WHERE aname=@aname", cs);
                da.UpdateCommand.Parameters.Add("@apass", SqlDbType.VarChar).Value = textBox9.Text;
                da.UpdateCommand.Parameters.Add("@aname", SqlDbType.VarChar).Value = textBox11.Text;
                cs.Open();


                x = da.UpdateCommand.ExecuteNonQuery();
                cs.Close();
                if (x >= 1)
                {
                    MessageBox.Show("password changed succesfullly");
                    textBox11.Text=" ";
                    textBox9.Text=" ";
                    textBox1.Text=" ";

                }
                else
                {
                    MessageBox.Show("pasword is not changed");
                }
                ds.Clear();
            }
            catch
            {
                MessageBox.Show("error ocured pasword is not changed");
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void pg_Click(object sender, EventArgs e)
        {

        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            //cs.Open();
            //MessageBox.Show(cs.State.ToString());
            //cs.Close();
            try
            {
                da.InsertCommand = new SqlCommand("INSERT INTO tblmaterials VALUES (@mname,@mamount,@mquality,@mfacilitator,@mpurchaser,@mplace)", cs);
                da.InsertCommand.Parameters.Add("@mname", SqlDbType.VarChar).Value = txtmname.Text;
                da.InsertCommand.Parameters.Add("@mamount", SqlDbType.VarChar).Value =txtmamounts.Text;
                da.InsertCommand.Parameters.Add("@mquality", SqlDbType.VarChar).Value = txtmquality.Text;
                da.InsertCommand.Parameters.Add("@mfacilitator", SqlDbType.VarChar).Value = txtmfacilitator.Text;
                da.InsertCommand.Parameters.Add("@mpurchaser", SqlDbType.VarChar).Value = txtmpurchaser.Text;
                da.InsertCommand.Parameters.Add("@mplace", SqlDbType.VarChar).Value = txtmplace.Text;
                cs.Open();
                da.InsertCommand.ExecuteNonQuery();
                cs.Close();
                txtmname.Text = " ";
                txtmamounts.Text= " ";
                txtmquality.Text = " ";
                txtmfacilitator.Text = " ";
                txtmpurchaser.Text = " ";
                txtmplace.Text = " ";
               
                MessageBox.Show("material added succesfully");
            }
            catch
            {
                MessageBox.Show("error please try to input corect data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                da.SelectCommand = new SqlCommand("SELECT * FROM tblmaterials", cs);
                ds.Clear();
                da.Fill(ds);
                dgg.DataSource = ds.Tables[0];
                tblNamesBSS.DataSource = ds.Tables[0];
                txtmname.DataBindings.Add(new Binding("Text", tblNamesBSS, "mname"));
                txtmamounts.DataBindings.Add(new Binding("Text", tblNamesBSS, "mamount"));
                txtmquality.DataBindings.Add(new Binding("Text", tblNamesBSS, "mquality"));
                txtmfacilitator.DataBindings.Add(new Binding("Text", tblNamesBSS, "mfacilitator"));
                txtmpurchaser.DataBindings.Add(new Binding("Text", tblNamesBSS, "mpurchaser"));
                txtmplace.DataBindings.Add(new Binding("Text", tblNamesBSS, "mplace"));

            }
            catch
            {
                MessageBox.Show("error ocured while retriving data");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tblNamesBSS.MoveFirst();
            dgupdatea();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tblNamesBSS.MovePrevious();
            dgupdatea();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tblNamesBSS.MoveNext();
            dgupdatea();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tblNamesBSS.MoveLast();
            dgupdatea();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {
                int x;
                da.UpdateCommand = new SqlCommand("UPDATE tblmaterials SET mamount=@mamount,mquality=@mquality,mfacilitator=@mfacilitator,mplace=@mplace,mpurchaser=@mpurchaser WHERE mname=@mname", cs);
                da.UpdateCommand.Parameters.Add("@mname", SqlDbType.VarChar).Value = txtmname.Text;
                da.UpdateCommand.Parameters.Add("@mamount", SqlDbType.VarChar).Value = txtmamounts.Text;

                da.UpdateCommand.Parameters.Add("@mquality", SqlDbType.VarChar).Value = txtmquality.Text;
                da.UpdateCommand.Parameters.Add("@mfacilitator", SqlDbType.VarChar).Value = txtmfacilitator.Text;
                da.UpdateCommand.Parameters.Add("@mpurchaser", SqlDbType.VarChar).Value = txtmpurchaser.Text;
                da.UpdateCommand.Parameters.Add("@mplace", SqlDbType.VarChar).Value = txtmplace.Text;
                cs.Open();


                x = da.UpdateCommand.ExecuteNonQuery();
                cs.Close();
                if (x >= 1)
                {
                    MessageBox.Show("Record updated");
                }
                else
                {
                    MessageBox.Show("No record has been updated");
                }
                ds.Clear();
            }
            catch
            {
                MessageBox.Show("error ocured cannot update the value");
            }
        }

        private void btnmclear_Click(object sender, EventArgs e)
        {
            txtmname.Clear();
            txtmamounts.Clear();
            txtmquality.Clear();
            ds.Clear();
            txtmfacilitator.Clear();
            txtmpurchaser.Clear();
            txtmplace.Clear();
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DAVID-PC\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            BindingSource tblNamesBS = new BindingSource();
            BindingSource tblNamesBSS = new BindingSource();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();


            //cs.Open();
            //MessageBox.Show(cs.State.ToString());
            //cs.Close();
            try
            {
                da.InsertCommand = new SqlCommand("INSERT INTO tblp VALUES (@fname,@lname,@id,@amount,@month)", con);
                da.InsertCommand.Parameters.Add("@fname", SqlDbType.VarChar).Value = txtfname.Text;
                da.InsertCommand.Parameters.Add("@lname", SqlDbType.VarChar).Value = txtlname.Text;
                da.InsertCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = txtid.Text;
                da.InsertCommand.Parameters.Add("@amount", SqlDbType.VarChar).Value = txtamount.Text;
                da.InsertCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = txtmonth.Text;

                con.Open();
                da.InsertCommand.ExecuteNonQuery();
                con.Close();
                txtfname.Text = " ";
                txtlname.Text = " ";
                txtid.Text = " ";
                txtamount.Text = " ";
                txtmonth.Text = " ";
               
                MessageBox.Show("payment added succesfully");
            }
            catch
            {
                MessageBox.Show("error please try to input corect data");
            }





        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DAVID-PC\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            BindingSource tblNamesBS = new BindingSource();
            BindingSource tblNamesBSS = new BindingSource();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();


            try
            {
                da.SelectCommand = new SqlCommand("SELECT * FROM tblp", con);
                ds.Clear();
                da.Fill(ds);
                dggg.DataSource = ds.Tables[0];
                tblNamesBS.DataSource = ds.Tables[0];
                txtfname.DataBindings.Add(new Binding("Text", tblNamesBS, "fname"));
                txtlname.DataBindings.Add(new Binding("Text", tblNamesBS, "lname"));
                txtid.DataBindings.Add(new Binding("Text", tblNamesBS, "id"));
                txtamount.DataBindings.Add(new Binding("Text", tblNamesBS, "amount"));
                txtmonth.DataBindings.Add(new Binding("Text", tblNamesBS, "month"));
                

            }
            catch
            {
                MessageBox.Show("error ocured while retriving data");
            }





        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
           
    }
}
