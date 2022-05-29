using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.RSA
{
    public class RSA
    {
        public int PowerFunction(int Base, int power, int mod)
        {
            ///M^e mod n
            /// mod <- n = p*q
            /// Power <- e
            /// Base <- M
            int result = 1;
            for (int i = 0; i < power; i++)
            {
                result = (result * Base) % mod;
            }
            return result;
        }
        static int gcd(int number, int b)
        {
            int r;

            while (b != 0)
            {
                r = number % b;
                number = b;
                b = r;
            }

            return number;
        }
        public int GetMultiplicativeInverse(int number, int baseN)
        {
            if (gcd(number, baseN) != 1)
                return -1;
            // A1 <- x , A2 <- y , A3 <- m0
            int m0 = baseN;
            int y = 0, x = 1;

            while (number > 1)
            {
                //Q <- A3/B3 , A3 <- number, B3 <- baseN
                int q = number / baseN;

                int t = baseN;

                baseN = number % baseN;
                number = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0)
                x += m0;

            return x;
        }
        public int Encrypt(int p, int q, int M, int e)
        {
            //throw new NotImplementedException();
            int n = p * q;
            int fie_n = (p - 1) * (q - 1);
            //C = M^e mod n 	
            int cipherText = PowerFunction(M, e, n);
            return cipherText;

        }

        public int Decrypt(int p, int q, int C, int e)
        {
            //throw new NotImplementedException();
            // M = C^d mod n
            int n = p * q;
            int fie_n = (p - 1) * (q - 1);
            int d = 0;
            if (gcd(fie_n, e) == 1)
            {
                d = GetMultiplicativeInverse(e, fie_n);
            }
            int plainText = PowerFunction(C, d, n);
            return plainText;
        }
    }
}
