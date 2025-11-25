using System;
using System.Text;

namespace matematicaCompiler.Core
{
    // O Lexer lê o texto da expressão e transforma em tokens (números, +, -, *, /, etc)
    public class Lexer
    {
        private string _codigo;     // Guarda o código digitado pelo usuário
        private int _posicao;       // Posição atual de leitura no texto

        public Lexer(string codigo)
        {
            _codigo = codigo.Replace(" ", ""); // Remove espaços da expressão
            _posicao = 0;                      // Começa lendo do início
        }

        // Retorna o próximo token encontrado na expressão
        public Token ProximoToken()
        {
            // Se chegou ao fim da string, devolve token de fim
            if (_posicao >= _codigo.Length)
                return new Token(TokenTipo.Fim, "");

            char atual = _codigo[_posicao]; // Caractere atual da leitura

            // Identificação de números (pode ter vários dígitos)
            if (char.IsDigit(atual))
            {
                StringBuilder numero = new StringBuilder();

                // Junta todos os dígitos enquanto forem números
                while (_posicao < _codigo.Length && char.IsDigit(_codigo[_posicao]))
                {
                    numero.Append(_codigo[_posicao++]);
                }

                return new Token(TokenTipo.Numero, numero.ToString());
            }

            // Identifica operadores
            if (atual == '+') { _posicao++; return new Token(TokenTipo.Soma, "+"); }
            if (atual == '-') { _posicao++; return new Token(TokenTipo.Subtracao, "-"); }
            if (atual == '*') { _posicao++; return new Token(TokenTipo.Multiplicacao, "*"); }
            if (atual == '/') { _posicao++; return new Token(TokenTipo.Divisao, "/"); }
            if (atual == '(') { _posicao++; return new Token(TokenTipo.AbreParenteses, "("); }
            if (atual == ')') { _posicao++; return new Token(TokenTipo.FechaParenteses, ")"); }

            // Caso encontre algo inválido
            throw new Exception($"Caractere inválido: {atual}");
        }
    }
}
