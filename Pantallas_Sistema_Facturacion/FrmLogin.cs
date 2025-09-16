using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pantallas_Sistema_Facturacion
{
    public partial class FrmLogin : Form
    {
        

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }   

        private void TxtUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string usuario = TxtUsuario.Text.Trim();
            string contraseña = txtPassword.Text.Trim();

            using (var conn = DBHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario AND contraseña = @contraseña";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contraseña", contraseña);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            // Usuario y contraseña correctos
                            FrmPrincipal principal = new FrmPrincipal(usuario);
                            principal.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o Contraseña incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                }
            }
        }
    }
}
