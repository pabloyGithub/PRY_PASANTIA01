using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LOGIC.Complementos
{
    public class encriptMD5
    {
        public static string encriptarMD5(string texto)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(texto);
            byte[] hash = md5.ComputeHash(inputBytes);
            string textoEncriptado = BitConverter.ToString(hash).Replace("-", "");
            return textoEncriptado;
        }
    }
}
