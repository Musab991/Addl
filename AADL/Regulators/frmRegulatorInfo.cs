using AADLBusiness;
using System;
using System.Windows.Forms;

namespace AADL.Regulators
{
    public partial class frmRegulatorInfo : Form
    {
        public event Action RegulatorInfoUpdated;

        protected virtual void OnRegulatorInfoUpdated() => RegulatorInfoUpdated?.Invoke();

        private void _Subscribe(ctrlRegulatorCard judgerCard) => judgerCard.RegulatorInfoUpdated += OnRegulatorInfoUpdated;

        private int _RegulatorID = -1;

        public frmRegulatorInfo(int RegulatorID)
        {
            _RegulatorID = RegulatorID;
            InitializeComponent();
        }


        private void frmRegulatorInfo_Load(object sender, EventArgs e)
        {
            try
            {
                if (_RegulatorID != -1)
                {
                    _Subscribe(ctrlRegulatorCard1);
                    ctrlRegulatorCard1.LoadRegulatorInfo(_RegulatorID, ctrlRegulatorCard.LoadRegulatorBy.RegulatorID);
                }
                else
                {
                    MessageBox.Show("الرقم التعريفي للمحامي النظامي ,غير مدخل بشكل صحيح", "فشل",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile("Regulator info form ,\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                Console.Error.WriteLine(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    
    }

}
