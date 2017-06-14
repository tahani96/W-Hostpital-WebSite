using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Prescription : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\fwfsw\OneDrive\Documents\Visual Studio 2010\WebSites\W-Hostpital-WebSite\App_Data\HospitalDatabase.mdf;Integrated Security=True;User Instance=True");

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void TxtID_TextChanged(object sender, EventArgs e)
    {
        conn.Open();
        SqlDataReader dr;
        SqlCommand SearchResultCmd = new SqlCommand("Select Pat_name from patient WHERE ([Pat_id] = @Pat_id)", conn);
        SearchResultCmd.Parameters.AddWithValue("@Pat_id", TxtID.Text);
        dr = SearchResultCmd.ExecuteReader();
        if (!dr.Read())
        {
            LabelName.Visible = true;
            LabelName.Text = "The ID you Entered is not exist!";
            ClientScript.RegisterStartupScript(this.GetType(), "Error!", "alert('" + "The ID you Entered is not exist!" + "');", true);
            LabelName.Text = "";

            dr.Close();
            conn.Close();
        }
        else
        {
            LabelName.Visible = true;
            LabelName.Text = dr["Pat_name"].ToString();
            dr.Close();
            SearchResultCmd.ExecuteNonQuery();
            conn.Close();
        }

    }
    protected void Btninsert_Click(object sender, EventArgs e)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Prescription VALUES(@Doc_id,@Pat_id,@Date,@Fee)", conn);
        cmd.Parameters.AddWithValue("@Doc_id", DropDownListname.SelectedValue);
        cmd.Parameters.AddWithValue("@Pat_id", TxtID.Text);
        cmd.Parameters.AddWithValue("@Date", TxtDate.Text);
        cmd.Parameters.AddWithValue("@Fee", TxtFee.Text);
        
        Labelmass.Visible = true;
        Labelmass.Text = "Inserted Succeefully";
        ClientScript.RegisterStartupScript(this.GetType(), "inserted Succeefully", "alert('" + "Inserted Succeefully" + "');", true);
        Labelmass.Text = "";
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    public string updatecommand { get; set; }
    protected void Btnupdate_Click(object sender, EventArgs e)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("Update prescription Set Doc_id='" + DropDownListname.SelectedValue + "', Pat_id='" + TxtID.Text + "', Date='" + TxtDate.Text + "', Fee='" + TxtFee.Text + "'WHERE ([Prs_id] = @Prs_id)", conn);
        cmd.Parameters.AddWithValue("@Prs_id", Txtsearch.Text);
        Labelmass.Visible = true;
        Labelmass.Text = "Updated Succeefully";
        ClientScript.RegisterStartupScript(this.GetType(), "Updated secessfully", "alert('" + "Updated secessfully Succeefully" + "');", true);
        Labelmass.Text = "";
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        TxtID.Text = "";
        TxtDate.Text = "";
        TxtFee.Text = "";
        Txtsearch.Text = "";
        DropDownListname.ClearSelection();
    }

    protected void DropDownListname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public string searchcommand { get; set; }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        conn.Open();
        SqlDataReader dr;
        SqlCommand SearchCmd = new SqlCommand("Select * from Prescription WHERE([Prs_id] = @Prs_id)", conn);
        SearchCmd.Parameters.AddWithValue("@Prs_id", Txtsearch.Text);

        dr = SearchCmd.ExecuteReader();
        if (dr.Read())
        {
            TxtID.Text = dr["Pat_id"].ToString();
            TxtDate.Text = dr["Date"].ToString();
            TxtFee.Text = dr["Fee"].ToString();
            DropDownListname.Text = dr["Doc_id"].ToString();
        }
        else
        {
            Labelmass.Visible = true;
            Labelmass.Text = "The ID you Entered is not exist!";
            ClientScript.RegisterStartupScript(this.GetType(), "Error!", "alert('" + "The ID you Entered is not exist!" + "');", true);
            Labelmass.Text = "";
            dr.Close();
            conn.Close();
        }

    }
}
