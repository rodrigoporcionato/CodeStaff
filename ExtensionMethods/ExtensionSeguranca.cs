using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtensionMethods
{
    public static class ExtensionSeguranca
    {

        /// <summary>
        /// Valida se senha está no padrão de segurança desejado que é uma letra Maiuscula,(pelo menos), números e no mínimo 8 caracteres
        /// </summary>
        /// <param name="senha"></param>
        /// <returns>true se estiver OK!</returns>
        public static bool ValidaPadraoSenhaSeguranca(this string senha)
        {
            var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{8,}$";
            return Regex.IsMatch(senha, pattern);
        }

    }
}
