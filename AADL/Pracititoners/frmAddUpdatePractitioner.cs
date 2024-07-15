using AADL.GlobalClasses;
using AADL.Lists;
using AADLBusiness;
using AADLBusiness.Expert;
using AADLBusiness.Judger;
using AADLBusiness.Sharia;
using AADLBusiness.Lists.Closed;
using AADLBusiness.Lists.WhiteList;
using MethodTimer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AADL.Regulators
{
   
    public partial class frmAddUpdatePractitioner : Form
    {
        // Define a delegate for the event handler
        public delegate void EntityAddedEventHandler(object sender, EventArgs e);

        // Define the event in PractitionerForm
        public event EntityAddedEventHandler evNewPractitionerAdded;

        // Define a delegate for the event handler
        public delegate void EntityUpdatedEventHandler(object sender, EventArgs e);

        // Define the event in PractitionerForm
        public event EntityUpdatedEventHandler evPractitionerUpdated;
        private enum enSubscriptionType { Free=1,Medium=2,Special=3};
        private enum enSubscriptionWay{ SpecialSupport=1, scholarship = 2};

        public enum enRunSpecificTabPage { Regulatory,Sharia,Expert,Judger,Personal};
        public enum enMode { AddNew = 0, Update = 1 }
    

        private enMode _Mode;

        private enMode _RegulatorMode;

        private enMode _ShariaMode;

        private enMode _ExpertMode;

        private enMode _JudgerMode;


        private int _PractitionerID = -1;
        clsRegulator _Regulator;
        clsSharia _Sharia;
        clsJudger _Judger;
        clsExpert _Expert;

        private enRunSpecificTabPage _initialTabPage = enRunSpecificTabPage.Personal;
        protected virtual void OnEntityAdded(EventArgs e)
        {
            if(evNewPractitionerAdded != null)
            {

            evNewPractitionerAdded(this, e);
            }
        }
        protected virtual void OnEntityUpdated(EventArgs e)
        {
            if (evPractitionerUpdated != null)
            {

                evPractitionerUpdated(this, e);
            }
        }


        public frmAddUpdatePractitioner()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            ctrlPersonCardWithFilter1.OnPersonComplete += CheckItOut;

        }
        private void CheckItOut(object sender, PersonCompleteEventArgs e)
        {

            if (e.PersonID == null)
            {
                _SwitchCurrentMode();
                MessageBox.Show("لا يمكن اضافة او تعديل بيانات لهذا الشخص , لعدم وجود بيانات مدنية له.", "فشل", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                clsGlobal.WriteEventToLogFile("Lack of accurate personID, to the lawyer or practitioner in add/update practitioner info",
                    System.Diagnostics.EventLogEntryType.Error);
                _ResetDefaultValues();
            }

        }
        public frmAddUpdatePractitioner(int  practitionerID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PractitionerID = practitionerID;
            ctrlPersonCardWithFilter1.OnPersonComplete += CheckItOut;
        }
        public frmAddUpdatePractitioner(int practitionerID,enRunSpecificTabPage RunSpecificTab)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PractitionerID = practitionerID;
            ctrlPersonCardWithFilter1.OnPersonComplete += CheckItOut;
            _initialTabPage = RunSpecificTab;
        }
        private void MoveTabPage()
        {

            switch (_initialTabPage)
            {
                case enRunSpecificTabPage.Regulatory:
                    {
                        tcPractitionernfo.SelectedTab = tpRegulatorInfo;
                        cbAddRegulator.Checked = true;
                        break;
                    }
                case enRunSpecificTabPage.Sharia:
                    {

                        tcPractitionernfo.SelectedTab = tpShariaInfo;
                        cbAddSharia.Checked = true;

                        break;

                    }
                case enRunSpecificTabPage.Judger:
                    {

                        tcPractitionernfo.SelectedTab = tpJudgerInfo;
                        cbAddJudger.Checked = true;
                        break;

                    }
                case enRunSpecificTabPage.Expert:
                    {

                        tcPractitionernfo.SelectedTab = tpExpertInfo;
                        cbAddExpert.Checked = true;
                        break;

                    }
            }


        }

        [Time]
        private void _loadRegulatoryCasesTypes()
        {
            
            try
            {

                DataTable RegulatoryCasesTypeDataTable = clsRegulatoryCaseType.All();
                if (RegulatoryCasesTypeDataTable.Rows.Count > 0)
                {

                    foreach (DataRow row in RegulatoryCasesTypeDataTable.Rows)
                    {
                        int RegulatoryCaseTypeID = (int)row["RegulatoryCaseTypeID"];
                        string RegulatoryCaseTypeName = (string)row["RegulatoryCaseTypeName"];

                        clsGlobal.CheckListBoxItem RegulatoryCaseTypeItem = new clsGlobal.CheckListBoxItem(RegulatoryCaseTypeID,
                            RegulatoryCaseTypeName);

                        clbRegulatoryCasesTypes.Items.Add(RegulatoryCaseTypeItem); // Add item using Name column

                    }
                }

            }
            catch (Exception ex)
            {
                clsGlobal.WriteEventToLogFile("Exception dropped at regulator form add/update while loading cases types ",
                                  System.Diagnostics.EventLogEntryType.Error);
                MessageBox.Show("Exception dropped while loading Lists cases !!\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void _loadShariaCasesTypes()
        {
            try
            {

                DataTable ShariaCasesTypeDataTable = clsShariaCaseType.All();
                if (ShariaCasesTypeDataTable.Rows.Count > 0)
                {

                    foreach (DataRow row in ShariaCasesTypeDataTable.Rows)
                    {
                        int ShariaCaseTypeID = (int)row["ShariaCaseTypeID"];
                        string ShariaCaseTypeName = (string)row["ShariaCaseTypeName"];

                        clsGlobal.CheckListBoxItem ShariaCaseTypeItem = new clsGlobal.CheckListBoxItem(ShariaCaseTypeID,
                            ShariaCaseTypeName);

                        clbShariaCasesTypes.Items.Add(ShariaCaseTypeItem);// Add item using Name column

                    }
                }

            }
            catch (Exception ex)
            {
                clsGlobal.WriteEventToLogFile("Exception dropped at Sharia form add/update while loading cases types ",
                                  System.Diagnostics.EventLogEntryType.Error);
                MessageBox.Show("Exception dropped while loading Lists cases !!\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void _loadJudgerCasesTypes()
        {
            try
            {

                DataTable JudgerCasesTypeDataTable = clsJudgeCaseType.All();
                if (JudgerCasesTypeDataTable.Rows.Count > 0)
                {

                    foreach (DataRow row in JudgerCasesTypeDataTable.Rows)
                    {
                        int JudgerCaseTypeID = (int)row["JudgeCaseTypeID"];
                        string JudgerCaseTypeName = (string)row["JudgeCaseTypeName"];

                        clsGlobal.CheckListBoxItem JudgerCaseTypeItem = new clsGlobal.CheckListBoxItem(JudgerCaseTypeID,
                            JudgerCaseTypeName);

                        clbJudgerCasesTypes.Items.Add(JudgerCaseTypeItem);// Add item using Name column

                    }
                }

            }
            catch (Exception ex)
            {
                clsGlobal.WriteEventToLogFile("Exception dropped at Judger form add/update while loading cases types ",
                                  System.Diagnostics.EventLogEntryType.Error);
                MessageBox.Show("Exception dropped while loading Lists cases !!\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void _loadExpertCasesTypes()
        {
            try
            {

                DataTable ExpertCasesTypeDataTable = clsExpertCaseType.All();
                if (ExpertCasesTypeDataTable.Rows.Count > 0)
                {

                    foreach (DataRow row in ExpertCasesTypeDataTable.Rows)
                    {
                        int ExpertCaseTypeID = (int)row["ExpertCaseTypeID"];
                        string ExpertCaseTypeName = (string)row["ExpertCaseTypeName"];

                        clsGlobal.CheckListBoxItem ExpertCaseTypeItem = new clsGlobal.CheckListBoxItem(ExpertCaseTypeID,
                            ExpertCaseTypeName);

                        clbExpertCasesTypes.Items.Add(ExpertCaseTypeItem);// Add item using Name column

                    }
                }

            }
            catch (Exception ex)
            {
                clsGlobal.WriteEventToLogFile("Exception dropped at Expert form add/update while loading cases types ",
                                  System.Diagnostics.EventLogEntryType.Error);
                MessageBox.Show("Exception dropped while loading Lists cases !!\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void _loadRegulatorInfoData()
        {
            try
            {
                _Regulator = clsRegulator.Find(_PractitionerID, clsRegulator.enSearchBy.PractitionerID);

                if (_Regulator != null)
                {

                    //the following code will not be executed if the regulator was not found
                    _LoadRegulatorCasesPractice();
                    lblRegulatorID.Text = _Regulator.RegulatorID.ToString();
                    ctbRegulatoryMembershipNumber.Text = _Regulator.MembershipNumber;
                    chkRegulatorIsActive.Checked = _Regulator.IsActive;
                    switch (_Regulator.SubscriptionTypeID)
                    {
                        case 1://Free
                            {
                                rbtnRegulatoryFree.Checked = true;
                                break;

                            }
                        case 2://Medium
                            {
                                rbtnRegulatoryMedium.Checked = true;
                                break;
                            }
                        case 3://Special
                            {
                                rbtnRegulatorySpecial.Checked = true;
                                break;
                            }
                    }
                    switch (_Regulator.SubscriptionWayID)
                    {
                        case 1://SCHOLARSHIP
                            {
                                rbtnRScholarship.Checked = true;
                                break;

                            }
                        case 2://SUPPORT
                            {
                                rbtnRSpecialSupport.Checked = true;
                                break;
                            }

                    }

                }

                else
                {
                    _RegulatorMode = enMode.AddNew;
                    MessageBox.Show("حدث هنالك خطاء فني  , اثناء تحميل البيانات المتعلقة بالمحامي النظامي","مشكلة",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                    //Ignore it ...
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("حدث خطاء فني اثناء تحميل البيانات ", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsHelperClasses.WriteEventToLogFile("Exception was dropped in ADd update practitioner form , while loading regulator info data,\n" + ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(ex.Message);

            }
        }
        private void _loadShariaInfoData()
        {
            try
            {
                _Sharia = clsSharia.Find(_PractitionerID, clsSharia.enSearchBy.PractitionerID);


                if (_Sharia != null)
                {
                    _LoadShariaCasesPractice();
                    //the following code will not be executed if the sharia was not found
                    lblShariaID.Text = _Sharia.ShariaID.ToString();
                    ctbShariaLicenseNumber.Text = _Sharia.ShariaLicenseNumber;
                    chkShariaIsActive.Checked = _Sharia.IsActive;
                    
                    switch (_Sharia.SubscriptionTypeID)
                    {
                        case 1://Free
                            {
                                rbtnShariaFree.Checked = true;
                                break;

                            }
                        case 2://Medium
                            {
                                rbtnShariaMedium.Checked = true;
                                break;
                            }
                        case 3://Special
                            {
                                rbtnShariaSpecial.Checked = true;
                                break;
                            }
                    }
                    switch (_Sharia.SubscriptionWayID)
                    {
                        case 1://Free
                            {
                                rbtnSScholarship.Checked = true;
                                break;

                            }
                        case 2://Medium
                            {
                                rbtnSSpecialSupport.Checked = true;
                                break;
                            }
                       
                    }

                }

                else
                {
                    _ShariaMode = enMode.AddNew;
                    MessageBox.Show("حدث هنالك خطاء فني  , اثناء تحميل البيانات المتعلقة بالمحامي الشرغي", "مشكلة",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Ignore it ...
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("حدث خطاء فني اثناء تحميل البيانات ", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsHelperClasses.WriteEventToLogFile("Exception was dropped in ADd update practitioner form, while loading sharia info data,\n" + ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(ex.Message);

            }
        }
        private void _loadJudgerInfoData()
        {
            try
            {
                _Judger = clsJudger.FindByPractitionerID(_PractitionerID);


                if (_Judger != null)
                {
                    _LoadJudgerCasesPractice();
                    //the following code will not be executed if the Judger was not found
                    lblJudgerID.Text = _Judger.JudgerID.ToString();
                    chkJudgerIsActive.Checked = _Judger.IsActive;

                    switch (_Judger.SubscriptionTypeID)
                    {
                        case 1://Free
                            {
                                rbtnJudgerFree.Checked = true;
                                break;

                            }
                        case 2://Medium
                            {
                                rbtnJudgerMedium.Checked = true;
                                break;
                            }
                        case 3://Special
                            {
                                rbtnJudgerSpecial.Checked = true;
                                break;
                            }
                    }
                    switch (_Judger.SubscriptionWayID)
                    {
                        case 1://Free
                            {
                                rbtnJScholarship.Checked = true;
                                break;

                            }
                        case 2://Medium
                            {
                                rbtnJSpecialSupport.Checked = true;
                                break;
                            }

                    }

                }

                else
                {
                    _JudgerMode = enMode.AddNew;
                    MessageBox.Show("حدث هنالك خطاء فني  , اثناء تحميل البيانات المتعلقة بالمحكم", "مشكلة",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Ignore it ...
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("حدث خطاء فني اثناء تحميل البيانات ", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsHelperClasses.WriteEventToLogFile("Exception was dropped in ADd update practitioner  form , while loading Judger info data,\n" + ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(ex.Message);

            }
        }
        private void _loadExpertInfoData()
        {
            try
            {
                _Expert = clsExpert.Find(_PractitionerID,clsExpert.enFindBy.PractitionerID);


                if (_Expert != null)
                {
                    _LoadExpertCasesPractice();
                    //the following code will not be executed if the Judger was not found
                    lblExpertID.Text = _Expert.ExpertID.ToString();
                    chkExpertIsActive.Checked = _Expert.IsActive;

                    switch (_Expert.SubscriptionTypeID)
                    {
                        case 1://Free
                            {
                                rbtnJudgerFree.Checked = true;
                                break;

                            }
                        case 2://Medium
                            {
                                rbtnJudgerMedium.Checked = true;
                                break;
                            }
                        case 3://Special
                            {
                                rbtnJudgerSpecial.Checked = true;
                                break;
                            }
                    }
                    switch (_Expert.SubscriptionWayID)
                    {
                        case 1://Free
                            {
                                rbtnJScholarship.Checked = true;
                                break;

                            }
                        case 2://Medium
                            {
                                rbtnJSpecialSupport.Checked = true;
                                break;
                            }

                    }

                }

                else
                {
                    _ExpertMode = enMode.AddNew;
                    MessageBox.Show("حدث هنالك خطاء فني  , اثناء تحميل البيانات المتعلقة بالخبير", "مشكلة",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Ignore it ...
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("حدث خطاء فني اثناء تحميل البيانات ", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsHelperClasses.WriteEventToLogFile("Exception was dropped in ADd update practitioner  form , while loading Judger info data,\n" + ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(ex.Message);

            }
        }
        private void _LoadRegulatorCasesPractice()
        {
            // Wait for the UI thread to process pending events
            if (_Regulator.RegulatorID != -1)
            {

                if (_Regulator.RegulatorCasesPracticeIDNameDictionary.Count > 0)
                {
                    for (int idx = 0; idx < clbRegulatoryCasesTypes.Items.Count; idx++)
                    {

                        clsGlobal.CheckListBoxItem item = (clsGlobal.CheckListBoxItem)clbRegulatoryCasesTypes.Items[idx];

                        // Check if the key case ID  exists in the Dictionary of cases of regulator 
                        if (_Regulator.RegulatorCasesPracticeIDNameDictionary.ContainsKey(item.ID))
                        {
                            // If the case ID  exists in the CheckedListBox items, set its checked state
                            clbRegulatoryCasesTypes.SetItemChecked(idx, true);
                        }

                    }

                    lbRegulatoryCasesRecord.Text = clbRegulatoryCasesTypes.CheckedItems.Count.ToString();
                }
            }
        }
        private void _LoadShariaCasesPractice()
        {
            // Wait for the UI thread to process pending events
            if (_Sharia.ShariaID != -1)
            {

                if (_Sharia.ShariaCasesPracticeIDNameDictionary.Count > 0)
                {
                    for (int idx = 0; idx < clbShariaCasesTypes.Items.Count; idx++)
                    {

                        clsGlobal.CheckListBoxItem item = (clsGlobal.CheckListBoxItem)clbShariaCasesTypes.Items[idx];

                        // Check if the key case ID  exists in the Dictionary of cases of sharia 
                        if (_Sharia.ShariaCasesPracticeIDNameDictionary.ContainsKey(item.ID))
                        {
                            // If the case ID  exists in the CheckedListBox items, set its checked state
                            clbShariaCasesTypes.SetItemChecked(idx, true);
                        }

                    }

                    lbShariaCasesRecord.Text = clbShariaCasesTypes.CheckedItems.Count.ToString();
                }
            }
        }
        private void _LoadJudgerCasesPractice()
        {
            // Wait for the UI thread to process pending events
            if (_Judger.JudgerID!= -1)
            {

                if (_Judger.JudgeCasesPracticeIDNameDictionary.Count > 0)
                {
                    for (int idx = 0; idx < clbJudgerCasesTypes.Items.Count; idx++)
                    {

                        clsGlobal.CheckListBoxItem item = (clsGlobal.CheckListBoxItem)clbJudgerCasesTypes.Items[idx];

                        // Check if the key case ID  exists in the Dictionary of cases of Judger 
                        if (_Judger.JudgeCasesPracticeIDNameDictionary.ContainsKey(item.ID))
                        {
                            // If the case ID  exists in the CheckedListBox items, set its checked state
                            clbJudgerCasesTypes.SetItemChecked(idx, true);
                        }

                    }

                    lbJudgerCasesRecord.Text = clbJudgerCasesTypes.CheckedItems.Count.ToString();
                }
            }
        }
        private void _LoadExpertCasesPractice()
        {
            // Wait for the UI thread to process pending events
            if (_Expert.ExpertID != null)
            {

                if (_Expert.ExpertCasesPracticeIDNameDictionary.Count > 0)
                {
                    for (int idx = 0; idx < clbExpertCasesTypes.Items.Count; idx++)
                    {

                        clsGlobal.CheckListBoxItem item = (clsGlobal.CheckListBoxItem)clbExpertCasesTypes.Items[idx];

                        // Check if the key case ID  exists in the Dictionary of cases of Expert 
                        if (_Expert.ExpertCasesPracticeIDNameDictionary.ContainsKey(item.ID))
                        {
                            // If the case ID  exists in the CheckedListBox items, set its checked state
                            clbExpertCasesTypes.SetItemChecked(idx, true);
                        }

                    }

                    lbExpertCasesRecord.Text = clbExpertCasesTypes.CheckedItems.Count.ToString();
                }
            }
        }

        private void _ResetRegulatorInfo()
        {
            _Regulator = new clsRegulator();
            ctbRegulatoryMembershipNumber.Text = "";
            lblRegulatorID.Text = "[????]";
            chkRegulatorIsActive.Checked = true;
            rbtnRegulatoryFree.Checked = true;
            rbtnRScholarship.Checked = true;
            lbRegulatoryCasesRecord.Text = "0";
            _RegulatorMode = enMode.AddNew;
            cbAddRegulator.Checked = false;
            tpRegulatorInfo.Enabled = false;
            _loadRegulatoryCasesTypes();
        }
        private void _ResetShariaInfo()
        {
            _Sharia=new clsSharia();
            ctbShariaLicenseNumber.Text = "";
            chkShariaIsActive.Checked = true;
            rbtnShariaFree.Checked = true;
            lbShariaCasesRecord.Text = "0"; 
            _ShariaMode = enMode.AddNew;
            tpShariaInfo.Enabled = false;
            cbAddSharia.Checked = false;
            lblShariaID.Text = "[????]";
            _loadShariaCasesTypes();

        }
        private void _ResetJudgerInfo()
        {
            //Reset - juder Info.
            _Judger = new clsJudger();
            _JudgerMode = enMode.AddNew;
            chkJudgerIsActive.Checked = true;
            rbtnJudgerFree.Checked = true;
            lbJudgerCasesRecord.Text = "0";
            tpJudgerInfo.Enabled = false;
            cbAddJudger.Checked = false; 
            lblJudgerID.Text = "[????]";
            _loadJudgerCasesTypes();

        }
        private void _ResetExpertInfo()
        {
            //Reset - expert Info.
            _Expert = new clsExpert();
            _ExpertMode = enMode.AddNew;
            chkExpertIsActive.Checked = true;
            rbtnExpertFree.Checked = true;
            lbExpertCasesRecord.Text = "0";
            tpExpertInfo.Enabled = false;
            cbAddExpert.Checked = false;
            lblExpertID.Text = "[????]";
            _loadExpertCasesTypes();

        }
        private void _ResetDefaultValues()
        {

            lblTitle.Text = "أضافة مزاول جديد للمهنة";

            this.Text = "أضافة مزاول جديد للمهنة";

             if (_Mode == enMode.Update)
             {
                lblTitle.Text = "أضافة مزاول جديد للمهنة";
                this.Text = "أضافة مزاول جديد للمهنة";
                lblTitle.Text = "تحديث و تعديل بيانات مزاول للمهنة";
                this.Text = "تحديث و تعديل بيانات مزاول للمهنة";

             }
           
            ctrlPersonCardWithFilter1.FilterFocus();

            _ResetRegulatorInfo();
            _ResetShariaInfo();
            _ResetJudgerInfo();
            _ResetExpertInfo();

        }
        private void _SwitchCurrentMode()
        {
            if (_Mode == enMode.Update)
            {
                _RegulatorMode= enMode.AddNew;
                _ShariaMode = enMode.AddNew;
                _ExpertMode= enMode.AddNew;
                _JudgerMode= enMode.AddNew;
                _Mode = enMode.AddNew;
            }

            else
            {
                _Mode = enMode.Update;
                _RegulatorMode= enMode.Update;
                _ShariaMode= enMode.Update;
                _ExpertMode= enMode.Update;
                _JudgerMode = enMode.Update;
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadData()
        {
            bool IsPersonInfoLoaded = false;
            try
            {

                if (clsPractitioner.IsPractitionerExists(_PractitionerID))
                {
                    if (clsRegulator.Exists(_PractitionerID, clsRegulator.enSearchBy.PractitionerID))
                    {
                        _loadRegulatorInfoData();
                        _RegulatorMode = enMode.Update;
                              if (!IsPersonInfoLoaded)
                              {
                            
                                  ctrlPersonCardWithFilter1.LoadPersonInfo(_Regulator.PersonID);
                                  ctrlPersonCardWithFilter1.FilterEnabled = false;
                                  IsPersonInfoLoaded = true;
                              }

                    }

                    if (clsSharia.Exists(_PractitionerID, clsSharia.enSearchBy.PractitionerID))
                    {
                        _loadShariaInfoData();
                        _ShariaMode = enMode.Update;
                              if (!IsPersonInfoLoaded)
                              {
                            
                                  ctrlPersonCardWithFilter1.LoadPersonInfo(_Sharia.PersonID);
                                  ctrlPersonCardWithFilter1.FilterEnabled = false;
                                  IsPersonInfoLoaded = true;
                            
                              }
                    }
                   
                    if (clsJudger.IsJudgerExistByPractitionerID(_PractitionerID))
                    {
                        _loadJudgerInfoData();
                        _JudgerMode = enMode.Update;
                        if (!IsPersonInfoLoaded)
                        {

                            ctrlPersonCardWithFilter1.LoadPersonInfo(_Judger.PersonID);
                            ctrlPersonCardWithFilter1.FilterEnabled = false;
                            IsPersonInfoLoaded = true;

                        }
                    }

                    if (clsExpert.Exists(_PractitionerID,clsExpert.enFindBy.PractitionerID))
                    {
                        _loadExpertInfoData();
                        _ExpertMode = enMode.Update;
                        if (!IsPersonInfoLoaded)
                        {

                            ctrlPersonCardWithFilter1.LoadPersonInfo(_Expert.PersonID);
                            ctrlPersonCardWithFilter1.FilterEnabled = false;
                            IsPersonInfoLoaded = true;

                        }
                    }

                }

                else
                {
                    MessageBox.Show("لا يوجد مزاول للمهنة يحمل رقم التعريف = " + _PractitionerID, "لا يوجد مزاول بهذا الرقم التعريفي", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

            }
            catch (Exception ex)
            {
                clsGlobal.WriteEventToLogFile("You have a problem in loading Practitioner info into the form due to lack of data access," +
                    "try to check the passed Lawyer Profile before launch (FrmADdUpdatePractitioners),\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);

                MessageBox.Show("حدث عطل فني داخل النظام اثناء تحميل البيانات,احتمال وجود " +
                    "حذف باليانات لعدم القدرة على استرجاعها بشكل صحيح", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _SwitchCurrentMode();
                _ResetDefaultValues();

            }
        }
        private void frmAddUpdateRegulator_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();

        }
        private int _GetSelectedSubscriptionTypeID()
        {

            if (rbtnRegulatoryFree.Checked)
            {
                return 1;
            }
            else if (rbtnRegulatoryMedium.Checked)
            {
                return 2;
            }
            else
            {
                return 3;
            }


        }
        private int _GetSelectedSubscriptionWayID()
        {

            if (rbtnRScholarship.Checked)
            {
                return 1;
            }
            else if (rbtnRSpecialSupport.Checked)
            {
                return 2;
            }


            return 1;

        }
        private Dictionary<int,string>GetCasesPracticesForPractitioner(clsPractitioner.enPractitionerType enPractitionerType)
        {
            CheckedListBox checkedListBoxCasesTypes = new CheckedListBox();
            switch (enPractitionerType)
            {
                case clsPractitioner.enPractitionerType.Regulatory:
                    {
                        checkedListBoxCasesTypes = clbRegulatoryCasesTypes;
                        break;
                    }
                case clsPractitioner.enPractitionerType.Sharia:
                    {
                        checkedListBoxCasesTypes = clbShariaCasesTypes;
                        break;
                    }
                case clsPractitioner.enPractitionerType.Judger:
                    {
                        checkedListBoxCasesTypes = clbJudgerCasesTypes;
                        break;
                    }
                case clsPractitioner.enPractitionerType.Expert:
                    {
                        checkedListBoxCasesTypes = clbExpertCasesTypes;
                        break;
                    }
            }
            try
            {

                Dictionary<int, string> CasesPracticeIdNameDictionary = new Dictionary<int, string>();

                // Get the selected items
                foreach (clsGlobal.CheckListBoxItem selectedItem in checkedListBoxCasesTypes.CheckedItems)
                {

                    CasesPracticeIdNameDictionary.Add(selectedItem.ID, selectedItem.Text);

                }

                return CasesPracticeIdNameDictionary;


            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile("practitioner add/update form , getCasesPractice().\n" +
                    ex.Message, System.Diagnostics.EventLogEntryType.Error);

                MessageBox.Show("Exception:\t" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;

            }
        }
        private void _AssignRegulator()
        {
            if (cbAddRegulator.Checked)
            {

                if (_RegulatorMode == enMode.AddNew)
                {
                    _Regulator.IssueDate = DateTime.Now;
                    _Regulator.CreatedByUserID = (int)clsGlobal.CurrentUser.UserID;

                }
                else if (_RegulatorMode == enMode.Update)//update
                {
                    _Regulator.LastEditByUserID = clsGlobal.CurrentUser.UserID;
                }
               
                _Regulator.PersonID = (int)ctrlPersonCardWithFilter1.PersonID;
                _Regulator.MembershipNumber = ctbRegulatoryMembershipNumber.Text.Trim();
                _Regulator.IsActive = chkRegulatorIsActive.Checked;
                _Regulator.SubscriptionTypeID = _GetSelectedSubscriptionTypeID();
                _Regulator.SubscriptionWayID = _GetSelectedSubscriptionWayID();
                _Regulator.RegulatorCasesPracticeIDNameDictionary = GetCasesPracticesForPractitioner(clsPractitioner.enPractitionerType.Regulatory);

            }
        }
        private void _AssignSharia()
        {

            if (cbAddSharia.Checked)
            {
                if (_ShariaMode == enMode.AddNew)
                {
                    _Sharia.IssueDate = DateTime.Now;
                    _Sharia.CreatedByUserID = (int)clsGlobal.CurrentUser.UserID;
                }

                else if (_ShariaMode == enMode.Update)
                {
                    _Sharia.LastEditByUserID = clsGlobal.CurrentUser.UserID;
                }

                _Sharia.PersonID = (int)ctrlPersonCardWithFilter1.PersonID;
                _Sharia.ShariaLicenseNumber = ctbShariaLicenseNumber.Text.Trim();
                _Sharia.IsActive = chkShariaIsActive.Checked;
                _Sharia.SubscriptionTypeID = _GetSelectedSubscriptionTypeID();
                _Sharia.SubscriptionWayID = _GetSelectedSubscriptionWayID();
                _Sharia.ShariaCasesPracticeIDNameDictionary = GetCasesPracticesForPractitioner(clsPractitioner.enPractitionerType.Sharia);


            }

        }
        private void _AssignJudger()
        {

            if (cbAddJudger.Checked)
            {
                if (_JudgerMode == enMode.AddNew)
                {
                    _Judger.IssueDate = DateTime.Now;
                    _Judger.CreatedByUserID = (int)clsGlobal.CurrentUser.UserID;
                }

                else if (_JudgerMode == enMode.Update)
                {
                    _Judger.LastEditByUserID = clsGlobal.CurrentUser.UserID;
                }

                _Judger.PersonID = (int)ctrlPersonCardWithFilter1.PersonID;
                _Judger.IsActive = chkJudgerIsActive.Checked;
                _Judger.SubscriptionTypeID = _GetSelectedSubscriptionTypeID();
                _Judger.SubscriptionWayID = _GetSelectedSubscriptionWayID();
                _Judger.JudgeCasesPracticeIDNameDictionary = GetCasesPracticesForPractitioner(clsPractitioner.enPractitionerType.Judger);


            }

        }
        private void _AssignExpert()
        {

            if (cbAddExpert.Checked)
            {
                if (_ExpertMode == enMode.AddNew)
                {
                    _Expert.IssueDate = DateTime.Now;
                    _Expert.CreatedByUserID = (int)clsGlobal.CurrentUser.UserID;
                }

                else if (_ExpertMode == enMode.Update)
                {
                    _Expert.LastEditByUserID = clsGlobal.CurrentUser.UserID;
                }

                _Expert.PersonID = (int)ctrlPersonCardWithFilter1.PersonID;
                _Expert.IsActive = chkJudgerIsActive.Checked;
                _Expert.SubscriptionTypeID = _GetSelectedSubscriptionTypeID();
                _Expert.SubscriptionWayID = _GetSelectedSubscriptionWayID();
                _Expert.ExpertCasesPracticeIDNameDictionary = GetCasesPracticesForPractitioner(clsPractitioner.enPractitionerType.Expert);

            }

        }

        private bool _AssignData()
        {

            try
            {
                _AssignRegulator();
                _AssignSharia();
                _AssignJudger();
                _AssignExpert();

            }
            catch (Exception ex)
            {
                MessageBox.Show("A problem occured while assign info to practitioner.\nException:"+ex.Message,"Failed.",MessageBoxButtons.OK,MessageBoxIcon.Error);

                clsGlobal.WriteEventToLogFile("Exception in practitioner form add/update assign DATA method: \n Exception:" + ex.Message,
                    System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine("Exception:"+ex.ToString());
                return false;
            }
            return true;
        }

        private void _SaveRegulator()
        {
            if (cbAddRegulator.Checked)
            {
                if (_Regulator.Save())
                {
                    if (_RegulatorMode == enMode.Update)
                    {
                        OnEntityUpdated(EventArgs.Empty);
                    }

                    lblRegulatorID.Text = _Regulator.RegulatorID.ToString();
                    _PractitionerID = _Regulator.PractitionerID;
                    //change form mode to update.
                    _Mode = enMode.Update;
                    _RegulatorMode = enMode.Update;
                    lblTitle.Text = "تحديث  و تعديل البيانات";
                    this.Text = "تحديث  و تعديل البيانات";
                    MessageBox.Show("حفظ البيانات للمحامي النظامي بنجاح.", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Save the entity to the database
                    // After saving successfully, raise the event
                    OnEntityAdded(EventArgs.Empty);
                }

                else
                {
                    MessageBox.Show("فشل: لم تحفظ البيانات المحامي النظامي بشكل صحيح.", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void _SaveSharia()
        {
            if (cbAddSharia.Checked)
            {
                if (_Sharia.Save())
                {
                    if (_RegulatorMode == enMode.Update)
                    {
                        OnEntityUpdated(EventArgs.Empty);
                    }
                    lblShariaID.Text = _Sharia.ShariaID.ToString();
                    _PractitionerID = _Sharia.PractitionerID;
                    //change form mode to update.
                    _Mode = enMode.Update;
                    _ShariaMode = enMode.Update;
                    lblTitle.Text = "تحديث  و تعديل البيانات";
                    this.Text = "تحديث  و تعديل البيانات";
                    MessageBox.Show("حفظ البيانات للمحامي الشرعي بنجاح.", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Save the entity to the database
                    // After saving successfully, raise the event
                    OnEntityAdded(null);
                }

                else
                {
                    MessageBox.Show("فشل: لم تحفظ البيانات للمحامي الشرعي بشكل صحيح.", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void _SaveJudger()
        {

            if (cbAddJudger.Checked)
            {
                if (_Judger.Save())
                {
                    if (_RegulatorMode == enMode.Update)
                    {
                        OnEntityUpdated(EventArgs.Empty);
                    }
                    lblJudgerID.Text = _Judger.JudgerID.ToString();
                    _PractitionerID = _Judger.PractitionerID;
                    //change form mode to update.
                    _Mode = enMode.Update;
                    _JudgerMode = enMode.Update;
                    lblTitle.Text = "تحديث  و تعديل البيانات";
                    this.Text = "تحديث  و تعديل البيانات";
                    MessageBox.Show("حفظ البيانات  للمحكم بنجاح.", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Save the entity to the database
                    // After saving successfully, raise the event
                    OnEntityAdded(null);
                }

                else
                {
                    MessageBox.Show("فشل: لم تحفظ البيانات للمحكم بشكل صحيح.", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void _SaveExpert()
        {

                if (cbAddExpert.Checked)
                {
                    if (_Expert.Save())
                    {
                        if (_ExpertMode == enMode.Update)
                        {
                            OnEntityUpdated(EventArgs.Empty);
                        }
                        lblExpertID.Text = _Expert.ExpertID.ToString();
                        _PractitionerID = _Expert.PractitionerID;
                        //change form mode to update.
                        _Mode = enMode.Update;
                        _ExpertMode = enMode.Update;
                        lblTitle.Text = "تحديث  و تعديل البيانات";
                        this.Text = "تحديث  و تعديل البيانات";
                        MessageBox.Show("حفظ البيانات  للخبير بنجاح.", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Save the entity to the database
                        // After saving successfully, raise the event
                        OnEntityAdded(null);
                    }

                    else
                    {
                        MessageBox.Show("فشل: لم تحفظ البيانات للخبير بشكل صحيح.", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
                }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Think deeply about saving , and updating ...
            try
            {
                if (!this.ValidateChildren())
                {
                    //Here we don't  continue because the form is not valid
                    MessageBox.Show("بعض الحقول غير صالحة! ضع الماوس فوق الأيقونة(الأيقونات) الحمراء لرؤية الخطأ",
                        "خطاء في البيانات المدخلة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (_AssignData())
                {
                    _SaveRegulator();
                    _SaveSharia();
                    _SaveJudger();
                    _SaveExpert();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //I stopped here...
        private void tbRegulatorMemberShip_Validating(object sender, CancelEventArgs e)
        {
            if (cbAddRegulator.Checked)
            {
                try
                {

                    string ErrorMessage = "";
                    if (!ctbRegulatoryMembershipNumber.IsValid(ref ErrorMessage))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(ctbRegulatoryMembershipNumber, ErrorMessage);
                        return;
                    }

                    else
                    {
                        e.Cancel = false;

                        errorProvider1.SetError(ctbRegulatoryMembershipNumber, null);
                    }

                    if (_RegulatorMode == enMode.AddNew)
                    {

                        if (clsRegulator.Exists(ctbRegulatoryMembershipNumber.Text.Trim(), clsRegulator.enSearchBy.MembershipNumber))
                        {

                            e.Cancel = true;
                            errorProvider1.SetError(ctbRegulatoryMembershipNumber, "رقم العضوية مستخدم بالفعل من قبل محامي أخر");
                            if (MessageBox.Show("هل تريد رؤية الملف الذي يحتوي على تطابق مع رقم العضوية؟\n",
                            "تاكيد ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {

                                frmRegulatorInfo frmRegulator = new frmRegulatorInfo(clsRegulator.Find(ctbRegulatoryMembershipNumber.Text.Trim(),
                                    clsRegulator.enSearchBy.MembershipNumber).RegulatorID);
                            }
                        }

                        else
                        {
                            e.Cancel = false;

                            errorProvider1.SetError(ctbRegulatoryMembershipNumber, null);
                        };

                    }

                    else
                    {
                        //in case update make sure not to use another user name
                        if (_Regulator.MembershipNumber != ctbRegulatoryMembershipNumber.Text.Trim())
                        {
                            if (clsRegulator.Exists(ctbRegulatoryMembershipNumber.Text.Trim(), clsRegulator.enSearchBy.MembershipNumber))
                            {
                                e.Cancel = true;
                                errorProvider1.SetError(ctbRegulatoryMembershipNumber, "رقم العضوية مستخدم بالفعل من قبل محامي أخر");
                                return;
                            }
                            else
                            {
                                e.Cancel = false;

                                errorProvider1.SetError(ctbRegulatoryMembershipNumber, null);
                            };
                        }
                    }
                }
                catch (Exception ex)
                {

                    clsGlobal.WriteEventToLogFile("Exception happen in Add/update practitioner while validting the member ship of regulator " +
                        "\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    MessageBox.Show("حصل خطاء ما داخل النظام , اثناء محاولة رفع المحتوى المتطابق");
                }

            }
        }
        private void btnRegulatorInfoNext_Click(object sender, EventArgs e)
        {

            if (ctrlPersonCardWithFilter1.PersonID == null)
            {
                MessageBox.Show("يرجى اختيار شخص ما.", "اختار شخص ما", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
                return;
            }
            if (_RegulatorMode == enMode.AddNew &&
                 clsRegulator.Exists(ctrlPersonCardWithFilter1.PersonID,
                     clsRegulator.enSearchBy.PersonID))
            {

                MessageBox.Show("الشخص المحدد لديه ملف محامي(نظامي) بالفعل، يرجى اختيار شخص آخر", "اختار شخص اخر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
                return;
            }


            else if (cbAddRegulator.Checked == false)
            {
                tcPractitionernfo.SelectedTab = tpRegulatorInfo;
                return;
            }

            else if (_RegulatorMode == enMode.Update)
            {

                btnSave.Enabled = true;
                tpRegulatorInfo.Enabled = true;
                tcPractitionernfo.SelectedTab = tpRegulatorInfo;
            }

            else
            {
                btnSave.Enabled = true;
                tpRegulatorInfo.Enabled = true;
                tcPractitionernfo.SelectedTab = tpRegulatorInfo;
            }

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {


        }

        private void tcRegulatorInfo_Selecting(object sender, TabControlCancelEventArgs e)
        {

            if(ctrlPersonCardWithFilter1.PersonID == null)
            {
                MessageBox.Show("يرجى اختيار شخص ما.", "اختار شخص ما", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
                return;
            }
  
            if (e.TabPage == tpRegulatorInfo) // 'tpRegulatorInfo' is the TabPage you want to restrict
            {
            
                if (_RegulatorMode == enMode.AddNew&&
                 clsRegulator.Exists(ctrlPersonCardWithFilter1.PersonID,
                     clsRegulator.enSearchBy.PersonID))
                {

                    MessageBox.Show("الشخص المحدد لديه ملف محامي(نظامي) بالفعل، يرجى اختيار شخص آخر", "اختار شخص اخر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFocus();
                    return;
                }

              
                else if (cbAddRegulator.Checked == false)
                { 
                    tcPractitionernfo.SelectedTab = tpRegulatorInfo;
                    return;
                }
              
                else if (_RegulatorMode == enMode.Update)
                {

                    btnSave.Enabled = true;
                    tpRegulatorInfo.Enabled = true;
                    tcPractitionernfo.SelectedTab = tpRegulatorInfo;
                }
          
                else
                {
                    btnSave.Enabled = true;
                    tpRegulatorInfo.Enabled = true;
                    tcPractitionernfo.SelectedTab = tpRegulatorInfo;
                }

            }
            
       

            else if (e.TabPage == tpShariaInfo)
            {
                if (_ShariaMode == enMode.Update && cbAddSharia.Checked == true && ctrlPersonCardWithFilter1.PersonID != null)
                {
                    btnSave.Enabled = true;
                    tpShariaInfo.Enabled = true;
                    tcPractitionernfo.SelectedTab = tpShariaInfo;
                }

                else if (_ShariaMode == enMode.AddNew && ctrlPersonCardWithFilter1.PersonID != null && cbAddSharia.Checked == true)
                {

                    if (clsSharia.Exists(ctrlPersonCardWithFilter1.PersonID,

                        clsSharia.enSearchBy.PersonID))

                    {

                        MessageBox.Show("الشخص المحدد لديه ملف محامي(شرعي) بالفعل، يرجى اختيار شخص آخر", "اختار شخص اخر", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ctrlPersonCardWithFilter1.FilterFocus();

                    }


                    else if (cbAddSharia.Checked == true)

                    {

                        btnSave.Enabled = true;

                        tpShariaInfo.Enabled = true;

                        tcPractitionernfo.SelectedTab = tpShariaInfo;

                    }



                }
            }
            
         
       
        }

        [Obsolete("This condition ain't used anymore")]
        private void clbRegulatoryCasesTypes_Validating(object sender, CancelEventArgs e)
        {
            if (rbtnRegulatoryFree.Checked && clbRegulatoryCasesTypes.CheckedItems.Count > 1)
            {

                errorProvider1.SetError(clbRegulatoryCasesTypes, "لقد تجاوزت الحد المسموح من القضايا لهذا الاشتراك.");
                e.Cancel = true;
            }
            else if (rbtnRegulatoryMedium.Checked && clbRegulatoryCasesTypes.CheckedItems.Count > 3)
            {

                errorProvider1.SetError(clbRegulatoryCasesTypes, "لقد تجاوزت الحد المسموح من القضايا لهذا الاشتراك.");
                e.Cancel = true;
            }
            else if (rbtnRegulatorySpecial.Checked && clbRegulatoryCasesTypes.CheckedItems.Count > 5)
            {

                errorProvider1.SetError(clbRegulatoryCasesTypes, "لقد تجاوزت الحد المسموح من القضايا لهذا الاشتراك.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(clbRegulatoryCasesTypes, "");

                e.Cancel = false;
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {

            BackColor = System.Drawing.Color.Black;
        }

        private void ListWasCreatedUpdated(object sender, EventArgs e)
        {
            evPractitionerUpdated(sender,e);
        }
        private void btnBlackList_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Mode == enMode.Update)
                {
                    
                    if (clsBlackList.IsPractitionerInBlackList(_PractitionerID))
                    {
                        DialogResult result = MessageBox.Show("الشخص مضاف بالفعل الى القائمة السوداء , ان كنت تريد التعديل اضعط على 'نعم ' ", "سؤال"
                             , MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.OK)
                        {
                            // get ID of black-list by practitioner ID 
                            FrmAddUpdateList form = new FrmAddUpdateList(_PractitionerID, 
                                 clsBlackList.Find(_PractitionerID, clsBlackList.enFindBy.PractitionerID).BlackListID,
                                 ctrlAddUpdateList.enCreationMode.BlackList);
                            form.evCustomEventAddUpdateList += ListWasCreatedUpdated;
                            form.ShowDialog();
                        }
                    }
                    //Check if there is already an exists ID  for his black-list ID .
                    else
                    {

                        FrmAddUpdateList form = new FrmAddUpdateList(_PractitionerID, ctrlAddUpdateList.enCreationMode.BlackList);
                        form.evCustomEventAddUpdateList += ListWasCreatedUpdated;
                        form.ShowDialog();
                    }
                }


                else
                {
                    MessageBox.Show("لا يوجد بيانات (مزاولة المنهة)داخل البرنامج,عليك اولا اضافته كمحامي ثم يمكنك اضافته الى القائمة السوداء.",
                       "فشل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                clsHelperClasses.WriteEventToLogFile("Exception in FrmAddupdateRegulator, BtnBlackList()\nException:" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }

        }

        private void clbRegulatoryCasesTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbRegulatoryCasesRecord.Text= clbRegulatoryCasesTypes.CheckedItems.Count.ToString();
        }

        private void frmAddUpdateRegulator_Shown(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
            MoveTabPage();
        }

        private void btnResetCases_Click(object sender, EventArgs e)
        {
            // Iterate through each item in the CheckedListBox
            for (int i = 0; i < clbRegulatoryCasesTypes.Items.Count; i++)
            {
                // Set the Checked property of each item to false to uncheck it
                clbRegulatoryCasesTypes.SetItemChecked(i, false);
            }

            lbRegulatoryCasesRecord.Text=clbRegulatoryCasesTypes.CheckedItems.Count.ToString(); 
        }
        private void ctrlPersonCardWithFilter1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tpRegulatorInfo_Click(object sender, EventArgs e)
        {

        }
        private void btnResetShariaCases_Click(object sender, EventArgs e)
        {
            // Iterate through each item in the CheckedListBox
            for (int i = 0; i < clbShariaCasesTypes.Items.Count; i++)
            {
                // Set the Checked property of each item to false to uncheck it
                clbShariaCasesTypes.SetItemChecked(i, false);
            }

            lbShariaCasesRecord.Text = clbShariaCasesTypes.CheckedItems.Count.ToString();
        }
        private void clbShariaCasesTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbShariaCasesRecord.Text = clbShariaCasesTypes.CheckedItems.Count.ToString();


        }
        private void ctbShariaLicenseNumber_Validating(object sender, CancelEventArgs e)
        {

            if (cbAddSharia.Checked)
            {

            try
            { 
           
            string ErrorMessage = "";
            if (!ctbShariaLicenseNumber.IsValid(ref ErrorMessage))
            {
                e.Cancel = true;
                errorProvider1.SetError(ctbShariaLicenseNumber, ErrorMessage);
                return;
            }

            else
            {
                e.Cancel = false;

                errorProvider1.SetError(ctbShariaLicenseNumber, null);
            }

            if (_ShariaMode == enMode.AddNew)
            {

                if (clsSharia.Exists(ctbShariaLicenseNumber.Text.Trim(), clsSharia.enSearchBy.ShariaLicenseNumber))
                {

                    e.Cancel = true;
                    errorProvider1.SetError(ctbShariaLicenseNumber, "رقم الاجازة الشرعية مستخدم بالفعل من قبل محامي أخر");
                    if (MessageBox.Show("هل تريد رؤية الملف الذي يحتوي على تطابق مع رقم الاجازة الشرعية؟\n",
                    "تاكيد ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        MessageBox.Show("Not Implemented yet");
                    }
                }

                else
                {
                    e.Cancel = false;

                    errorProvider1.SetError(ctbShariaLicenseNumber, null);
                };

            }

            else
            {
                //in case update make sure not to use another user name
                if (_Sharia.ShariaLicenseNumber!= ctbShariaLicenseNumber.Text.Trim())
                {
                    if (clsSharia.Exists(ctbShariaLicenseNumber.Text.Trim(), clsSharia.enSearchBy.ShariaLicenseNumber))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(ctbShariaLicenseNumber, "رقم الاجازة الشرعية مستخدم بالفعل من قبل محامي أخر");
                        return;
                    }
                    else
                    {
                        e.Cancel = false;

                        errorProvider1.SetError(ctbShariaLicenseNumber, null);
                    };
                }
                }

            }
            catch (Exception ex)
            {


                clsGlobal.WriteEventToLogFile("Exception happen in Add/update practitioner while validting the License number of Sharia" +
                    "\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                MessageBox.Show("حصل خطاء ما داخل النظام , اثناء محاولة رفع المحتوى المتطابق");

            }
            }

        }
        private void _UpdateSaveButton(object sender, EventArgs e)
        {
            btnSave.Enabled = (tpRegulatorInfo.Enabled || tpShariaInfo.Enabled || tpJudgerInfo.Enabled || tpExpertInfo.Enabled);

        }
        private void _UpdateTabs(object sender ,EventArgs e)
        {
            if(sender is CheckBox checkbox)
            {
                if (checkbox.Tag.ToString() == "1")//Regulatory
                {
                      tpRegulatorInfo.Enabled = (
                        cbAddRegulator.Checked && ctrlPersonCardWithFilter1.SelectedPersonInfo != null
                       && _RegulatorMode == enMode.Update &&
                       clsRegulator.Exists  (ctrlPersonCardWithFilter1.PersonID, clsRegulator.enSearchBy.PersonID)
                       ) 
                       ||
                       (
                       cbAddRegulator.Checked && ctrlPersonCardWithFilter1.SelectedPersonInfo != null
                       && _RegulatorMode == enMode.AddNew &&
                       !clsRegulator.Exists(ctrlPersonCardWithFilter1.PersonID, clsRegulator.enSearchBy.PersonID)
                       );

                }

                else if (checkbox.Tag.ToString() == "2")//Sharia
                {
                    tpShariaInfo.Enabled = (
                      cbAddSharia.Checked && ctrlPersonCardWithFilter1.SelectedPersonInfo != null
                     && _ShariaMode == enMode.Update &&
                     clsSharia.Exists(ctrlPersonCardWithFilter1.PersonID, clsSharia.enSearchBy.PersonID)
                     )
                     ||
                     (
                     cbAddSharia.Checked && ctrlPersonCardWithFilter1.SelectedPersonInfo != null
                     && _ShariaMode == enMode.AddNew &&
                     !clsSharia.Exists(ctrlPersonCardWithFilter1.PersonID, clsSharia.enSearchBy.PersonID)
                     );

                }

                else if (checkbox.Tag.ToString() == "3")//Judger
                {
                    tpJudgerInfo.Enabled = (
                      cbAddJudger.Checked && ctrlPersonCardWithFilter1.SelectedPersonInfo != null
                     && _JudgerMode == enMode.Update &&
                     clsJudger.IsJudgerExistByPersonID((int)ctrlPersonCardWithFilter1.PersonID)
                     )
                     ||
                     (
                     cbAddJudger.Checked && ctrlPersonCardWithFilter1.SelectedPersonInfo != null
                     && _JudgerMode == enMode.AddNew &&
                     !clsJudger.IsJudgerExistByPersonID((int)ctrlPersonCardWithFilter1.PersonID)
                     );

                }
            
                else if (checkbox.Tag.ToString() == "4")//Expert
                {
                    tpExpertInfo.Enabled = (
                      cbAddExpert.Checked && ctrlPersonCardWithFilter1.SelectedPersonInfo != null
                     && _ExpertMode == enMode.Update &&
                     clsExpert.Exists((int)ctrlPersonCardWithFilter1.PersonID, clsExpert.enFindBy.PersonID)
                     )
                     ||
                     (
                     cbAddExpert.Checked && ctrlPersonCardWithFilter1.SelectedPersonInfo != null
                     && _ExpertMode == enMode.AddNew &&
                     !clsExpert.Exists((int)ctrlPersonCardWithFilter1.PersonID, clsExpert.enFindBy.PersonID)
                     );

                }
            }

        }
        private void cbAdd_CheckedChanged(object sender, EventArgs e)
        {
            _UpdateTabs(sender,e);

            _UpdateSaveButton(null,null);
        }
        private void RadioButton_SubscriptionType_CheckedChanged(object sender, EventArgs e)
        {

            bool isChecked = false;
            if (sender is RadioButton radioButton)
            {
                isChecked = radioButton.Checked;

                if (int.TryParse(radioButton.Tag.ToString(),out int TagValue)) 
                {
                    if (TagValue == (int)enSubscriptionType.Free)
                    {
                        rbtnRegulatoryFree.Checked = rbtnShariaFree.Checked =rbtnJudgerFree.Checked =  rbtnExpertFree.Checked = isChecked;
                    }
                    else if (TagValue == (int)enSubscriptionType.Medium)
                    {
                        rbtnRegulatoryMedium.Checked = rbtnShariaMedium.Checked = rbtnJudgerMedium.Checked = rbtnExpertMedium.Checked = isChecked;
                    }
                    else if(TagValue == (int)enSubscriptionType.Special)
                    {
                        rbtnRegulatorySpecial.Checked = rbtnShariaSpecial.Checked = rbtnJudgerSpecial.Checked = rbtnExpertSpecial.Checked = isChecked;
                    }
                }

            }

        }
        private void tcPractitionernfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(tcPractitionernfo.SelectedIndex ==0)
            {
                if (_Mode == enMode.AddNew)
                {
                    lblTitle.Text = "أضافة مزاول جديد للمهنة";
                    this.Text = "أضافة مزاول جديد للمهنة";
                    lblTitle.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);

                }


                else if (_Mode == enMode.Update)
                {
                  
                    lblTitle.Text = "تحديث و تعديل بيانات مزاول للمهنة";
                    this.Text = "تحديث و تعديل بيانات مزاول للمهنة";
                    lblTitle.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);

                }
            }
          
            else if (tcPractitionernfo.SelectedIndex == 1)
            {
                if (_RegulatorMode == enMode.AddNew)
                {
                    lblTitle.Text = "أضافة محامي نظامي جديد";
                    lblTitle.ForeColor = System.Drawing.Color.SandyBrown;

                }
                else if(_RegulatorMode == enMode.Update)
                {
                    lblTitle.Text = "تحديث او تعديل بيانات المحامي نظامي";
                    lblTitle.ForeColor = System.Drawing.Color.SandyBrown;

                }
            }
      
            else if (tcPractitionernfo.SelectedIndex == 2)
            {
                if (_ShariaMode == enMode.AddNew)
                {
                    lblTitle.Text = "أضافة محامي شرعي جديد";
                    lblTitle.ForeColor = System.Drawing.Color.Red;

                }
                else if (_ShariaMode == enMode.Update)
                {
                    lblTitle.Text = "تحديث او تعديل بيانات المحامي الشرعي ";
                    lblTitle.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (tcPractitionernfo.SelectedIndex == 3)
            {
                if (_JudgerMode == enMode.AddNew)
                {
                    lblTitle.Text = "أضافة  محكم جديد";
                    lblTitle.ForeColor = System.Drawing.Color.LimeGreen;

                }
                else if (_JudgerMode == enMode.Update)
                {
                    lblTitle.Text = "تحديث او تعديل بيانات المحكم ";
                    lblTitle.ForeColor = System.Drawing.Color.LimeGreen;
                }
            }
            else if (tcPractitionernfo.SelectedIndex == 4)
            {
                if (_ExpertMode == enMode.AddNew)
                {
                    lblTitle.Text = "أضافة خبير جديد";
                    lblTitle.ForeColor = System.Drawing.Color.DarkBlue;

                }
                else if (_ExpertMode == enMode.Update)
                {
                    lblTitle.Text = "تحديث او تعديل بيانات الخبير ";
                    lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
                }
            }

        }

        private void RadioButton_SubscriptionWay_CheckedChanged(object sender, EventArgs e)
        {

            bool isChecked = false;
            if (sender is RadioButton radioButton)
            {
                isChecked = radioButton.Checked;
               
                if (int.TryParse(radioButton.Tag.ToString(), out int TagValue))
                {
                    if (TagValue == (int)enSubscriptionWay.SpecialSupport)
                    {
                        rbtnRSpecialSupport.Checked = rbtnSSpecialSupport.Checked=rbtnJSpecialSupport.Checked=
                            rbtnESpecialSupport.Checked=isChecked;
                    }
                    else if (TagValue == (int)enSubscriptionWay.scholarship)
                    {
                        rbtnRScholarship.Checked = rbtnSScholarship.Checked = rbtnJScholarship.Checked =
                                                rbtnEScholarship.Checked = isChecked;
                    }
                  
                }
            }
        }
   
        private void frmAddUpdatePractitioner_KeyPress(object sender, KeyPressEventArgs e)
        {
            ctrlPersonCardWithFilter1.PerFormClick();

        }

        private void btnRegulatoryWhiteList_Click(object sender, EventArgs e)
        {
            try
            {
                if (_PractitionerID != -1 && clsRegulator.Exists(_PractitionerID, clsRegulator.enSearchBy.PractitionerID))
                {
                    if (_Mode == enMode.Update && _RegulatorMode == enMode.Update 
                    && _Regulator.IsRegulatorInWhiteList())
                {
                    DialogResult result = MessageBox.Show("الشخص مضاف بالفعل الى القائمة البيضاء للنظامين , ان كنت تريد التعديل اضعط على 'نعم ' ", "سؤال"
                         , MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.OK)
                    {
                        // get ID of white-list by practitioner ID 
                        FrmAddUpdateList form = new FrmAddUpdateList(_PractitionerID,
                            (int)clsWhiteList.Find(_PractitionerID, clsPractitioner.enPractitionerType.Regulatory).WhiteListID,
                             ctrlAddUpdateList.enCreationMode.RegulatoryWhiteList);
                            form.evCustomEventAddUpdateList += ListWasCreatedUpdated;

                            form.ShowDialog();
                    }
                }
                else
                {

                    FrmAddUpdateList AddUpdateWhiteList = new FrmAddUpdateList(_PractitionerID,
                    ctrlAddUpdateList.enCreationMode.RegulatoryWhiteList);
                        AddUpdateWhiteList.evCustomEventAddUpdateList += ListWasCreatedUpdated;

                        AddUpdateWhiteList.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show(text: "عليك اولا اضافة ملف للمحامي النظامي قبل اضافته الى احد القوائم."
                   , "فشل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile("I have a problem in loading white list form for practitioners type " +
                    "regulators,You might need to check add/update practitioner form \nexception:" + ex.Message
                    ,System.Diagnostics.EventLogEntryType.Error);

                MessageBox.Show(text: "Problem happen in the system while loading data,you might need to contact maintainance team."
                    , "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Exception:\t" + ex.Message);

            }
           

        }

        private void btnRegulatoryClosedList_Click(object sender, EventArgs e)
        {
            try
            {
                if (_PractitionerID != -1 && clsRegulator.Exists(_PractitionerID, clsRegulator.enSearchBy.PractitionerID))
                {
                    if (_Mode == enMode.Update && _RegulatorMode == enMode.Update
                    && _Regulator.IsRegulatorInClosedList())
                    {
                        DialogResult result = MessageBox.Show("الشخص مضاف بالفعل الى القائمة المغلقة للنظامين , ان كنت تريد التعديل اضعط على 'نعم ' ", "سؤال"
                             , MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.OK)
                        {
                            // get ID of white-list by practitioner ID 
                            FrmAddUpdateList form = new FrmAddUpdateList(_PractitionerID,
                                (int)clsClosedList.Find(_PractitionerID, clsPractitioner.enPractitionerType.Regulatory).ClosedListID,
                                 ctrlAddUpdateList.enCreationMode.RegulatoryClosedList);
                            form.evCustomEventAddUpdateList += ListWasCreatedUpdated;
                            form.ShowDialog();
                        }
                    }
                    else
                    {

                        FrmAddUpdateList AddUpdateClosedList = new FrmAddUpdateList(_PractitionerID,
                        ctrlAddUpdateList.enCreationMode.RegulatoryClosedList);
                        AddUpdateClosedList.evCustomEventAddUpdateList += ListWasCreatedUpdated;
                        AddUpdateClosedList.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show(text: "عليك اولا اضافة ملف للمحامي النظامي قبل اضافته الى احد القوائم."
                   , "فشل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile("I have a problem in loading closed list form for practitioners type " +
                    "regulators,You might need to check add/update practitioner form \nexception:" + ex.Message
                    , System.Diagnostics.EventLogEntryType.Error);

                MessageBox.Show(text: "Problem happen in the system while loading data,you might need to contact maintenance team."
                    , "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Exception:\t" + ex.Message);

            }
        }

        private void btnShariaWhite_Click(object sender, EventArgs e)
        {
            try
            {
                if (_PractitionerID != -1 && clsSharia.Exists(_PractitionerID, clsSharia.enSearchBy.PractitionerID))
                {

                if (_Mode == enMode.Update && _ShariaMode == enMode.Update 
                    && _Sharia.IsShariaInWhiteList())
                {
                    DialogResult result = MessageBox.Show("الشخص مضاف بالفعل الى القائمة البيضاء للشرعيين , ان كنت تريد التعديل اضعط على 'نعم ' ", "سؤال"
                         , MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.OK)
                    {
                        // get ID of white-list by practitioner ID 
                        FrmAddUpdateList form = new FrmAddUpdateList(_PractitionerID,
                            (int)clsWhiteList.Find(_PractitionerID, clsPractitioner.enPractitionerType.Sharia).WhiteListID,
                             ctrlAddUpdateList.enCreationMode.ShariaWhiteList);
                            form.evCustomEventAddUpdateList += ListWasCreatedUpdated;

                            form.ShowDialog();
                    }
                }
                else
                {

                    FrmAddUpdateList AddUpdateWhiteList = new FrmAddUpdateList(_PractitionerID,
                    ctrlAddUpdateList.enCreationMode.ShariaWhiteList);
                        AddUpdateWhiteList.evCustomEventAddUpdateList += ListWasCreatedUpdated;

                        AddUpdateWhiteList.ShowDialog();

                }
                }
                else
                {
                    MessageBox.Show(text: "عليك اولا اضافة ملف للمحامي الشرعي قبل اضافته الى احد القوائم."
                   , "فشل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile("I have a problem in loading white list form for practitioners type " +
                    "sharia,You might need to check add/update practitioner form \nexception:" + ex.Message
                    , System.Diagnostics.EventLogEntryType.Error);

                MessageBox.Show(text: "Problem happen in the system while loading data,you might need to contact maintenance team."
                    , "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Exception:\t" + ex.Message);

            }

        }
        private void btnShariaClosedList_Click(object sender, EventArgs e)

        {
            try
            {
                if (_PractitionerID != -1 && clsSharia.Exists(_PractitionerID, clsSharia.enSearchBy.PractitionerID))
                {
                    if (_Mode == enMode.Update && _ShariaMode == enMode.Update 
                    && _Sharia.IsShariaInClosedList())
                {
                    DialogResult result = MessageBox.Show("الشخص مضاف بالفعل الى القائمة المغلقة للشرعيين , ان كنت تريد التعديل اضعط على 'نعم ' ", "سؤال"
                         , MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.OK)
                    {
                        // get ID of white-list by practitioner ID 
                        FrmAddUpdateList form = new FrmAddUpdateList(_PractitionerID,
                            (int)clsClosedList.Find(_PractitionerID, clsPractitioner.enPractitionerType.Sharia).ClosedListID,
                             ctrlAddUpdateList.enCreationMode.ShariaClosedList);
                            form.evCustomEventAddUpdateList += ListWasCreatedUpdated;

                            form.ShowDialog();
                    }
                }
                else
                {

                    FrmAddUpdateList AddUpdateClosedList = new FrmAddUpdateList(_PractitionerID,
                    ctrlAddUpdateList.enCreationMode.ShariaClosedList);
                        AddUpdateClosedList.evCustomEventAddUpdateList += ListWasCreatedUpdated;

                        AddUpdateClosedList.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show(text: "عليك اولا اضافة ملف للمحامي الشرعي قبل اضافته الى احد القوائم."
                   , "فشل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile("I have a problem in loading closed list form for practitioners type " +
                    "sharia,You might need to check add/update practitioner form \nexception:" + ex.Message
                    , System.Diagnostics.EventLogEntryType.Error);

                MessageBox.Show(text: "Problem happen in the system while loading data,you might need to contact maintenance team."
                    , "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Exception:\t" + ex.Message);

            }
        }

        private void btnJudgerWhite_Click(object sender, EventArgs e)
        {
            try
            {
                if (_PractitionerID != -1 && clsJudger.IsJudgerExistByPractitionerID(_PractitionerID))
                {

                if (_Mode == enMode.Update && _ShariaMode == enMode.Update 
                    && _Judger.IsJudgerInWhiteList())
                {
                    DialogResult result = MessageBox.Show("الشخص مضاف بالفعل الى القائمة البيضاء للمحكمين , ان كنت تريد التعديل اضعط على 'نعم ' ", "سؤال"
                         , MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.OK)
                    {
                        // get ID of white-list by practitioner ID 
                        FrmAddUpdateList form = new FrmAddUpdateList(_PractitionerID,
                            (int)clsWhiteList.Find(_PractitionerID, clsPractitioner.enPractitionerType.Judger).WhiteListID,
                             ctrlAddUpdateList.enCreationMode.JudgerWhiteList);
                            form.evCustomEventAddUpdateList += ListWasCreatedUpdated;

                            form.ShowDialog();
                    }
                }
                else
                {

                    FrmAddUpdateList AddUpdateWhiteList = new FrmAddUpdateList(_PractitionerID,
                    ctrlAddUpdateList.enCreationMode.JudgerWhiteList);
                        AddUpdateWhiteList.evCustomEventAddUpdateList += ListWasCreatedUpdated;

                        AddUpdateWhiteList.ShowDialog();

                }
                }
                else
                {
                    MessageBox.Show(text: "عليك اولا اضافة ملف للمحكم قبل اضافته الى احد القوائم."
                   , "فشل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile("I have a problem in loading white list form for practitioners type " +
                    "judger,You might need to check add/update practitioner form \nexception:" + ex.Message
                    , System.Diagnostics.EventLogEntryType.Error);

                MessageBox.Show(text: "Problem happen in the system while loading data,you might need to contact maintenance team."
                    , "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Exception:\t" + ex.Message);

            }

        }
        private void btnJudgerClosedList_Click(object sender, EventArgs e)
        {
            try
            {
                if (_PractitionerID != -1 && clsJudger.IsJudgerExistByPractitionerID(_PractitionerID))
                {

                    if (_Mode == enMode.Update && _ShariaMode == enMode.Update
                        && _Judger.IsJudgerInClosedList())
                    {
                        DialogResult result = MessageBox.Show("الشخص مضاف بالفعل الى القائمة البيضاء للمحكمين , ان كنت تريد التعديل اضعط على 'نعم ' ", "سؤال"
                             , MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.OK)
                        {
                            // get ID of white-list by practitioner ID 
                            FrmAddUpdateList form = new FrmAddUpdateList(_PractitionerID,
                                (int)clsClosedList.Find(_PractitionerID, clsPractitioner.enPractitionerType.Judger).ClosedListID,
                                 ctrlAddUpdateList.enCreationMode.JudgerClosedList);
                            form.evCustomEventAddUpdateList += ListWasCreatedUpdated;

                            form.ShowDialog();
                        }
                    }
                    else
                    {

                        FrmAddUpdateList AddUpdateWhiteList = new FrmAddUpdateList(_PractitionerID,
                        ctrlAddUpdateList.enCreationMode.JudgerClosedList);
                        AddUpdateWhiteList.evCustomEventAddUpdateList += ListWasCreatedUpdated;

                        AddUpdateWhiteList.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show(text: "عليك اولا اضافة ملف للمحكم قبل اضافته الى احد القوائم."
                   , "فشل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile("I have a problem in loading white list form for practitioners type " +
                    "judger,You might need to check add/update practitioner form \nexception:" + ex.Message
                    , System.Diagnostics.EventLogEntryType.Error);

                MessageBox.Show(text: "Problem happen in the system while loading data,you might need to contact maintenance team."
                    , "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Exception:\t" + ex.Message);

            }

        }
        private void btnExpertWhite_Click(object sender, EventArgs e)

        {
            try
            {
                if (_PractitionerID != -1 && clsExpert.Exists(_PractitionerID,clsExpert.enFindBy.PractitionerID))
                {

                    if (_Mode == enMode.Update && _ExpertMode == enMode.Update
                        && _Expert.IsExpertInWhiteList())
                    {
                        DialogResult result = MessageBox.Show("الشخص مضاف بالفعل الى القائمة البيضاء للخبراء , ان كنت تريد التعديل اضعط على 'نعم ' ", "سؤال"
                             , MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.OK)
                        {
                            // get ID of white-list by practitioner ID 
                            FrmAddUpdateList form = new FrmAddUpdateList(_PractitionerID,
                                (int)clsWhiteList.Find(_PractitionerID, clsPractitioner.enPractitionerType.Expert).WhiteListID,
                                 ctrlAddUpdateList.enCreationMode.ExpertWhiteList);
                            form.evCustomEventAddUpdateList += ListWasCreatedUpdated;

                            form.ShowDialog();
                        }
                    }
                    else
                    {

                        FrmAddUpdateList AddUpdateWhiteList = new FrmAddUpdateList(_PractitionerID,
                        ctrlAddUpdateList.enCreationMode.ExpertWhiteList);
                        AddUpdateWhiteList.evCustomEventAddUpdateList += ListWasCreatedUpdated;
                        AddUpdateWhiteList.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show(text: "عليك اولا اضافة ملف للخبير قبل اضافته الى احد القوائم."
                   , "فشل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile("I have a problem in loading white list form for practitioners type " +
                    "expert,You might need to check add/update practitioner form \nexception:" + ex.Message
                    , System.Diagnostics.EventLogEntryType.Error);

                MessageBox.Show(text: "Problem happen in the system while loading data,you might need to contact maintenance team."
                    , "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Exception:\t" + ex.Message);

            }

        }
        private void btnExpertClosedList_Click(object sender, EventArgs e)
        {
            try
            {
                if (_PractitionerID != -1 && clsExpert.Exists(_PractitionerID, clsExpert.enFindBy.PractitionerID))
                {

                    if (_Mode == enMode.Update && _ExpertMode == enMode.Update
                        && _Expert.IsExpertInClosedList())
                    {
                        DialogResult result = MessageBox.Show("الشخص مضاف بالفعل الى القائمة البيضاء للخبراء , ان كنت تريد التعديل اضعط على 'نعم ' ", "سؤال"
                             , MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.OK)
                        {
                            // get ID of white-list by practitioner ID 
                            FrmAddUpdateList form = new FrmAddUpdateList(_PractitionerID,
                                (int)clsClosedList.Find(_PractitionerID, clsPractitioner.enPractitionerType.Expert).ClosedListID,
                                 ctrlAddUpdateList.enCreationMode.ExpertClosedList);
                            form.evCustomEventAddUpdateList += ListWasCreatedUpdated;

                            form.ShowDialog();
                        }
                    }
                    else
                    {

                        FrmAddUpdateList AddUpdateWhiteList = new FrmAddUpdateList(_PractitionerID,
                        ctrlAddUpdateList.enCreationMode.ExpertClosedList);
                        AddUpdateWhiteList.evCustomEventAddUpdateList += ListWasCreatedUpdated;
                        AddUpdateWhiteList.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show(text: "عليك اولا اضافة ملف للخبير قبل اضافته الى احد القوائم."
                   , "فشل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile("I have a problem in loading white list form for practitioners type " +
                    "expert,You might need to check add/update practitioner form \nexception:" + ex.Message
                    , System.Diagnostics.EventLogEntryType.Error);

                MessageBox.Show(text: "Problem happen in the system while loading data,you might need to contact maintenance team."
                    , "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Exception:\t" + ex.Message);

            }

        }
        private void clbShariaCasesTypes_Validating(object sender, CancelEventArgs e)
        {
            if (rbtnShariaFree.Checked && clbShariaCasesTypes.CheckedItems.Count > 1)
            {

                errorProvider1.SetError(clbShariaCasesTypes, "لقد تجاوزت الحد المسموح من القضايا لهذا الاشتراك.");
                e.Cancel = true;
            }
            else if(rbtnShariaMedium.Checked && clbShariaCasesTypes.CheckedItems.Count > 3)
            {

                errorProvider1.SetError(clbShariaCasesTypes, "لقد تجاوزت الحد المسموح من القضايا لهذا الاشتراك.");
                e.Cancel = true;
            }
            else if (rbtnShariaSpecial.Checked && clbShariaCasesTypes.CheckedItems.Count > 5)
            {

                errorProvider1.SetError(clbShariaCasesTypes, "لقد تجاوزت الحد المسموح من القضايا لهذا الاشتراك.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(clbShariaCasesTypes, "");

                e.Cancel = false;
            }
        }
        private void clbJudgerCasesTypes_Validating(object sender, CancelEventArgs e)
        {
            if (rbtnJudgerFree.Checked && clbJudgerCasesTypes.CheckedItems.Count > 1)
            {

                errorProvider1.SetError(clbJudgerCasesTypes, "لقد تجاوزت الحد المسموح من القضايا لهذا الاشتراك.");
                e.Cancel = true;
            }
            else if (rbtnJudgerMedium.Checked && clbJudgerCasesTypes.CheckedItems.Count > 3)
            {

                errorProvider1.SetError(clbJudgerCasesTypes, "لقد تجاوزت الحد المسموح من القضايا لهذا الاشتراك.");
                e.Cancel = true;
            }
            else if (rbtnJudgerSpecial.Checked && clbJudgerCasesTypes.CheckedItems.Count > 5)
            {

                errorProvider1.SetError(clbJudgerCasesTypes, "لقد تجاوزت الحد المسموح من القضايا لهذا الاشتراك.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(clbJudgerCasesTypes, "");

                e.Cancel = false;
            }

        }
        private void clbExpertCasesTypes_Validating(object sender, CancelEventArgs e)
        {
            if (rbtnExpertFree.Checked && clbExpertCasesTypes.CheckedItems.Count > 1)
            {

                errorProvider1.SetError(clbExpertCasesTypes, "لقد تجاوزت الحد المسموح من القضايا لهذا الاشتراك.");
                e.Cancel = true;
            }
            else if (rbtnExpertMedium.Checked && clbExpertCasesTypes.CheckedItems.Count > 3)
            {

                errorProvider1.SetError(clbExpertCasesTypes, "لقد تجاوزت الحد المسموح من القضايا لهذا الاشتراك.");
                e.Cancel = true;
            }
            else if (rbtnExpertSpecial.Checked && clbExpertCasesTypes.CheckedItems.Count > 5)
            {

                errorProvider1.SetError(clbExpertCasesTypes, "لقد تجاوزت الحد المسموح من القضايا لهذا الاشتراك.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(clbExpertCasesTypes, "");

                e.Cancel = false;
            }
        }

        private void clbJudgerCasesTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbJudgerCasesRecord.Text = clbJudgerCasesTypes.CheckedItems.Count.ToString();
        }
        private void clbExpertCasesTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbExpertCasesRecord.Text = clbExpertCasesTypes.CheckedItems.Count.ToString();

        }


    }

}
