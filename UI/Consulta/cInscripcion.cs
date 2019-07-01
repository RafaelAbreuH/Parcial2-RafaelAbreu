using Parcial2_RafaelAbreu.BLL;
using Parcial2_RafaelAbreu.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2_RafaelAbreu.UI.Consulta
{
    public partial class cInscripcion : Form
    {
        Expression<Func<Inscripcion, bool>> filtro = x => true;
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
                    case 0:
                        filtro = (p => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        filtro = (p => p.InscripcionId == id);
                        break;

                    case 2:
                        int est = Convert.ToInt32(CriteriotextBox.Text);
                        filtro=(p => p.EstudianteId == est);
                        break;

                    case 3:
                        decimal monto = Convert.ToInt32(CriteriotextBox.Text);
                        filtro= (p => p.Monto == monto);
                        break;

                }
                //listado = listado.Where(c => c.Fecha.Date >= DesdedateTimePicker.Value.Date && c.Fecha.Date <= HastadateTimePicker.Value.Date).ToList();
            }
            listado = db.GetList(filtro);
            if (FechaCheckBox.Checked == true)
                listado = db.GetList(filtro).Where(x => x.Fecha.Date >= DesdedateTimePicker.Value.Date && x.Fecha.Date <= HastadateTimePicker.Value.Date).ToList();
            else
                listado = db.GetList(filtro);
            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }
        public void soloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {

                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void CriteriotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(FiltrocomboBox.SelectedIndex == 1)
            {
                soloNumeros(e);
            }
        }
    }
}

