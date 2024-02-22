﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
           
          
        }

       

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            ProductoDB oProductoDB = new ProductoDB();
            dtProductos.DataSource = oProductoDB.Get();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            FrmNuevoProducto frm = new FrmNuevoProducto();
            frm.ShowDialog();
            Refresh();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? ID = GetId();
            if (ID != null)
            {
                FrmNuevoProducto frmEdit = new FrmNuevoProducto(ID);
                frmEdit.ShowDialog();
                Refresh();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? ID = GetId();
            try
            {

            
            if (ID != null)
            {
                ProductoDB oProductoDB = new ProductoDB();
                oProductoDB.Delete((int)ID);
                Refresh();
            }

            }
            catch (Exception ex)
            { 
              MessageBox.Show("Ocurrio un error al eliminiar : "+ ex.Message);
            
            }

        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dtProductos.Rows[dtProductos.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch 
            {
                return null;
              }
        }

        
    }
}
