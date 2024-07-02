using AADL.Lists;
using AADLBusiness;
using AADLBusiness.Lists.Closed;
using AADLBusiness.Lists.WhiteList;
using DVLD.Classes;
using System;
using System.Windows.Forms;

namespace AADL.Regulators
{
    public partial class ctrlRegulatorCard : UserControl
    {
        public event Action RegulatorInfoUpdated;

        // the pramas are only there to match the signature of the delegate in frmAddUpdatePractitioner
        protected virtual void OnRegulatorInfoUpdated(object sender, EventArgs e)
        {
            RegulatorInfoUpdated?.Invoke();

            // Refresh card 
            LoadRegulatorInfo(_value, _enLoadRegulatorBy);
        }

        protected virtual void OnRegulatorInfoUpdated()
        {
            RegulatorInfoUpdated?.Invoke();

            // Refresh card 
            LoadRegulatorInfo(_value, _enLoadRegulatorBy);
        }

        private void _Subscribe(frmPersonInfo frm)
        {
            frm.PersonUpdated += OnRegulatorInfoUpdated;
        }

        private void _Subscribe(frmAddUpdatePractitioner frm)
        {
            frm.evPractitionerUpdated += OnRegulatorInfoUpdated;
            frm.evPractitionerUpdated += _ResetOnDemand;
        }
        private void _settings()
        {
            clsUtil.ListViewSettings(lvCasestypes);
        }

        private LoadRegulatorBy _enLoadRegulatorBy;
        private object _value;

        public enum LoadRegulatorBy { PersonID, RegulatorID, MembershipNumber,PractitionerID };

        public enum LoadShariaBy { PersonID, ShariaID, ShariaLicenseNumber, PractitionerID };

        public enum enCreationMode { Regulator,Sharia,Expert,Judger}
        
        private clsRegulator _Regulator;

        private int? _RegulatorID = null;

        public int? RegulatorID
        {
            get { return _RegulatorID; }
        }

        public clsRegulator SelectedRegulatorInfo
        {
            get { return _Regulator; }
        }

        public ctrlRegulatorCard()
        {
            InitializeComponent();
        }

