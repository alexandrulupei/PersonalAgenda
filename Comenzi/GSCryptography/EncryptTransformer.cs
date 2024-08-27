using System;
using System.Text;
using System.Collections;
using System.Security.Cryptography;

namespace GSCryptography
{
    internal class EncryptTransformer
    {
        #region Constructor
        internal EncryptTransformer(EncryptionAlgorithm _encrAlg)
        {
            encrAlg = _encrAlg;
            InitCryptographicData();
        }
        #endregion

        #region Private and Protected Variables
        private EncryptionAlgorithm encrAlg;
        private byte[] encrIV = null;
        private byte[] encrKey = null;
        #endregion

        #region Private and Protected Methods
        private void InitCryptographicData()
        {
            EncryptionUtil crUtil = new EncryptionUtil(encrAlg);
            encrIV = crUtil.IV;
            encrKey = crUtil.Key;
        }
        #endregion

        #region Public and Internal Methods
        internal ICryptoTransform GetCryptoServiceProvider()
        {
            switch (encrAlg)
            {
                case EncryptionAlgorithm.Des:
                    {
                        DES des = new DESCryptoServiceProvider();
                        des.Mode = CipherMode.CBC;

                        des.Key = encrKey;
                        des.IV = encrIV;

                        return des.CreateEncryptor();
                    }
                case EncryptionAlgorithm.Rc2:
                    {
                        RC2 rc2 = new RC2CryptoServiceProvider();
                        rc2.Mode = CipherMode.CBC;

                        rc2.Key = encrKey;
                        rc2.IV = encrIV;

                        return rc2.CreateEncryptor();
                    }
                case EncryptionAlgorithm.Rijndael:
                    {
                        Rijndael rijn = new RijndaelManaged();
                        rijn.Mode = CipherMode.CBC;

                        rijn.Key = encrKey;
                        rijn.IV = encrIV;

                        return rijn.CreateEncryptor();
                    }
                case EncryptionAlgorithm.TripleDes:
                    {
                        TripleDES tDes = new TripleDESCryptoServiceProvider();
                        tDes.Mode = CipherMode.CBC;

                        tDes.Key = encrKey;
                        tDes.IV = encrIV;

                        return tDes.CreateEncryptor();
                    }
                default:
                    {
                        throw new CryptographicException("Algoritmul de criptare '" + encrAlg + "' nu este suportat.");
                    }
            }
        }
        #endregion
    }
}
