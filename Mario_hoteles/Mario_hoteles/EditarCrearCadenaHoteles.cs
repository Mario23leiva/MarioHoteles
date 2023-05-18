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
    public partial class EditarCrearCadenaHoteles : Form
    {
        cadenas cadenaSeleccionada;
        public EditarCrearCadenaHoteles()
        {
            InitializeComponent();
            buttonEliminar.Visible = false;
        }

        public EditarCrearCadenaHoteles(cadenas cad)
        {
            cadenaSeleccionada = cad;
            InitializeComponent();
            cargarCadena(cadenaSeleccionada);
            buttonEliminar.Visible = true;
            textBoxCif.Enabled = false;
        }

        private void cargarCadena(cadenas cad)
        {
            textBoxCif.Text = cad.cif;
            textBoxDirFiscakl.Text = cad.dir_fis;
            textBoxNombre.Text = cad.nombre;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            cadenas cadenaUpdate = cogerCadena();
            if (buttonEliminar.Visible)
            {
                
                string msgError = CadenaHotelesOrm.UpdateCadena(cadenaSeleccionada, cadenaUpdate);
                if (msgError == "")
                {
                    MessageBox.Show("Updated", "actualizado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string msgError = CadenaHotelesOrm.AddCadena(cadenaUpdate);
                if (msgError == "")
                {
                    MessageBox.Show("Saved", "guardado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            this.Close();
        }

        private cadenas cogerCadena()
        {
            cadenas cadenaToUpdate = new cadenas()
            {
                cif = textBoxCif.Text,
                dir_fis = textBoxDirFiscakl.Text,
                nombre = textBoxNombre.Text
            };

            return cadenaToUpdate;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {

            string msgError = CadenaHotelesOrm.DeleteCadena(cadenaSeleccionada);
            if (msgError == "")
            {
                MessageBox.Show("Deleted", "eliminado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
            else
            {
                MessageBox.Show(msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
