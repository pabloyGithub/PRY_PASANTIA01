using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Administracion
{
    public class logicUsuarios
    {
        private static DbPasantiaDataContext db = new DbPasantiaDataContext();

        public static List<TBL_USUARIO> obtenerUsuarios()
        {
            try
            {
                var usuarios = db.TBL_USUARIOs.Where(x => x.usu_status == 'A');
                return usuarios.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static TBL_USUARIO obtenerUsuariosXLogin(string username, string password)
        {
            try
            {
                var usuario = db.TBL_USUARIOs.FirstOrDefault(x => x.usu_status == 'A'
                                                                && x.usu_username.Equals(username.ToUpper()) 
                                                                && x.usu_password.Equals(password.ToUpper()));
                return usuario;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static TBL_USUARIO obtenerUsuariosXUsername(string username)
        {
            try
            {
                var usuario = db.TBL_USUARIOs.FirstOrDefault(x => x.usu_status == 'A'
                                                                && x.usu_username.Equals(username.ToUpper()));
                return usuario;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static bool updateStatusXUsername(TBL_USUARIO user)
        {
            try
            {
                user.usu_status = 'I';
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)            {
                return false;
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
