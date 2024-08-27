namespace Comenzi
{
    partial class SelectionForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControlBase = new DevExpress.XtraEditors.PanelControl();
            this.treeViewSelectionList = new System.Windows.Forms.TreeView();
            this.buttonAbort = new DevExpress.XtraEditors.SimpleButton();
            this.buttonPick = new DevExpress.XtraEditors.SimpleButton();
            this.labelPick = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorkerFindServers = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerFindDatabases = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlBase)).BeginInit();
            this.panelControlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControlBase
            // 
            this.panelControlBase.Controls.Add(this.treeViewSelectionList);
            this.panelControlBase.Controls.Add(this.buttonAbort);
            this.panelControlBase.Controls.Add(this.buttonPick);
            this.panelControlBase.Controls.Add(this.labelPick);
            this.panelControlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlBase.Location = new System.Drawing.Point(0, 0);
            this.panelControlBase.Name = "panelControlBase";
            this.panelControlBase.Size = new System.Drawing.Size(377, 362);
            this.panelControlBase.TabIndex = 0;
            // 
            // treeViewSelectionList
            // 
            this.treeViewSelectionList.Location = new System.Drawing.Point(34, 65);
            this.treeViewSelectionList.Name = "treeViewSelectionList";
            this.treeViewSelectionList.Size = new System.Drawing.Size(331, 245);
            this.treeViewSelectionList.TabIndex = 4;
            this.treeViewSelectionList.DoubleClick += new System.EventHandler(this.treeViewSelectionList_DoubleClick);
            // 
            // buttonAbort
            // 
            this.buttonAbort.Location = new System.Drawing.Point(290, 327);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(75, 23);
            this.buttonAbort.TabIndex = 3;
            this.buttonAbort.Text = "Renunta";
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // buttonPick
            // 
            this.buttonPick.Location = new System.Drawing.Point(186, 327);
            this.buttonPick.Name = "buttonPick";
            this.buttonPick.Size = new System.Drawing.Size(75, 23);
            this.buttonPick.TabIndex = 2;
            this.buttonPick.Text = "Alege";
            this.buttonPick.Click += new System.EventHandler(this.buttonPick_Click);
            // 
            // labelPick
            // 
            this.labelPick.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelPick.Location = new System.Drawing.Point(34, 24);
            this.labelPick.Name = "labelPick";
            this.labelPick.Size = new System.Drawing.Size(161, 35);
            this.labelPick.TabIndex = 0;
            this.labelPick.Text = "Alegeti";
            // 
            // backgroundWorkerFindServers
            // 
            this.backgroundWorkerFindServers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFindServers_DoWork);
            this.backgroundWorkerFindServers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFindServers_RunWorkerCompleted);
            // 
            // backgroundWorkerFindDatabases
            // 
            this.backgroundWorkerFindDatabases.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFindDatabases_DoWork);
            this.backgroundWorkerFindDatabases.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFindDatabases_RunWorkerCompleted);
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 362);
            this.Controls.Add(this.panelControlBase);
            this.Name = "SelectionForm";
            this.Text = "SelectionForm";
            ((System.ComponentModel.ISupportInitialize)(this.panelControlBase)).EndInit();
            this.panelControlBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlBase;
        private DevExpress.XtraEditors.LabelControl labelPick;
        private DevExpress.XtraEditors.SimpleButton buttonAbort;
        private DevExpress.XtraEditors.SimpleButton buttonPick;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFindServers;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFindDatabases;
        private System.Windows.Forms.TreeView treeViewSelectionList;
    }
}