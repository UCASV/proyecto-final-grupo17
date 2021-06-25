﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalPOOBD.Backend;
using ProyectoFinalPOOBD.VaccineContext;
using ProyectoFinalPOOBD.ViewModel;


namespace ProyectoFinalPOOBD.Backend
{
    public partial class Pruebas : Form
    {
        public Pruebas()
        {
            InitializeComponent();
        }

        private void Pruebas_Load(object sender, EventArgs e)
        {
            label1.Text = Backend.Functions2.OneVaccination().ToString();
        }
    }
    
}