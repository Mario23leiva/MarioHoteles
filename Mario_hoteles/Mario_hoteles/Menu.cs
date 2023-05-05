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
    public partial class Menu : Form
    {
        hoteles hot;
        cadenas cad;
        Boolean hotel = false;
        
        public Menu()
        {
            InitializeComponent();
            panelCadenas.Visible = false;
            panelHoteles.Visible = true;
            hotelesBindingSource.DataSource = HotelesOrm.SelectHoteles();
            hotel = true;

        }

        private void RefrescarTablaHoteles()
        {
            panelCadenas.Visible = false;
            panelHoteles.Visible = true;
            hotelesBindingSource.DataSource = HotelesOrm.SelectHoteles();
            hotel = true;

        }

        private void RefrescarTablaCadenaHoteles()
        {
            panelCadenas.Visible = true;
            panelHoteles.Visible = false;
            cadenasBindingSource.DataSource = CadenaHotelesOrm.SelectCadenaHoteles();
            hotel = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
                string id = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); // Obtiene el valor de la celda 6 de la fila actual
                string result = CadenasOrm.SelectByCif(id); // Ejecuta la función y obtiene el resultado
                dataGridView1.Rows[e.RowIndex].Cells[7].Value = result; // Asigna el resultado a la celda 8 de la fila actual
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Comprueba si hay una fila seleccionada
            {
                if (hotel)
                {
                    hot = (hoteles)dataGridView1.CurrentRow.DataBoundItem;
                    EditarCrearHoteles editarCrear = new EditarCrearHoteles(hot);
                    editarCrear.ShowDialog();
                    RefrescarTablaHoteles();
                }
                else
                {

                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (hotel)
            {
                EditarCrearHoteles editarCrear = new EditarCrearHoteles();
                editarCrear.ShowDialog();
                RefrescarTablaHoteles();
            }
            else
            {
                EditarCrearCadenaHoteles editarCrear = new EditarCrearCadenaHoteles();
                editarCrear.ShowDialog();
                RefrescarTablaCadenaHoteles();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RefrescarTablaCadenaHoteles();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RefrescarTablaHoteles();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (!hotel)
                {
                    cad = (cadenas)dataGridView2.CurrentRow.DataBoundItem;
                    EditarCrearCadenaHoteles editarCrear = new EditarCrearCadenaHoteles(cad);
                    editarCrear.ShowDialog();
                    RefrescarTablaCadenaHoteles();
                }
                else
                {

                }
            }
        }
    }
}
