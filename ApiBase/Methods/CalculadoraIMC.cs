using ApiBase.Models;

namespace ApiBase.Methods
{
    public class CalculadoraIMC
    {
        public static string CalcularIMC(Pessoas pessoa)
        {

            if (pessoa is not null)
            {
                var imc = pessoa.Peso / (pessoa.Altura * pessoa.Altura);


                if (imc < 18.5)
                    return $"IMC: {imc} - Magreza";
                else if (imc < 24.9)
                    return $"IMC: {imc} - Normal";
                else if (imc < 29.9)
                    return $"IMC: {imc} - Sobrepeso";
                else if (imc < 34.9)
                    return $"IMC: {imc} - Obesidade Grau I";
                else if (imc < 39.9)
                    return $"IMC: {imc} - Obesidade Grau II";
                else
                    return $"IMC: {imc} - Obseidade Grau III";
            }
            else
                return "Pessoa não cadastrada";
        }
    }
}
