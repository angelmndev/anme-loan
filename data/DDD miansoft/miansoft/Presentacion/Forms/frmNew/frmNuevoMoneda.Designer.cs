﻿namespace Presentacion.Forms.frmNew
{
    partial class frmNuevoMoneda
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.chkEstado = new Telerik.WinControls.UI.RadCheckBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btCancelar = new XanderUI.XUIButton();
            this.btGuardar = new XanderUI.XUIButton();
            this.txtCodigo = new Telerik.WinControls.UI.RadTextBox();
            this.txtNombre = new Telerik.WinControls.UI.RadTextBox();
            this.txtLenguaje = new Telerik.WinControls.UI.RadTextBox();
            this.txtSimbolo = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLenguaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSimbolo)).BeginInit();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.chkEstado);
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.Controls.Add(this.txtCodigo);
            this.radGroupBox1.Controls.Add(this.txtNombre);
            this.radGroupBox1.Controls.Add(this.txtLenguaje);
            this.radGroupBox1.Controls.Add(this.txtSimbolo);
            this.radGroupBox1.Controls.Add(this.label5);
            this.radGroupBox1.Controls.Add(this.label3);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(17, 63);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(446, 267);
            this.radGroupBox1.TabIndex = 14;
            this.radGroupBox1.ThemeName = "Office2010Silver";
            // 
            // chkEstado
            // 
            this.chkEstado.Location = new System.Drawing.Point(14, 174);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(54, 18);
            this.chkEstado.TabIndex = 49;
            this.chkEstado.Text = "Estado";
            this.chkEstado.ThemeName = "Office2010Silver";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btCancelar);
            this.radGroupBox2.Controls.Add(this.btGuardar);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(14, 201);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(414, 49);
            this.radGroupBox2.TabIndex = 45;
            this.radGroupBox2.ThemeName = "Office2010Silver";
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btCancelar.ButtonImage = null;
            this.btCancelar.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btCancelar.ButtonText = "CANCELAR";
            this.btCancelar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btCancelar.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.CornerRadius = 5;
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btCancelar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btCancelar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.btCancelar.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btCancelar.Location = new System.Drawing.Point(179, 10);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(109, 30);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.TextColor = System.Drawing.Color.White;
            this.btCancelar.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btGuardar
            // 
            this.btGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGuardar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(222)))), ((int)(((byte)(57)))));
            this.btGuardar.ButtonImage = null;
            this.btGuardar.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btGuardar.ButtonText = "GUARDAR";
            this.btGuardar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(222)))), ((int)(((byte)(57)))));
            this.btGuardar.ClickTextColor = System.Drawing.Color.WhiteSmoke;
            this.btGuardar.CornerRadius = 5;
            this.btGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btGuardar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btGuardar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(222)))), ((int)(((byte)(57)))));
            this.btGuardar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.btGuardar.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btGuardar.Location = new System.Drawing.Point(294, 10);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(109, 30);
            this.btGuardar.TabIndex = 0;
            this.btGuardar.TextColor = System.Drawing.Color.White;
            this.btGuardar.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(14, 32);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(414, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.ThemeName = "Office2010Silver";
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(14, 149);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(414, 20);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.ThemeName = "Office2010Silver";
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtLenguaje
            // 
            this.txtLenguaje.Location = new System.Drawing.Point(14, 110);
            this.txtLenguaje.Name = "txtLenguaje";
            this.txtLenguaje.Size = new System.Drawing.Size(414, 20);
            this.txtLenguaje.TabIndex = 2;
            this.txtLenguaje.ThemeName = "Office2010Silver";
            this.txtLenguaje.TextChanged += new System.EventHandler(this.txtLenguaje_TextChanged);
            // 
            // txtSimbolo
            // 
            this.txtSimbolo.Location = new System.Drawing.Point(14, 71);
            this.txtSimbolo.MaxLength = 11;
            this.txtSimbolo.Name = "txtSimbolo";
            this.txtSimbolo.Size = new System.Drawing.Size(414, 20);
            this.txtSimbolo.TabIndex = 1;
            this.txtSimbolo.ThemeName = "Office2010Silver";
            this.txtSimbolo.TextChanged += new System.EventHandler(this.txtSimbolo_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label5.Location = new System.Drawing.Point(11, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Codigo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.Location = new System.Drawing.Point(11, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.Location = new System.Drawing.Point(11, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Leguaje:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.Location = new System.Drawing.Point(11, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Simbolo:";
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.pnHeader.Controls.Add(this.btClose);
            this.pnHeader.Controls.Add(this.label12);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(483, 49);
            this.pnHeader.TabIndex = 13;
            this.pnHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnHeader_MouseMove);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BackgroundImage = global::Presentacion.Properties.Resources.cerrar__1_;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(441, 13);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(20, 20);
            this.btClose.TabIndex = 0;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(244, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "NUEVO TIPO DE MONEDA";
            // 
            // frmNuevoMoneda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 350);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevoMoneda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoMoneda";
            this.Load += new System.EventHandler(this.frmNuevoMoneda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLenguaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSimbolo)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadCheckBox chkEstado;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private XanderUI.XUIButton btCancelar;
        private XanderUI.XUIButton btGuardar;
        private Telerik.WinControls.UI.RadTextBox txtCodigo;
        private Telerik.WinControls.UI.RadTextBox txtNombre;
        private Telerik.WinControls.UI.RadTextBox txtLenguaje;
        private Telerik.WinControls.UI.RadTextBox txtSimbolo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label12;
    }
}