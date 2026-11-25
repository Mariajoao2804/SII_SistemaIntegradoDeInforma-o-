using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Hospital> hospitais = new List<Hospital>();
    static void Main()
    {
        int opcao = -1;
        Console.WriteLine(" SISTEMA 2 - GESTAO DE HOSPITAIS - UIGE");
        CarregarHospitaisDoFicheiro();
        while (opcao != 0)
        {
            Console.WriteLine("\n MENU HOSPITAIS ");
            Console.WriteLine("1. Registar Hospital / Unidade");
            Console.WriteLine("2. Listar Todos os Hospitais");
            Console.WriteLine("3. Pesquisar por Municipio");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha: ");
            if (!int.TryParse(Console.ReadLine(), out opcao)) { Console.WriteLine("Escreve so o numero."); opcao = -1; continue; }
            if (opcao == 1) RegistarHospital();
            else if (opcao == 2) ListarHospitais();
            else if (opcao == 3) PesquisarPorMunicipio();
            else if (opcao == 0) Console.WriteLine("A sair...");
            else Console.WriteLine("Opcao invalida.");
        }
    }
    static void RegistarHospital()
    {
        Console.WriteLine("\n REGISTO DE HOSPITAL ");
        Hospital h = new Hospital();
        Console.Write("Codigo (ex: 1): "); int.TryParse(Console.ReadLine(), out int codigo); h.Codigo = codigo;
        Console.Write("Nome: "); h.Nome = Console.ReadLine();
        Console.Write("Municipio: "); h.Municipio = Console.ReadLine();
        Console.Write("Tipo (Geral, Municipal, Centro de Saude): "); h.Tipo = Console.ReadLine();
        Console.Write("Numero de Camas: "); int.TryParse(Console.ReadLine(), out int camas); h.Camas = camas;
        Console.Write("Director: "); h.Director = Console.ReadLine();
        hospitais.Add(h);
        File.AppendAllText("hospitais.txt", h.Codigo + ";" + h.Nome + ";" + h.Municipio + ";" + h.Tipo + ";" + h.Camas + ";" + h.Director + "\n");
        Console.WriteLine("Hospital registado e partilhado com o Sistema 1!");
    }
    static void ListarHospitais()
    {
        Console.WriteLine("\n LISTA DE HOSPITAIS ");
        if (hospitais.Count == 0) { Console.WriteLine("Nenhum hospital registado."); return; }
        foreach (var h in hospitais) { Console.WriteLine(h.Codigo + " - " + h.Nome + " | " + h.Municipio + " | " + h.Tipo + " | Camas: " + h.Camas); }
    }
    static void PesquisarPorMunicipio()
    {
        Console.Write("Municipio: "); string mun = Console.ReadLine();
        foreach (var h in hospitais) { if (h.Municipio.ToLower() == mun.ToLower()) { Console.WriteLine(h.Codigo + " - " + h.Nome + " | " + h.Tipo); } }
    }
    static void CarregarHospitaisDoFicheiro()
    {
        if (File.Exists("hospitais.txt"))
        {
            string[] linhas = File.ReadAllLines("hospitais.txt");
            foreach (string linha in linhas)
            {
                if (linha == "") continue;
                string[] partes = linha.Split(';');
                Hospital h = new Hospital();
                h.Codigo = int.Parse(partes[0]); h.Nome = partes[1]; h.Municipio = partes[2]; h.Tipo = partes[3]; h.Camas = int.Parse(partes[4]); h.Director = partes[5];
                hospitais.Add(h);
            }
        }
    }
}
class Hospital { public int Codigo; public string Nome; public string Municipio; public string Tipo; public int Camas; public string Director; }
