using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using GSFramework;

namespace Comenzi
{
    public partial class SelectionForm : Window
    {
        #region 
        public SelectionForm()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Private Fields
        private SelectorType selector;
        private TreeNode RootNode;
        private DataTable Servers;
        private DataTable Databases;
        private ImageList NodeIcons;
        private SqlConnection CurrentConnection;
        #endregion

        #region Public Properties
        public string WindowInfo
        {
            set { this.labelPick.Text = value; }
        }
        public bool EnableCheckboxes
        {
            set { this.treeViewSelectionList.CheckBoxes = value; }
        }
        public SelectorType SelType
        {
            set { selector = value; }
        }
        #endregion

        #region Private Events

        private void treeViewSelectionList_DoubleClick(object sender, EventArgs e)
        {
            Pick();
        }

        private void buttonPick_Click(object sender, EventArgs e)
        {
            Pick();
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            if (Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.IsAbort") != null)
            {
                Context.DeleteEntryFromUserContextParameterList("Comenzi.ConnectionConfig.IsAbort");
            }
            Context.AddUserContextParameterList("Comenzi.ConnectionConfig.IsAbort", true);
        }
        private void backgroundWorkerFindServers_DoWork(object sender, DoWorkEventArgs e)
        {
            Servers = SqlDataSourceEnumerator.Instance.GetDataSources();
        }

        private void backgroundWorkerFindServers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Servers.Rows.Count == 0)
            {
                RootNode.Text = "Nu sunt servere disponibile";
            }
            else
            {
                RootNode.Text = "Servere SQL disponibile";
            }
            RootNode.ImageKey = "Server";
            RootNode.SelectedImageKey = "Server";

            foreach (DataRow drs in Servers.Select("", "ServerName ASC, InstanceName ASC"))
            {
                TreeNode tn = new TreeNode();
                if (drs["InstanceName"].ToString().Trim() != string.Empty)
                {
                    tn.Text = drs["ServerName"].ToString() + "\\" + drs["InstanceName"].ToString();
                }
                else
                {
                    tn.Text = drs["ServerName"].ToString();
                }
                tn.ImageKey = "Server";
                tn.SelectedImageKey = "Server";
                RootNode.Nodes.Add(tn);
            }

            RootNode.Expand();
        }

