namespace matematicaCompiler.Core
{
    // Tipos de tokens possíveis
    public enum TokenTipo
    {
        Numero,
        Soma,
        Subtracao,
        Multiplicacao,
        Divisao,
        AbreParenteses,
        FechaParenteses,
        Fim
    }

    // Estrutura que representa um token da expressão
    public class Token
    {
        public TokenTipo Tipo { get; set; } // Tipo do token
        public string Valor { get; set; }   // Texto do token

        public Token(TokenTipo tipo, string valor)
        {
            Tipo = tipo;
            Valor = valor;
        }
    }
}
