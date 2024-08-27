using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSFramework;

namespace ComenziBase
{
    public partial class FrameworkWindow : Window
    {
        #region Constructor
        public FrameworkWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Fields
        private SortedList<string, object> mButtonEditAlegeList = new SortedList<string, object>();
        #endregion

        #region Private Events

        private void FrameworkWindow_FormClosed(object sender, FormClosedEventArgs e)
        {

            //if (Context != null)
            //    this.Context.DeleteEntryFromUserContextParameterList(ContextUtilityClass.OnlyInstance.DocumenteParameterListKey);
        }

        #endregion

        #region Public Methods
        public override void Initialize()
        {
            base.Initialize();
            this.ShowInTaskbar = false;
        }
        public override void Bind()
        {
            base.Bind();
        }
        /// <summary>
        /// Seteaza display-ul si datasource-ul pentru buttonEditAlege in tag-ul ferestrei
        /// </summary>
        /// <param name="pReturnCod">Cod-ul returnat ca valoare in buttonEditAlege</param>
        /// <param name="pSourceDataTable">Tabela - sursa de date pentru buttonEditAlege</param>
        /// <returns>Lista ce se seteaza de forma this.Tag = SetButtonEditAlegeList("Cod", mDataSet.tblNotaContabila)</returns>
        public object SetButtonEditAlegeList(string pReturnCod, DataTable pSourceDataTable)
        {
            return SetButtonEditAlegeList(pReturnCod, pSourceDataTable, Guid.Empty); ;
        }
        public object SetButtonEditAlegeList(string pReturnCod, DataTable pSourceDataTable, Guid pID)
        {
            mButtonEditAlegeList["ID"] = pID;
            mButtonEditAlegeList["Cod"] = pReturnCod;
            mButtonEditAlegeList["DataSource"] = pSourceDataTable;
            return mButtonEditAlegeList;
        }

        #endregion

       


    }
}
