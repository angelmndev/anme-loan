using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace Presentacion.MyLibrary
{
    class style
    {
        public void tabPageModif(RadPageView nombre)
        {
            TabVsShape shape = new TabVsShape();
            shape.RightToLeft = true;
            foreach (RadPageViewPage p in nombre.Pages)
            {
                p.Item.Shape = shape;
                p.Item.MinSize = new Size(65, 0);
                p.Item.BackColor2 = Color.White;
                p.Item.BackColor3 = Color.White;
                p.Item.BorderColor = Color.FromArgb(255, 0, 54);
                p.Item.FocusBorderColor = Color.FromArgb(255, 0, 54);
                p.Item.ForeColor = Color.Black;

            }
        }

        public void rowStyle(object sender, RowCellStyleEventArgs e)
        {
            
            //cambiar de color de fila seleccionado
            GridView view = sender as GridView;
            
            if (view.FocusedRowHandle == e.RowHandle && !view.FocusedColumn.Equals(e.Column))
                e.Appearance.BackColor = Color.FromArgb(133, 146, 158);

            //cambiar el color de la fila filter188, 201, 203
            if (e.RowHandle == GridControl.AutoFilterRowHandle)
                e.Appearance.BackColor = Color.Transparent;
                e.Appearance.ForeColor = Color.Black;          
        }

        //elimina el boton de exit de "rDock"
        public void DockStyle(RadDock nameRDock,DocumentWindow nameDWindow)
        {
            foreach (DockWindow item in nameRDock.DockWindows)
            {
                if (item is DocumentWindow)
                {
                    item.DocumentButtons = DocumentStripButtons.ActiveWindowList;           
                }

            }
            nameDWindow.AllowedDockState = AllowedDockState.TabbedDocument;
        }



        public  void gridNavegador(GridControl nameGrid)
        {
            ControlNavigator navigator = nameGrid.EmbeddedNavigator;
            navigator.Buttons.BeginUpdate();
            try
            {
                navigator.Buttons.Append.Visible = false;
                navigator.Buttons.Remove.Visible = false;
            }
            finally
            {
                navigator.Buttons.EndUpdate();
            }
        }

    }
}
