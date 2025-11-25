using System;

namespace matematicaCompiler.Visual
{
    public static class Animacoes
    {
        // Texto com efeito de digitação
        public static void EscreverLento(string texto, int delay = 30)
        {
            foreach (char c in texto)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        // Animação "carregando"
        public static void Carregando(string mensagem, int duracao = 2000)
        {
            string[] animacao = { "|", "/", "-", "\\" };
            int i = 0;
            DateTime fim = DateTime.Now.AddMilliseconds(duracao);

            while (DateTime.Now < fim)
            {
                Console.Write($"\r{mensagem} {animacao[i++ % animacao.Length]}");
                System.Threading.Thread.Sleep(100);
            }

            Console.Write("\r" + new string(' ', mensagem.Length + 2) + "\r");
        }

        // Banner de abertura
        public static void MostrarBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            EscreverLento("╔═══════════════════════════════════════════════════╗", 1);
            EscreverLento("║       COMPILADOR DE EXPRESSÕES MATEMÁTICAS        ║", 1);
            EscreverLento("║          Desenvolvido por MATEUS BRUN 💻          ║", 1);
            EscreverLento("╚═══════════════════════════════════════════════════╝", 1);
            Console.ResetColor();

            Console.WriteLine("\nAceita +, -, *, / e ().");
            Console.WriteLine("Digite 'sair' para encerrar.");
            Console.WriteLine("-------------------------------------------------------");
        }

        public static void MostrarResultado(double resultado)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Beep(800, 150);
            Console.WriteLine($"Resultado: {resultado}");
            Console.ResetColor();
        }

        public static void MostrarErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Beep(300, 200);
            Console.WriteLine($"Erro: {mensagem}");
            Console.ResetColor();
        }
    }
}
