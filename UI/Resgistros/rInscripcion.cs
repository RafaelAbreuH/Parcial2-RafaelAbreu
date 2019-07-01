using Parcial2_RafaelAbreu.BLL;
using Parcial2_RafaelAbreu.DAL;
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

namespace Parcial2_RafaelAbreu.UI.Resgistros
{
    public partial class rInscripcion : Form
    {
        public List<InscripcionDetalle> Detalle { get; set; }
        public rInscripcion()
        {
            InitializeComponent();
            LlenarComboBox();
            this.Detalle = new List<InscripcionDetalle>();
        }
        private decimal ObtenerTotal()
        {
            decimal total = 0;

            foreach (var item in Detalle)
            {
                total += item.SubTotal;
            }
            return total;

        }

        public decimal RestarBalance()
        {
            Estudiantes e = new Estudiantes();
            var total = e.Balance -= ObtenerTotal();
            return total;
        }
        private void CargarGrid()
        {
            detalleDataGridView.DataSource = null;
            detalleDataGridView.DataSource = Detalle;
            detalleDataGridView.Columns["Id"].Visible = false;
            detalleDataGridView.Columns["InscripcionId"].Visible = false;
        }

        private void Limpiar()
        {
            InscripcionIdnumericUpDown.Value = 0;
            EstudiantecomboBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            AsignaturacomboBox.Text = string.Empty;
            CreditotextBox.Text = String.Empty;
            PrecioUpDown.Value = 0;
            BalancetextBox.Text = String.Empty;
            errorProvider.Clear();
            Detalle = new List<InscripcionDetalle>();
            CargarGrid();

        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Inscripcion> db = new RepositorioBase<Inscripcion>();
            Inscripcion inscripcion = db.Buscar((int)InscripcionIdnumericUpDown.Value);
            return (inscripcion != null);
        }

    private Inscripcion LlenaClase()
        {
            Inscripcion inscripcion = new Inscripcion();
            inscripcion.Asignaturas = this.Detalle;
            inscripcion.EstudianteId = Convert.ToInt32(EstudiantecomboBox.SelectedValue);
            inscripcion.Fecha = FechadateTimePicker.Value;
            inscripcion.InscripcionId = Convert.ToInt32(InscripcionIdnumericUpDown.Value);
            inscripcion.Monto = Convert.ToDecimal(PrecioUpDown.Value);
            inscripcion.CalcularMonto();

            return inscripcion;

        }

        private void LlenaCampo(Inscripcion inscripcion)
        {
            InscripcionIdnumericUpDown.Value = inscripcion.InscripcionId;
            EstudiantecomboBox.Text = inscripcion.EstudianteId.ToString();
            FechadateTimePicker.Value = inscripcion.Fecha;
            BalancetextBox.Text = inscripcion.Monto.ToString();
            this.Detalle = inscripcion.Asignaturas;
            CargarGrid();


        }

        private void LlenarComboBox()
        {

            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            var listado = new List<Estudiantes>();
            listado = db.GetList(l => true);
            EstudiantecomboBox.DataSource = listado;
            EstudiantecomboBox.DisplayMember = "Nombre";
            EstudiantecomboBox.ValueMember = "EstudianteId";


            RepositorioBase<Asignaturas> db2 = new RepositorioBase<Asignaturas>();
            var listado2 = new List<Asignaturas>();
            listado2 = db2.GetList(p => true);
            AsignaturacomboBox.DataSource = listado2;
            AsignaturacomboBox.DisplayMember = "Descripcion";
            AsignaturacomboBox.ValueMember = "AsignaturaId";


        }

