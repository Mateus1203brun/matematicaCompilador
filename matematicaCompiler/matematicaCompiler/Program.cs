using matematicaCompiler.Core;
using matematicaCompiler.Visual;
using System;

namespace matematicaCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Animacoes.MostrarBanner(); 

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nDigite uma expressão (ou 'sair'): ");
                Console.ResetColor();

                string codigoFonte = Console.ReadLine()?.Trim();

                // Se digitar "sair", encerra
                if (codigoFonte?.ToLower() == "sair")
                {
                    Animacoes.EscreverLento("\nEncerrando o compilador... Até logo!", 30);
                    break;
                }

                // Impede expressão vazia
                if (string.IsNullOrEmpty(codigoFonte))
                {
                    Console.WriteLine("Expressão vazia. Tente novamente.");
                    continue;
                }

                try
                {
                    Animacoes.Carregando("Calculando");

                    // Cria lexer e parser
                    Lexer lexer = new Lexer(codigoFonte);
                    Parser parser = new Parser(lexer);

                    // Calcula o resultado
                    double resultado = parser.Expressao();

                    Animacoes.MostrarResultado(resultado);
                }
                catch (Exception ex)
                {
                    // Quando ocorre erro de sintaxe ou outro erro
                    Animacoes.MostrarErro(ex.Message);
                }
            }
        }
    }
}