        public void LoadRegulatorInfo<T>(T Value, LoadRegulatorBy enLoadRegulatorBy)
        {
            _enLoadRegulatorBy = enLoadRegulatorBy;
            _value = Value;

            switch (enLoadRegulatorBy)
            {
                case LoadRegulatorBy.RegulatorID:
                    {

                        if (Value != null && int.TryParse(Value.ToString(), out int RegulatorID))
                        {
                            _Regulator = clsRegulator.Find(RegulatorID, clsRegulator.enSearchBy.RegulatorID);
                            if (_Regulator == null)
                            {
                                MessageBox.Show("لا يوجد شخص يحمل (الرقم التعريفي) .  = " + RegulatorID.ToString(), "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        break;
                    }

                case LoadRegulatorBy.PersonID:
                    {

                        if (Value != null && int.TryParse(Value.ToString(), out int PersonID))
                        {
                            _Regulator = clsRegulator.Find(PersonID, clsRegulator.enSearchBy.PersonID);
                            if (_Regulator == null)
                            {
                                MessageBox.Show("لا يوجد شخص يحمل (الرقم التعريفي) .  = " + PersonID.ToString(), "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        break;
                    }

                case LoadRegulatorBy.MembershipNumber:
                    {
                        string MembershipNumber = Value.ToString();
                        if (!string.IsNullOrEmpty(MembershipNumber))
                        {
                            _Regulator = clsRegulator.Find(MembershipNumber, clsRegulator.enSearchBy.MembershipNumber);
                            if (_Regulator == null)
                            {
                                MessageBox.Show("لا يوجد شخص يحمل (الرقم التعريفي) .  = " + MembershipNumber.ToString(), "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        break;
                    }

                case LoadRegulatorBy.PractitionerID:
                    {

                        if (Value != null && int.TryParse(Value.ToString(), out int PractitionerID))
                        {
                            _Regulator = clsRegulator.Find(PractitionerID, clsRegulator.enSearchBy.PractitionerID);
                            if (_Regulator == null)
                            {
                                MessageBox.Show("لا يوجد شخص يحمل (الرقم التعريفي) .  = " + PractitionerID.ToString(), "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        break;

                    }

            }
            _FillRegulatorInfo();

        }

        private void _FillRegulatorInfo()
        {
            ResetRegulatorInfo();
            try
            {
                lbFullName.Text = _Regulator.SelectedPersonInfo.FullName;
                llEditRegulatorInfo.Enabled = true;
                lbPersonInfo.Enabled = _Regulator!=null;
                lbBlackList.Enabled = _Regulator.IsPractitionerInBlackList();
                lbWhiteList.Enabled = (clsWhiteList.IsPractitionerInWhiteList(_Regulator.PractitionerID,
                    clsPractitioner.enPractitionerType.Regulatory));
                 lbClosedList.Enabled = (clsClosedList.IsPractitionerInClosedList(_Regulator.PractitionerID,
                    clsPractitioner.enPractitionerType.Regulatory));

                //Regulator info.
                _RegulatorID = _Regulator.RegulatorID;
                lblRegulatorID.Text = _Regulator.RegulatorID.ToString();
                lbMemberShip.Text = _Regulator.MembershipNumber;
                lbSubscriptionType.Text = _Regulator.SubscriptionTypeInfo.SubscriptionName;
                lbSubscriptionWay.Text = _Regulator.SubscriptionWayInfo.SubscriptionName;

                llEditRegulatorInfo.Enabled = _Regulator.IsActive;
                //Edit and create 
                lbCreatedByUserID.Text = _Regulator.UserInfo.UserName;
                lbIssueDate.Text = _Regulator.IssueDate.ToShortDateString();
                lbLastEditDate.Text = _Regulator.LastEditDate == null?"[????]" : _Regulator.LastEditDate.ToString();

                //cases practice
                try
                {
                    lvCasestypes.Items.Clear();
                    if (_Regulator.RegulatorCasesPracticeIDNameDictionary != null && _Regulator.RegulatorCasesPracticeIDNameDictionary.Count != 0)
                    {

                        foreach (string CaseTypeName in _Regulator.RegulatorCasesPracticeIDNameDictionary.Values)
                        {
                            if (!string.IsNullOrEmpty(CaseTypeName))
                            {

                                lvCasestypes.Items.Add(CaseTypeName);
                            }
                        }

                    }
                    else
                    {
                        lvCasestypes.Items.Add("لا يوجد قضايا");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطاء فني اثناء اضافة قضايا المحامي .. \n" + ex.Message, "خطاء",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clsGlobal.WriteEventToLogFile("Problem in regulator Card info ,while uploading cases practice,Exception:\n" +
                        ex.Message, System.Diagnostics.EventLogEntryType.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("بعض الحقول قد تكون فارغة بسسب مشكلة داخلية اثناء التحميل", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsHelperClasses.WriteEventToLogFile("Error at card regulator info ctrl , while loading properties of regulator info ,\n" +
                    "some properties drop exception:" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

        }

        public void ResetRegulatorInfo()
        {
            //Regulator info
            _RegulatorID = -1;
            lbMemberShip.Text = "[????]";
            lbSubscriptionType.Text = "[????]";
            lbSubscriptionWay.Text = "[????]";
            lblRegulatorID.Text = "[????]";
            lbFullName.Text = "[????]";

            //Edit and create.
            lbCreatedByUserID.Text = "[????]";
            lbIssueDate.Text = "[????]";
            lbLastEditDate.Text = "[????]";

            ////list view 
            lvCasestypes.Items.Clear();
            lvCasestypes.Columns.Clear();

            //Link label
            llEditRegulatorInfo.Enabled = false;
            lbBlackList.Enabled = false;
            lbWhiteList.Enabled = false;
            lbClosedList.Enabled = false;
        }

        public void _ResetOnDemand(object sender, EventArgs e)
        {
            _FillRegulatorInfo();
        }

        private void llEditRegulatorInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePractitioner frmAddUpdatePractitioner = new frmAddUpdatePractitioner(_Regulator.PractitionerID,
                frmAddUpdatePractitioner.enRunSpecificTabPage.Regulatory);
            _Subscribe(frmAddUpdatePractitioner);
            frmAddUpdatePractitioner.ShowDialog();
        }

        private void lbBlackList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmListInfo frmListInfo = new frmListInfo(clsBlackList.Find(_Regulator.PractitionerID, clsBlackList.enFindBy.PractitionerID).BlackListID
                    , ctrlListInfo.CreationMode.BlackList);

                frmListInfo.ShowDialog();
            }catch (Exception ex)
            {
                Console.WriteLine("Exception:"+ex.ToString());

                MessageBox.Show("لقد حدث عطل فني داخل النظام , اثناء محاولة استرجاع البيانات .","فشل",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void lbWhiteList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmListInfo ListInfoForm= new frmListInfo((int)clsWhiteList.Find(_Regulator.PractitionerID,
                clsPractitioner.enPractitionerType.Regulatory).WhiteListID,
                ctrlListInfo.CreationMode.WhiteList);
            ListInfoForm.ShowDialog();
        }

        private void lbClosedList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmListInfo ListInfoForm = new frmListInfo((int)clsClosedList.Find(_Regulator.PractitionerID,
           clsPractitioner.enPractitionerType.Regulatory).ClosedListID,
           ctrlListInfo.CreationMode.ClosedList);
            ListInfoForm.ShowDialog();

        }

        private void lbPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonInfo frmPersonInfo = new frmPersonInfo(_Regulator.PersonID);
            _Subscribe(frmPersonInfo);
            frmPersonInfo.ShowDialog();
        }
    }
}
