using AADLBusiness;
using CommandLine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static AADL.Pracititoners.frmAdvancedSearch;


namespace AADL.Pracititoners
{
    public partial class frmAdvancedSearch : Form
    {

        private AdvancedSearchPractitionerProperties _advancedSearchPractitionerProperties = new AdvancedSearchPractitionerProperties();

        public delegate void MyDelegate(AdvancedSearchPractitionerProperties PractitionerProperties);
        public MyDelegate SelectedPractitionerProperties; // Declare a delegate variable


        private Dictionary<DateTimePicker, CheckBox> _dateTimePickerCheckBoxPairs;

        private void InitializeDateTimePickerCheckBoxPairs()
        {

            _dateTimePickerCheckBoxPairs = new Dictionary<DateTimePicker, CheckBox>
            {
            { dtpRegulatorIssueDate, cbEnableRegulatorIssueDate },
            { dtpRegulatorIssueDateFrom, cbEnableRegulatorFromDate },
            { dtpRegulatorIssueDateTo, cbEnableRegulatorToDate },
            { dtpShariaIssueDate, cbEnableShariaIssueDate },
            { dtpShariaIssueDateFrom, cbEnableShariaFromDate },
            { dtpShariaIssueDateTo, cbEnableShariaToDate },
            { dtpJudgerIssueDate, cbEnableJudgerIssueDate },
            { dtpJudgerIssueDateFrom, cbEnableJudgerFromDate },
            { dtpJudgerIssueDateTo, cbEnableJudgerToDate },
            { dtpExpertIssueDate, cbEnableExpertIssueDate },
            { dtpExpertIssueDateFrom, cbEnableExpertFromDate },
            { dtpExpertIssueDateTo, cbEnableExpertToDate }
            };

            foreach (KeyValuePair<DateTimePicker, CheckBox> dateTimePickerCheckBoxControlPair in _dateTimePickerCheckBoxPairs)
            {
                dateTimePickerCheckBoxControlPair.Key.Tag = 0;
                dateTimePickerCheckBoxControlPair.Key.CustomFormat = " ";
                dateTimePickerCheckBoxControlPair.Key.Format = DateTimePickerFormat.Custom;
                dateTimePickerCheckBoxControlPair.Key.ValueChanged += dateTimePicker_ValueChanged;
                dateTimePickerCheckBoxControlPair.Value.CheckedChanged += checkBox_CheckedChanged;

            }

        }
        public frmAdvancedSearch()
        {
            InitializeComponent();
        }
        private void InitializeDateTimePicker(DateTimePicker dateTimePicker, CheckBox checkBox)
        {
            dateTimePicker.Tag = 0;
            dateTimePicker.CustomFormat = " ";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            checkBox.CheckedChanged += checkBox_CheckedChanged;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                
                switch (Convert.ToInt32(checkBox.Tag))
                {

                    case 1:
                        {

                            dtpRegulatorIssueDate.Tag = 0;
                            dtpRegulatorIssueDate.CustomFormat = " ";
                            break;
                        }

                    case 2:
                        {
                            dtpRegulatorIssueDateFrom.Tag = 0;
                            dtpRegulatorIssueDateFrom.CustomFormat = " ";
                            break;
                        }

                    case 3:
                        {
                            dtpRegulatorIssueDateTo.Tag = 0;
                            dtpRegulatorIssueDateTo.CustomFormat = " ";
                            break;
                        }

                    case 4:
                        {

                            dtpShariaIssueDate.Tag = 0;
                            dtpShariaIssueDate.CustomFormat = " ";
                            break;
                        }

                    case 5:
                        {
                            dtpShariaIssueDateFrom.Tag = 0;
                            dtpShariaIssueDateFrom.CustomFormat = " ";
                            break;
                        }

                    case 6:
                        {
                            dtpShariaIssueDateTo.Tag = 0;
                            dtpShariaIssueDateTo.CustomFormat = " ";
                            break;
                        }
                  
                    case 7:
                        {

                            dtpJudgerIssueDate.Tag = 0;
                            dtpJudgerIssueDate.CustomFormat = " ";
                            break;
                        }

                    case 8:
                        {
                            dtpJudgerIssueDateFrom.Tag = 0;
                            dtpJudgerIssueDateFrom.CustomFormat = " ";
                            break;
                        }

                    case 9:
                        {
                            dtpJudgerIssueDateTo.Tag = 0;
                            dtpJudgerIssueDateTo.CustomFormat = " ";
                            break;
                        }

                    case 10:
                        {

                            dtpExpertIssueDate.Tag = 0;
                            dtpExpertIssueDate.CustomFormat = " ";
                            break;
                        }

                    case 11:
                        {
                            dtpExpertIssueDateFrom.Tag = 0;
                            dtpExpertIssueDateFrom.CustomFormat = " ";
                            break;
                        }

                    case 12:
                        {
                            dtpExpertIssueDateTo.Tag = 0;
                            dtpExpertIssueDateTo.CustomFormat = " ";
                            break;
                        }

                }

            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (sender is DateTimePicker dateTimePickerControl && 
                _dateTimePickerCheckBoxPairs.TryGetValue(dateTimePickerControl, out CheckBox checkBoxControl)
                && !checkBoxControl.Checked)
            {
                dateTimePickerControl.Tag = 1;
                dateTimePickerControl.CustomFormat = "dd/MM/yyyy";
            }




        ////Regulatory
        //if (cbEnableRegulatorIssueDate.Checked == false && (DateTimePicker)sender == dtpRegulatorIssueDate)
        //{
        //    //you need to extend it to all controls.
        //    dtpRegulatorIssueDate.Tag = 1;
        //    dtpRegulatorIssueDate.CustomFormat = "dd/MM/yyyy";

        //}
        //if (cbEnableRegulatorFromDate.Checked == false && (DateTimePicker)sender == dtpRegulatorIssueDateFrom)
        //{
        //    //you need to extend it to all controls.
        //    dtpRegulatorIssueDateFrom.Tag = 1;
        //    dtpRegulatorIssueDateFrom.CustomFormat = "dd/MM/yyyy";

        //}
        //if (cbEnableRegulatorToDate.Checked == false && (DateTimePicker)sender == dtpRegulatorIssueDateTo)
        //{
        //    //you need to extend it to all controls.
        //    dtpRegulatorIssueDateTo.Tag = 1;
        //    dtpRegulatorIssueDateTo.CustomFormat = "dd/MM/yyyy";

        //}

        ////Sharia

        //if (cbEnableShariaIssueDate.Checked == false && (DateTimePicker)sender == dtpShariaIssueDate)
        //{
        //    //you need to extend it to all controls.
        //    dtpShariaIssueDate.Tag = 1;
        //    dtpShariaIssueDate.CustomFormat = "dd/MM/yyyy";

        //}
        //if (cbEnableShariaFromDate.Checked == false && (DateTimePicker)sender == dtpShariaIssueDateFrom)
        //{
        //    //you need to extend it to all controls.
        //    dtpShariaIssueDateFrom.Tag = 1;
        //    dtpShariaIssueDateFrom.CustomFormat = "dd/MM/yyyy";

        //}
        //if (cbEnableShariaToDate.Checked == false && (DateTimePicker)sender == dtpShariaIssueDateTo)
        //{
        //    //you need to extend it to all controls.
        //    dtpShariaIssueDateTo.Tag = 1;
        //    dtpShariaIssueDateTo.CustomFormat = "dd/MM/yyyy";

        //}

        ////Judger
        //if (cbEnableJudgerIssueDate.Checked == false && (DateTimePicker)sender == dtpJudgerIssueDate)
        //{
        //    //you need to extend it to all controls.
        //    dtpJudgerIssueDate.Tag = 1;
        //    dtpJudgerIssueDate.CustomFormat = "dd/MM/yyyy";

        //}  
        //if (cbEnableJudgerFromDate.Checked == false && (DateTimePicker)sender == dtpJudgerIssueDateFrom)
        //{
        //    //you need to extend it to all controls.
        //    dtpJudgerIssueDateFrom.Tag = 1;
        //    dtpJudgerIssueDateFrom.CustomFormat = "dd/MM/yyyy";

        //}   
        //if (cbEnableJudgerToDate.Checked == false && (DateTimePicker)sender == dtpJudgerIssueDateTo)
        //{
        //    //you need to extend it to all controls.
        //    dtpJudgerIssueDateTo.Tag = 1;
        //    dtpJudgerIssueDateTo.CustomFormat = "dd/MM/yyyy";

        //}

        ////Expert
        //if (cbEnableExpertIssueDate.Checked == false && (DateTimePicker)sender == dtpExpertIssueDate)
        //{
        //    //you need to extend it to all controls.
        //    dtpExpertIssueDate.Tag = 1;
        //    dtpExpertIssueDate.CustomFormat = "dd/MM/yyyy";

        //}     
        //if (cbEnableExpertFromDate.Checked == false && (DateTimePicker)sender == dtpExpertIssueDateFrom)
        //{
        //    //you need to extend it to all controls.
        //    dtpExpertIssueDateFrom.Tag = 1;
        //    dtpExpertIssueDateFrom.CustomFormat = "dd/MM/yyyy";

        //}    
        //if (cbEnableExpertToDate.Checked == false && (DateTimePicker)sender == dtpExpertIssueDateTo)
        //{
        //    //you need to extend it to all controls.
        //    dtpExpertIssueDateTo.Tag = 1;
        //    dtpExpertIssueDateTo.CustomFormat = "dd/MM/yyyy";

        //}

    }
        private void ResetValuesToDefault()
        {

            _loadSubscriptionTypes();
            _loadSubscriptionWays();
            InitializeDateTimePickerCheckBoxPairs();
        }
        private void frmAdvancedSearch_Load(object sender, EventArgs e)
        {
            try
            {

                ResetValuesToDefault();
            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile("Exception was dropped in your (frmAdavanceSearch)form , you might want to take" +
                    "a look on load the form event\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        private void _loadSubscriptionTypes()
        {
            DataTable dataTableSubscriptionTypes = clsSubscriptionType.GetAllSubscriptionTypes();
            cbSubscriptionType.DataSource = dataTableSubscriptionTypes;
            cbSubscriptionType.DisplayMember = "SubscriptionName";
            cbSubscriptionType.ValueMember = "SubscriptionTypeID";
            cbSubscriptionType.ResetText();

            //to reset selected value
            cbSubscriptionType.SelectedIndex = -1;
        }
        private void _loadSubscriptionWays()
        {
            DataTable dataTableSubscriptionWays = clsSubscriptionWay.GetAllSubscriptionWays();
            cbSubscriptionWay.DataSource = dataTableSubscriptionWays;
            cbSubscriptionWay.DisplayMember = "SubscriptionName";
            cbSubscriptionWay.ValueMember = "SubscriptionWayID";
            cbSubscriptionWay.ResetText();

            //to reset selected value
            cbSubscriptionWay.SelectedIndex = -1;
        }
        private bool? IsPractitionerActive(clsPractitioner.enPractitionerType practitionerType)
        {

            switch (practitionerType)
            {
                case clsPractitioner.enPractitionerType.Regulatory:
                    {

                        if (rbtnIsRegulatorActiveNo.Checked)
                        {
                            return false;
                        }
                        else if (rbtnIsRegulatorActiveYes.Checked)
                        {
                            return true;
                        }
                        break;

                    }

                case clsPractitioner.enPractitionerType.Sharia:
                    {

                        if (rbtnIsShariaActiveNo.Checked)
                        {
                            return false;
                        }
                        else if (rbtnIsShariaActiveYes.Checked)
                        {
                            return true;
                        }

                        break;
                    }
         
                case clsPractitioner.enPractitionerType.Judger:
                    {

                        if (rbtnIsJudgerActiveNo.Checked)
                        {
                            return false;
                        }
                        else if (rbtnIsJudgerActiveYes.Checked)
                        {
                            return true;
                        }
                        else
                            return null;
                    }

                case clsPractitioner.enPractitionerType.Expert:
                    {

                        if (rbtnIsExpertActiveNo.Checked)
                        {
                            return false;
                        }
                        else if (rbtnIsExpertActiveYes.Checked)
                        {
                            return true;
                        }
                        else
                            return null;
                    }

            }

            return null;

        }
        private bool? IsPractitionerInList(clsList.enListType listType)
        {
            switch (listType)
            {

                case clsList.enListType.Black:
                    {

                        //3 case yes , no ,nothing 
                        if (rbtnIsPractitionerInBlackListYes.Checked)
                        {
                            return true;
                        }
                        else if (rbtnIsPractitionerInBlackListNo.Checked)
                        {
                            return false;
                        }
                        break;

                    }

                case clsList.enListType.RegulatoryWhite:
                    {

                        //3 case yes , no ,nothing 
                        if (rbtnIsRegulatorWhiteListYes.Checked)
                        {
                            return true;

                        }
                        else if (rbtnIsRegulatorWhiteListNo.Checked)
                        {
                            return false;

                        }
                        break;

                    }

                case clsList.enListType.RegulatoryClosed:
                    {

                        //3 case yes , no ,nothing 
                        if (rbtnIsRegulatorClosedListYes.Checked)
                        {
                            return true;

                        }
                        else if (rbtnIsRegulatorClosedListNo.Checked)
                        {
                            return false;

                        }
                        break;

                    }

                case clsList.enListType.ShariaWhite:
                    {

                        //3 case yes , no ,nothing 
                        if (rbtnIsShariaWhiteListYes.Checked)
                        {
                            return true;

                        }

                        else if (rbtnIsShariaWhiteListNo.Checked)
                        {
                            return false;

                        }

                        break;

                    }

                case clsList.enListType.ShariaClosed:
                    {

                        if (rbtnIsShariaClosedListYes.Checked)
                        {
                            return true;

                        }

                        else if (rbtnIsShariaClosedListNo.Checked)
                        {
                            return false;

                        }

                        break;

                    }

                case clsList.enListType.JudgerWhite:
                    {

                        //3 case yes , no ,nothing 
                        if (rbtnIsJudgerWhiteListYes.Checked)
                        {
                            return true;

                        }

                        else if (rbtnIsJudgerWhiteListNo.Checked)
                        {
                            return false;

                        }

                        break;

                    }

                case clsList.enListType.JudgerClosed:
                    {

                        if (rbtnIsJudgerClosedListYes.Checked)
                        {
                            return true;

                        }

                        else if (rbtnIsJudgerClosedListNo.Checked)
                        {
                            return false;

                        }

                        break;

                    }

                case clsList.enListType.ExpertWhite:
                    {

                        //3 case yes , no ,nothing 
                        if (rbtnIsExpertWhiteListYes.Checked)
                        {
                            return true;

                        }

                        else if (rbtnIsExpertWhiteListNo.Checked)
                        {
                            return false;

                        }

                        break;

                    }

                case clsList.enListType.ExpertClosed:
                    {

                        if (rbtnIsExpertClosedListYes.Checked)
                        {
                            return true;

                        }

                        else if (rbtnIsExpertClosedListNo.Checked)
                        {
                            return false;

                        }

                        break;

                    }

            }

            return null;
        }

        private void AssignPersonalInfo()
        {

            _advancedSearchPractitionerProperties.FullName = string.IsNullOrWhiteSpace(mtbFullName.Text) ? "" : mtbFullName.Text;
            _advancedSearchPractitionerProperties.PhoneNumber = string.IsNullOrWhiteSpace(mtbPhone.Text) ? "" : mtbPhone.Text;
            _advancedSearchPractitionerProperties.Email = string.IsNullOrWhiteSpace(mtbEmail.Text) ? "" : mtbEmail.Text;

        }
        private void AssignRegulatorInfo()
        {

            _advancedSearchPractitionerProperties.MembershipNumber = string.IsNullOrWhiteSpace(mtbMembershipNumber.Text) ? "" : mtbMembershipNumber.Text;
            _advancedSearchPractitionerProperties.IsRegulatorActive = IsPractitionerActive(clsPractitioner.enPractitionerType.Regulatory);
            _advancedSearchPractitionerProperties.RegulatorIssueDate = (int)dtpRegulatorIssueDate.Tag == 0 ? (DateTime?)null : dtpRegulatorIssueDate.Value.Date;
            _advancedSearchPractitionerProperties.RegulatorIssueDateFrom = (int)dtpRegulatorIssueDateFrom.Tag == 0 ? (DateTime?)null : dtpRegulatorIssueDateFrom.Value.Date;
            _advancedSearchPractitionerProperties.RegulatorIssueDateTo = (int)dtpRegulatorIssueDateTo.Tag == 0 ? (DateTime?)null : dtpRegulatorIssueDateTo.Value.Date;
            _advancedSearchPractitionerProperties.RegulatorCreatedByUserName = string.IsNullOrWhiteSpace(mtbRegulatorCreatedByUserName.Text) ?
                "" : mtbRegulatorCreatedByUserName.Text;
            _advancedSearchPractitionerProperties.IsRegulatoryInWhiteList = IsPractitionerInList(clsList.enListType.RegulatoryWhite);
            _advancedSearchPractitionerProperties.IsRegulatoryInClosedList = IsPractitionerInList(clsList.enListType.RegulatoryClosed);

        }
        private void AssignShariaInfo()
        {

            _advancedSearchPractitionerProperties.ShariaLicenseNumber = string.IsNullOrWhiteSpace(mtbShariaLicenseNumber.Text) ? "" : mtbShariaLicenseNumber.Text;
            _advancedSearchPractitionerProperties.IsShariaActive = IsPractitionerActive(clsPractitioner.enPractitionerType.Sharia);
            _advancedSearchPractitionerProperties.ShariaIssueDate = (int)dtpShariaIssueDate.Tag == 0 ? (DateTime?)null : dtpShariaIssueDate.Value.Date;
            _advancedSearchPractitionerProperties.ShariaIssueDateFrom = (int)dtpShariaIssueDateFrom.Tag == 0 ? (DateTime?)null : dtpShariaIssueDateFrom.Value.Date;
            _advancedSearchPractitionerProperties.ShariaIssueDateTo = (int)dtpShariaIssueDateTo.Tag == 0 ? (DateTime?)null : dtpShariaIssueDateTo.Value.Date;
            _advancedSearchPractitionerProperties.ShariaCreatedByUserName = string.IsNullOrWhiteSpace(mtbShariaCreatedByUserName.Text) ?
                "" : mtbShariaCreatedByUserName.Text;
            _advancedSearchPractitionerProperties.IsShariaInWhiteList = IsPractitionerInList(clsList.enListType.ShariaWhite);
            _advancedSearchPractitionerProperties.IsShariaInClosedList = IsPractitionerInList(clsList.enListType.ShariaClosed);

        }
        private void AssignJudgerInfo()
        {

            _advancedSearchPractitionerProperties.IsJudgerActive = IsPractitionerActive(clsPractitioner.enPractitionerType.Judger);
            _advancedSearchPractitionerProperties.JudgerIssueDate = (int)dtpJudgerIssueDate.Tag == 0 ? (DateTime?)null : dtpJudgerIssueDate.Value.Date;
            _advancedSearchPractitionerProperties.JudgerIssueDateFrom = (int)dtpJudgerIssueDateFrom.Tag == 0 ? (DateTime?)null : dtpJudgerIssueDateFrom.Value.Date;
            _advancedSearchPractitionerProperties.JudgerIssueDateTo = (int)dtpJudgerIssueDateTo.Tag == 0 ? (DateTime?)null : dtpJudgerIssueDateTo.Value.Date;
            _advancedSearchPractitionerProperties.JudgerCreatedByUserName = string.IsNullOrWhiteSpace(mtbJudgerCreatedByUserName.Text) ?"" : mtbJudgerCreatedByUserName.Text;
            _advancedSearchPractitionerProperties.IsJudgerInWhiteList = IsPractitionerInList(clsList.enListType.JudgerWhite);
            _advancedSearchPractitionerProperties.IsJudgerInClosedList = IsPractitionerInList(clsList.enListType.JudgerClosed);
        }
        private void AssignExpertInfo()

        {

            _advancedSearchPractitionerProperties.IsExpertActive = IsPractitionerActive(clsPractitioner.enPractitionerType.Expert);
            _advancedSearchPractitionerProperties.ExpertIssueDate = (int)dtpExpertIssueDate.Tag == 0 ? (DateTime?)null : dtpExpertIssueDate.Value.Date;
            _advancedSearchPractitionerProperties.ExpertIssueDateFrom = (int)dtpExpertIssueDateFrom.Tag == 0 ? (DateTime?)null : dtpExpertIssueDateFrom.Value.Date;
            _advancedSearchPractitionerProperties.ExpertIssueDateTo = (int)dtpExpertIssueDateTo.Tag == 0 ? (DateTime?)null : dtpExpertIssueDateTo.Value.Date;
            _advancedSearchPractitionerProperties.ExpertCreatedByUserName = string.IsNullOrWhiteSpace(mtbExpertCreatedByUserName.Text) ? "" : mtbExpertCreatedByUserName.Text;
            _advancedSearchPractitionerProperties.IsExpertInWhiteList = IsPractitionerInList(clsList.enListType.ExpertWhite);
            _advancedSearchPractitionerProperties.IsExpertInClosedList = IsPractitionerInList(clsList.enListType.ExpertClosed);
        }
        private int? GetSubscriptionTypeID()
        {

            DataRowView selectedRow = (DataRowView)cbSubscriptionType.SelectedItem;
            int? SubscriptionTypeID = selectedRow != null ? Convert.ToInt32(selectedRow["SubscriptionTypeID"]) : (int?)null;
            return SubscriptionTypeID;
        }
        private int? GetSubscriptionWayID()
        {


            DataRowView selectedRow = (DataRowView)cbSubscriptionWay.SelectedItem;
            int? SubscriptionWayID = selectedRow != null ? Convert.ToInt32(selectedRow["SubscriptionWayID"]) : (int?)null;
            return SubscriptionWayID;
        }
        private void AssignPractitionerInfo()
        {
            _advancedSearchPractitionerProperties.IsPractitionerInBlackList = IsPractitionerInList(clsList.enListType.Black);
            _advancedSearchPractitionerProperties.SubscriptionTypeID = GetSubscriptionTypeID();
            _advancedSearchPractitionerProperties.SubscriptionWayID = GetSubscriptionWayID();

        }

        private void MakeQueryProperties()
        {
            AssignPersonalInfo();
            AssignPractitionerInfo();
            AssignRegulatorInfo();
            AssignShariaInfo();
            AssignJudgerInfo();
            AssignExpertInfo();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MakeQueryProperties();
            AdvancedSearchPractitionerProperties practitionerProperties = _advancedSearchPractitionerProperties;
            // Check if there's a delegate assigned
            if (SelectedPractitionerProperties != null)
            {
                SelectedPractitionerProperties(practitionerProperties); // Invoke the delegate with the object
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}