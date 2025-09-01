using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas_Sistema_Facturacion
{
    public partial class frmListaClientes : MaterialForm
    {
        public frmListaClientes()
        {
            InitializeComponent();
        }
        public void llenar_grid()
        {
            
        }
        private void frmListaClientes_Load(object sender, EventArgs e)
        {
            llenar_grid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
        
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
   
        }
    }
}
