using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        private const string sRem = "|Empty Node|";

        static String DataBaseServer = "ralpholiveie7eb";
        static String DataBaseName = "SBODEMOUS";
        static String DataBaseType = "dst_MSSQL2012";
        static String DataBaseUserName = "sa";
        static String DataBasePassword = "sapb1";
        static String CompanyUserName = "manager";
        static String CompanyPassword = "1234";
        static String Language = "ln_English";
        static String LicenseServer = DataBaseServer + ":30000";
        static String DIS_SessionId = null;


        //DI API
        private SAPbobsCOM.Company objCompany = null;
        private int intRetCode = -1;
        private string strMessage = "";
        private SAPbobsCOM.BusinessPartners objBP = null;

        public Form1()
        {
            InitializeComponent();
        }



        private void DISConnect_Click(object sender, EventArgs e)
        {

            SBODI_Server.Node DISnode = null;
            string sSOAPans = null, sCmd = null;

            DISnode = new SBODI_Server.Node();

            sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>"
                    + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">"
                        + @"<env:Body>"
                                + @"<dis:Login xmlns:dis=""http://www.sap.com/SBO/DIS"">"
                                    + "<DatabaseServer>" + DataBaseServer + "</DatabaseServer>"
                                    + "<DatabaseName>" + DataBaseName + "</DatabaseName>"
                                    + "<DatabaseType>" + DataBaseType + "</DatabaseType>"
                                    + "<DatabaseUsername>" + DataBaseUserName + "</DatabaseUsername>"
                                    + "<DatabasePassword>" + DataBasePassword + "</DatabasePassword>"
                                    + "<CompanyUsername>" + CompanyUserName + "</CompanyUsername>"
                                    + "<CompanyPassword>" + CompanyPassword + "</CompanyPassword>"
                                    + "<Language>" + Language + "</Language>"
                                    + "<LicenseServer>" + LicenseServer + "</LicenseServer>"
                              + "</dis:Login>"
                        + "</env:Body>"
                    + "</env:Envelope>";

            sSOAPans = DISnode.Interact(sCmd);

            //  Parse the SOAP answer
            System.Xml.XmlValidatingReader xmlValid = null;
            string sRet = null;
            xmlValid = new System.Xml.XmlValidatingReader(sSOAPans, System.Xml.XmlNodeType.Document, null);
            while (xmlValid.Read())
            {
                if (xmlValid.NodeType == System.Xml.XmlNodeType.Text)
                {
                    if (sRet == null)
                    {
                        sRet += xmlValid.Value;
                    }
                    else
                    {
                        if (sRet.StartsWith("Error"))
                        {
                            sRet += " " + xmlValid.Value;
                        }
                        else
                        {
                            sRet = "Error " + sRet + " " + xmlValid.Value;
                        }
                    }
                }
            }

            if (sSOAPans.Contains("<env:Fault>"))
            {
                sRet = "Error: " + sRet;
            }
            else
            {
                DIS_SessionId = sRet;
                sRet = "Connection ID: " + DIS_SessionId;
            }

            MessageBox.Show(sRet);
        }

        private void DIS_CreateBP_Click(object sender, EventArgs e)
        {


            //Formats XML with BP attributes
            System.Xml.XmlDocument xmlD = null;
            System.Xml.XmlElement xmlE = null;
            System.Xml.XmlNodeList bpCode = null;
            System.Xml.XmlNode bpName = null;


            xmlD = GetEmptyBPXml();
            xmlE = (System.Xml.XmlElement)xmlD.DocumentElement;

            xmlE.InnerXml = xmlE.InnerXml.Replace("<CardCode />", "<CardCode>" + DIS_BPCode.Text + "</CardCode>");
            xmlE.InnerXml = xmlE.InnerXml.Replace("<CardName />", "<CardName>" + "Inserted By DI Server at - " + DIS_BPCode.Text + "</CardName>");

            SBODI_Server.Node node = null;
            System.Xml.XmlDocument doc = null;
            System.Xml.XmlDocument parseXML = null;

            doc = new System.Xml.XmlDocument();
            node = new SBODI_Server.Node();

            string AddCmd = null;
            System.Xml.XmlNode netoXML = null;

            parseXML = new System.Xml.XmlDocument();
            parseXML.LoadXml(xmlE.OuterXml);

            netoXML = (RemoveEmptyNodes(parseXML));

            AddCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>" +
                        @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" +
                            "<env:Header>" +
                                "<SessionID>" + DIS_SessionId + "</SessionID>" +
                            @"</env:Header>" +
                            "<env:Body>" +
                                @"<dis:AddObject xmlns:dis=""http://www.sap.com/SBO/DIS"">" +
                                    netoXML.InnerXml +
                                "</dis:AddObject>" +
                            "</env:Body>" +
                        "</env:Envelope>";

            string res = null;
            res = node.Interact(AddCmd);
            doc.LoadXml(res);
            showXmlReturn(doc);

        }

        private void DIS_GetBpList_Click(object sender, EventArgs e)
        {
            SBODI_Server.Node DISnode = null;
            string strSOAPans = null, strSOAPcmd = null;
            System.Xml.XmlDocument xmlDoc = null;

            xmlDoc = new System.Xml.XmlDocument();
            DISnode = new SBODI_Server.Node();

            strSOAPcmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>" +
                            @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" +
                                "<env:Header>" +
                                    "<SessionID>" + DIS_SessionId + "</SessionID>" +
                                @"</env:Header>" +
                                "<env:Body>" +
                                    @"<dis:GetBPList xmlns:dis=""http://www.sap.com/SBO/DIS"">" +
                                        "<CardType>" + getCardtype(DIS_CardType.Text) + "</CardType>" +
                                    "</dis:GetBPList>" +
                                "</env:Body>" +
                            "</env:Envelope>";

            strSOAPans = DISnode.Interact(strSOAPcmd);
            xmlDoc.LoadXml(strSOAPans);
            showXmlReturn(xmlDoc);    
        }


        private bool DISConnected()
        {
            if (DIS_SessionId == null)
                return false;
            return true;
        }



        // This function returns an XML document of an empty Business Partner object
        // To do so, it calls DI Server asking the object BusinessPartners
        public System.Xml.XmlDocument GetEmptyBPXml()
        {

            SBODI_Server.Node n = null;
            string s = null, strXML = null;
            System.Xml.XmlDocument d = null;

            d = new System.Xml.XmlDocument();
            n = new SBODI_Server.Node();

            strXML = @"<?xml version=""1.0"" encoding=""UTF-16""?>" +
                     @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" +
                        "<env:Header>" +
                            "<SessionID>" + DIS_SessionId + "</SessionID>"
                        + @"</env:Header>" +
                        "<env:Body>" +
                            @"<dis:GetBusinessObjectTemplate xmlns:dis=""http://www.sap.com/SBO/DIS"">" +
                                "<Object>oBusinessPartners</Object>" +
                            "</dis:GetBusinessObjectTemplate>" +
                        " </env:Body>" +
                     "</env:Envelope>";

            s = n.Interact(strXML);
            d.LoadXml(s);

            return (RemoveEnv(d));
        }

        //  This function removes the SOAP envelope
        public System.Xml.XmlDocument RemoveEnv(System.Xml.XmlDocument xmlD)
        {
            System.Xml.XmlDocument d = null;
            string s = null;

            d = new System.Xml.XmlDocument();
            if (xmlD.InnerXml.Contains("<env:Fault>"))
            {
                return xmlD;
            }
            else
            {
                s = xmlD.FirstChild.NextSibling.FirstChild.FirstChild.InnerXml;
                d.LoadXml(s);
            }

            return d;

        }
        //  This function removes all the empty nodes from an XML document
        private System.Xml.XmlNode RemoveEmptyNodes(System.Xml.XmlNode n)
        {
            System.Xml.XmlNode nAns = null;

            nAns = MarkEmptyNodes(n);
            System.Xml.XmlNodeList nc = null;
            string sSelect = null;

            sSelect = @"//*[text()=""";
            sSelect += sRem;
            sSelect += @"""]";

            nc = nAns.SelectNodes(sSelect);
            foreach (System.Xml.XmlNode nN in nc)
            {
                nN.ParentNode.RemoveChild(nN);
            }
            return nAns;
        }
        //  This function marks all the empty nodes with special text.
        //  The "RemoveEmptyNodes" function uses it to select the nodes to be deleted.
        private System.Xml.XmlNode MarkEmptyNodes(System.Xml.XmlNode n)
        {
            System.Xml.XmlNode MainNode = null;
            MainNode = n;
            System.Xml.XmlNode nI = null;

            int i = 0, Removed = 0;
            i = 0;
            Removed = 0;

            for (i = 0; i <= MainNode.ChildNodes.Count - 1 - Removed; i++)
            {
                nI = MainNode.ChildNodes[i];
                if (nI.InnerText == "")
                {
                    nI.InnerText = sRem;
                }
                else if (nI.HasChildNodes)
                {
                    nI = MarkEmptyNodes(nI);
                }
            }
            return MainNode;
        }



        private String getCardtype(String desc)
        {
            return "c"+desc;
        }
        private SAPbobsCOM.BoCardTypes getDIACardtype(String desc)
        {
            if (desc == "Supplier"){
                return SAPbobsCOM.BoCardTypes.cSupplier;
            }
            else if (desc == "Customer")
            {
                return SAPbobsCOM.BoCardTypes.cCustomer;
            }
            return SAPbobsCOM.BoCardTypes.cLid;
 

        }

        private void showXmlReturn(System.Xml.XmlDocument doc)
        {
            MessageBox.Show("XML Return: \n" + doc.InnerXml);
        }

        private void DIS_CardType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DIA_Connect_Click(object sender, EventArgs e)
        {
            this.connect();

        }

        private void DIA_GetBpList_Click(object sender, EventArgs e)
        {
            SAPbobsCOM.Recordset objRecordset = null;
            try
            {
                if (this.objCompany == null || !objCompany.Connected)
                {
                    this.connect();
                }
                if (this.objCompany != null && objCompany.Connected)
                {
                    objBP = (SAPbobsCOM.BusinessPartners)objCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
                    objRecordset = (SAPbobsCOM.Recordset)objCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    SAPbobsCOM.SBObob objBOB = null;
                    objBOB = objCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
                    objRecordset = objBOB.GetBPList(getDIACardtype(DIA_CardType.Text));
                    objBP.Browser.Recordset = objRecordset;

                    objBP.Browser.MoveFirst();
                    
                    String msg = null;
                    while (!objBP.Browser.EoF)
                    {
                        msg += objBP.CardCode + " - " + objBP.CardName + "\n";
                        objBP.Browser.MoveNext();
                    }

                    MessageBox.Show(msg);
                        
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void DIA_CreateBP_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.objCompany == null || !objCompany.Connected)
                {
                    this.connect();
                }
                if (this.objCompany != null && objCompany.Connected)
                {

                    SAPbobsCOM.BusinessPartners oBP = null;
                    int retCode = -1;
                    String retMess = "";

                    oBP = objCompany.GetBusinessObject(
                                    SAPbobsCOM.BoObjectTypes.oBusinessPartners);

                    oBP.CardCode = DIA_BPCode.Text;
                    oBP.CardName = "Insert via DIAPI - "+ DIA_BPCode.Text;
                    oBP.CardType = SAPbobsCOM.BoCardTypes.cCustomer;
                    retCode = oBP.Add();

                    if (retCode != 0)
                    {
                        retMess = objCompany.GetLastErrorDescription();
                    }
                    else
                    {
                        retMess = "BP inserted successfully! - " + objCompany.GetNewObjectKey();
                    }

                    MessageBox.Show(retMess);
                }

            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }

        }

        private void connect()
        {
            try
            {
                objCompany = new SAPbobsCOM.Company();
                objCompany.Server = DataBaseServer;
                objCompany.UseTrusted = false;
                objCompany.DbUserName = DataBaseUserName;
                objCompany.DbPassword = DataBasePassword;
                objCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
                objCompany.CompanyDB = DataBaseName;
                objCompany.UserName = CompanyUserName;
                objCompany.Password = CompanyPassword;

                intRetCode = objCompany.Connect();

                if (intRetCode != 0)
                {
                    strMessage = objCompany.GetLastErrorDescription();
                }
                else
                {
                    strMessage = "Connected to " + objCompany.CompanyName;
                }
                MessageBox.Show(strMessage);

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }




    }
}
