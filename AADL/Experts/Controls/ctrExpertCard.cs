using AADL.Lists;
using AADL.Regulators;
using AADLBusiness;
using AADLBusiness.Expert;
using AADLBusiness.Lists.Closed;
using AADLBusiness.Lists.WhiteList;
using DVLD.Classes;
using System;
using System.Windows.Forms;

namespace AADL.Experts.Controls
{
    public partial class ctrExpertCard : UserControl
    {
        public event Action ExpertInfoUpdated;

        // the pramas are only there to match the signature of the delegate in frmAddUpdatePractitioner
        protected virtual void OnExpertInfoUpdated(object sender, EventArgs e)
        {
            ExpertInfoUpdated?.Invoke();

            // Refresh card 
            LoadExpertInfo(_ID, _findBy);
        }

        protected virtual void OnExpertInfoUpdated()
        {
            ExpertInfoUpdated?.Invoke();

            // Refresh card 
            LoadExpertInfo(_ID, _findBy);
        }

        private void _Subscribe(frmPersonInfo frm)
        {
            frm.PersonUpdated += OnExpertInfoUpdated;
        }

        private void _Subscribe(frmAddUpdatePractitioner frm)
        {
            frm.evPractitionerUpdated += OnExpertInfoUpdated;
        }
        private void _settings()
        {
            clsUtil.ListViewSettings(lvCasestypes);
        }
        public ctrExpertCard()
        {
            InitializeComponent();
        }

        private clsExpert _expert;
        private clsExpert.enFindBy _findBy;
        private int _ID;

        private void _FillFormWithExpertInfo()
        {
            lblExpertID.Text = _expert.ExpertID.ToString();
            lblFullName.Text = _expert.SelectedPersonInfo.FullName;
            lblSubscriptionType.Text = _expert.SubscriptionTypeInfo.SubscriptionName;
            lblSubscriptionWay.Text = _expert.SubscriptionWayInfo.SubscriptionName;
            lblCreatedByUserID.Text = _expert.UserInfo.UserName;
            lblIssueDate.Text = _expert.IssueDate.ToShortDateString();
            lblLastEditDate.Text = _expert.LastEditDate?.ToString() ?? "[????]";
            llblBlackList.Enabled = _expert.IsPractitionerInBlackList();
            llblWhiteList.Enabled = (clsWhiteList.IsPractitionerInWhiteList(_expert.PractitionerID,
                clsPractitioner.enPractitionerType.Expert));
            llblClosedList.Enabled = (clsClosedList.IsPractitionerInClosedList(_expert.PractitionerID,
               clsPractitioner.enPractitionerType.Expert));
            llblEditExpertInfo.Enabled = _expert.IsActive;
            llblPersonInfo.Enabled = true;
            // Handle Expert Casess
            lvCasestypes.Items.Clear();
            if (_expert.ExpertCasesPracticeIDNameDictionary != null && _expert.ExpertCasesPracticeIDNameDictionary.Count != 0)
            {
                int count = 0;
                foreach (var item in _expert.ExpertCasesPracticeIDNameDictionary.Values)
                {
                    lvCasestypes.Items.Add($"  {++count}- {item}");
                }
            }
            else
            {
                lvCasestypes.Items.Add("لا يوجد قضايا");
            }
        }
        public void LoadExpertInfo(int ID, clsExpert.enFindBy findBy)
        {
            _ID = ID;
            _findBy = findBy;

            _expert = clsExpert.Find(ID, findBy);

            if (_expert == null)
            {
                MessageBox.Show($"لا يوجد خبير يحمل الرقم التعريفي ({_ID})", "غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetExpertInfo();
                return;
            }

            _FillFormWithExpertInfo();
        }

        public void ResetExpertInfo()
        {
            //Expert info
            _ID = -1;
            lblExpertID.Text = "[????]";
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
            llblEditExpertInfo.Enabled = false;
            llblBlackList.Enabled = false;
            llblWhiteList.Enabled = false;
            llblClosedList.Enabled = false;
        }

        private void llblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo(_expert.PersonID);
            _Subscribe(frm);
            frm.ShowDialog();
        }

        private void llblEditExpertInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePractitioner form = new frmAddUpdatePractitioner(_expert.PractitionerID,
              frmAddUpdatePractitioner.enRunSpecificTabPage.Expert);
            _Subscribe(form);
            form.ShowDialog();
        }

        private void llblBlackList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmListInfo frmListInfo = new frmListInfo(clsBlackList.Find(_expert.PractitionerID, clsBlackList.enFindBy.PractitionerID).BlackListID
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
                frmListInfo ListInfoForm = new frmListInfo((int)clsWhiteList.Find(_expert.PractitionerID,
              clsPractitioner.enPractitionerType.Expert).WhiteListID,
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
                    frmListInfo ListInfoForm = new frmListInfo((int)clsClosedList.Find(_expert.PractitionerID,
              clsPractitioner.enPractitionerType.Expert).ClosedListID,
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
