using Mario_hoteles.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario_hoteles
{
    public partial class EditarCrearHoteles : Form
    {

        private hoteles hotelSeleccionado;

        public EditarCrearHoteles()
        {
            InitializeComponent();
            if (hotelSeleccionado == null)
            {
                button2.Visible = false;
                actividadesBindingSource.DataSource = ActividadesHotelesOrm.SelectActividades();
                cadenasBindingSource.DataSource = CadenaHotelesOrm.SelectCadenaHoteles();
                ciudadesBindingSource.DataSource = CiudadesOrm.SelectCiudades();
            }
        }

        public EditarCrearHoteles(hoteles hotel)
        {
            InitializeComponent();
            hotelSeleccionado = hotel;
            actividadesBindingSource.DataSource = ActividadesHotelesOrm.SelectActividades();
            cadenasBindingSource.DataSource = CadenaHotelesOrm.SelectCadenaHoteles();
            ciudadesBindingSource.DataSource = CiudadesOrm.SelectCiudades();
            cargarHotel(hotelSeleccionado);            
            textBoxNombre.Enabled = false;
            comboBox2.Enabled = false;
        }

        private void cargarHotel(hoteles hotel)
        {
            textBoxNombre.Text = hotel.nombre.ToString();
            comboBox1.SelectedItem = hotel.cadenas;
            comboBox2.SelectedItem = hotel.ciudades;
            textBoxUbicacion.Text = hotel.tipo.ToString();
            textBoxTelefono.Text = hotel.telefono.ToString();
            textBoxCategoria.Text = hotel.categoria.ToString();
            textBoxDireccion.Text = hotel.direccion.ToString();
            Fill(hotel.act_hotel.ToList());
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el objeto seleccionado en la ComboBox
            actividades selectedActividad = comboBoxActividades.SelectedItem as actividades;

            // Actualizar el texto del TextBox con la descripción del objeto seleccionado
            if (selectedActividad != null)
            {
                textBoxGradoDificultad.Text = ActividadesHotelesOrm.SelectGradoDificultad(selectedActividad).ToString();
            }
            else
            {
                textBoxGradoDificultad.Text = "";
            }
        }
        private void Fill(List<act_hotel> act_Hotel)
        {
            foreach (act_hotel act in act_Hotel)
            {
                dataGridView1.Rows.Add();
                int rowIndex = dataGridView1.Rows.Count - 1;

                dataGridView1.Rows[rowIndex].Cells[0].Value = act.id_act;
                dataGridView1.Rows[rowIndex].Cells[1].Value = act.actividades.descripcion;
                dataGridView1.Rows[rowIndex].Cells[2].Value = act.grado;
            }
        }
        private List<act_hotel> GetActHotel()
        {
            List<act_hotel> listaActividades = new List<act_hotel>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                act_hotel actividad = new act_hotel();

                actividad.id_act = Convert.ToInt32(row.Cells[0].Value);
                actividad.nombre = row.Cells[1].Value.ToString();
                actividad.grado = Convert.ToInt32(row.Cells[2].Value);
                actividad.id_ciudad = (int)comboBox2.SelectedValue;
                listaActividades.Add(actividad);   
            }

            return listaActividades;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (button2.Visible == false)
            {
                hoteles hotel = new hoteles();
                hotel.nombre = textBoxNombre.Text;
                hotel.id_ciudad = (int)comboBox2.SelectedValue;
                hotel.act_hotel = GetActHotel();
                hotel.categoria = int.Parse(textBoxCategoria.Text);
                hotel.telefono = int.Parse(textBoxTelefono.Text);
                hotel.direccion = textBoxDireccion.Text;
                hotel.cif = comboBox1.SelectedValue.ToString();
                hotel.tipo = textBoxUbicacion.Text;

               
                string msgError = HotelesOrm.Add(hotel);
                if (msgError == "")
                {
                    MessageBox.Show("Saved", "guardado", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show(msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Crear un objeto hoteles con los valores actualizados
                hoteles hotelToUpdate = cogerHotel();

                // Actualizar el objeto en la base de datos
                HotelesOrm.UpdateHotel(hotelSeleccionado, hotelToUpdate);
            }
            
            this.Close();
        }

        private hoteles cogerHotel()
        {
            hoteles hotelToUpdate = new hoteles()
            {
                id_ciudad = hotelSeleccionado.id_ciudad,
                direccion = textBoxDireccion.Text,
                telefono = int.Parse(textBoxTelefono.Text),
                tipo = textBoxUbicacion.Text,
                categoria = int.Parse(textBoxCategoria.Text),
                cadenas = new cadenas() { nombre = comboBox1.SelectedItem.ToString() },
                ciudades = new ciudades() { nombre = comboBox2.SelectedItem.ToString() },
                act_hotel = GetActHotel()
            };

            return hotelToUpdate;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Actualizar el objeto en la base de datos
            HotelesOrm.DeleteHotel(hotelSeleccionado);

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idAct = (int)comboBoxActividades.SelectedValue;
            string nombre = comboBoxActividades.Text;
            int grado = int.Parse(textBoxGradoDificultad.Text);

            // Verificar si ya existe el elemento
            bool existe = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && (int)row.Cells[0].Value == idAct)
                {
                    existe = true;
                    break;
                }
            }

            if (existe)
            {
                // Mostrar alerta
                MessageBox.Show("Este elemento ya fue agregado anteriormente.", "Elemento duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dataGridView1.Rows.Add();

                int rowIndex = dataGridView1.Rows.Count - 1;

                dataGridView1.Rows[rowIndex].Cells[0].Value = idAct;
                dataGridView1.Rows[rowIndex].Cells[1].Value = nombre;
                dataGridView1.Rows[rowIndex].Cells[2].Value = grado;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Obtenemos la fila seleccionada
            DataGridViewRow row = dataGridView1.CurrentRow;

            // Si hay una fila seleccionada, la eliminamos
            if (row != null)
            {
                dataGridView1.Rows.Remove(row);
            }
        }
    }
}
