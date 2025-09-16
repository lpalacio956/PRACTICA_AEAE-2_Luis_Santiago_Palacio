using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pantallas_Sistema_Facturacion
{
    public partial class frmSeguridad : MaterialForm
    {
        private string usuarioActual;

        public frmSeguridad(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT usuario, rol FROM usuarios WHERE usuario = @usuario";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuarioActual);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblUsuario.Text = reader.GetString("usuario");
                            lblRol.Text = reader.GetString("rol");
                        }
                    }
                }
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string antigua = txtAntigua.Text.Trim();
            string nueva = txtNueva.Text.Trim();

            if (string.IsNullOrEmpty(antigua) || string.IsNullOrEmpty(nueva))
            {
                MessageBox.Show("Debe completar ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario AND contraseña = @antigua";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuarioActual);
                    cmd.Parameters.AddWithValue("@antigua", antigua);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        MessageBox.Show("La contraseña antigua es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string update = "UPDATE usuarios SET contraseña = @nueva WHERE usuario = @usuario";
                using (var cmd = new MySqlCommand(update, conn))
                {
                    cmd.Parameters.AddWithValue("@nueva", nueva);
                    cmd.Parameters.AddWithValue("@usuario", usuarioActual);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}