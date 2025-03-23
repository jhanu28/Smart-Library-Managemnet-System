﻿using smartlibrary.Insert;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace smartlibrary.view
{
    public partial class Rackview : Form
    {
        public Rackview()
        {
            InitializeComponent();
        }
        
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")//Update
            {

                RackInsert frm = new RackInsert();
                String id1 = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvrack"].Value);

                frm.txtRackNo.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvrack"].Value);
                frm.txtCatName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvcategory"].Value);

                string qry = "Delete From rack where rackno = '" + id1 + "' "; 
                Hashtable ht = new Hashtable();
                MainClass.SQl(qry, ht);
                MainClass.BlurBackground(frm);
                GetData();

            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")//Delete
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {
                    String id1 = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvrack"].Value);
                    string qry = "Delete From rack where rackno = '" + id1 + "' ";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                    guna2MessageDialog1.Show("Detete Successfull");
                    GetData();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new RackInsert());
            GetData();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new RackInsert());
            GetData();
        }
       
        public void GetData()
        {
            string qry = "Select * From rack where category like '%" + txtSearch.Text + "%'    ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvrack);
            lb.Items.Add(dgvcategory);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void Rackview_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
