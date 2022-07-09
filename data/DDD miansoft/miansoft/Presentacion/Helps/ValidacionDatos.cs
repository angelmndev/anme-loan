using DevExpress.XtraEditors.Filtering.Templates;
using Presentacion.Forms.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Presentacion.Helps
{
    public class ValidacionDatos
    {
        public void BorderColor(bool estado,RadTextBox textBox)
        {
            if (estado)
            {
                textBox.TextBoxElement.Border.ForeColor = Color.FromArgb(153, 152, 158);
                textBox.TextBoxElement.Border.ForeColor2 = Color.FromArgb(153, 152, 158);
                textBox.TextBoxElement.Border.ForeColor3 = Color.FromArgb(193, 192, 200);
                textBox.TextBoxElement.Border.ForeColor4 = Color.FromArgb(193, 192, 200);
            }
            else
            {
                textBox.TextBoxElement.Border.ForeColor = Color.FromArgb(248, 140, 135);
                textBox.TextBoxElement.Border.ForeColor2 = Color.FromArgb(248, 140, 135);
                textBox.TextBoxElement.Border.ForeColor3 = Color.FromArgb(247, 151, 146);
                textBox.TextBoxElement.Border.ForeColor4 = Color.FromArgb(247, 151, 146);
            }
           
        }

        //Validamos campo vacio de textbox
        public bool validarCampoVacioTxt(RadTextBox textBox)
        {
            if (textBox.Text == "")
            {
                BorderColor(false, textBox);
                return false;
            }
            else
            {
                BorderColor(true, textBox);
                return true;
            }                    
        }


        //validar por medio de rango 
        public bool validarTexboxRange(RadTextBox textBox,int range)
        {
            if (textBox.TextLength >= range)
            {
                BorderColor(true, textBox);
                return true;
            }
            else
            {
                BorderColor(false, textBox);
                return false;
            }
              
        }

        //validar por formato email
        public bool ComprobarFormatoEmail(string email,RadTextBox textBox)
        {
            string sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, sFormato))
            {
                if (Regex.Replace(email, sFormato, string.Empty).Length == 0)
                {
                    BorderColor(true, textBox);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                BorderColor(false, textBox);
                return false;
            }
        }
    }
}
