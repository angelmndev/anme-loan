namespace Presentacion.Forms.Main
{
    partial class frmNotificaciones
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
            this.components = new System.ComponentModel.Container();
            this.btIcon = new FontAwesome.Sharp.IconButton();
            this.lbMensaje = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btIcon
            // 
            this.btIcon.BackColor = System.Drawing.Color.Transparent;
            this.btIcon.FlatAppearance.BorderSize = 0;
            this.btIcon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btIcon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btIcon.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btIcon.ForeColor = System.Drawing.Color.White;
            this.btIcon.IconChar = FontAwesome.Sharp.IconChar.SkullCrossbones;
            this.btIcon.IconColor = System.Drawing.Color.White;
            this.btIcon.IconSize = 70;
            this.btIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btIcon.Location = new System.Drawing.Point(12, 16);
            this.btIcon.Name = "btIcon";
            this.btIcon.Rotation = 0D;
            this.btIcon.Size = new System.Drawing.Size(82, 72);
            this.btIcon.TabIndex = 1;
            this.btIcon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btIcon.UseVisualStyleBackColor = false;
            // 
            // lbMensaje
            // 
            this.lbMensaje.AutoSize = true;
            this.lbMensaje.BackColor = System.Drawing.Color.Transparent;
            this.lbMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensaje.ForeColor = System.Drawing.Color.White;
            this.lbMensaje.Location = new System.Drawing.Point(100, 43);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Size = new System.Drawing.Size(160, 16);
            this.lbMensaje.TabIndex = 2;
            this.lbMensaje.Text = "Se guardo correctamente";
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.Transparent;
            this.btClose.BackgroundImage = global::Presentacion.Properties.Resources.cerrar__1_;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(385, 12);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(15, 15);
            this.btClose.TabIndex = 17;
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);

            // 
            // frmNotificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BackgroundImage = global::Presentacion.Properties.Resources.noti;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(412, 100);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.lbMensaje);
            this.Controls.Add(this.btIcon);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotificaciones";
            this.Text = "frmNotificaciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btIcon;
        private System.Windows.Forms.Label lbMensaje;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Timer timer;
    }
}