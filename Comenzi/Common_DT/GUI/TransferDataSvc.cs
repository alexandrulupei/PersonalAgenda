using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GSBusFramework;
using CommonDataSets.GUI;
using System.Collections;

namespace Common_DT.GUI
{
    public partial class TransferDataSvc : DataService
    {
        #region Constructor
        public TransferDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public TransferDataSvc(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion 

        #region Class Fields

        protected AdapterList viewDataAdapters = new AdapterList();

        #endregion

        #region Infrastructure Methods
        protected override void setupDataService()
        {
            this.sqlTableName = "tblTransfer";
            viewDataAdapters["tblTransfer"] = sqlDataAdapter_tblTransfer;
        
        }
        #endregion

        #region Public Methods

        public bool GetCentru(TransferDataSet pDataSet)
        {
            this.sqlTableName = "tblCentru";
            GetList(pDataSet, sqlDataAdapter_GetCentru);
            this.sqlTableName = "tblLotBase";
            GetList(pDataSet, sqlDataAdapter_GetLot);
            return true;
        }

        public bool GetDate(TransferDataSet pDataSet, Guid pLotBaseID, Guid pCentruId)
        {
            this.sqlTableName = "tblDate";
            IList keyList = new ArrayList();
            if (pLotBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pLotBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pLotBaseID", pLotBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            if (pCentruId == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pCentruId", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pCentruId", pCentruId, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }

            GetList(pDataSet, keyList, sqlDataAdapter_getDate);
            return true;
        }


        public bool UpdateDS(TransferDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion
    }
}
