﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Models.BO;
using AerolineaFrba.Models.DAO;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class BajaAeronaveD : Form
    {

        private DAOServicio daoPais = new DAOServicio();
        private DAOVuelo daoVuelo = new DAOVuelo();



        private Aeronave aeronave { get; set; }
        private bool update;
        private List<Vuelo> lstVuelo { get; set; }
        private Vuelo vuelo { get; set; }



        public BajaAeronaveD(Aeronave aer)
        {
            aeronave = aer;
            InitializeComponent();
            lstVuelo = new List<Vuelo>();

        }


        private void FormBajaDefinitiva_Load(object sender, EventArgs e)
        {
            cargarCombos();
            if (aeronave.matricula != null)
            {
                txtmatricula.Enabled = false;
                update = true;
                cargarDatosClientes();                
               
           }

            cargarGrilla();
            actualizarGrilla();
        }

        private void cargarDatosClientes()
        {
            txtmatricula.Text = aeronave.matricula;

            txtModelo.Text = aeronave.modelo;

            txtFabri.Text = aeronave.fabricante;

            txtPeso.Text = aeronave.peso_disponible.ToString();

            string serv = (string)aeronave.get_service();
            cmbServicio.SelectedIndex = cmbServicio.FindStringExact(serv);


            //dateBaja.Value = (DateTime)aeronave.fecha_alta;

            /*txtPiso.Text = cliente.dom_piso.ToString();
            txtMail.Text = cliente.mail;
            txtNumero.Text = cliente.dom_nro.ToString();
            txtNumID.Text = cliente.documento.ToString();
            dateNacimiento.Value = (DateTime)cliente.fecha_nac;

            string pa = (string)cliente.get_pais().Substring(1);
            cbNacionalidad.SelectedIndex = cbNacionalidad.FindStringExact(pa);

            string tip = ((TipoDocumento)daoTipoDoc.retrieveBy_id(cliente.tipo_documento)).descripcion;
            cmbTipo.SelectedIndex = cmbTipo.FindStringExact(tip);
            checkActivo.Checked = (bool)cliente.activo;*/
        }

        private void cargarCombos()
        {
            cmbServicio.Items.AddRange(daoPais.retrieveBase().ToArray());

        }

        private void cargarGrilla()
        {
            DataGridViewTextBoxColumn colAeronave = new DataGridViewTextBoxColumn();
            colAeronave.DataPropertyName = "aeronave";
            colAeronave.HeaderText = "Aeronave";
            colAeronave.Width = 120;
            DataGridViewTextBoxColumn colRuta = new DataGridViewTextBoxColumn();
            colRuta.DataPropertyName = "ruta";
            colRuta.HeaderText = "Ruta";
            colRuta.Width = 120;

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.DataPropertyName = "id";
            colID.HeaderText = "Vuelo ID";
            colID.Width = 120;

            dtgVuelos.Columns.Add(colID);
            dtgVuelos.Columns.Add(colAeronave);
            dtgVuelos.Columns.Add(colRuta);
            
        }

        public void actualizarGrilla()
        {
            if (txtmatricula.Text != "")
                lstVuelo = daoVuelo.search(txtmatricula.Text);
           // else
            //    lstAeronaves = dao.retrieveAll();
            //Vuelo vuelo = new Vuelo();
            //vuelo = lstVuelo[0];
            dtgVuelos.DataSource = lstVuelo;
        }


    }
}
