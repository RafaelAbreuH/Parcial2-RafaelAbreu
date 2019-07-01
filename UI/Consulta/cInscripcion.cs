using Parcial2_RafaelAbreu.BLL;
using Parcial2_RafaelAbreu.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2_RafaelAbreu.UI.Consulta
{
    public partial class cInscripcion : Form
    {
        public cInscripcion()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Inscripcion>();
            RepositorioBase<Inscripcion> db = new RepositorioBase<Inscripcion>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 1:
                        listado = db.GetList(p => true);
                        break;

                    case 2:
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = db.GetList(p => p.InscripcionId == id);
                        break;

                    case 3:
                        int est = Convert.ToInt32(CriteriotextBox.Text);
                        listado = db.GetList(p => p.EstudianteId == est);
                        break;

                    case 4:
                        decimal monto = Convert.ToInt32(CriteriotextBox.Text);
                        listado = db.GetList(p => p.Monto == monto);
                        break;

                }
                listado = listado.Where(c => c.Fecha.Date >= DesdedateTimePicker.Value.Date && c.Fecha.Date <= HastadateTimePicker.Value.Date).ToList();
            }
            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }
    }
}

