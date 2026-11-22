using System;
using System.Collections.Generic;

class Program
{
  
    static List<Paciente> pacientes = new List<Paciente>();
    static List<Consulta> consultas = new List<Consulta>();
    static int proximoRegisto = 1001;

    static void Main()
    {
        int opcao = -1;

        Console.WriteLine(" SISTEMA INTEGRADO DE INFORMACAO - UÍGE");
        Console.WriteLine(" Hospitais e Unidades de Saude da Provincia");

        while (opcao != 0)
        {
            Console.WriteLine("\n MENU ");
            Console.WriteLine("1. Registar Paciente");
            Console.WriteLine("2. Registar Consulta");
            Console.WriteLine("3. Consultar Historico Clinico");
            Console.WriteLine("4. Listar Todos os Utentes");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha: ");

            
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Por favor escreve só o numero da opcao.");
                opcao = -1;
                continue;
            }

            if (opcao == 1)
            {
                RegistarPaciente();
            }
            else if (opcao == 2)
            {
                RegistarConsulta();
            }
            else if (opcao == 3)
            {
                ConsultarHistorico();
            }
            else if (opcao == 4)
            {
                ListarPaciente();
            }
            else if (opcao == 0)
            {
                Console.WriteLine("A sair... Obrigado!");
            }
            else
            {
                Console.WriteLine("Opcao invalida, tenta de novo.");
            }
        }
    }

    static void RegistarPaciente()
    {
        Console.WriteLine("\n REGISTO DE PACIENTE ");

        Paciente p = new Paciente();
        p.NumeroRegisto = proximoRegisto;
        proximoRegisto++;

        Console.Write("Nome completo: ");
        p.Nome = Console.ReadLine();

        Console.Write("NIF: ");
        p.Nif = Console.ReadLine();

        Console.Write("Idade: ");
        int.TryParse(Console.ReadLine(), out int idade);
        p.Idade = idade;

        Console.Write("Hospital / Unidade Hospitalar: ");
        p.HospitalOrigem = Console.ReadLine();

        pacientes.Add(p);

        Console.WriteLine("\nPaciente registado com sucesso!");
        Console.WriteLine("Numero de Registo: " + p.NumeroRegisto);
    }

    static void RegistarConsulta()
    {
        Console.WriteLine("\n REGISTAR CONSULTA ");
        Console.Write("Numero de Registo do Paciente: ");
        int.TryParse(Console.ReadLine(), out int numero);

        Paciente encontrado = null;
        foreach (var item in pacientes)
        {
            if (item.NumeroRegisto == numero)
            {
                encontrado = item;
                break;
            }
        }

        if (encontrado == null)
        {
            Console.WriteLine("Paciente nao encontrado!");
            return;
        }

        Console.WriteLine("Paciente: " + encontrado.Nome);

        Consulta c = new Consulta();
        c.NumeroRegistoUtente = numero;

        Console.Write("Data da consulta (ex: 01/11/2020): ");
        c.Data = Console.ReadLine();

        Console.Write("Hospital onde foi atendido: ");
        c.Hospital = Console.ReadLine();

        Console.Write("Nome do medico: ");
        c.Medico = Console.ReadLine();

        Console.Write("Diagnostico: ");
        c.Diagnostico = Console.ReadLine();

        consultas.Add(c);
        Console.WriteLine("\nConsulta registada!");
    }

    static void ConsultarHistorico()
    {
        Console.WriteLine("\nCONSULTAR HISTORICO CLINICO");
        Console.Write("Numero de Registo: ");
        int.TryParse(Console.ReadLine(), out int numero);

        Paciente pacienteEncontrado = null;
        foreach (var item in pacientes)
        {
            if (item.NumeroRegisto == numero)
            {
                pacienteEncontrado = item;
                break;
            }
        }

        if (pacienteEncontrado == null)
        {
            Console.WriteLine("Paciente nao encontrado!");
            return;
        }

        Console.WriteLine("\nPaciente: " + pacienteEncontrado.Nome);
        Console.WriteLine("NIF: " + pacienteEncontrado.Nif + " | Idade: " + pacienteEncontrado.Idade);
        Console.WriteLine("Hospital de origem: " + pacienteEncontrado.HospitalOrigem);

        Console.WriteLine("\n      Historico (visivel em todos os hospitais)    ");
        bool temConsulta = false;
        foreach (var cons in consultas)
        {
            if (cons.NumeroRegistoUtente == numero)
            {
                Console.WriteLine("Data: " + cons.Data + " | Hospital: " + cons.Hospital + " | Medico: " + cons.Medico + " | Diagnostico: " + cons.Diagnostico);
                temConsulta = true;
            }
        }

        if (!temConsulta)
        {
            Console.WriteLine("Nenhuma consulta registada ainda.");
        }
    }

    static void ListarPaciente()
    {
        Console.WriteLine("\n      LISTA DE TODOS OS UTENTES    ");

        if (pacientes.Count == 0)
        {
            Console.WriteLine("Nenhum paciente registado ainda.");
            return;
        }

        foreach (var u in pacientes)
        {
            Console.WriteLine(u.NumeroRegisto + " - " + u.Nome + " | NIF: " + u.Nif + " | Hospital: " + u.HospitalOrigem);
        }

        Console.WriteLine("\nTotal de pacientes: " + pacientes.Count);
    }
}

// Classe simples para o utente
class Paciente
{
    public int NumeroRegisto;
    public string Nome;
    public string Nif;
    public int Idade;
    public string HospitalOrigem;
}

// Classe simples para a consulta
class Consulta
{
    public int NumeroRegistoUtente;
    public string Data;
    public string Hospital;
    public string Medico;
    public string Diagnostico;
}

