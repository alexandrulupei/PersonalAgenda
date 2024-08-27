using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Utilities
{
    /// <summary>
    /// GSSign - Semnatura digitala GS
    /// </summary>
    public class GSSign
    {
        #region Nested Classes
        /// <summary>
        /// clickSIGNCore - integrare clickSIGN
        /// clickSIGN este o componenta din suita de aplicatii de securitate shellSAFE integrata in Windows Explorer si Microsoft Office, 
        /// care permite criptarea si semnarea digitala a fisierelor si directoarelor
        /// </summary>
        public sealed class clickSIGNCore
        {
            private clickSIGNCore() { }

            [DllImport("clickSIGNCore.dll")]
            public static extern int SignFile(String szFileName);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Salveaza mesajele de eroare int-un fisier log GD_Error.log
        /// Fisierul se va gasi in calea curenta unde se afla executabilul instalat
        /// </summary>
        /// <param name="logMessage">Mesajul de eroare</param>
        public static void Log(String logMessage)
        {
            StreamWriter w = File.AppendText("GS_ErrorLog.log");
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine(":");
            w.WriteLine(":{0}", logMessage);
            w.WriteLine("-------------------------------");
            // Update the underlying file.
            w.Flush();
            w.Close();
        }
        /// <summary>
        /// Semneaza digital (folosing clickSIGN) un fisier 
        /// </summary>
        /// <param name="pFileName">Fisierul de semnat</param>
        public int Semneaza(String pFileName)
        {
            try
            {
                int retVal = 0;

                retVal = clickSIGNCore.SignFile(pFileName);

                if (retVal != 0)
                {
                    MessageBox.Show("Error: Could not sign file. clickSIGN return an error.", "Eroare");                
                }

                return retVal;
            }
            catch (Exception excep)
            {
                MessageBox.Show("Error: Could not sign file. Original error: " + excep.Message, "Eroare");
                Log("Error: Could not sign file. Original error: " + excep.Message);

                return -1;
            }
        }
        /// <summary>
        /// Vizualizeaza un fisier semnat digital (folosing clickSIGN)
        /// </summary>
        /// <param name="pFileName">Fisierul de semnat</param>
        public int Vizualizeaza(String pFileName)
        {
            try
            {
                int retVal = 0;
                bool retBoolVal = false;

                Process pr = new Process();
                pr.StartInfo.FileName = "rundll32.exe ";
                pr.StartInfo.Arguments = " clickSignVerif.dll,OpenP7M " + pFileName;
                retBoolVal = pr.Start();

                if (!retBoolVal)
                {                    
                    MessageBox.Show("Error: Could not view sign file. clickSIGN return an error.", "Eroare");

                    retVal = -1;
                }

                System.Threading.Thread.Sleep(5000);

                return retVal;
            }
            catch (Exception excep)
            {
                MessageBox.Show("Error: Could not view file. Original error: " + excep.Message, "Eroare");
                Log("Error: Could not view sign file. Original error: " + excep.Message);

                return -1;
            }
        }
        #endregion
    }
}
