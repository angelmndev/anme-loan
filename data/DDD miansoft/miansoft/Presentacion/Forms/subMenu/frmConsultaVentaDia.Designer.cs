namespace Presentacion.Forms.subMenu
{
    partial class frmConsultaVentaDia
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.ReporteVentasModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ListaReporteVentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReporteVentasPeriodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteVentasModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaReporteVentasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteVentasPeriodoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 152);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(126, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(141, 152);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(126, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "reporteVentas";
            reportDataSource1.Value = this.ReporteVentasModelBindingSource;
            reportDataSource2.Name = "listaVentas";
            reportDataSource2.Value = this.ListaReporteVentasBindingSource;
            reportDataSource3.Name = "ventaPeriodo";
            reportDataSource3.Value = this.ReporteVentasPeriodoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Reporte.ReporteVentaDia.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 220);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 132);
            this.reportViewer1.TabIndex = 3;
            // 
            // ReporteVentasModelBindingSource
            // 
            this.ReporteVentasModelBindingSource.DataSource = typeof(Dominio.Models.ReporteVentasModel.ReporteVentasModel);
            // 
            // ListaReporteVentasBindingSource
            // 
            this.ListaReporteVentasBindingSource.DataSource = typeof(Dominio.Models.ReporteVentasModel.ListaReporteVentas);
            // 
            // ReporteVentasPeriodoBindingSource
            // 
            this.ReporteVentasPeriodoBindingSource.DataSource = typeof(Dominio.Models.ReporteVentasModel.ReporteVentasPeriodo);
            // 
            // frmConsultaVentaDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "frmConsultaVentaDia";
            this.Text = "frmConsultaVentaDia";
            this.Load += new System.EventHandler(this.frmConsultaVentaDia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteVentasModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaReporteVentasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteVentasPeriodoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.Windows.Forms.BindingSource ReporteVentasModelBindingSource;
        private System.Windows.Forms.BindingSource ListaReporteVentasBindingSource;
        private System.Windows.Forms.BindingSource ReporteVentasPeriodoBindingSource;
    }
}