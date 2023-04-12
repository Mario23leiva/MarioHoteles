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
        
        public Menu()
        {
            InitializeComponent();
            hotelesBindingSource.DataSource = HotelesOrm.SelectByMale();
            
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
            EditarCrearHoteles editarCrear = new EditarCrearHoteles();
            editarCrear.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (hot != null)
            {
                EditarCrearHoteles editarCrear = new EditarCrearHoteles(hot);
                editarCrear.ShowDialog();
            }
            else
            {
                MessageBox.Show("No has seleccionado ningún objeto para editar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Comprueba si hay una fila seleccionada
            {
                

                hot = (hoteles)dataGridView1.CurrentRow.DataBoundItem;

            }
        }
    }
}
