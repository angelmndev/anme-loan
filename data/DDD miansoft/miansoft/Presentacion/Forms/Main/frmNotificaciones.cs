using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.Main
{
    public partial class frmNotificaciones : Form
    {
        private enumAction action;
        private int posX, posY;
        public frmNotificaciones()
        {
            InitializeComponent();
        }
        public enum enumAction
        {
            wait,
            start,
            close
        }
        public enum estado
        {
            Success,
            Warning,
            Error,
            Info
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            timer.Interval = 1;
            action = enumAction.close;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enumAction.wait:
                    timer.Interval = 5000;
                    action = enumAction.close;
                    break;
                case enumAction.start:
                    timer.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.posX < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enumAction.wait;
                        }
                    }
                    break;
                case enumAction.close:
                    timer.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }
        public void showAlert(string message, estado std)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string formName;

            for (int i = 1; i < 10; i++)
            {
                formName = "alert" + i.ToString();
                frmNotificaciones frm = (frmNotificaciones)Application.OpenForms[formName];

                if (frm == null)
                {
                    this.Name = formName;
                    this.posX = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.posY = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.posX, this.posY);
                    break;
                }
            }

            this.posX = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (std)
            {
                case estado.Success:
                    this.btIcon.IconChar = FontAwesome.Sharp.IconChar.Check;
                    this.btIcon.IconColor = Color.White;
                    this.btIcon.BackColor = Color.FromArgb(41, 183, 97);
                    this.BackColor = Color.FromArgb(41, 183, 97);
                    break;
                case estado.Error:
                    this.btIcon.IconChar = FontAwesome.Sharp.IconChar.Bug;
                    this.btIcon.IconColor = Color.White;
                    this.btIcon.BackColor = Color.FromArgb(255, 46, 75);
                    this.BackColor = Color.FromArgb(255, 46, 75);
                    break;
                case estado.Info:
                    this.btIcon.IconChar = FontAwesome.Sharp.IconChar.Info;
                    this.btIcon.IconColor = Color.White;
                    this.btIcon.BackColor = Color.FromArgb(10, 175, 201);
                    this.BackColor = Color.FromArgb(10, 175, 201);
                    break;
                case estado.Warning:
                    this.btIcon.IconChar = FontAwesome.Sharp.IconChar.SkullCrossbones;
                    this.btIcon.IconColor = Color.White;
                    this.btIcon.BackColor = Color.FromArgb(255, 174, 0);
                    this.BackColor = Color.FromArgb(255, 174, 0);
                    break;
            }

            this.lbMensaje.Text = message;
            this.Show();
            this.action = enumAction.start;
            this.timer.Interval = 1;
            timer.Start();
        }
    
        
    }
}
