using AADL.Judgers.Controls;
using System;
using System.Windows.Forms;

namespace AADL.Judgers
{
    public partial class frmJudgerCard : Form
    {
        public event Action JudgerInfoUpdated;

        protected virtual void OnJudgerInfoUpdated() => JudgerInfoUpdated?.Invoke();

        private void _Subscribe(ctrJudgerCard judgerCard) => judgerCard.JudgerInfoUpdated += OnJudgerInfoUpdated;

        ctrJudgerCard.enWhichID _whichID;
        int _ID;

        public frmJudgerCard(int ID, ctrJudgerCard.enWhichID whichID)
        {
            InitializeComponent();
            _ID = ID;
            _whichID = whichID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmJudgerCard_Load(object sender, EventArgs e)
        {
            _Subscribe(ctrJudgerCard1);
            ctrJudgerCard1.LoadJudgerInfo(_ID, _whichID);
        }
    }
}
