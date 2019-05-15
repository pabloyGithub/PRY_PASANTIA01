using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DATA;
using LOGIC;

namespace PRY_PASANTIA01.Formularios.Login
{
    public partial class wfmLogin : Form
    {
        #region "Métodos"
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Este campo es obligatorio");
                txtUsername.Focus();
                return false;
            }
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtPaswword.Text))
            {
                errorProvider1.SetError(txtPaswword, "Este campo es obligatorio");
                txtUsername.Focus();
                return false;
            }
            errorProvider1.Clear();

            return true;
        }

        private void borrar()
        {
            txtUsername.Clear();
            txtPaswword.Clear();

        }
        #endregion
        private int verificaLogin = 0; //variable golbal
        public wfmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPaswword.Text;

            if (ValidarCampos())
            {
                TBL_USUARIO _infoUsuario = new TBL_USUARIO();
                _infoUsuario = LOGIC.Administracion.logicUsuarios.obtenerUsuariosXLogin(username, password);
                if (_infoUsuario != null)
                {
                    MessageBox.Show("Bienvenido al Sistema", "Info Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Administracion.wfmPrincipal frmPrincipal = new Administracion.wfmPrincipal();
                    frmPrincipal.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Usuario no existe", "Info Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    borrar();
                    txtUsername.Focus();
                    verificaLogin = verificaLogin + 1;
                    if (verificaLogin == 3)
                    {
                        MessageBox.Show("Supero el número de intentos", "Info Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TBL_USUARIO _infoUser = new TBL_USUARIO();
                        _infoUser = LOGIC.Administracion.logicUsuarios.obtenerUsuariosXUsername(username);
                        if (_infoUser != null)
                        {
                            var result = LOGIC.Administracion.logicUsuarios.updateStatusXUsername(_infoUser);
                            if (result) {
                                MessageBox.Show("Usuario bloqueado\nPor favor comuniquese con el Departamento de Sistemas", "Info Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        Hide();
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
