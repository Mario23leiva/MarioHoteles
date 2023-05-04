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
        }

        public EditarCrearHoteles(hoteles hotel)
        {
            InitializeComponent();
            hotelSeleccionado = hotel;
            cargarHotel(hotelSeleccionado);
            List<actividades> actividades = ActividadesHotelesOrm.SelectActividades();
            actividadesBindingSource.DataSource = actividades;
            textBoxNombre.Enabled = false;
            textBoxCiudad.Enabled = false;
        }

        private void cargarHotel(hoteles hotel)
        {
            textBoxNombre.Text = hotel.nombre.ToString();
            textBoxCadenaHotel.Text = hotel.cadenas.nombre.ToString();
            textBoxCiudad.Text = hotel.ciudades.nombre.ToString();
            textBoxUbicacion.Text = hotel.tipo.ToString();
            textBoxTelefono.Text = hotel.telefono.ToString();
            textBoxCategoria.Text = hotel.categoria.ToString();
            textBoxDireccion.Text = hotel.direccion.ToString();


            listBox1.DataSource = ActividadesHotelesOrm.SelectAct_Hotel(hotel);
            //comboBoxActividades.DataSource = ActividadesHotelesOrm.SelectActividades();
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

            // Crear un objeto hoteles con los valores actualizados
            hoteles hotelToUpdate = cogerHotel();

            // Actualizar el objeto en la base de datos
            HotelesOrm.UpdateHotel(hotelSeleccionado, hotelToUpdate);
            
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
                cadenas = new cadenas() { nombre = textBoxCadenaHotel.Text },
                ciudades = new ciudades() { nombre = textBoxCiudad.Text }
            };

            return hotelToUpdate;
        }
    }
}
