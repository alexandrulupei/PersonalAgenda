using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace GSCryptography
{
    public sealed class DecryptService
    {
        #region Constructor
        public DecryptService(EncryptionAlgorithm _decrAlg)
        {
            decrTransformer = new DecryptTransformer(_decrAlg);
        }
        #endregion

        #region Private and Protected Variables
        private DecryptTransformer decrTransformer;
        #endregion

        #region Public and Internal Methods
        public byte[] DecryptData(byte[] pData)
        {
            MemoryStream mStream = new MemoryStream();
            ICryptoTransform transform = decrTransformer.GetCryptoServiceProvider();
            CryptoStream dStream = new CryptoStream(mStream, transform, CryptoStreamMode.Write);

            try
            {
                dStream.Write(pData, 0, pData.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare la scrierea datelor decriptate: " + ex.Message);
            }

            dStream.FlushFinalBlock();
            dStream.Close();
            return mStream.ToArray();
        }
        #endregion
    }
}
