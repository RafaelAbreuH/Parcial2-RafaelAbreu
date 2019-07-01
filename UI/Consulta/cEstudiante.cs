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
    public partial class cEstudiante : Form
    {
        public cEstudiante()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Estudiantes>();
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 1:
                        listado = db.GetList(p => true);
                        break;

                    case 2:
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = db.GetList(p => p.EstudianteId == id);
                        break;

                    case 3:
                        listado = db.GetList(p => p.Nombre.Contains(CriteriotextBox.Text));
                        break;

                    case 4:
                        decimal bal = Convert.ToInt32(CriteriotextBox.Text);
                        listado = db.GetList(p => p.Balance == bal);
                        break;
                }
                listado = listado.Where(c => c.FechaIngreso.Date >= DesdedateTimePicker.Value.Date && c.FechaIngreso.Date <= HastadateTimePicker.Value.Date).ToList();
            }

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }
    }
}
