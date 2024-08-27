using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GSFramework {
    public class ExceptionDisplay : System.Windows.Forms.Form 	{
        
        #region Form Designer Variables
        private System.Windows.Forms.Label lbDialog;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbDialog;
        private System.ComponentModel.Container components = null;
		#endregion

		#region Constructor and Dispose
        public ExceptionDisplay()	{
            InitializeComponent();
        }
        public ExceptionDisplay(string strHeaderPassed, string strMessagePassed) 
        {
            InitializeComponent();
            lbDialog.Text = strHeaderPassed;
            tbDialog.Text = strMessagePassed;
        }
        public ExceptionDisplay(string strHeaderPassed, string strMessagePassed, Control pnlPassed) {
            InitializeComponent();
            lbDialog.Text = strHeaderPassed;
            tbDialog.Text = strMessagePassed;
        }
        protected override void Dispose( bool disposing ) {
            if( disposing ) {
                if(components != null) {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }
		#endregion

		#region Windows Form Designer generated code
        private void InitializeComponent() {
			this.lbDialog = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbDialog = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lbDialog
			// 
			this.lbDialog.Location = new System.Drawing.Point(8, 16);
			this.lbDialog.Name = "lbDialog";
			this.lbDialog.Size = new System.Drawing.Size(712, 64);
			this.lbDialog.TabIndex = 3;
			this.lbDialog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnOK.Location = new System.Drawing.Point(8, 352);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(56, 20);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "Da";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnCancel.Location = new System.Drawing.Point(128, 352);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(50, 20);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Nu";
			// 
			// tbDialog
			// 
			this.tbDialog.Location = new System.Drawing.Point(8, 80);
			this.tbDialog.Multiline = true;
			this.tbDialog.Name = "tbDialog";
			this.tbDialog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbDialog.Size = new System.Drawing.Size(712, 264);
			this.tbDialog.TabIndex = 6;
			this.tbDialog.Text = "";
			// 
			// ExceptionDisplay
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(730, 375);
			this.ControlBox = false;
			this.Controls.Add(this.tbDialog);
			this.Controls.Add(this.lbDialog);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExceptionDisplay";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Stack Trace - Exceptii";
			this.ResumeLayout(false);

		}
		#endregion
        
        #region Private Variables
		#endregion

        #region Public Properties
        public Button OKButton {
            get {return btnOK;}
        }
        public Button CanButton {
            get {return btnCancel;}
        }
        #endregion
    }
}
