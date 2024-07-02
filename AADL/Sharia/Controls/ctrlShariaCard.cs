using AADL.Lists;
using AADL.Regulators;
using AADLBusiness.Sharia;
using AADLBusiness.Lists.Closed;
using AADLBusiness.Lists.WhiteList;
using AADLBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Diagnostics.Tracing.Parsers.Kernel;
using DVLD.Classes;

namespace AADL.Sharia.Controls
{
    public partial class ctrlShariaCard : UserControl
    {
        public ctrlShariaCard()
        {
            InitializeComponent();
        }
        public event Action ShariaInfoUpdated;

        // the pramas are only there to match the signature of the delegate in frmAddUpdatePractitioner
        protected virtual void OnShariaInfoUpdated(object sender, EventArgs e)
        {
            ShariaInfoUpdated?.Invoke();

            // Refresh card 
            LoadShariaInfo(_ID, _whichID);
        }

        protected virtual void OnShariaInfoUpdated()
        {
            ShariaInfoUpdated?.Invoke();

            // Refresh card 
            LoadShariaInfo(_ID, _whichID);
        }

        private void _Subscribe(frmPersonInfo frm)
        {
            frm.PersonUpdated += OnShariaInfoUpdated;
        }

        private void _Subscribe(frmAddUpdatePractitioner frm)
        {
            frm.evPractitionerUpdated += OnShariaInfoUpdated;
        }

        public enum enWhichID { ShariaID = 1,ShariaLicenseNumber, PractitionerID, PersonID }
        private clsSharia _Sharia;
        private int _ID;
        private enWhichID _whichID;

        private void _FillFormWithShariaInfo()
        {
            try
            {

                lblShariaID.Text = _Sharia.ShariaID.ToString();
                lblFullName.Text = _Sharia.SelectedPersonInfo.FullName;
                lblShariaLicenesNumber.Text = _Sharia.ShariaLicenseNumber;
                lblSubscriptionType.Text = _Sharia.SubscriptionTypeInfo.SubscriptionName;
                lblSubscriptionWay.Text = _Sharia.SubscriptionWayInfo.SubscriptionName;
                lblCreatedByUserID.Text = _Sharia.UserInfo.UserName;
                lblIssueDate.Text = _Sharia.IssueDate.ToShortDateString();
                lblLastEditDate.Text = _Sharia.LastEditDate?.ToString() ?? "[????]";
                llblBlackList.Enabled = _Sharia.IsPractitionerInBlackList();
                llblWhiteList.Enabled = (clsWhiteList.IsPractitionerInWhiteList(_Sharia.PractitionerID,
                    clsPractitioner.enPractitionerType.Sharia));
                llblClosedList.Enabled = (clsClosedList.IsPractitionerInClosedList(_Sharia.PractitionerID,
                   clsPractitioner.enPractitionerType.Sharia));
                llblEditShariaInfo.Enabled = _Sharia.IsActive;
                // Handle Sharia Casess
                lvCasestypes.Items.Clear();

                if (_Sharia.ShariaCasesPracticeIDNameDictionary != null && _Sharia.ShariaCasesPracticeIDNameDictionary.Count != 0)
                {
                    int count = 0;
                    foreach (var item in _Sharia.ShariaCasesPracticeIDNameDictionary.Values)
                    {
                        lvCasestypes.Items.Add($"  {++count}- {item}");
                    }

                }
                else
                {
                    lvCasestypes.Items.Add("لا يوجد قضايا");
                }
            }
            catch (Exception ex) {
                clsHelperClasses.WriteEventToLogFile("Exception dropped from sharia card control:\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        private void _settings()
        {
            clsUtil.ListViewSettings(lvCasestypes);
        }
        public void LoadShariaInfo(int ID, enWhichID whichID)
        {
            _ID = ID;
            _whichID = whichID;

            switch (whichID)
            {
                case enWhichID.ShariaID:
                    _Sharia = clsSharia.Find(ID,clsSharia.enSearchBy.ShariaID);
                    break;
                case enWhichID.PractitionerID:
                    _Sharia = clsSharia.Find(ID, clsSharia.enSearchBy.PractitionerID);
                    break;
                case enWhichID.PersonID:
                    _Sharia = clsSharia.Find(ID, clsSharia.enSearchBy.PersonID);
                    break;
                case enWhichID.ShariaLicenseNumber:
                    _Sharia = clsSharia.Find(ID, clsSharia.enSearchBy.ShariaLicenseNumber);
                    break;
                default:
                    _Sharia = null;
                    break;
            }

            if (_Sharia == null)
            {
                MessageBox.Show($"لا يوجد محكم يحمل الرقم التعريفي ({_ID})", "غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetShariaInfo();
                return;
            }

            _FillFormWithShariaInfo();
            _settings();
        }

        public void ResetShariaInfo()
        {
            //Sharia info
            _ID = -1;
            lblShariaID.Text = "[????]";
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
            llblEditShariaInfo.Enabled = false;
            llblBlackList.Enabled = false;
            llblWhiteList.Enabled = false;
            llblClosedList.Enabled = false;
        }
        private void llblBlackList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmListInfo frmListInfo = new frmListInfo(clsBlackList.Find(_Sharia.PractitionerID, clsBlackList.enFindBy.PractitionerID).BlackListID
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
                frmListInfo ListInfoForm = new frmListInfo((int)clsWhiteList.Find(_Sharia.PractitionerID,
              clsPractitioner.enPractitionerType.Sharia).WhiteListID,
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
                    frmListInfo ListInfoForm = new frmListInfo((int)clsClosedList.Find(_Sharia.PractitionerID,
              clsPractitioner.enPractitionerType.Sharia).ClosedListID,
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

        private void llblEditShariaInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePractitioner form = new frmAddUpdatePractitioner(_Sharia.PractitionerID,
                frmAddUpdatePractitioner.enRunSpecificTabPage.Sharia);
            _Subscribe(form);
            form.ShowDialog();
        }

        private void llblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo(_Sharia.PersonID);
            _Subscribe(frm);
            frm.ShowDialog();
          
        }
    
    }

}
