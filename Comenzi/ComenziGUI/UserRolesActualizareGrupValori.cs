using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComenziBase;

namespace ComenziGUI
{
    public partial class UserRolesActualizareGrupValori : FrameworkWindow
    {
        #region Constructor
        public UserRolesActualizareGrupValori()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Fields
        private Guid mRolesID = Guid.Empty;
        #endregion

        #region Properties
        public Guid RoleID
        {
            get { return this.mRolesID; }
        }
        #endregion

        #region Events
        private void simpleButtonAccepta_Click(object sender, EventArgs e)
        {
            if (this.lookUpEditRoles.Text.Equals(string.Empty))
            {
                this.lookUpEditRoles.ErrorText = "Alegeti un rol!";
                this.lookUpEditRoles.Focus();
                return;
            }
            this.mRolesID = (Guid)this.lookUpEditRoles.EditValue;
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void simpleButtonRenunta_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Public Methods
        public override void Initialize()
        {
            try
            {
                base.Initialize();
                object obj = this.Context.GetParameterValueUserContextParameterList("EconetAdmin.Users.UserRolesActualizareGrupValori.tblRolesBindingSource");
                if (!obj.Equals(string.Empty))
                    this.tblRolesBindingSource.DataSource = obj;
                base.Bind();
            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
        }
        public override void Bind()
        {
            base.Bind();
        }
        #endregion

      

       
    }
}
