using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;

namespace XML130.CustomGridLookUpEdit
{
    [UserRepositoryItem("RegisterCustomGridLookUpEdit")]
    public class RepositoryItemCustomGridLookUpEdit : RepositoryItemGridLookUpEdit
    {
        public const string CustomGridLookUpEditName = "CustomGridLookUpEdit";

        static RepositoryItemCustomGridLookUpEdit()
        {
            RegisterCustomGridLookUpEdit();
        }

        public RepositoryItemCustomGridLookUpEdit()
        {
            TextEditStyle = TextEditStyles.Standard;
            AutoComplete = false;
        }

        [Browsable(false)]
        public override sealed TextEditStyles TextEditStyle
        {
            get { return base.TextEditStyle; }
            set { base.TextEditStyle = value; }
        }

        public override string EditorTypeName
        {
            get { return CustomGridLookUpEditName; }
        }

        public static void RegisterCustomGridLookUpEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomGridLookUpEditName,
                typeof (CustomGridLookUpEdit), typeof (RepositoryItemCustomGridLookUpEdit),
                typeof (GridLookUpEditBaseViewInfo), new ButtonEditPainter(), true));
        }

        protected override ColumnView CreateViewInstance()
        {
            return new CustomGridView();
        }

        protected override GridControl CreateGrid()
        {
            return new CustomGridControl();
        }
    }

    [ToolboxItem(true)]
    public class CustomGridLookUpEdit : GridLookUpEdit
    {
        static CustomGridLookUpEdit()
        {
            RepositoryItemCustomGridLookUpEdit.RegisterCustomGridLookUpEdit();
        }

        public override string EditorTypeName
        {
            get { return RepositoryItemCustomGridLookUpEdit.CustomGridLookUpEditName; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomGridLookUpEdit Properties
        {
            get { return base.Properties as RepositoryItemCustomGridLookUpEdit; }
        }

        protected new CustomPopupGridLookUpEditForm PopupForm { get { return (CustomPopupGridLookUpEditForm)base.PopupForm; } }

        public class CustomPopupGridLookUpEditForm : PopupGridLookUpEditForm
        {
            public CustomPopupGridLookUpEditForm(CustomGridLookUpEdit ownerEdit) : base(ownerEdit) { }

        }
    }
}