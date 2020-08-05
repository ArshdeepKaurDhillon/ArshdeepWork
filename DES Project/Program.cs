using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ForDES
{
    class Program
    {
        static void Main(string[] args)
        {

        var text = "Hi my Name is Arsh";
        var encryptedText = For3DES.Encrypt(text);
        var decryptedText = For3DES.Decrypt(encryptedText);
        Console.WriteLine("Before Encryption Text = " + text);
        Console.WriteLine("After Encryption Text = " + encryptedText);
        Console.WriteLine("After Decryption Text = " + decryptedText);
        Console.ReadLine();
        

        }
    }
}
