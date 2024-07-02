using AADL.Lists;
using AADL.Regulators;
using AADLBusiness;
using AADLBusiness.Judger;
using AADLBusiness.Lists.Closed;
using AADLBusiness.Lists.WhiteList;
using DVLD.Classes;
using System;
using System.Windows.Forms;

namespace AADL.Judgers.Controls
{
    public partial class ctrJudgerCard : UserControl
    {
        public event Action JudgerInfoUpdated;

        // the pramas are only there to match the signature of the delegate in frmAddUpdatePractitioner
        protected virtual void OnJudgerInfoUpdated(object sender, EventArgs e)
        {
            JudgerInfoUpdated?.Invoke();

            // Refresh card 
            LoadJudgerInfo(_ID, _whichID);
        }

        protected virtual void OnJudgerInfoUpdated()
        {
            JudgerInfoUpdated?.Invoke();

            // Refresh card 
            LoadJudgerInfo(_ID, _whichID);
        }

        private void _Subscribe(frmPersonInfo frm)
        {
            frm.PersonUpdated += OnJudgerInfoUpdated;
        }

        private void _Subscribe(frmAddUpdatePractitioner frm)
        {
            frm.evPractitionerUpdated += OnJudgerInfoUpdated;
            frm.evPractitionerUpdated += _ResetOnDemand;
        }
        private void _settings()
        {
            clsUtil.ListViewSettings(lvCasestypes);
        }
        public enum enWhichID { JudgerID = 1, PractitionerID, PersonID }
        private clsJudger _judger;
        private int _ID;
        private enWhichID _whichID;
        public ctrJudgerCard()
        {
            InitializeComponent();
        }

        private void _FillFormWithJudgerInfo()
        {
            lblJudgerID.Text = _judger.JudgerID.ToString();
            lblFullName.Text = _judger.SelectedPersonInfo.FullName;
            lblSubscriptionType.Text = _judger.SubscriptionTypeInfo.SubscriptionName;
            lblSubscriptionWay.Text = _judger.SubscriptionWayInfo.SubscriptionName;
            lblCreatedByUserID.Text = _judger.UserInfo.UserName;
            lblIssueDate.Text = _judger.IssueDate.ToShortDateString();
            lblLastEditDate.Text = _judger.LastEditDate?.ToString() ?? "[????]";
            llblBlackList.Enabled = _judger.IsPractitionerInBlackList();
            llblWhiteList.Enabled = (clsWhiteList.IsPractitionerInWhiteList(_judger.PractitionerID,
                clsPractitioner.enPractitionerType.Judger));
            llblClosedList.Enabled = (clsClosedList.IsPractitionerInClosedList(_judger.PractitionerID,
               clsPractitioner.enPractitionerType.Judger));

            llblEditJudgerInfo.Enabled = _judger.IsActive;

            // Handle Judger Casess
            lvCasestypes.Items.Clear();

            if (_judger.JudgeCasesPracticeIDNameDictionary != null && _judger.JudgeCasesPracticeIDNameDictionary.Count != 0)
            {
                int count = 0;
                foreach (var item in _judger.JudgeCasesPracticeIDNameDictionary.Values)
                {
                    lvCasestypes.Items.Add($"  {++count}- {item}");
                }
            }
            else
            {
                lvCasestypes.Items.Add("لا يوجد قضايا");
            }
        }

        public void LoadJudgerInfo(int ID, enWhichID whichID)
        {
            _ID = ID;
            _whichID = whichID;

            switch (whichID)
            {
                case enWhichID.JudgerID:
                    _judger = clsJudger.FindByJudgerID(ID);
                    break;
                case enWhichID.PractitionerID:
                    _judger = clsJudger.FindByPractitionerID(ID);
                    break;
                case enWhichID.PersonID:
                    _judger = clsJudger.FindByPersonID(ID);
                    break;
                default:
                    _judger = null;
                    break;
            }

            if(_judger == null) 
            {
                MessageBox.Show($"لا يوجد محكم يحمل الرقم التعريفي ({_ID})", "غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetJudgerInfo();
                return;
            }

            _FillFormWithJudgerInfo();
        }

        public void ResetJudgerInfo()
        {
            //Judger info
            _ID = -1;
            lblJudgerID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblSubscriptionType.Text = "[????]";
            lblSubscriptionWay.Text = "[????]";

            //Edit and create.
            lblCreatedByUserID.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblLastEditDate.Text = "[????]";

            ////list view 
            lvCasestypes.Items.Clear();
            lvCasestypes.Columns.Clear();

            //Link label
            llblPersonInfo.Enabled = false;
            llblEditJudgerInfo.Enabled = false;
            llblBlackList.Enabled = false;
            llblWhiteList.Enabled = false;
            llblClosedList.Enabled = false;
        }

        private void llblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo(_judger.PersonID);
            _Subscribe(frm);    
            frm.ShowDialog();
        }

        private void _ResetOnDemand(object sender, EventArgs e)
        {
            ResetJudgerInfo();
            _FillFormWithJudgerInfo();
        }

        private void llblEditJudgerInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePractitioner form = new frmAddUpdatePractitioner(_judger.PractitionerID,
                frmAddUpdatePractitioner.enRunSpecificTabPage.Judger);
            _Subscribe(form);
            form.ShowDialog();
        }

        private void llblBlackList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmListInfo frmListInfo = new frmListInfo(clsBlackList.Find(_judger.PractitionerID, clsBlackList.enFindBy.PractitionerID).BlackListID
                    , ctrlListInfo.CreationMode.BlackList);

                frmListInfo.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.ToString());

                MessageBox.Show("لقد حدث عطل فني داخل النظام , اثناء محاولة استرجاع البيانات .", "فشل",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblWhiteList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmListInfo ListInfoForm = new frmListInfo((int)clsWhiteList.Find(_judger.PractitionerID,
              clsPractitioner.enPractitionerType.Judger).WhiteListID,
              ctrlListInfo.CreationMode.WhiteList);
            ListInfoForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.ToString());

                MessageBox.Show("لقد حدث عطل فني داخل النظام , اثناء محاولة استرجاع البيانات .", "فشل",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblClosedList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmListInfo ListInfoForm = new frmListInfo((int)clsClosedList.Find(_judger.PractitionerID,
          clsPractitioner.enPractitionerType.Judger).ClosedListID,
          ctrlListInfo.CreationMode.ClosedList);
                ListInfoForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.ToString());

                MessageBox.Show("لقد حدث عطل فني داخل النظام , اثناء محاولة استرجاع البيانات .", "فشل",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
