using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonGUIControllers.Base
{
    public class ControllerUtils
    {
        public static void HandleException(System.Exception exception)
        {
            throw exception;
        }

        /// <summary>
        /// Shows a window with the exception details, if the operation fails.
        /// </summary>
        public static bool HandleResultCode(GSFramework.Controller target)
        {
            if (target.ResultCode != 0)
            {
                target.Context.HandleException(target.ServerException.ToString());
                return true;
            }
            return false;
        }

        /// <summary>
        /// Shows an error message box with the given message, if the operation fails.
        /// </summary>
        public static bool HandleError(GSFramework.Controller target, string message)
        {
            if (target.ResultCode != 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("test");
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    message,
                        "Eroare",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
    }
}

