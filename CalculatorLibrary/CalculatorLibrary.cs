using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;


namespace CalculatorLibrary
{
    //classe publica
    public class Calculator
    {
        JsonWriter writer;
        //construtor
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculator.json");
           // Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            logFile.AutoFlush = true;
            //Trace.WriteLine("Starting Calculator Log");
            //Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }
        //metodo que conclui o json
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
        public double Operacao(double A, double B, string op)
        {
            //variavel resultado
            double result = double.NaN;//valor vazio
            //cria um objeto em json e nomeia-os
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(A);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(B);
            writer.WritePropertyName("Operation");

            //Switch para digitar uma opção
            switch (op)
            {
                case "a":
                    result = A + B;
                    writer.WriteValue("Add");
                    Trace.WriteLine(String.Format("{0} + {1} = {2}", A, B, result));
                    break;
                case "b":
                    result = A - B;
                    writer.WriteValue("Subtract");
                    Trace.WriteLine(String.Format("{0} - {1} = {2}", A, B, result));
                    break;
                case "c":
                    if (B != 0)
                    {
                        result = A / B;
                        writer.WriteValue("Divide");
                        Trace.WriteLine(String.Format("{0} / {1} = {2}", A, B, result));
                    }
                    break;
                case "d":
                    result = A * B;
                    writer.WriteValue("Multiply");
                    Trace.WriteLine(String.Format("{0} * {1} = {2}", A, B, result));
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            //Guarda o resultado
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

    }
}
