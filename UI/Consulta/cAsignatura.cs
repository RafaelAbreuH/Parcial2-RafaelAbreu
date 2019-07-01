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
    public partial class cAsignatura : Form
    {
        public cAsignatura()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Asignaturas>();
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0: // Todo
                        listado = db.GetList(p => true);
                        break;

                    case 1: // ID
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = db.GetList(p => p.AsignaturaId == id);
                        break;

                    case 2://Descripcion
                        listado = db.GetList(p => p.Descripcion.Contains(CriteriotextBox.Text));
                        break;

                }
            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }
    }
}
