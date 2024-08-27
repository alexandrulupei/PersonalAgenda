using System;
using System.Data;
using CommonDataSets.Liste;
using CommonGUIControllers.Liste;
using GSFramework;
using Utilities;

namespace ComenziListe
{
    public partial class NIRHome : GSFramework.Window
    {
        #region Constructor
        public NIRHome()
        {
            InitializeComponent();
        }
       #endregion

        #region  Class Fields

        private NirDataSet mDataSet;
        private NirController mController;
        private Guid mReceptieID = Guid.Empty;

        private Utility mUtil = new Utility();

        #endregion


        #region  Public Methods

        public override void Initialize()
        {
            try
            {

                base.Initialize();
                object obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Nir.NirID");
                if (obj != null && (!string.IsNullOrEmpty(obj.ToString())))
                    mReceptieID = new Guid(obj.ToString());
                mController =
                    (NirController)
                    Context.CreateController("CommonGUIControllers.Liste.NirController,CommonGUIControllers");
                mController.LoadDate = true;
                mController.ReceptieBaseID = mReceptieID;
                mController.CentruID = ContextUtilityClass.OnlyInstance.CentruID;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());

                    return;
                }

                mDataSet = (NirDataSet)mController.DataSet;
                mDataSet.AcceptChanges();

                AddPersoaneGestiuni();
                this.Bind();
            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }

        }

        #endregion

        private void AddPersoaneGestiuni()
        {
            int nr = 1;
            foreach (DataRow drVwNir in mDataSet.tblNir.Rows)
            {
                drVwNir["Gestionar"] = "";
                drVwNir["Comisie"] = "";
                drVwNir["Intocmit"] = "";
                drVwNir["NrCrt"] = nr;
                nr++;

                DataRow[] drs = mDataSet.tblPersoane.Select();
                for (int i = 0; i < drs.Length; i++)
                {
                    DataRow drVwPersoane = drs[i];
                    string codIntern =drVwPersoane["CodIntern"].ToString();
                    switch (codIntern)
                    {
                        //gestionar
                        case "01":
                            drVwNir["Gestionar"] = drVwNir["Gestionar"].ToString() + drVwPersoane["Persoana"].ToString() + "\r\n\r\n";
                            break;
                        //Comisie
                        case "02":
                            drVwNir["Comisie"] = drVwNir["Comisie"].ToString() + drVwPersoane["Persoana"].ToString() + "\r\n\r\n";
                            break;
                        case "03":
                            drVwNir["Intocmit"] = drVwNir["Intocmit"].ToString() + drVwPersoane["Persoana"].ToString()  + "\r\n\r\n";
                            break;
                      
                    }
                }
            }
           
        }
        private void NIRHome_Load(object sender, EventArgs e)
        {
            NIRReport raport = new NIRReport();
            raport.DataSource = mDataSet.tblNir;
            raport.NrZecimaleCantitati = 2;
            raport.NrZecimaleSume = 2;
            printControl1.PrintingSystem = raport.PrintingSystem;
            raport.CreateDocument();
        }
    }
}
