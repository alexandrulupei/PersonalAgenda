using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonDataSets.GUI;
using GSBusFramework;

namespace Common_DT.GUI
{
    public partial class ListaComenziDataSvc : DataService
    {
        #region Constructor
        public ListaComenziDataSvc()
        {
            InitializeComponent();
        }

        public ListaComenziDataSvc(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion 

        #region Class Fields

        protected AdapterList viewDataAdapters = new AdapterList();

        #endregion

        #region Public Methods
        public bool GetLista(ListaComenziDataSet pDataSet, Guid pTipCentruID, DateTime @pDataStart, DateTime @pDataStop, Guid pFurnizorID, Guid pLotID)
        {
            this.sqlTableName = "tblLista";
            IList keyList = new ArrayList();
            if (pTipCentruID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pTipCentruID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pTipCentruID", pTipCentruID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            if (pLotID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pLotID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pLotID", pLotID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            if (pFurnizorID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pFurnizorID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pFurnizorID", pFurnizorID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            keyList.Add(new FilterInfo("@pDataStart", pDataStart, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            keyList.Add(new FilterInfo("@pDataStop", pDataStop, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            GetList(pDataSet, keyList,sqlDataAdapter_GetLista);
            return true;
        }

        public bool GetCentre(ListaComenziDataSet pDataSet, Guid pTipCentruID)
        {
            this.sqlTableName = "tblCentru";
            IList keyList = new ArrayList();
            if (pTipCentruID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pTipCentruID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pTipCentruID", pTipCentruID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
          
            return GetList(pDataSet, keyList, sqlDataAdapter_Centre);
        }

        public bool GetListaDisponibil(ListaComenziDataSet pDataSet, Guid pFurnizorID, Guid pLotID)
        {
            this.sqlTableName = "tblListaDisponibil";
            IList keyList = new ArrayList();

            if (pLotID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pLotID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pLotID", pLotID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            if (pFurnizorID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pFurnizorID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pFurnizorID", pFurnizorID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            
            GetList(pDataSet, keyList, sqlDataAdapter_GetListaDisponibil);
            return true;
        }

        public bool GetDate(ListaComenziDataSet pDataSet)
        {
            this.sqlTableName = "tblPartener";
            GetList(pDataSet, sqlDataAdapter_GetParteneri);

            this.sqlTableName = "tblLotBase";
            GetList(pDataSet, sqlDataAdapter_GetLoturi);
            return true;

        }

        public bool UpdateDS(ListaComenziDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion
    }
}
