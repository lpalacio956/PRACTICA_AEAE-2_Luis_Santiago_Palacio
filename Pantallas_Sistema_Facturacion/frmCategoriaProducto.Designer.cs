namespace Pantallas_Sistema_Facturacion
{
    partial class frmCategoriaProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCategoriaProductos = new MaterialSkin.Controls.MaterialLabel();
            this.txtNombreCategoria = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtId = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnActualizar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSalir = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // lblCategoriaProductos
            // 
            this.lblCategoriaProductos.AutoSize = true;
            this.lblCategoriaProductos.Depth = 0;
            this.lblCategoriaProductos.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoriaProductos.ForeColor = System.Drawing.Color.Maroon;
            this.lblCategoriaProductos.Location = new System.Drawing.Point(251, 94);
            this.lblCategoriaProductos.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCategoriaProductos.Name = "lblCategoriaProductos";
            this.lblCategoriaProductos.Size = new System.Drawing.Size(314, 26);
            this.lblCategoriaProductos.TabIndex = 0;
            this.lblCategoriaProductos.Text = "Categoria de Productos";
            // 
            // txtNombreCategoria
            // 
            this.txtNombreCategoria.Depth = 0;
            this.txtNombreCategoria.Hint = "Nombre Categoria";
            this.txtNombreCategoria.Location = new System.Drawing.Point(42, 208);
            this.txtNombreCategoria.MaxLength = 32767;
            this.txtNombreCategoria.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.PasswordChar = '\0';
            this.txtNombreCategoria.SelectedText = "";
            this.txtNombreCategoria.SelectionLength = 0;
            this.txtNombreCategoria.SelectionStart = 0;
            this.txtNombreCategoria.Size = new System.Drawing.Size(268, 23);
            this.txtNombreCategoria.TabIndex = 1;
            this.txtNombreCategoria.TabStop = false;
            this.txtNombreCategoria.UseSystemPasswordChar = false;
            // 
            // txtId
            // 
            this.txtId.Depth = 0;
            this.txtId.Hint = "";
            this.txtId.Location = new System.Drawing.Point(42, 163);
            this.txtId.MaxLength = 32767;
            this.txtId.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtId.Name = "txtId";
            this.txtId.PasswordChar = '\0';
            this.txtId.SelectedText = "";
            this.txtId.SelectionLength = 0;
            this.txtId.SelectionStart = 0;
            this.txtId.Size = new System.Drawing.Size(75, 23);
            this.txtId.TabIndex = 2;
            this.txtId.TabStop = false;
            this.txtId.Text = "Id";
            this.txtId.UseSystemPasswordChar = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Depth = 0;
            this.btnActualizar.Icon = null;
            this.btnActualizar.Location = new System.Drawing.Point(115, 366);
            this.btnActualizar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Primary = true;
            this.btnActualizar.Size = new System.Drawing.Size(155, 36);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Depth = 0;
            this.btnSalir.Icon = null;
            this.btnSalir.Location = new System.Drawing.Point(516, 367);
            this.btnSalir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Primary = true;
            this.btnSalir.Size = new System.Drawing.Size(155, 35);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmCategoriaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtNombreCategoria);
            this.Controls.Add(this.lblCategoriaProductos);
            this.Name = "frmCategoriaProducto";
            this.Text = "frmCategoriaProducto";
            this.Load += new System.EventHandler(this.frmCategoriaProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblCategoriaProductos;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombreCategoria;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtId;
        private MaterialSkin.Controls.MaterialRaisedButton btnActualizar;
        private MaterialSkin.Controls.MaterialRaisedButton btnSalir;
    }
}