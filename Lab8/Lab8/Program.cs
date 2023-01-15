using System;

namespace Lab8
{
  class Program
  {
    static void Main(string[] args)
    {
      string login, pas, conpas;

      CheckLogin check = new CheckLogin();

      do
      {
        Console.WriteLine("Login: ");
        login = Console.ReadLine();
        Console.WriteLine("Password: ");
        pas = Console.ReadLine();
        Console.WriteLine("ConfirmPassword: ");
        conpas = Console.ReadLine();
      } while (!check.ResultChek(login, pas, conpas));
    }    
  }
}
