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

            List<string> listaActividades = ActividadesHotelesOrm.SelectAct_Hotel(hotel);
            listBoxActividades.DataSource = listaActividades;
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (button2.Visible == false)
            {
                hoteles hotel = new hoteles();
                hotel.nombre = textBoxNombre.Text;
                //falta cadena y ciudad
                hotel.categoria = int.Parse(textBoxCategoria.Text);
                hotel.telefono = int.Parse(textBoxTelefono.Text);
                hotel.direccion = textBoxDireccion.Text;
                hotel.tipo = textBoxUbicacion.Text;

                HotelesOrm.AddHotel(hotel);
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
                ciudades = new ciudades() { nombre = comboBox2.SelectedItem.ToString() }
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
            listBoxActividades.Items.Add(comboBoxActividades.SelectedItem);

           
        }
    }
}
