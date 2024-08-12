using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class Company_Credential
    {

        private string _companyID = string.Empty;
        public string CompanyID
        {
            get { return _companyID; }

        }

        private string _hap = string.Empty;
        public string HAP
        {
            get { return _hap; }

        }

        private string _hapType = string.Empty;
        public string HAP_Type
        {
            get { return _hapType; }

        }

        private string _hapPwd = string.Empty;
        public string HAP_Password
        {
            get { return _hapPwd; }

        }

        private string _agentID = "1";
        public string AgentID
        {
            get { return _agentID; }
            set { _agentID = value; }
        }

        private string _branchID = "1";
        public string BranchID
        {
            get { return _branchID; }
            set { _branchID = value; }
        }


        private string _customerType = string.Empty;
        public string CustomerType
        {
            get { return _customerType; }
            set { _customerType = value; }
        }

       

        public void Set_Company_Credential(string __companyCode, string __hap, string __hapPwd, string __haptype)
        {
            _companyID = __companyCode.Trim();
            _hap = __hap.Trim();
            _hapType = __haptype.Trim();
            _hapPwd = __hapPwd.Trim();


            if (String.IsNullOrEmpty(_companyID))
            {
                throw new ArgumentException("Invalid Company  : Company Not Registered.");
            }
            
        }
        private List<Credential> _credential = new List<Credential>();
        public List<Credential> Credentials
        {
            get { return _credential; }

        }
    }
}