using System;

namespace Medvedev
{
    public interface ICipher 
    {
        void encode();
        void decode();
    }

    public class ACipher : ICipher
    {
        private string text;
        private char[] iv;

        public ACipher(string S)
        {
            text = S;
            iv = text.ToCharArray();
        }

        public void encode()
        {
            for(int i = 0; i < iv.Length; i++)
            {
                iv[i] = (char)(iv[i] + 1);
            }

            text = new string(iv);
            Console.WriteLine(text);
        }

        public void decode()
        {
            for(int k = 0; k < iv.Length; k++)
            {
                iv[k] = (char)(iv[k] - 1); 
            }

            text = new string(iv);
            Console.WriteLine(text);
        }

    }

    public class BCipher : ICipher
    {
        private string text;
        private char[] iv;
        private string key = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public BCipher(string t)
        {
            text = t;
            iv = text.ToCharArray();
        }

        private char Mirror(char c)
        {
            int idx = key.IndexOf(c);
            if(idx >= 0 )
            {
                return key[key.Length - 1 - idx];
            }

            return c;
        }

        private void Transport()
        {
            for(int i =0; i < iv.Length;i++)
            {
                iv[i] = Mirror(iv[i]);
            }

            text = new string(iv);
            Console.WriteLine(text);
        }

        public void encode() { Transport(); }
        public void decode() { Transport(); }
    }

    class Program
    {
        public static void Main()
        {
            Console.Write("ВВедите строку: ");
            string text = Console.ReadLine();

            ACipher AC = new ACipher(text);
            Console.Write("ЗАшифрованный вариант: ");
            AC.encode();
            Console.Write("Расшифрованный вариант: ");
            AC.decode();
            Console.WriteLine();

            BCipher BC = new BCipher(text);
            Console.Write("Втрой вариант зашифровки: ");
            BC.encode();
            Console.Write("Расшифрованный вариант: ");
            BC.decode();
        }
    }
}