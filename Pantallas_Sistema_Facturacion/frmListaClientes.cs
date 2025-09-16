using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
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
            dgClientes.CellContentClick += dgClientes_CellContentClick;
            dgClientes.CellEndEdit += dgClientes_CellEndEdit;
        }

        public void llenar_grid()
        {
            using (var conn = DBHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, nombre_cliente, documento, direccion, telefono, email FROM clientes";
                    using (var da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgClientes.DataSource = dt;
                    }
                    // Elimina la columna "borrar" si existe para evitar duplicados
                    if (dgClientes.Columns.Contains("borrar"))
                        dgClientes.Columns.Remove("borrar");

                    // Agrega la columna "Borrar" después de asignar el DataSource
                    DataGridViewButtonColumn btnBorrar = new DataGridViewButtonColumn();
                    btnBorrar.Name = "borrar";
                    btnBorrar.HeaderText = "Borrar";
                    btnBorrar.Text = "Borrar";
                    btnBorrar.UseColumnTextForButtonValue = true;
                    dgClientes.Columns.Add(btnBorrar);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmListaClientes_Load(object sender, EventArgs e)
        {
            dgClientes.ReadOnly = false;
            llenar_grid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCliente nuevoCliente = new frmCliente();
            if (nuevoCliente.ShowDialog() == DialogResult.OK)
            {
                llenar_grid(); // Actualiza el grid solo si se creó el cliente
            }
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que no sea el encabezado
            if (e.RowIndex < 0)
                return;

            // "Borrar" está en la columna con nombre "borrar"
            if (dgClientes.Columns[e.ColumnIndex].Name == "borrar")
            {
                int id = Convert.ToInt32(dgClientes.Rows[e.RowIndex].Cells["id"].Value);
                var confirm = MessageBox.Show("¿Está seguro de borrar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (var conn = DBHelper.GetConnection())
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM clientes WHERE id = @id";
                            using (var cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Cliente borrado correctamente.", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            llenar_grid(); // Actualiza el grid
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al borrar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dgClientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgClientes.Rows[e.RowIndex].Cells["id"].Value);
                string nombre = dgClientes.Rows[e.RowIndex].Cells["nombre_cliente"].Value.ToString();
                string documento = dgClientes.Rows[e.RowIndex].Cells["documento"].Value.ToString();
                string direccion = dgClientes.Rows[e.RowIndex].Cells["direccion"].Value.ToString();
                string telefono = dgClientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                string email = dgClientes.Rows[e.RowIndex].Cells["email"].Value.ToString();

                using (var conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE clientes SET nombre_cliente=@nombre, documento=@documento, direccion=@direccion, telefono=@telefono, email=@email WHERE id=@id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@documento", documento);
                        cmd.Parameters.AddWithValue("@direccion", direccion);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
