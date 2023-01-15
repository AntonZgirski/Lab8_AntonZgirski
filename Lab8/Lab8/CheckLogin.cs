using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
  public class CheckLogin
  {
    static void CheckValue(string log, string pas, string conpas)
    {     
      bool dig = false;

      char[] ar = log.ToCharArray();
      int i = ar.Length;

      if (ar.Length > 20) throw new WrongLoginException("Login length more than 20 characters!\nTry again!\n");

      foreach (var v in ar)
      {
        if (v == ' ') throw new WrongLoginException("There is a space in the login!\nTry again!\n");
      }

      Array.Clear(ar,0,ar.Length);

      ar = pas.ToCharArray();

      if (ar.Length > 20) throw new WrongPasswordException ("Password length more than 20 characters!\nTry again!\n");

      foreach (var v in ar)
      {
        if (v == ' ') throw new WrongPasswordException("There is a space in the password!\nTry again!\n");
        if (Char.IsDigit(v)) dig = true;
      }

      if (dig != true) throw new WrongPasswordException("Password must contain at least one number!\nTry again!\n");
      
      if (pas != conpas) throw new WrongPasswordException("Password does not match ConfirmPassword!\nTry again!\n");

    }

    public bool ResultChek(string log, string pas, string conpas)
    {
      bool res = false;

      try
      {
        CheckValue(log, pas, conpas);
        res = true;
        Console.WriteLine("Success!");
      }
      catch(WrongLoginException ex)
      {
        Console.WriteLine(ex.LoginMessageException);
      }
      catch (WrongPasswordException ex)
      {
        Console.WriteLine(ex.PasswordMesException);
      }

      return res;
    }
  }

  public class WrongLoginException : Exception
  {
    public WrongLoginException(string message, Exception ex) : base(message,ex)
    {
    }

    public WrongLoginException(string message)
    {
      LoginMessageException = message;
    }
    public string LoginMessageException { get; set; }
  }

  public class WrongPasswordException : Exception
  {
    public WrongPasswordException(string message, Exception ex) : base(message, ex)
    {
    }

    public WrongPasswordException(string message)
    {
      PasswordMesException = message;
    }

    public string PasswordMesException { get; set; }
  }
}
