//--------------------------------------------------------------------------------------------------------
// Project: PracticalCodingTest
// Author: Jason Peixoto
// Version: v1.0
// Copyright: IOTEcoSystem
// May not use this code without granted permission from Jason Peixoto
//--------------------------------------------------------------------------------------------------------
using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace PracticalCodingTest.Helpers
{
    public static class Extentions
    {
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T GetObject<T>()
        {
            if (typeof(T).IsValueType || typeof(T) == typeof(string))
            {
                return default(T);
            }
            return (T)Activator.CreateInstance(typeof(T));
        }

        /// <summary>
        /// Ises the valid email.
        /// </summary>
        /// <returns><c>true</c>, if valid email was ised, <c>false</c> otherwise.</returns>
        /// <param name="email">Email.</param>
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Ises the password strong.
        /// </summary>
        /// <returns><c>true</c>, if password strong was ised, <c>false</c> otherwise.</returns>
        /// <param name="password">Password.</param>
        public static bool IsPasswordStrong(this string password)
        {
            if (string.IsNullOrEmpty(password)) return false;
            if (!password.ValidatePassword()) return false;
            if (password.HasConsecutiveChars()) return false;
            return true;
        }

        /// <summary>
        /// Validates the password.
        /// </summary>
        /// <returns><c>true</c>, if password was validated, <c>false</c> otherwise.</returns>
        /// <param name="password">Password.</param>
        public static bool ValidatePassword(this string password, int MIN_LENGTH = 5, int MAX_LENGTH = 12)
        {
            if (password == null) return false;
            return password.MeetsLengthRequirements(MIN_LENGTH, MAX_LENGTH)
                        && password.HasUpperCaseLetter()
                        && password.HasLowerCaseLetter()
                        && password.HasDecimalDigit();

        }

        /// <summary>
        /// Meetses the length requirements.
        /// </summary>
        /// <returns><c>true</c>, if length requirements was meetsed, <c>false</c> otherwise.</returns>
        /// <param name="password">Password.</param>
        public static bool MeetsLengthRequirements(this string password, int MIN_LENGTH = 5, int MAX_LENGTH = 12)
        {
            if (password == null) return false;
            return password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
        }

        /// <summary>
        /// Hases the upper case letter.
        /// </summary>
        /// <returns><c>true</c>, if upper case letter was hased, <c>false</c> otherwise.</returns>
        /// <param name="password">Password.</param>
        public static bool HasUpperCaseLetter(this string password)
        {
            if (password == null) return false;
            bool hasUpperCaseLetter = false;
            if (password == null) return false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpperCaseLetter = true;
            }

            return hasUpperCaseLetter;
        }

        /// <summary>
        /// Hases the lower case letter.
        /// </summary>
        /// <returns><c>true</c>, if lower case letter was hased, <c>false</c> otherwise.</returns>
        /// <param name="password">Password.</param>
        public static bool HasLowerCaseLetter(this string password)
        {
            if (password == null) return false;
            bool hasLowerCaseLetter = false;
            if (password == null) return false;
            foreach (char c in password)
            {
                if (char.IsLower(c)) hasLowerCaseLetter = true;
            }

            return hasLowerCaseLetter; 
        }

        /// <summary>
        /// Hases the decimal digit.
        /// </summary>
        /// <returns><c>true</c>, if decimal digit was hased, <c>false</c> otherwise.</returns>
        /// <param name="password">Password.</param>
        public static bool HasDecimalDigit(this string password)
        {
            if (password == null) return false;
            bool hasDecimalDigit = false;
            if (password == null) return false;
            foreach (char c in password)
            {
                if (char.IsDigit(c)) hasDecimalDigit = true;
            }

            return hasDecimalDigit; 
        }

        /// <summary>
        /// Hases the consecutive chars.
        /// </summary>
        /// <returns><c>true</c>, if consecutive chars was hased, <c>false</c> otherwise.</returns>
        /// <param name="source">Source.</param>
        /// <param name="sequenceLength">Sequence length.</param>
        public static bool HasConsecutiveChars(this string password)
        {
            if (password == null) return false;
            var charEnumerator = StringInfo.GetTextElementEnumerator(password);
            var currentElement = string.Empty;
            int count = 1;
            while (charEnumerator.MoveNext())
            {
                if (currentElement == charEnumerator.GetTextElement())
                {
                    if (++count >= 1)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 1;
                    currentElement = charEnumerator.GetTextElement();
                }
            }
            return false;
        }

        /// <summary>
        /// Passwords the encrypt.
        /// </summary>
        /// <returns>The encrypt.</returns>
        /// <param name="inText">In text.</param>
        /// <param name="key">Key.</param>
        public static string Encrypt(this string inText, string key = "ChangeKey")
        {
            byte[] bytesBuff = Encoding.Unicode.GetBytes(inText);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    inText = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return inText;
        }

        /// <summary>
        /// Decrypt the specified cryptTxt and key.
        /// </summary>
        /// <returns>The decrypt.</returns>
        /// <param name="cryptTxt">Crypt text.</param>
        /// <param name="key">Key.</param>
        public static string Decrypt(this string cryptTxt, string key = "ChangeKey")
        {
            cryptTxt = cryptTxt.Replace(" ", "+");
            byte[] bytesBuff = Convert.FromBase64String(cryptTxt);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    cryptTxt = Encoding.Unicode.GetString(mStream.ToArray());
                }
            }
            return cryptTxt;
        }

    }
}
