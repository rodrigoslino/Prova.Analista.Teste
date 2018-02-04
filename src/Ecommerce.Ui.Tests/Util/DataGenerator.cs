using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Ui.Tests.Util
{
    /// <summary>
    ///     Gerador de tipos de dados randomicos
    /// </summary>
    public static class DataGenerator
    {
        private const int MIN_EMAIL_LENGTH = MIN_EMAIL_USERPART_LENGTH + 1 + MIN_HOST_LENGTH;
        private const int MAX_EMAIL_LENGTH = 64;
        private const int MIN_EMAIL_USERPART_LENGTH = 1;
        private const int MAX_EMAIL_USERPART_LENGTH = MAX_EMAIL_LENGTH / 2;
        private const int MIN_HOST_LENGTH = 1 + 1 + MAX_TLD_LENGTH;
        private const int MAX_HOST_LENGTH = 253;
        private const int MAX_HOST_PART_LENGTH = 63;
        private const int MAX_HOST_PARTS = 127;
        private const int MIN_URL_LENGTH = MAX_SCHEME_LENGTH + 3 + MIN_HOST_LENGTH;
        private const int MAX_URL_LENGTH = 4096;
        private const int MAX_URL_PORT_NUMBER = 65535;
        private const int MAX_URL_REST_PART_LENGTH = 1024;
        private const int MAX_SCHEME_LENGTH = 6;
        private const int MAX_TLD_LENGTH = 6;
        private static readonly string[] topLevelDomains = new[] { "org" };
        private static readonly string[] urlSchemes = new[] { "ftp", "gopher", "http", "https", "ssh", "telnet", "wais" };
        private static readonly Random Random = new Random();

        #region Character set arrays

        private static readonly char[] CHARS_ALPHANUM;
        private static readonly char[] CHARS_ENGLISH_ALPHANUM;
        private static readonly char[] CHARS_ENGLISH_ALPHA;
        private static readonly char[] CHARS_ALPHA_UPPER = new[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
            'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
            'Y', 'Z'
        };
        private static readonly char[] CHARS_ALPHA_LOWER = new[]
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
            'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z'
        };
        private static readonly char[] CHARS_CHINESE = new[]
        {
            '健', '康','繁','荣'
        };
        private static readonly char[] CHARS_CYRILLIC = new[]
        {
            'И', 'в', 'а', 'н', 'Ч', 'е', 'т', 'ё', 'р', 'ы', 'й', 'с', 'и', 'л', 'ь', 'ч'
        };
        private static readonly char[] CHARS_NUM = new[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        #endregion

        static DataGenerator()
        {
            List<char> tempCharset;

            tempCharset = new List<char>();
            tempCharset.AddRange(CHARS_ALPHA_UPPER);
            tempCharset.AddRange(CHARS_ALPHA_LOWER);
            tempCharset.AddRange(CHARS_CHINESE);
            tempCharset.AddRange(CHARS_CYRILLIC);
            tempCharset.AddRange(CHARS_NUM);
            CHARS_ALPHANUM = tempCharset.ToArray();

            tempCharset = new List<char>();
            tempCharset.AddRange(CHARS_ALPHA_UPPER);
            tempCharset.AddRange(CHARS_ALPHA_LOWER);
            CHARS_ENGLISH_ALPHA = tempCharset.ToArray();

            tempCharset = new List<char>();
            tempCharset.AddRange(CHARS_ALPHA_UPPER);
            tempCharset.AddRange(CHARS_ALPHA_LOWER);
            tempCharset.AddRange(CHARS_NUM);
            CHARS_ENGLISH_ALPHANUM = tempCharset.ToArray();
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static string RandomStringNumber(int length)
        {
            const string chars = "123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static long RandomPhoneNumber()
        {
            var length = 8;
            const string chars = "123456789";
            var result = "";
            result += new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());

            return Convert.ToInt64(result);
        }

        public static long RandomMobileNumber()
        {
            var length = 9;
            const string chars = "123456789";
            var result = "";
            result += new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());

            return Convert.ToInt64(result);
        }

        public static string RandomCpf()
        {
            int soma = 0;
            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var rnd = new Random();
            var semente = rnd.Next(100000000, 999999999).ToString();

            for (var i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (var i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }

        public static string RandomCnpj()
        {
            return RandomCnpj(false);
        }

        public static string RandomCnpj(bool comPontos)
        {
            int n1 = Random.Next(0, 9);
            int n2 = Random.Next(0, 9);
            int n3 = Random.Next(0, 9);
            int n4 = Random.Next(0, 9);
            int n5 = Random.Next(0, 9);
            int n6 = Random.Next(0, 9);
            int n7 = Random.Next(0, 9);
            int n8 = Random.Next(0, 9);
            int n9 = 0;
            int n10 = 0;
            int n11 = 0;
            int n12 = 1;
            int d1 = n12 * 2 + n11 * 3 + n10 * 4 + n9 * 5 + n8 * 6 + n7 * 7 + n6 * 8 + n5 * 9 + n4 * 2 + n3 * 3 + n2 * 4 + n1 * 5;

            d1 = 11 - (d1 % 11);

            if (d1 >= 10)
                d1 = 0;

            int d2 = d1 * 2 + n12 * 3 + n11 * 4 + n10 * 5 + n9 * 6 + n8 * 7 + n7 * 8 + n6 * 9 + n5 * 2 + n4 * 3 + n3 * 4 + n2 * 5 + n1 * 6;

            d2 = 11 - (d2 % 11);

            if (d2 >= 10)
                d2 = 0;

            string retorno;

            if (comPontos)
                retorno = "" + n1 + n2 + "." + n3 + n4 + n5 + "." + n6 + n7 + n8 + "/" + n9 + n10 + n11 + n12 + "-" + d1 +
                          d2;
            else
                retorno = "" + n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10 + n11 + n12 + d1 + d2;

            return retorno;
        }

        /// <summary>
        /// Generate and return a random email address with a valid top level domain, 
        /// evenly distributed in length and value.
        /// </summary>
        /// <returns>The email address</returns>
        public static string RandomEmailAddress()
        {
            return RandomEmailAddress(MAX_EMAIL_LENGTH);
        }

        /// <summary>
        /// Generate and return a random email address with a valid top level domain, 
        /// up to the specified length, evenly distributed in length and value.
        /// </summary>
        /// <param name="maxAddrLength">The maximum length to return.</param>
        /// <returns>The email address</returns>
        public static string RandomEmailAddress(int maxAddrLength)
        {
            // ServiceDesk erroneously thinks email address user-parts have a very restricted character set.
            // This is the validation pattern from SSJS/inc/Validation.js:
            //      /^[A-Z0-9._%'-]+@[A-Z0-9._%-]+\.[A-Z]{2,4}$/i
            // We also omit "." because it really isn't allowed at the start or end of a local-part, and I don't feel
            // like duplicating the RandomHostName() label-loop code here right now.
            char[] userPartCharset = new[] {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
                'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
                'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                '_', '%', '\'', '-'
            };
            int maxLength = RandomInteger(MIN_EMAIL_LENGTH, Math.Min(maxAddrLength, MAX_EMAIL_LENGTH));
            int remainingLength = maxLength - (MIN_HOST_LENGTH + 1);
            string result = Random.NextString(userPartCharset, MIN_EMAIL_USERPART_LENGTH, Math.Min(remainingLength, MAX_EMAIL_USERPART_LENGTH)) + '@';
            remainingLength = maxLength - result.Length;
            result += RandomHostName(remainingLength);
            remainingLength = maxLength - result.Length;

            if (result.Length > maxLength)
            {
                throw new Exception($"Illegal value produced. maxAddrLength={maxAddrLength}; maxLength={maxLength}; result.Length={result.Length}; remainingLength={remainingLength}; value={result}");
            }

            return result;
        }

        /// <summary>
        /// Generate and return a random hostname with a valid top level domain,
        /// evenly distributed in length and value.
        /// </summary>
        /// <returns>The hostname.</returns>
        public static string RandomHostName()
        {
            return RandomHostName(MAX_HOST_LENGTH);
        }

        /// <summary>
        /// Generate and return a random hostname with a valid top level domain,
        /// up to the specified length, evenly distributed in length and value.
        /// </summary>
        /// <param name="maxHostNameLength">The maximum length to return.</param>
        /// <returns>The hostname.</returns>
        public static string RandomHostName(int maxHostNameLength)
        {
            int maxLength = RandomInteger(MIN_HOST_LENGTH, Math.Min(maxHostNameLength, MAX_HOST_LENGTH));
            int hostPartCount = RandomInteger(1, MAX_HOST_PARTS);
            string result = Random.NextChoice(topLevelDomains);
            int remainingLength = maxLength - result.Length;

            for (int i = 0; i < hostPartCount && remainingLength >= 2; i++)
            {
                string hostPart = Random.NextChoice(CHARS_ENGLISH_ALPHA) +
                                  Random.NextString(CHARS_ENGLISH_ALPHANUM, 0,
                                      Math.Min(remainingLength, MAX_HOST_PART_LENGTH) - 2) +
                                  '.';
                result = hostPart + result;
                remainingLength = maxLength - result.Length;
            }

            if (result.Length > maxLength)
            {
                throw new Exception($"Illegal value produced. maxHostNameLength={maxHostNameLength}; maxLength={maxLength}; length={result.Length}; value={result}");
            }

            return result;
        }

        /// <summary>
        /// Generate and return an integer between Int32.MinValue and Int32.MaxValue inclusive, evenly distributed.
        /// </summary>
        /// <returns>The value</returns>
        public static int RandomInteger()
        {
            return RandomInteger(Int32.MinValue, Int32.MaxValue);
        }

        /// <summary>
        /// Generate and return an integer within the value range (if any) inclusive, evenly distributed.
        /// </summary>
        /// <param name="min">The minimum value, or null for Int32.MinValue</param>
        /// <param name="max">The maximum value, or null for Int32.MaxValue</param>
        /// <returns>The value</returns>
        public static int RandomInteger(int min, int max)
        {
            if (max < Int32.MaxValue)
            {
                max++;  // Because Random.Next() returns min through max-1.
            }

            if (min > max)
            {
                throw new Exception($"Minimum value {min} greater than maximum value {max}.");
            }

            int result = Random.Next(min, max);

            return result;
        }

        /// <summary>
        /// Generate and return a random URL with a valid scheme, port, and top level domain,
        /// evenly distributed in length and value.
        /// </summary>
        /// <returns>The URL.</returns>
        public static string RandomUrl(int maxUrlLength)
        {
            string result = Random.NextChoice(urlSchemes) + "://";
            bool includePort = Random.NextBool();
            int maxLength = RandomInteger(MIN_URL_LENGTH + (includePort ? 6 : 0), Math.Min(maxUrlLength, MAX_URL_LENGTH));
            int remainingLength = maxLength - result.Length - (includePort ? 6 : 0);
            result += RandomHostName(remainingLength);
            result += (includePort ? ":" + RandomInteger(1, MAX_URL_PORT_NUMBER) : "");
            remainingLength = maxLength - result.Length;

            if (remainingLength > 0)
            {
                result += '/';
                remainingLength = maxLength - result.Length;
            }

            if (remainingLength > 0)
            {
                result += Random.NextString(CHARS_ALPHANUM, 1, Math.Min(remainingLength, MAX_URL_REST_PART_LENGTH));
            }

            if (result.Length > maxLength)
            {
                throw new Exception($"Illegal value produced. maxUrlLength={maxUrlLength}; maxLength={maxLength}; length={result.Length}; value={result}");
            }

            return result;
        }
    }

    public static class RandomExtensions
    {
        /// <summary>
        /// Returns a random true or false value.
        /// </summary>
        /// <param name="random">The Random instance.</param>
        /// <returns>True or false.</returns>
        public static bool NextBool(this Random random)
        {
            return random.Next(0, 2) == 1;
        }

        /// <summary>
        /// Returns a random item from the specified collection of items.
        /// </summary>
        /// <param name="random">The Random instance.</param>
        /// <param name="collection">The items to select from.</param>
        /// <returns>The item.</returns>
        public static DataType NextChoice<DataType>(this Random random, IList<DataType> collection)
        {
            if (collection == null || collection.Count == 0)
            {
                throw new Exception("There are no values.");
            }

            var item = collection[random.Next(0, collection.Count)];

            return item;
        }

        /// <summary>
        /// Returns a random string of up to the specified number of characters from the specified set.
        /// </summary>
        /// <param name="random">The Random instance.</param>
        /// <param name="validChars">The characters to select from.</param>
        /// <param name="minLength">The minimum length of the string.</param>
        /// <param name="maxLength">The maximum length of the string.</param>
        /// <returns>The string.</returns>
        public static string NextString(this Random random, char[] validChars, int minLength, int maxLength)
        {
            if (minLength > maxLength)
            {
                return "";
            }

            StringBuilder result = new StringBuilder("");
            int length = random.Next(minLength, maxLength);

            for (int i = 0; i < length; i++)
            {
                result.Append(random.NextChoice(validChars));
            }

            if (result.Length > maxLength)
            {
                throw new Exception($"Illegal value produced. maxLength={maxLength}; result.Length={result.Length}; value={result}");
            }

            return result.ToString();
        }
    }
}