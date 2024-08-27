namespace CommonGUIControllers.UC
{
    partial class UCData
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spinEditDay = new DevExpress.XtraEditors.SpinEdit();
            this.textEditMonthYear = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMonthYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // spinEditDay
            // 
            this.spinEditDay.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditDay.Location = new System.Drawing.Point(0, 3);
            this.spinEditDay.Name = "spinEditDay";
            this.spinEditDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditDay.Properties.Mask.EditMask = "N0";
            this.spinEditDay.Size = new System.Drawing.Size(47, 20);
            this.spinEditDay.TabIndex = 0;
            this.spinEditDay.EditValueChanged += new System.EventHandler(this.spinEditDay_EditValueChanged);
            // 
            // textEditMonthYear
            // 
            this.textEditMonthYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditMonthYear.Enabled = false;
            this.textEditMonthYear.Location = new System.Drawing.Point(52, 3);
            this.textEditMonthYear.Name = "textEditMonthYear";
            this.textEditMonthYear.Size = new System.Drawing.Size(137, 20);
            this.textEditMonthYear.TabIndex = 1;
            // 
            // UCData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEditMonthYear);
            this.Controls.Add(this.spinEditDay);
            this.Name = "UCData";
            this.Size = new System.Drawing.Size(201, 25);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMonthYear.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit spinEditDay;
        private DevExpress.XtraEditors.TextEdit textEditMonthYear;
    }
}
