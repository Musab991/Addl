using AADL.Experts.Controls;
using AADLBusiness.Expert;
using System;
using System.Windows.Forms;

namespace AADL.Experts
{
    public partial class frmExpertCard : Form
    {
        public event Action ExpertInfoUpdated;

        protected virtual void OnExpertInfoUpdated() => ExpertInfoUpdated?.Invoke();

        private void _Subscribe(ctrExpertCard expertCard) => expertCard.ExpertInfoUpdated += OnExpertInfoUpdated;

        private int _ID;
        private clsExpert.enFindBy _findBy;

        public frmExpertCard(int ID, clsExpert.enFindBy findBy)
        {
            InitializeComponent();
            _ID = ID;
            _findBy = findBy;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmExpertCard_Load(object sender, EventArgs e)
        {
            _Subscribe(ctrExpertCard1);
            ctrExpertCard1.LoadExpertInfo(_ID, _findBy);
        }
    }
}
