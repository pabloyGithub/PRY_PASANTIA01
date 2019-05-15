using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using System.Data.Linq;

namespace LOGIC.Administracion
{
    public class logicEmpresa
    {
        private static DbPasantiaDataContext db = new DbPasantiaDataContext();

        public List<TBL_EMPRESA> obtenerEmpresas()
        {
            try
            {
                var empresas = db.TBL_EMPRESAs.Where(x => x.emp_status == 'A');
                return empresas.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public List<TBL_EMPRESA> obtenerEmpresas(int codigoEmpresa)
        {
            try
            {
                var empresas = db.TBL_EMPRESAs.Where(x => x.emp_status == 'A' && x.emp_id.Equals(codigoEmpresa));
                return empresas.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public bool saveEmpresa(TBL_EMPRESA empresa)
        {
            try
            {
                db.TBL_EMPRESAs.InsertOnSubmit(empresa);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
