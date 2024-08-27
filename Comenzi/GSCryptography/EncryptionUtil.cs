using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace GSCryptography
{
    // Cei patru algoritmi simetrici de criptare folositi in serviciul de securitate din .NET Framework
    public enum EncryptionAlgorithm { Des = 1, Rc2, Rijndael, TripleDes };

    public class EncryptionUtil
    {
        #region Constructor
        internal EncryptionUtil(EncryptionAlgorithm _crAlg)
        {
            HardDriveInfo hdInfo = new HardDriveInfo();
            string pHashSource;

            try
            {
                pHashSource = hdInfo.GetHardDriveSerialNumber();

                Regex regex = new Regex("[0-9a-zA-Z-]*");
                if (!regex.IsMatch(pHashSource))
                    pHashSource = "1234";
            }
            catch
            {
                pHashSource = "1234";
            }

            // LEGENDA:
            //  KEY - cheie de criptare folosita de catre algoritm
            //  IV - vector de initializare (initialization vector). marimea lui trebuie sa fie egala cu cea a BS-ului folosit de metoda.
            //  BS - block size, marimea unui bloc de date care poate fi criptat intr-o singura operatiune
            switch (_crAlg)
            {
                case EncryptionAlgorithm.Des:
                    {
                        // DES, KEY: 64 biti, IV: 64 biti
                        if (String.IsNullOrEmpty(pHashSource))
                            pHashSource = "1234";
                        string pCrSource = BuildCrString(pHashSource, 8);
                        this.crKey = StringToByteArray(pCrSource);
                        this.crIV = StringToByteArray(ReverseString(pCrSource));
                        break;
                    }
                case EncryptionAlgorithm.Rc2:
                    {
                        // RC2, KEY: 40 -> 128 biti cu pas de 8 biti, IV: 64 biti. Valori folosite: KEY: 128 biti, IV: 64 biti
                        string pCrSource = BuildCrString(pHashSource, 16);
                        this.crKey = StringToByteArray(pCrSource);
                        this.crIV = StringToByteArray(ReverseString(pCrSource).Substring(0, 8));
                        break;
                    }
                case EncryptionAlgorithm.Rijndael:
                    {
                        // Rijndael, KEY: 128, 192, 256 biti. Valori folosite: KEY: 128 biti, IV: 128 biti
                        string pCrSource = BuildCrString(pHashSource, 16);
                        this.crKey = StringToByteArray(pCrSource);
                        this.crIV = StringToByteArray(ReverseString(pCrSource));
                        break;
                    }
                case EncryptionAlgorithm.TripleDes:
                    {
                        // TripleDES, KEY: 128 -> 192 biti cu pas de 64 biti, Valori folosite: KEY: 128 biti, IV: 64 biti
                        // Acest algoritm este o tripla iterare a algoritmului DES
                        string pCrSource = BuildCrString(pHashSource, 16);
                        this.crKey = StringToByteArray(pCrSource);
                        this.crIV = StringToByteArray(ReverseString(pCrSource).Substring(0, 8));
                        break;
                    }
                default:
                    {
                        throw new CryptographicException("Algoritmul de criptare '" + _crAlg + "' nu este suportat.");
                    }
            }
        }
        #endregion

        #region Private and Protected Variables
        private byte[] crKey = null;
        private byte[] crIV = null;
        #endregion

        #region Public Properties
        public byte[] Key
        {
            get { return this.crKey; }
        }
        public byte[] IV
        {
            get { return this.crIV; }
        }
        #endregion

        #region Private and Protected Methods
        private string ReverseString(string pString)
        {
            string pReversedString = string.Empty;
            for (int i = 0; i < pString.Length; i++)
            {
                pReversedString += pString[pString.Length - 1 - i];
            }
            return pReversedString;
        }
        private string BuildCrString(string pString, int pLength)
        {
            string pCrString = string.Empty;
            if (pString.Length >= pLength)
            {
                pCrString = pString.Substring(0, pLength);
            }
            else 
            {
                int pMedLength = pLength - pString.Length;
                pCrString += pString;
                for (int i = 0; i < pMedLength; i++)
                {
                    pCrString += i.ToString();
                }
            }

            return pCrString;
        }
        #endregion

        #region Public Static Methods
        public static string StringFromByteArray(byte[] bArray)
        {
            string s = string.Empty;
            for (int i = 0; i < bArray.Length; i++)
            {
                s += Convert.ToChar(bArray[i]).ToString();
            }
            return s;
        }
        public static byte[] StringToByteArray(string pString)
        {
            MemoryStream mstream = new MemoryStream();
            StreamWriter sw = new StreamWriter(mstream);
            sw.WriteLine(pString);
            sw.Close();
            byte[] b = new byte[mstream.ToArray().Length - 2];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = (byte)(mstream.ToArray())[i];
            }
            return b;
        }
        #endregion
    }
}