        private void backgroundWorkerFindDatabases_DoWork(object sender, DoWorkEventArgs e)
        {
            if (CurrentConnection != null)
            {
                try
                {
                    CurrentConnection.Open();

                    if (CurrentConnection.State == ConnectionState.Open)
                    {
                        Databases = CurrentConnection.GetSchema("Databases");
                    }
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show(sqlex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.InnerException + " / " + ex.Message);
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.InnerException + " / " + ex1.Message);
                }
                finally
                {
                    if (CurrentConnection.State == ConnectionState.Open)
                    {
                        CurrentConnection.Close();
                    }
                }
            }
        }

        private void backgroundWorkerFindDatabases_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RootNode.Text = CurrentConnection.DataSource;
            RootNode.ImageKey = "Server";
            RootNode.SelectedImageKey = "Server";

            if (Databases != null)
            {
                foreach (DataRow drs in Databases.Select("", "database_name ASC"))
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = drs["database_name"].ToString();
                    tn.ImageKey = "Database";
                    tn.SelectedImageKey = "Database";
                    RootNode.Nodes.Add(tn);
                }

                RootNode.Expand();
            }
        }

        

        #endregion

        #region Private Methods
        private void LoadServers()
        {
            RootNode = new TreeNode();
            treeViewSelectionList.Nodes.Add(RootNode);
            RootNode.Text = "Se incarca lista de servere...";
            backgroundWorkerFindServers.RunWorkerAsync();
        }
        private void LoadDatabases()
        {
            RootNode = new TreeNode();
            treeViewSelectionList.Nodes.Add(RootNode);
            RootNode.Text = "Se incarca lista de baze de date...";
            backgroundWorkerFindDatabases.RunWorkerAsync();
        }
        private void Pick()
        {
            bool InvalidNodeSelected = false;

            switch (selector)
            {
                case SelectorType.Server:
                    TreeNode SelectedNode = treeViewSelectionList.SelectedNode;

                    if (SelectedNode != null)
                    {
                        if (SelectedNode != RootNode)
                        {
                            PickServer(SelectedNode);
                            this.Close();
                        }
                        else
                        {
                            InvalidNodeSelected = true;
                        }
                    }
                    else
                    {
                        InvalidNodeSelected = true;
                    }

                    break;
                case SelectorType.Database:
                    int NodeCount = 0;
                    foreach (TreeNode Node in RootNode.Nodes)
                    {
                        if (Node.Checked)
                        {
                            NodeCount++;
                        }
                    }
                    if (NodeCount >= 1)
                    {
                        PickDatabases(RootNode);
                        this.Close();
                    }
                    else
                    {
                        InvalidNodeSelected = true;
                    }
                    break;
            }

            if (InvalidNodeSelected)
            {
                string ErrorMessage;
                switch (selector)
                {
                    case SelectorType.Server:
                        ErrorMessage = "Trebuie sa selectati un server";
                        MessageBox.Show(ErrorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case SelectorType.Database:
                        ErrorMessage = "Trebuie sa alegeti cel putin o baze de date";
                        MessageBox.Show(ErrorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    default:
                        break;
                }
            }
        }

        private void PickDatabases(TreeNode RootNode)
        {
            string DatabaseList = string.Empty;
            foreach (TreeNode DBNode in RootNode.Nodes)
            {
                if (DBNode.Checked)
                {
                    if (DatabaseList.Trim().Length > 0)
                    {
                        DatabaseList += ", ";
                    }
                    DatabaseList += DBNode.Text;
                }
            }

            if (Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.IsAbort") != null)
            {
                Context.DeleteEntryFromUserContextParameterList("Comenzi.ConnectionConfig.IsAbort");
            }
            Context.AddUserContextParameterList("Comenzi.ConnectionConfig.IsAbort", false);

            if (Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.DatabaseList") != null)
            {
                Context.DeleteEntryFromUserContextParameterList("Comenzi.ConnectionConfig.DatabaseList");
            }
            Context.AddUserContextParameterList("Comenzi.ConnectionConfig.DatabaseList", DatabaseList);
        }
        private void PickServer(TreeNode SelectedNode)
        {
            if (Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.IsAbort") != null)
            {
                Context.DeleteEntryFromUserContextParameterList("Comenzi.ConnectionConfig.IsAbort");
            }
            Context.AddUserContextParameterList("Comenzi.ConnectionConfig.IsAbort", false);

            if (Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.ServerName") != null)
            {
                Context.DeleteEntryFromUserContextParameterList("Comenzi.ConnectionConfig.ServerName");
            }
            Context.AddUserContextParameterList("Comenzi.ConnectionConfig.ServerName", SelectedNode.Text);
        }
        #endregion

        #region Public Methods
        public override void Initialize()
        {
            try
            {
                base.Initialize();

                object WindowInfo = Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.SelectorWindowInfo");
                object WindowText = Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.SelectorWindowText");
                object EnableCheckboxes = Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.EnableCheckboxes");
                object SelType = Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.SelectorType");
                object Connection = Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.Connection");

                if (SelType.ToString() != string.Empty)
                {
                    selector = (SelectorType)SelType;
                }

                labelPick.Text = WindowInfo.ToString();
                this.Text = WindowText.ToString();

                if (EnableCheckboxes.ToString() != string.Empty)
                {
                    treeViewSelectionList.CheckBoxes = (bool)EnableCheckboxes;
                }

                if (Connection.ToString() != string.Empty)
                {
                    CurrentConnection = (SqlConnection)Connection;
                }

                ResourceManager rm = new ResourceManager("Comenzi.Properties.Resources", typeof(Properties.Resources).Assembly);

                NodeIcons = new ImageList();
                //NodeIcons.Images.Add("Server", (Image)rm.GetObject("Server.bmp"));
                //NodeIcons.Images.Add("Database", (Image)rm.GetObject("Database.bmp"));
                NodeIcons.TransparentColor = Color.Magenta;
                NodeIcons.ColorDepth = ColorDepth.Depth32Bit;

                treeViewSelectionList.ImageList = NodeIcons;

                switch (selector)
                {
                    case SelectorType.Server:
                        LoadServers();
                        break;
                    case SelectorType.Database:
                        LoadDatabases();
                        break;
                    default:
                        break;
                }


                this.Bind();
            }
            catch (Exception ex)
            {
                Context.HandleException(this, "", ex);
            }
        }
        public override void Bind()
        {
            try
            {
                base.Bind();
            }
            catch (Exception ex)
            {
                Context.HandleException(this, "", ex);
            }
        }
        #endregion




    }
}
