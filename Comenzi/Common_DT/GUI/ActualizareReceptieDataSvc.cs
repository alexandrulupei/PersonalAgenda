using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CommonDataSets.GUI;
using GSBusFramework;

namespace Common_DT.GUI
{
    public partial class ActualizareReceptieDataSvc : DataService
    {
        #region Constructor
        public ActualizareReceptieDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public ActualizareReceptieDataSvc(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region ClassFields

        protected AdapterList viewDataAdapters = new AdapterList();

        #endregion


        #region Infrastructure Methods
        protected override void setupDataService()
        {
            this.sqlTableName = "tblReceptieComandaBase";
            viewDataAdapters["tblReceptieComandaBase"] = sqlDataAdapter_tblReceptieComenziBase;
            viewDataAdapters["tblReceptieComandaDet"] = sqlDataAdapter_tblReceptieComandaDet;
        }
        #endregion

        #region Public Methods
        public bool GetReceptieByComanda(ActualizareReceptieDataSet pDataSet, Guid pComandaBaseID)
        {

            this.sqlTableName = pDataSet.tblReceptieComandaBase.TableName;
            GetList(pDataSet, sqlDataAdapter_tblReceptieComenziBase);

            this.sqlTableName = pDataSet.tblReceptieComandaDet.TableName;
            GetList(pDataSet, sqlDataAdapter_tblReceptieComandaDet);

            this.sqlTableName = "tblDate";

            IList keyList = new ArrayList();
            if (pComandaBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pComandaBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pComandaBaseID", pComandaBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            return GetList(pDataSet, keyList, sqlDataAdapter_getReceptieByComanda);
        }


        public bool UpdateDS(ActualizareReceptieDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }

        #endregion
    }
}
