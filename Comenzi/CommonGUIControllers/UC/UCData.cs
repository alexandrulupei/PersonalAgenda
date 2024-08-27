using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GSFramework;

namespace CommonGUIControllers.UC
{
    public partial class UCData : GSFramework.Panel
    {
        #region Constructor
        public UCData()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Fields
        private DateTime mUserDateTime;
        private DateTime mDataLucru = ContextUtilityClass.OnlyInstance.DataLucru;
        private bool mSeteazaZiCurenta;
        CultureInfo mCultureInfo = new CultureInfo("ro-RO", false);
        private const string mDateFormat = "MMMM - yyyy";
        private bool mSetTimeForDate = true;
        #endregion

        #region Properties
        /// <summary>
        /// Proprietate pe care se face DataBindings
        /// Ex: ucData1.DataBindings.Add("UserDateTime", mDataSet.tblPropunereBase, "Data", true, DataSourceUpdateMode.OnValidation, string.Empty);
        /// </summary>
        public DateTime UserDateTime
        {
            set
            {
                this.mUserDateTime = value;
                this.textEditMonthYear.Text = mUserDateTime.ToString(mDateFormat, mCultureInfo).ToUpper();
                this.spinEditDay.Value = mUserDateTime.Day;
            }
            get
            {
                return mUserDateTime;
            }
        }
        /// <summary>
        /// Se aduaga si timp la data. Implicit este pe true
        /// </summary>
        public bool SetTimeForDate
        {
            set { this.mSetTimeForDate = value; }
        }
        public DateTime GetDateTime
        {
            get
            {
                return mUserDateTime;
            }
        }
        /// <summary>
        /// Daca parametrul este setat true, si luna de lucru este egala cu luna sistemului
        /// se va pune implicit ziua si nu 1 a lunii
        /// </summary>
        public bool SeteazaZiCurenta
        {
            set { mSeteazaZiCurenta = value; }
        }
        #endregion

        #region Events
        private void spinEditDay_EditValueChanged(object sender, EventArgs e)
        {
            SetDateTime();
            OnDateTimeChanged();
        }
        #endregion

        #region Private Methods
        private void SetDateTime()
        {
            if ((int)spinEditDay.Value > System.DateTime.DaysInMonth(mUserDateTime.Year, mUserDateTime.Month) || (int)spinEditDay.Value <= 0)
            {
                spinEditDay.ErrorText = "Zi din luna incorecta";
                spinEditDay.Focus();
                return;

            }
            if (mSetTimeForDate)
                mUserDateTime = new DateTime(mUserDateTime.Year, mUserDateTime.Month, (int)spinEditDay.Value, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            else
                mUserDateTime = new DateTime(mUserDateTime.Year, mUserDateTime.Month, (int)spinEditDay.Value);
        }
        private void SetCurrentDateTime()
        {
            DateTime currentDate = DateTime.Now.Date;
            if (currentDate.Year == mDataLucru.Year && currentDate.Month == mDataLucru.Month)
            {
                mUserDateTime = currentDate;
            }
            else
            {
                mUserDateTime = mDataLucru;
            }
        }
        #endregion

        #region Public Methods
        public override void Initialize()
        {
            base.Initialize();
            if (!mSeteazaZiCurenta)
                mUserDateTime = mDataLucru;
            else
            {
                SetCurrentDateTime();
            }
            this.textEditMonthYear.Text = mDataLucru.ToString(mDateFormat, mCultureInfo).ToUpper();
            this.spinEditDay.Properties.MinValue = 1;
            this.spinEditDay.Properties.MaxValue = DateTime.DaysInMonth(mDataLucru.Year, mDataLucru.Month);
        }
        #endregion

        #region Public Events
        public delegate void UCDataUserDateTimeChanged();
        [Browsable(true)]
        [Category("User Defined")]
        [Description("Define which borders of the control are bound to the container")]
        [DisplayName("DateTimeChanged")]
        public event UCDataUserDateTimeChanged DateTimeChanged;
        protected virtual void OnDateTimeChanged()
        {
            if (DateTimeChanged != null)
                DateTimeChanged();
        }
        #endregion

    
    }
}
