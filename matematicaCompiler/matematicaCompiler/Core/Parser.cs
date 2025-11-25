using System;

namespace matematicaCompiler.Core
{
    // O Parser interpreta os tokens e calcula o resultado
    public class Parser
    {
        private Lexer _lexer;   // Fonte dos tokens
        private Token _atual;   // Token atual sendo analisado

        public Parser(Lexer lexer)
        {
            _lexer = lexer;
            _atual = _lexer.ProximoToken(); // Começa pegando o 1º token
        }

        // Verifica se o token atual é o esperado e avança
        private void Consumir(TokenTipo tipoEsperado)
        {
            if (_atual.Tipo == tipoEsperado)
            {
                _atual = _lexer.ProximoToken(); // Avança para o próximo token
            }
            else
            {
                throw new Exception($"Erro de sintaxe: esperado {tipoEsperado}, encontrado {_atual.Tipo}");
            }
        }

        // Trata soma e subtração (nível mais externo da expressão)
        public double Expressao()
        {
            double resultado = Termo(); // Começa por um termo

            // Enquanto houver + ou -, continua calculando
            while (_atual.Tipo == TokenTipo.Soma || _atual.Tipo == TokenTipo.Subtracao)
            {
                if (_atual.Tipo == TokenTipo.Soma)
                {
                    Consumir(TokenTipo.Soma);
                    resultado += Termo();
                }
                else
                {
                    Consumir(TokenTipo.Subtracao);
                    resultado -= Termo();
                }
            }

            return resultado;
        }

        // Trata multiplicação e divisão
        private double Termo()
        {
            double resultado = Fator();

            while (_atual.Tipo == TokenTipo.Multiplicacao || _atual.Tipo == TokenTipo.Divisao)
            {
                if (_atual.Tipo == TokenTipo.Multiplicacao)
                {
                    Consumir(TokenTipo.Multiplicacao);
                    resultado *= Fator();
                }
                else
                {
                    Consumir(TokenTipo.Divisao);
                    double divisor = Fator();

                    if (divisor == 0)
                        throw new Exception("Erro: divisão por zero!");

                    resultado /= divisor;
                }
            }

            return resultado;
        }

        // Trata números e expressões entre parênteses
        private double Fator()
        {
            // Se for número, converte e consome
            if (_atual.Tipo == TokenTipo.Numero)
            {
                double valor = double.Parse(_atual.Valor);
                Consumir(TokenTipo.Numero);
                return valor;
            }
            // Se for parênteses, resolve a expressão interna
            else if (_atual.Tipo == TokenTipo.AbreParenteses)
            {
                Consumir(TokenTipo.AbreParenteses);
                double valor = Expressao();
                Consumir(TokenTipo.FechaParenteses);
                return valor;
            }

            throw new Exception($"Erro de sintaxe: token inesperado {_atual.Tipo}");
        }
    }
}
