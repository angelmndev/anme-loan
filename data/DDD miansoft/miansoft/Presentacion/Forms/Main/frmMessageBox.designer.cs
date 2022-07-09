namespace Presentacion.Forms.Main
{
    partial class frmMessageBox
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
            this.btAceptar = new XanderUI.XUIButton();
            this.btCancelar = new XanderUI.XUIButton();
            this.lbInformacion = new System.Windows.Forms.Label();
            this.lbMensaje = new System.Windows.Forms.Button();
            this.pbEstado = new System.Windows.Forms.PictureBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btIcon = new FontAwesome.Sharp.IconButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.object_a6a7e0b1_49c7_4f8c_886b_2d21eb0d21a8 = new Telerik.WinControls.RootRadElement();
            ((System.ComponentModel.ISupportInitialize)(this.pbEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAceptar
            // 
            this.btAceptar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btAceptar.ButtonImage = null;
            this.btAceptar.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btAceptar.ButtonText = "ACEPTAR";
            this.btAceptar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btAceptar.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.btAceptar.CornerRadius = 5;
            this.btAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btAceptar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btAceptar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.btAceptar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.btAceptar.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btAceptar.Location = new System.Drawing.Point(214, 152);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(90, 30);
            this.btAceptar.TabIndex = 44;
            this.btAceptar.TextColor = System.Drawing.Color.White;
            this.btAceptar.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btCancelar.ButtonImage = null;
            this.btCancelar.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btCancelar.ButtonText = "CANCELAR";
            this.btCancelar.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.btCancelar.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.btCancelar.CornerRadius = 5;
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btCancelar.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btCancelar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.btCancelar.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btCancelar.Location = new System.Drawing.Point(118, 152);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(90, 30);
            this.btCancelar.TabIndex = 45;
            this.btCancelar.TextColor = System.Drawing.Color.White;
            this.btCancelar.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // lbInformacion
            // 
            this.lbInformacion.AutoSize = true;
            this.lbInformacion.BackColor = System.Drawing.Color.Transparent;
            this.lbInformacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInformacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(19)))), ((int)(((byte)(62)))));
            this.lbInformacion.Location = new System.Drawing.Point(31, 9);
            this.lbInformacion.Name = "lbInformacion";
            this.lbInformacion.Size = new System.Drawing.Size(42, 17);
            this.lbInformacion.TabIndex = 47;
            this.lbInformacion.Text = "Aviso";
            // 
            // lbMensaje
            // 
            this.lbMensaje.BackColor = System.Drawing.Color.Transparent;
            this.lbMensaje.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.lbMensaje.FlatAppearance.BorderSize = 0;
            this.lbMensaje.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.lbMensaje.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.lbMensaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbMensaje.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensaje.ForeColor = System.Drawing.Color.Black;
            this.lbMensaje.Location = new System.Drawing.Point(12, 95);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Size = new System.Drawing.Size(301, 47);
            this.lbMensaje.TabIndex = 48;
            this.lbMensaje.Text = "Estas seguro que quieres eliminar...?\r\nmiguel";
            this.lbMensaje.UseVisualStyleBackColor = false;
            // 
            // pbEstado
            // 
            this.pbEstado.Image = global::Presentacion.Properties.Resources.bien;
            this.pbEstado.Location = new System.Drawing.Point(104, 32);
            this.pbEstado.Name = "pbEstado";
            this.pbEstado.Size = new System.Drawing.Size(117, 67);
            this.pbEstado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEstado.TabIndex = 51;
            this.pbEstado.TabStop = false;
            // 
            // btClose
            // 
            this.btClose.BackgroundImage = global::Presentacion.Properties.Resources.cerrar__1_;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btClose.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(289, 10);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(15, 15);
            this.btClose.TabIndex = 50;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btIcon
            // 
            this.btIcon.BackColor = System.Drawing.Color.Transparent;
            this.btIcon.FlatAppearance.BorderSize = 0;
            this.btIcon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btIcon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btIcon.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btIcon.ForeColor = System.Drawing.Color.White;
            this.btIcon.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
            this.btIcon.IconColor = System.Drawing.Color.Red;
            this.btIcon.IconSize = 30;
            this.btIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btIcon.Location = new System.Drawing.Point(-3, 3);
            this.btIcon.Name = "btIcon";
            this.btIcon.Rotation = 0D;
            this.btIcon.Size = new System.Drawing.Size(35, 33);
            this.btIcon.TabIndex = 46;
            this.btIcon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btIcon.UseVisualStyleBackColor = false;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.pbEstado);
            this.radPanel1.Controls.Add(this.lbInformacion);
            this.radPanel1.Controls.Add(this.lbMensaje);
            this.radPanel1.Controls.Add(this.btCancelar);
            this.radPanel1.Controls.Add(this.btIcon);
            this.radPanel1.Controls.Add(this.btAceptar);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(325, 194);
            this.radPanel1.TabIndex = 52;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.Red;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).ForeColor2 = System.Drawing.Color.Red;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).ForeColor3 = System.Drawing.Color.Red;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).ForeColor4 = System.Drawing.Color.Red;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.White;
            // 
            // object_a6a7e0b1_49c7_4f8c_886b_2d21eb0d21a8
            // 
            this.object_a6a7e0b1_49c7_4f8c_886b_2d21eb0d21a8.Name = "object_a6a7e0b1_49c7_4f8c_886b_2d21eb0d21a8";
            this.object_a6a7e0b1_49c7_4f8c_886b_2d21eb0d21a8.StretchHorizontally = true;
            this.object_a6a7e0b1_49c7_4f8c_886b_2d21eb0d21a8.StretchVertically = true;
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(325, 194);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.btClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMessageBox";
            this.Load += new System.EventHandler(this.frmMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private XanderUI.XUIButton btAceptar;
        private XanderUI.XUIButton btCancelar;
        private FontAwesome.Sharp.IconButton btIcon;
        private System.Windows.Forms.Label lbInformacion;
        private System.Windows.Forms.Button lbMensaje;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.PictureBox pbEstado;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.RootRadElement object_a6a7e0b1_49c7_4f8c_886b_2d21eb0d21a8;
    }
}