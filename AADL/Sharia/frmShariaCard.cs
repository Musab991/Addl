using AADL.Judgers.Controls;
using AADL.Sharia.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AADL.Sharia
{
    public partial class frmShariaCard : Form
    {
        public event Action ShariaInfoUpdated;

        protected virtual void OnShariaInfoUpdated() => ShariaInfoUpdated?.Invoke();

        private void _Subscribe(ctrlShariaCard shariaCard) => shariaCard.ShariaInfoUpdated += OnShariaInfoUpdated;

        ctrlShariaCard.enWhichID _whichID;
        int _ID;
        public frmShariaCard(int ID, ctrlShariaCard.enWhichID whichID)
        {
            InitializeComponent();
            _ID = ID;
            _whichID = whichID;
        }
        public frmShariaCard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmShariaCard_Load(object sender, EventArgs e)
        {
            _Subscribe(ctrlShariaCard1);
            ctrlShariaCard1.LoadShariaInfo(_ID, _whichID);
        }
    }
}
