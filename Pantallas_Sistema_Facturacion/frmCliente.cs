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
using MySql.Data.MySqlClient;

namespace Pantallas_Sistema_Facturacion
{
    public partial class frmCliente : MaterialForm
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmEditarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            {
                string nombre = txtNombreCliente.Text.Trim();
                string documento = txtDocumento.Text.Trim();
                string direccion = txtDireccion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();

                if (string.IsNullOrEmpty(nombre) ||
                    string.IsNullOrEmpty(documento) ||
                    string.IsNullOrEmpty(direccion) ||
                    string.IsNullOrEmpty(telefono) ||
                    string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var conn = DBHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO clientes (nombre_cliente, documento, direccion, telefono, email) VALUES (@nombre, @documento, @direccion, @telefono, @email)";
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@documento", documento);
                            cmd.Parameters.AddWithValue("@direccion", direccion);
                            cmd.Parameters.AddWithValue("@telefono", telefono);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Cliente creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Indica éxito al formulario padre
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al crear el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
