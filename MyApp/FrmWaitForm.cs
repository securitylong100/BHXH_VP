using DevExpress.XtraWaitForm;

namespace XML130
{
    public partial class FrmWaitForm : WaitForm
    {
        public enum WaitFormCommand
        {
        }

        public FrmWaitForm()
        {
            InitializeComponent();

            progressPanel.AutoHeight = true;
            try
            {
                SetCaption("Vui lòng đợi");
                SetDescription("Hệ thống đang tải dữ liệu ...");
            }
            catch
            {
            }
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel.Caption = caption;
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel.Description = description;
        }

        #endregion
    }
}