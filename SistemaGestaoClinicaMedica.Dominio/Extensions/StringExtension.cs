using System;

namespace SistemaGestaoClinicaMedica.Dominio.Extensions
{
    public static class StringExtension
    {
        public static bool ToLowerContains(this string str, string busca) => str.ToLower().Contains(busca.ToLower());

        public static bool ToLowerStartsWith(this string str, string busca) => str.ToLower().StartsWith(busca.ToLower());

        public static bool ToLowerEquals(this string str, string busca) => str.ToLower().Equals(busca.ToLower());

        public static bool ValidaCPF(this string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", string.Empty).Replace("-", string.Empty);
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static string FormataCPF(this string cpfSemPontos)
        {
            var cpfComPontos = cpfSemPontos.Trim();
            if (cpfComPontos.Length == 11)
            {
                cpfComPontos = cpfComPontos.Insert(9, "-");
                cpfComPontos = cpfComPontos.Insert(6, ".");
                cpfComPontos = cpfComPontos.Insert(3, ".");
            }

            return cpfComPontos;
        }

        public static string RemoveFormatacaoCPF(this string cpf)
        {
            if (cpf.Contains(".") || cpf.Contains("-"))
                cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);

            return cpf;
        }

        public static string ParaCodigoExame(this Guid id)
        {
            return id.ToString().Substring(0, 8).ToUpper();
        }
    }
}
