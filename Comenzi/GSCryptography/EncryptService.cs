using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace GSCryptography
{
    public sealed class EncryptService
    {
        #region Constructor
        public EncryptService(EncryptionAlgorithm _encrAlg)
        {
            encrTransformer = new EncryptTransformer(_encrAlg);
        }
        #endregion

        #region Private and Protected Variables
        private EncryptTransformer encrTransformer;
        #endregion

        #region Public and Internal Methods
        public byte[] EncryptData(byte[] pData)
        {
            try
            {
                MemoryStream mStream = new MemoryStream();
                ICryptoTransform transform = encrTransformer.GetCryptoServiceProvider();
                CryptoStream cStream = new CryptoStream(mStream, transform, CryptoStreamMode.Write);

                cStream.Write(pData, 0, pData.Length);

                cStream.FlushFinalBlock();
                cStream.Close();
                return mStream.ToArray();
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