        private bool Validar()
        {

            bool paso = true;
            errorProvider.Clear();


            if (PrecioUpDown.Value < 0)
            {
                errorProvider.SetError(PrecioUpDown, "Digite el precio por cada Credito");
                PrecioUpDown.Focus();
                paso = false;

            }
            if (FechadateTimePicker.Value > DateTime.Now)
            {
                errorProvider.SetError(FechadateTimePicker, "La fecha no puede ser Mayor que la de hoy");
                paso = false;
            }
            return paso;

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Inscripcion> db = new RepositorioBase<Inscripcion>();
            Inscripcion inscripcion = new Inscripcion();
            try
            {
                if (InscripcionIdnumericUpDown.Value > 0)
                {
                    if ((inscripcion = db.Buscar((int)InscripcionIdnumericUpDown.Value)) != null)
                    {
                        Limpiar();
                        LlenaCampo(inscripcion);
                    }
                    else
                        MessageBox.Show("No se encontro!", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo buscar", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SumarMonto()
        {
            List<InscripcionDetalle> detalle = new List<InscripcionDetalle>();

            if (detalleDataGridView.DataSource != null)
            {
                detalle = (List<InscripcionDetalle>)detalleDataGridView.DataSource;
            }
            decimal Total = 0;
            foreach (var item in detalle)
            {
                Total += item.SubTotal;
            }
            BalancetextBox.Text = Total.ToString();
        }

        private void BajarMonto()
        {
            List<InscripcionDetalle> detalle = new List<InscripcionDetalle>();

            if (detalleDataGridView.DataSource != null)
            {
                detalle = (List<InscripcionDetalle>)detalleDataGridView.DataSource;
            }
            decimal Total = 0;
            foreach (var item in detalle)
            {
                Total -= item.SubTotal;
            }
            Total *= (-1);
            BalancetextBox.Text = Total.ToString();
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            Inscripcion inscripcion = new Inscripcion() ;
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();
            Asignaturas asignatura = db.Buscar((int)AsignaturacomboBox.SelectedValue);
            if (PrecioUpDown.Value == 0)
            {
                errorProvider.SetError(PrecioUpDown, "Digite el precio por cada Credito");
                PrecioUpDown.Focus();
            }
            else
            {
                if (detalleDataGridView.DataSource != null)
                    this.Detalle = (List<InscripcionDetalle>)detalleDataGridView.DataSource;



                this.Detalle.Add(new InscripcionDetalle()
                {
                    InscripcionId = (int)InscripcionIdnumericUpDown.Value,
                    AsignaturaId = (int)AsignaturacomboBox.SelectedValue,
                    Id = 0,
                    SubTotal = (asignatura.Creditos * PrecioUpDown.Value)
                });
                CargarGrid();
            }
            SumarMonto();
        }

        // DURE 3 DIAS TRATAnDO DE QUE ESTO FUNCIONARA.... ME FALTABA el +1 cuando seleccionaba el Index del combobox porque empieza por 0
        private void AsignaturacomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id= AsignaturacomboBox.SelectedIndex + 1; ;
            Asignaturas a = new Asignaturas();
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();
            a = db.Buscar(id);
           CreditotextBox.Text = a.Creditos.ToString();
           
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (detalleDataGridView.Rows.Count > 0 && detalleDataGridView.CurrentRow != null)
            {
                //remover la fila
                Detalle.RemoveAt(detalleDataGridView.CurrentRow.Index);
                CargarGrid();
            }
            BajarMonto();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioInscripcion db = new RepositorioInscripcion();
            errorProvider.Clear();
           
            try
            {
                if (InscripcionIdnumericUpDown.Value > 0)
                {
                    if (db.Eliminar((int)InscripcionIdnumericUpDown.Value))
                    {
                       
                        Limpiar();
                        MessageBox.Show("Eliminado", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioInscripcion db = new RepositorioInscripcion();
            Inscripcion inscripcion = LlenaClase();
            bool paso = false;

            if (!Validar())
                return;

            inscripcion.CalcularMonto();
            if (InscripcionIdnumericUpDown.Value == 0)
                paso = db.Guardar(inscripcion);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una Inscripcion que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(inscripcion);
            }
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void DetalleDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }
    }
}
