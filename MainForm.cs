﻿using Parcial2_RafaelAbreu.UI.Consulta;
using Parcial2_RafaelAbreu.UI.Resgistros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2_RafaelAbreu
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void AsignaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rAsignaturas ver = new rAsignaturas();
            ver.MdiParent = this;
            ver.Show();
        }

        private void EstudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEstudiantes ver = new rEstudiantes();
            ver.MdiParent = this;
            ver.Show();
        }

        private void InscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rInscripcion ver = new rInscripcion();
            ver.MdiParent = this;
            ver.Show();
        }

        private void AsignaturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cAsignatura ver = new cAsignatura();
            ver.MdiParent = this;
            ver.Show();
        }

        private void Estudi9an9te7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cEstudiante ver = new cEstudiante();
            ver.MdiParent = this;
            ver.Show();
        }

        private void InscripcionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cInscripcion ver = new cInscripcion();
            ver.MdiParent = this;
            ver.Show();
        }
    }
}
