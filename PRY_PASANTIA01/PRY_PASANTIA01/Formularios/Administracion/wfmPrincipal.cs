using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRY_PASANTIA01.Administracion
{
    public partial class wfmPrincipal : Form
    {
        #region "Métodos"

        private string VerificarFormularioAbierto()
        {
            string nombreFormAbierto = null;
            Form existe = Application.OpenForms.OfType<Form>().Where(x =>
              x.Name == "frmFormulario1" ||
              x.Name == "frmFormulario2").FirstOrDefault<Form>();
            if (existe != null)
            {
                nombreFormAbierto = existe.Name;
            }
            return nombreFormAbierto;
        }

        #endregion
        public wfmPrincipal()
        {
            InitializeComponent();
        }

        private void wfmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VerificarFormularioAbierto() != null)
            {
                MessageBox.Show(
                    string.Format("Cierre el Formulario {0}", VerificarFormularioAbierto().Remove(0, 3)),
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }

        }

        private void wfmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
