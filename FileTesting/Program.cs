using System;
using System.IO;

namespace FileTesting
{
  class Program
  {
    static void Main(string[] args)
    {
      
      var fileName = $"C:\\Users\\manoel.vitor\\Desktop\\teste\\teste.txt";

      if (!File.Exists(fileName)) return;

        FileStream fs = File.Open(fileName, FileMode.Open);
      var byteRed= fs.ReadByte();

      //O Scream reader vai facilitar batante leitura de arquivos, 
      //Com vários construtores, posso criar uma stream de leitura facilmente.
      StreamReader leitor = new StreamReader(fs);

      string linha = leitor.ReadLine();

      while (linha != null)
      {
        Console.WriteLine(linha);

        linha = leitor.ReadLine();
      }

      fs.Close();
      leitor.Close();

      //Muito mais fácil criar um streamreader direto de um arquivo de leitura, para depois só ler as linhas
      StreamReader segundoLeitor = new StreamReader(fileName);

      Console.WriteLine("Lendo a segunda linha agora....");
      linha = segundoLeitor.ReadLine();
      var conteudoCompleto = segundoLeitor.ReadToEnd();

      while (linha != null)
      {
        Console.WriteLine(linha);
        linha = segundoLeitor.ReadLine();
      }

      segundoLeitor.Close();

      //Writing Files
      Stream saida = File.Open(fileName + "2", FileMode.Create);

      StreamWriter streamWriter = new StreamWriter(saida);
      streamWriter.Close();

      StreamWriter streamWriter2 = new StreamWriter(fileName + "2");
      streamWriter2.WriteLine("Testando");
      streamWriter2.WriteLine("Testand2");
      streamWriter2.Close();


    }
  }
}
