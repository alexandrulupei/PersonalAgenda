using System;
using System.Text;
using System.Security.Cryptography;

namespace GSCryptography
{
    internal class DecryptTransformer
    {
        #region Constructor
        internal DecryptTransformer(EncryptionAlgorithm _decrAlg)
        {
            decrAlg = _decrAlg;
            InitCryptographicData();
        }
        #endregion

        #region Private and Protected Variables
        private EncryptionAlgorithm decrAlg;
        private byte[] decrIV = null;
        private byte[] decrKey = null;
        #endregion

        #region Private and Protected Methods
        private void InitCryptographicData()
        {
            EncryptionUtil crUtil = new EncryptionUtil(decrAlg);
            decrIV = crUtil.IV;
            decrKey = crUtil.Key;
        }
        private byte[] StringToByteArray(string pString)
        {
            byte[] pByteArray = Encoding.ASCII.GetBytes(pString);
            return pByteArray;
        }
        private string ReverseString(string pString)
        {
            string pReversedString = string.Empty;
            for (int i = 0; i < pString.Length; i++)
            {
                pReversedString += pString[pString.Length - 1 - i];
            }
            return pReversedString;
        }
        #endregion

        #region Public and Internal Methods
        internal ICryptoTransform GetCryptoServiceProvider()
        {
            switch (decrAlg)
            {
                case EncryptionAlgorithm.Des:
                    {
                        DES des = new DESCryptoServiceProvider();
                        des.Mode = CipherMode.CBC;

                        des.Key = decrKey;
                        des.IV = decrIV;

                        return des.CreateDecryptor();
                    }
                case EncryptionAlgorithm.Rc2:
                    {
                        RC2 rc2 = new RC2CryptoServiceProvider();
                        rc2.Mode = CipherMode.CBC;

                        return rc2.CreateDecryptor(decrKey, decrIV);
                    }
                case EncryptionAlgorithm.Rijndael:
                    {
                        Rijndael rijn = new RijndaelManaged();
                        rijn.Mode = CipherMode.CBC;

                        return rijn.CreateDecryptor(decrKey, decrIV);
                    }
                case EncryptionAlgorithm.TripleDes:
                    {
                        TripleDES tDes = new TripleDESCryptoServiceProvider();
                        tDes.Mode = CipherMode.CBC;

                        return tDes.CreateDecryptor(decrKey, decrIV);
                    }
                default:
                    {
                        throw new CryptographicException("Algoritmul de criptare '" + decrAlg + "' nu este suportat.");
                    }
            }
        }
        #endregion
    }
}
