namespace Presentacion.Forms.frmDetails
{
    partial class frmInfoUsuario
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
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoUsuario));
            this.txtNomApe = new FontAwesome.Sharp.IconButton();
            this.txtTipoCuenta = new FontAwesome.Sharp.IconButton();
            this.txtTelefono = new FontAwesome.Sharp.IconButton();
            this.txtCorreo = new FontAwesome.Sharp.IconButton();
            this.pbFoto = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.txtUser = new System.Windows.Forms.Button();
            this.btCerrar = new FontAwesome.Sharp.IconButton();
            this.transEntrada = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.transSalida = new BunifuAnimatorNS.BunifuTransition(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomApe
            // 
            this.txtNomApe.BackColor = System.Drawing.Color.Transparent;
            this.transSalida.SetDecoration(this.txtNomApe, BunifuAnimatorNS.DecorationType.None);
            this.transEntrada.SetDecoration(this.txtNomApe, BunifuAnimatorNS.DecorationType.None);
            this.txtNomApe.FlatAppearance.BorderSize = 0;
            this.txtNomApe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtNomApe.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.txtNomApe.ForeColor = System.Drawing.Color.White;
            this.txtNomApe.IconChar = FontAwesome.Sharp.IconChar.User;
            this.txtNomApe.IconColor = System.Drawing.Color.White;
            this.txtNomApe.IconSize = 18;
            this.txtNomApe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtNomApe.Location = new System.Drawing.Point(25, 217);
            this.txtNomApe.Name = "txtNomApe";
            this.txtNomApe.Rotation = 0D;
            this.txtNomApe.Size = new System.Drawing.Size(176, 28);
            this.txtNomApe.TabIndex = 1;
            this.txtNomApe.Text = "Miguel Angel Meza";
            this.txtNomApe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.txtNomApe.UseVisualStyleBackColor = false;
            // 
            // txtTipoCuenta
            // 
            this.txtTipoCuenta.BackColor = System.Drawing.Color.Transparent;
            this.transSalida.SetDecoration(this.txtTipoCuenta, BunifuAnimatorNS.DecorationType.None);
            this.transEntrada.SetDecoration(this.txtTipoCuenta, BunifuAnimatorNS.DecorationType.None);
            this.txtTipoCuenta.FlatAppearance.BorderSize = 0;
            this.txtTipoCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtTipoCuenta.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.txtTipoCuenta.ForeColor = System.Drawing.Color.White;
            this.txtTipoCuenta.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.txtTipoCuenta.IconColor = System.Drawing.Color.White;
            this.txtTipoCuenta.IconSize = 18;
            this.txtTipoCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTipoCuenta.Location = new System.Drawing.Point(25, 244);
            this.txtTipoCuenta.Name = "txtTipoCuenta";
            this.txtTipoCuenta.Rotation = 0D;
            this.txtTipoCuenta.Size = new System.Drawing.Size(130, 28);
            this.txtTipoCuenta.TabIndex = 1;
            this.txtTipoCuenta.Text = "Administrador";
            this.txtTipoCuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.txtTipoCuenta.UseVisualStyleBackColor = false;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.Transparent;
            this.transSalida.SetDecoration(this.txtTelefono, BunifuAnimatorNS.DecorationType.None);
            this.transEntrada.SetDecoration(this.txtTelefono, BunifuAnimatorNS.DecorationType.None);
            this.txtTelefono.FlatAppearance.BorderSize = 0;
            this.txtTelefono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtTelefono.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.txtTelefono.ForeColor = System.Drawing.Color.White;
            this.txtTelefono.IconChar = FontAwesome.Sharp.IconChar.PhoneAlt;
            this.txtTelefono.IconColor = System.Drawing.Color.White;
            this.txtTelefono.IconSize = 18;
            this.txtTelefono.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTelefono.Location = new System.Drawing.Point(25, 270);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Rotation = 0D;
            this.txtTelefono.Size = new System.Drawing.Size(130, 28);
            this.txtTelefono.TabIndex = 1;
            this.txtTelefono.Text = "918688681";
            this.txtTelefono.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.txtTelefono.UseVisualStyleBackColor = false;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.Transparent;
            this.transSalida.SetDecoration(this.txtCorreo, BunifuAnimatorNS.DecorationType.None);
            this.transEntrada.SetDecoration(this.txtCorreo, BunifuAnimatorNS.DecorationType.None);
            this.txtCorreo.FlatAppearance.BorderSize = 0;
            this.txtCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtCorreo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.txtCorreo.ForeColor = System.Drawing.Color.White;
            this.txtCorreo.IconChar = FontAwesome.Sharp.IconChar.At;
            this.txtCorreo.IconColor = System.Drawing.Color.White;
            this.txtCorreo.IconSize = 18;
            this.txtCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCorreo.Location = new System.Drawing.Point(25, 294);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Rotation = 0D;
            this.txtCorreo.Size = new System.Drawing.Size(130, 28);
            this.txtCorreo.TabIndex = 1;
            this.txtCorreo.Text = "migue@gmail.com";
            this.txtCorreo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.txtCorreo.UseVisualStyleBackColor = false;
            // 
            // pbFoto
            // 
            this.pbFoto.BaseColor = System.Drawing.Color.White;
            this.transSalida.SetDecoration(this.pbFoto, BunifuAnimatorNS.DecorationType.None);
            this.transEntrada.SetDecoration(this.pbFoto, BunifuAnimatorNS.DecorationType.None);
            this.pbFoto.Image = global::Presentacion.Properties.Resources.userFoto;
            this.pbFoto.Location = new System.Drawing.Point(76, 31);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(60, 60);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 2;
            this.pbFoto.TabStop = false;
            this.pbFoto.UseTransfarantBackground = false;
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.Transparent;
            this.transEntrada.SetDecoration(this.txtUser, BunifuAnimatorNS.DecorationType.None);
            this.transSalida.SetDecoration(this.txtUser, BunifuAnimatorNS.DecorationType.None);
            this.txtUser.FlatAppearance.BorderSize = 0;
            this.txtUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.txtUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.txtUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtUser.Location = new System.Drawing.Point(23, 92);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(167, 27);
            this.txtUser.TabIndex = 3;
            this.txtUser.Text = "Migue20";
            this.txtUser.UseVisualStyleBackColor = false;
            // 
            // btCerrar
            // 
            this.btCerrar.BackColor = System.Drawing.Color.Transparent;
            this.transSalida.SetDecoration(this.btCerrar, BunifuAnimatorNS.DecorationType.None);
            this.transEntrada.SetDecoration(this.btCerrar, BunifuAnimatorNS.DecorationType.None);
            this.btCerrar.FlatAppearance.BorderSize = 0;
            this.btCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCerrar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btCerrar.ForeColor = System.Drawing.Color.White;
            this.btCerrar.IconChar = FontAwesome.Sharp.IconChar.ChevronUp;
            this.btCerrar.IconColor = System.Drawing.Color.Red;
            this.btCerrar.IconSize = 30;
            this.btCerrar.Location = new System.Drawing.Point(76, 3);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Rotation = 0D;
            this.btCerrar.Size = new System.Drawing.Size(60, 22);
            this.btCerrar.TabIndex = 1;
            this.btCerrar.UseVisualStyleBackColor = false;
            this.btCerrar.Click += new System.EventHandler(this.BtCerrar_Click);
            // 
            // transEntrada
            // 
            this.transEntrada.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
            this.transEntrada.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.transEntrada.DefaultAnimation = animation2;
            // 
            // transSalida
            // 
            this.transSalida.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
            this.transSalida.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.transSalida.DefaultAnimation = animation1;
            // 
            // frmInfoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Presentacion.Properties.Resources.infoUsurio;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(213, 334);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.pbFoto);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtTipoCuenta);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.txtNomApe);
            this.transEntrada.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.transSalida.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInfoUsuario";
            this.Text = "frmInfoUsuario";
            this.Deactivate += new System.EventHandler(this.frmInfoUsuario_Deactivate);
            this.Load += new System.EventHandler(this.frmInfoUsuario_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FrmInfoUsuario_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmInfoUsuario_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton txtNomApe;
        private FontAwesome.Sharp.IconButton txtTipoCuenta;
        private FontAwesome.Sharp.IconButton txtTelefono;
        private FontAwesome.Sharp.IconButton txtCorreo;
        private Guna.UI.WinForms.GunaCirclePictureBox pbFoto;
        private System.Windows.Forms.Button txtUser;
        private BunifuAnimatorNS.BunifuTransition transSalida;
        private BunifuAnimatorNS.BunifuTransition transEntrada;
        private FontAwesome.Sharp.IconButton btCerrar;
    }
}