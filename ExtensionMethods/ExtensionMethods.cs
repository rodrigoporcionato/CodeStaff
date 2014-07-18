public static class ExtensionMethods 
    {
        public static string Valida(this string value) {

            return string.Format("{0}-", value);
        }

        /// <summary>
        /// valida é null ou falso
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {

            if (string.IsNullOrEmpty(value)) throw new InvalidOperationException(value);

            return true;
        }

        public static string RetornaCEP(this string cep) {

            cep.IsNullOrEmpty();

            return string.Format("{0}-{1}", cep.Substring(0,5), cep.Substring(0,5));
        }
    }