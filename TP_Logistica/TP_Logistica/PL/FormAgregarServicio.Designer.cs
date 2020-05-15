namespace Proyecto_Logistica
{
    partial class FormAgregarServicio
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
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.labeleditarservicio = new System.Windows.Forms.Label();
            this.labelagregarservicio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnguardarservicionuevo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.txtCV = new System.Windows.Forms.TextBox();
            this.btnguardareditarservicio = new System.Windows.Forms.Button();
            this.cbxUnidad = new System.Windows.Forms.ComboBox();
            this.cbxCliente = new System.Windows.Forms.ComboBox();
            this.BarraTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.BarraTitulo.Controls.Add(this.labeleditarservicio);
            this.BarraTitulo.Controls.Add(this.labelagregarservicio);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(439, 38);
            this.BarraTitulo.TabIndex = 3;
            // 
            // labeleditarservicio
            // 
            this.labeleditarservicio.AutoSize = true;
            this.labeleditarservicio.Font = new System.Drawing.Font("Nirmala UI", 14.25F);
            this.labeleditarservicio.ForeColor = System.Drawing.Color.White;
            this.labeleditarservicio.Location = new System.Drawing.Point(159, 0);
            this.labeleditarservicio.Name = "labeleditarservicio";
            this.labeleditarservicio.Size = new System.Drawing.Size(133, 25);
            this.labeleditarservicio.TabIndex = 17;
            this.labeleditarservicio.Text = "Editar Servicio";
            // 
            // labelagregarservicio
            // 
            this.labelagregarservicio.AutoSize = true;
            this.labelagregarservicio.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelagregarservicio.ForeColor = System.Drawing.Color.White;
            this.labelagregarservicio.Location = new System.Drawing.Point(149, 0);
            this.labelagregarservicio.Name = "labelagregarservicio";
            this.labelagregarservicio.Size = new System.Drawing.Size(152, 25);
            this.labelagregarservicio.TabIndex = 15;
            this.labelagregarservicio.Text = "Agregar Servicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "CV";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(327, 106);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnguardarservicionuevo
            // 
            this.btnguardarservicionuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnguardarservicionuevo.FlatAppearance.BorderSize = 0;
            this.btnguardarservicionuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardarservicionuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardarservicionuevo.ForeColor = System.Drawing.Color.White;
            this.btnguardarservicionuevo.Location = new System.Drawing.Point(327, 65);
            this.btnguardarservicionuevo.Name = "btnguardarservicionuevo";
            this.btnguardarservicionuevo.Size = new System.Drawing.Size(100, 35);
            this.btnguardarservicionuevo.TabIndex = 24;
            this.btnguardarservicionuevo.Text = "Guardar";
            this.btnguardarservicionuevo.UseVisualStyleBackColor = false;
            this.btnguardarservicionuevo.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Origen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Unidad";
            // 
            // txtOrigen
            // 
            this.txtOrigen.BackColor = System.Drawing.SystemColors.Menu;
            this.txtOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrigen.Location = new System.Drawing.Point(74, 103);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(244, 23);
            this.txtOrigen.TabIndex = 3;
            // 
            // txtCV
            // 
            this.txtCV.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCV.Location = new System.Drawing.Point(74, 48);
            this.txtCV.Name = "txtCV";
            this.txtCV.Size = new System.Drawing.Size(244, 23);
            this.txtCV.TabIndex = 1;
            // 
            // btnguardareditarservicio
            // 
            this.btnguardareditarservicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(125)))));
            this.btnguardareditarservicio.FlatAppearance.BorderSize = 0;
            this.btnguardareditarservicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardareditarservicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardareditarservicio.ForeColor = System.Drawing.Color.White;
            this.btnguardareditarservicio.Location = new System.Drawing.Point(327, 65);
            this.btnguardareditarservicio.Name = "btnguardareditarservicio";
            this.btnguardareditarservicio.Size = new System.Drawing.Size(100, 35);
            this.btnguardareditarservicio.TabIndex = 29;
            this.btnguardareditarservicio.Text = "Guardar";
            this.btnguardareditarservicio.UseVisualStyleBackColor = false;
            this.btnguardareditarservicio.Click += new System.EventHandler(this.btnguardareditarservicio_Click);
            // 
            // cbxUnidad
            // 
            this.cbxUnidad.FormattingEnabled = true;
            this.cbxUnidad.Location = new System.Drawing.Point(74, 76);
            this.cbxUnidad.Name = "cbxUnidad";
            this.cbxUnidad.Size = new System.Drawing.Size(244, 21);
            this.cbxUnidad.TabIndex = 30;
            this.cbxUnidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxUnidad_KeyPress);
            // 
            // cbxCliente
            // 
            this.cbxCliente.FormattingEnabled = true;
            this.cbxCliente.Location = new System.Drawing.Point(74, 134);
            this.cbxCliente.Name = "cbxCliente";
            this.cbxCliente.Size = new System.Drawing.Size(244, 21);
            this.cbxCliente.TabIndex = 31;
            this.cbxCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxCliente_KeyPress);
            // 
            // FormAgregarServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(439, 170);
            this.Controls.Add(this.cbxCliente);
            this.Controls.Add(this.cbxUnidad);
            this.Controls.Add(this.btnguardareditarservicio);
            this.Controls.Add(this.txtCV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnguardarservicionuevo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.BarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAgregarServicio";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormAgregarServicio";
            this.Load += new System.EventHandler(this.FormAgregarServicio_Load);
            this.BarraTitulo.ResumeLayout(false);
            this.BarraTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Label labelagregarservicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnguardarservicionuevo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtOrigen;
        public System.Windows.Forms.TextBox txtCV;
        private System.Windows.Forms.Button btnguardareditarservicio;
        private System.Windows.Forms.Label labeleditarservicio;
        private System.Windows.Forms.ComboBox cbxUnidad;
        private System.Windows.Forms.ComboBox cbxCliente;
    }
}