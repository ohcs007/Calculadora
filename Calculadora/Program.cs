using System;
using CalculatorLibrary;
namespace Calculadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //valor booleano para fim de jogo
            bool fimDeJogo = false;
            //Display da calculadora
            Console.WriteLine("CALCULATOR\r");
            Console.WriteLine("-------------\n");

            //instanciar a classe
            Calculator calculator = new Calculator();
            while (!fimDeJogo) 
            {
                //declarando variaveis
                string num1 = "";
                string num2 = "";
                double result = 0;

                //Entrada do primeiro valor
                Console.WriteLine("Digite o primeiro numero e pressione enter");
                num1 = Console.ReadLine();

                //declara uma variavel e converte para um double, cria um loop no caso de o numero ser diferente de double(procura um numero em uma string e o converte)
                double cleanNum1 = 0;
                while (!double.TryParse(num1, out cleanNum1))
                {
                    Console.WriteLine("Não é um numero valido digite novamente e pressione enter");
                    num1 = Console.ReadLine();
                }

                //Entrada do segundo valor

                //Entrada do primeiro valor
                Console.WriteLine("Digite o segundo numero e pressione enter");
                num2 = Console.ReadLine();

                //declara uma variavel e converte para um double, cria um loop no caso de o numero ser diferente de double(procura um numero em uma string e o converte)
                double cleanNum2 = 0;
                while (!double.TryParse(num2, out cleanNum2))
                {
                    Console.WriteLine("Não é um numero valido digite novamente e pressione enter");
                    num2 = Console.ReadLine();
                }


                //Qual Opcao escolher
                Console.WriteLine("Escolha uma opção da lista abaixo:");
                Console.WriteLine("\ta - Soma");
                Console.WriteLine("\tb - Subtracão");
                Console.WriteLine("\tc - Divisão");
                Console.WriteLine("\td - Multiplicação");
                Console.Write("Qual sua opção?");

                //entrado menu
                string op= Console.ReadLine();

                //tratamento de erros
                try
                {
                    //instanciei uma classe em uma variavel
                    result = calculator.Operacao(cleanNum1, cleanNum2, op);

                    //resultado inexistente
                    //segunda verificacao de erro
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") fimDeJogo = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            calculator.Finish();
            return;
        }
    }
}
