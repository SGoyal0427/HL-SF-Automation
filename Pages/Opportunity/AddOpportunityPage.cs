﻿using OpenQA.Selenium;
using SF_Automation.TestData;
using SF_Automation.UtilityFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SF_Automation.Pages
{
    class AddOpportunityPage : BaseClass
    {
        By txtOpportunityName = By.Id("Name");
        By txtClient = By.XPath("//span[@class='lookupInput']/input[@name='CF00Ni000000D7zoC']");
        By txtSubject = By.XPath("//span[@class='lookupInput']/input[@name='CF00Ni000000D80OZ']");
        By comboJobType = By.CssSelector("select[id*= 'hWW']");
        By comboIndustryGroup = By.CssSelector("select[name*= 'VT3']");
        By comboSector = By.CssSelector("select[name*='PI']");
        By comboAdditionalClient = By.CssSelector("select[name*='FmBza']");
        By comboAdditionalSubject = By.CssSelector("select[name*='Bzb']");

        By comboStage = By.CssSelector("select[id*='00Ni000000D80OA']");
        By txtErrorMessages = By.CssSelector("div[id*='errorDiv_ep']");

        By comboReferralType = By.CssSelector("select[name*='uS']");
        By comboNonPublicInfo = By.CssSelector("select[name*='Bzn']");
        By comboBeneficialOwner = By.CssSelector("select[name*='HERR2']");
        By comboPrimaryOffice = By.CssSelector("select[name*='VIA']");
        By txtLegalEntity = By.XPath("//span[@class='lookupInput']/input[@name='CF00N5A00000M0eg5']");
        By comboDisclosureStatus = By.CssSelector("select[name*='HaP']");
        By comboLegalAdvisor = By.CssSelector("select[id*='00N5A00000M4yQB']");
        By btnSave = By.CssSelector("input[value=' Save ']");
        By comboClientOwnership = By.CssSelector("select[name*='M0d2T']");
        By comboSubjectOwnership = By.CssSelector("select[name*='M0d2U']");
        By comboRecordType = By.CssSelector("select[name='00Ni000000D8hW2']");
        By txtTotalDebt = By.CssSelector("input[name*='DwfqW']");
        By comboEMEAInitiatives = By.CssSelector("span>select[name*='MR']");
        By txtFee = By.CssSelector("input[name*='FmBzg']");
        By txtTotalAntRev = By.CssSelector("input[id*='00N6e00000H0zNU']");
        By labelWomenLed = By.CssSelector("div:nth-child(25) > table > tbody > tr:nth-child(4) > td:nth-child(3) > span > label");
        By labelWomenLedFVA = By.CssSelector("div:nth-child(25) > table > tbody > tr:nth-child(3) > td:nth-child(3) > span > label");
        By labelWomenLedFR = By.CssSelector("div:nth-child(21) > table > tbody > tr:nth-child(4) > td:nth-child(3) > span > label");
        By labelAdmSection = By.CssSelector("div[id='head_12_ep'] > h3");
        By labelAdmSectionFVA = By.CssSelector("div[id = 'head_12_ep'] > h3");
        By labelAdmSectionFR = By.CssSelector("div[id = 'head_10_ep'] > h3");
        By selectedLOBvalue = By.CssSelector("select[id='00Ni000000D8hW2']");
        By labelOpportunityEdit = By.CssSelector("h2[class='mainTitle']");
        By btnCancel = By.CssSelector("td[class='pbButton'] > input[value='Cancel']");
        By comboWomenLed = By.CssSelector("select[id*='NgW']>option");
        By msgFee = By.XPath("//*[@id='ep']/div[2]/div[17]/table/tbody/tr[3]/td[2]/div/div[2]");

        By comboSuccessProb = By.CssSelector("select[id*='00N5A00000M4yXq']");
        By txtEstTranscSize = By.CssSelector("input[id*='00Ni000000D80P4']");
        By txtRetainerFee = By.CssSelector("input[id*='00Ni000000DwTdF']");
        By txtMnthFee = By.CssSelector("input[id*='00Ni000000FmBzi']");
        By txtContingFee = By.CssSelector("input[id*='00Ni000000FkGE9']");
        By txtEstCloseDate = By.CssSelector("input[id*='00Ni000000FnLTw']");
        By comboReferType = By.CssSelector("select[id*='00Ni000000FF5uS']");
        By chkboxNBC = By.CssSelector("input[id*='00Ni000000FmBzh']");
        By chkboxByPassConflictCheck = By.CssSelector("input[id*='00N3100000Gb1CJ']");

        //Lightning
        By txtOpportunityNameL = By.XPath("//input[@name= 'Name']");
        By txtClientL = By.XPath("//label[text()='Client']/following::div[1]/div/lightning-base-combobox/div[1]/div/input");
        By txtSubjectL = By.XPath("//label[text()='Subject']/following::div[1]/div/lightning-base-combobox/div[1]/div/input");
        By btnJobTypeL = By.XPath("//button[@aria-label='Job Type, --None--']");
        By btnIGL = By.XPath("//button[@aria-label='Industry Group, --None--']");
        By comboSectorL = By.XPath("//button[@aria-label='Sector, --None--']");
        By comboPrimaryOfficeL = By.XPath("//button[@aria-label='Primary Office, --None--']");
        By txtLegalEntitiesL = By.XPath("//input[@placeholder='Search Legal Entities...']");
        By comboRefTypeL = By.XPath("//button[@aria-label='Referral Type, --None--']");
        By comboAddClientL = By.XPath("//button[@aria-label='Additional Client, --None--']");
        By comboAddSubjectL = By.XPath("//button[@aria-label='Additional Subject, --None--']");
        By comboBenOwnerL = By.XPath("//button[@aria-label='Beneficial Owner & Control Person form?, --None--']");
        By comboHLMaterialL = By.XPath("//button[@aria-label='Does HL Have Material Non-Public Info?, --None--']");
        By btnSaveL = By.XPath("//button[text()='Save']");
        By btnConfAgreeL = By.XPath("//flexipage-component2[11]/slot/flexipage-field-section2/div/div/div/laf-progressive-container/slot/div/slot/flexipage-column2[1]/div/slot/flexipage-field[1]/slot/record_flexipage-record-field/div/span/slot/records-record-picklist/records-form-picklist/lightning-picklist/lightning-combobox/div/lightning-base-combobox/div/div[1]/button");

        public string AddOpportunities(string type, string file)
        {
            ReadJSONData.Generate("Admin_Data.json");
            string dir = ReadJSONData.data.filePaths.testData;
            string excelPath = dir + file;
            Console.WriteLine("path:" + excelPath);

            //--------------------------Enter Opportunity details-----------------------------
            //Information Section           
            WebDriverWaits.WaitUntilEleVisible(driver, txtOpportunityName, 40);
            string valOpportunity = CustomFunctions.RandomValue();

            driver.FindElement(txtOpportunityName).SendKeys(valOpportunity);
            //driver.FindElement(txtClient).SendKeys(ReadJSONData.data.addOpportunityDetails.client);            
            driver.FindElement(txtClient).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 1));
            driver.FindElement(txtSubject).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 2));
            WebDriverWaits.WaitUntilEleVisible(driver, comboJobType, 80);
            driver.FindElement(comboJobType).SendKeys(type);
            driver.FindElement(comboIndustryGroup).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 4));
            driver.FindElement(comboSector).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 5));
            driver.FindElement(comboClientOwnership).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 18));
            driver.FindElement(comboSubjectOwnership).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 19));
            Console.WriteLine("Subject");

            //Additional Client/Subject
            driver.FindElement(comboAdditionalClient).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 6));
            driver.FindElement(comboAdditionalSubject).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 7));

            //Referral Information
            driver.FindElement(comboReferralType).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 8));

            //Compliance Section
            driver.FindElement(comboNonPublicInfo).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 9));
            driver.FindElement(comboBeneficialOwner).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 10));
            Console.WriteLine("owner");

            //Administration Section
            driver.FindElement(comboPrimaryOffice).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 11));
            driver.FindElement(txtLegalEntity).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 12));
            driver.FindElement(comboDisclosureStatus).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 13));

            if (driver.FindElement(comboRecordType).Text.Contains("FR"))
            {
                Console.WriteLine("in if");
                driver.FindElement(txtTotalDebt).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 17));
                driver.FindElement(comboEMEAInitiatives).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 29));
            }

            else if (driver.FindElement(comboRecordType).Text.Contains("FVA"))
            {
                Console.WriteLine("in else if");
                driver.FindElement(txtFee).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 27));
            }
            else
            {
                Console.WriteLine("CF types ");
            }
            //Click Save button
            driver.FindElement(btnSave).Click();
            return valOpportunity;
        }

        public string AddOpportunitiesWithLegalEntityOtherThanHLCapital(string type, string file)
        {
            ReadJSONData.Generate("Admin_Data.json");
            string dir = ReadJSONData.data.filePaths.testData;
            string excelPath = dir + file;

            //--------------------------Enter Opportunity details-----------------------------
            //Information Section           
            WebDriverWaits.WaitUntilEleVisible(driver, txtOpportunityName, 40);
            string valOpportunity = CustomFunctions.RandomValue();

            driver.FindElement(txtOpportunityName).SendKeys(valOpportunity);
            driver.FindElement(txtClient).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 1));
            driver.FindElement(txtSubject).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 2));
            WebDriverWaits.WaitUntilEleVisible(driver, comboJobType, 80);
            driver.FindElement(comboJobType).SendKeys(type);
            driver.FindElement(comboIndustryGroup).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 4));
            driver.FindElement(comboSector).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 5));
            driver.FindElement(comboClientOwnership).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 18));
            driver.FindElement(comboSubjectOwnership).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 19));
            Console.WriteLine("Subject");
            //Additional Client/Subject
            driver.FindElement(comboAdditionalClient).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 6));
            driver.FindElement(comboAdditionalSubject).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 7));

            //Referral Information
            driver.FindElement(comboReferralType).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 8));

            //Compliance Section
            driver.FindElement(comboNonPublicInfo).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 9));
            driver.FindElement(comboBeneficialOwner).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 10));
            Console.WriteLine("owner");
            //Administration Section
            driver.FindElement(comboPrimaryOffice).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 11));
            driver.FindElement(txtLegalEntity).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 32));
            driver.FindElement(comboDisclosureStatus).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 13));

            if (driver.FindElement(comboRecordType).Text.Contains("FR"))
            {
                Console.WriteLine("in if");
                driver.FindElement(txtTotalDebt).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 17));
                driver.FindElement(comboEMEAInitiatives).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 29));
            }

            else if (driver.FindElement(comboRecordType).Text.Contains("FVA"))
            {
                Console.WriteLine("in else if");
                driver.FindElement(txtFee).SendKeys("10001");

            }
            else
            {
                Console.WriteLine("CF types ");
            }
            //Click Save button
            driver.FindElement(btnSave).Click();
            return valOpportunity;
        }

        public string AddOpportunitiesWithStageVerballyEngaged(string type, string file)
        {
            ReadJSONData.Generate("Admin_Data.json");
            string dir = ReadJSONData.data.filePaths.testData;
            string excelPath = dir + file;
            Console.WriteLine("path:" + excelPath);

            //--------------------------Enter Opportunity details-----------------------------
            //Information Section           
            WebDriverWaits.WaitUntilEleVisible(driver, txtOpportunityName, 40);
            string valOpportunity = CustomFunctions.RandomValue();

            driver.FindElement(txtOpportunityName).SendKeys(valOpportunity);
            //driver.FindElement(txtClient).SendKeys(ReadJSONData.data.addOpportunityDetails.client);            
            driver.FindElement(txtClient).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 1));
            driver.FindElement(txtSubject).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 2));
            WebDriverWaits.WaitUntilEleVisible(driver, comboJobType, 80);
            driver.FindElement(comboJobType).SendKeys(type);
            driver.FindElement(comboIndustryGroup).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 4));
            driver.FindElement(comboSector).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 5));
            driver.FindElement(comboClientOwnership).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 18));
            driver.FindElement(comboSubjectOwnership).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 19));
            Console.WriteLine("Subject");
            driver.FindElement(comboStage).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 29));

            //Additional Client/Subject
            driver.FindElement(comboAdditionalClient).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 6));
            driver.FindElement(comboAdditionalSubject).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 7));

            //Referral Information
            driver.FindElement(comboReferralType).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 8));

            //Compliance Section
            driver.FindElement(comboNonPublicInfo).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 9));
            driver.FindElement(comboBeneficialOwner).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 10));
            Console.WriteLine("owner");

            //Administration Section
            driver.FindElement(comboPrimaryOffice).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 11));
            driver.FindElement(txtLegalEntity).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 32));
            driver.FindElement(comboDisclosureStatus).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 13));

            //Click Save button
            driver.FindElement(btnSave).Click();

            return valOpportunity;
        }

        public void UpdateMissingFieldsForOpportunityWithStageVerballyEngagedAndLegalEntityOtherThanHLCapital(string type, string file)
        {
            ReadJSONData.Generate("Admin_Data.json");
            string dir = ReadJSONData.data.filePaths.testData;
            string excelPath = dir + file;

            //--------------------------Update Missing Opportunity details-----------------------------
            //Information Section

            //driver.FindElement(comboSuccessProb).Click();
            Thread.Sleep(3000);
            driver.FindElement(comboSuccessProb).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 30));

            //Estimated Financials Section
            driver.FindElement(txtEstTranscSize).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 31));

            //Estimated Fees Section
            driver.FindElement(txtRetainerFee).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 15));
            driver.FindElement(txtMnthFee).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 16));
            driver.FindElement(txtContingFee).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 17));

            //Administration Section
            string getDate = DateTime.Today.AddDays(0).ToString("MM/dd/yyyy");
            driver.FindElement(txtEstCloseDate).SendKeys(getDate);

            // Approve NBC Form
            driver.FindElement(chkboxNBC).Click();

            // By Pass Conflict check
            driver.FindElement(chkboxByPassConflictCheck).Click();

            //Click Save button
            driver.FindElement(btnSave).Click();
        }

        public bool ValidateIfTailExpiresFieldIsRequiredOrNot()
        {
            if (driver.FindElement(txtErrorMessages).Displayed)
            {
                string errorMessages = driver.FindElement(txtErrorMessages).Text;
                if (errorMessages.Contains("Tail Expires"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public void ChangeLegalEntityFieldToHLCapitalToCreateOpportunityWithStageVerballyEngaged(string type, string file)
        {
            ReadJSONData.Generate("Admin_Data.json");
            string dir = ReadJSONData.data.filePaths.testData;
            string excelPath = dir + file;

            //--------------------------Change Legal Entity to HL Capital-----------------------------

            //Admministration Section
            driver.FindElement(txtLegalEntity).Clear();
            Thread.Sleep(2000);
            driver.FindElement(txtLegalEntity).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 12));

            //Referral Information Section
            driver.FindElement(comboReferralType).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 8));

            //Click Save button
            driver.FindElement(btnSave).Click();
            Thread.Sleep(5000);
        }

        //Validate Women Led field
        public string ValidateWomenLedField(string recType)
        {
            if (recType.Equals("CF"))
            {
                WebDriverWaits.WaitUntilEleVisible(driver, labelWomenLed);
                string fieldName = driver.FindElement(labelWomenLed).Text;
                return fieldName;
            }
            else if (recType.Equals("FVA"))
            {
                WebDriverWaits.WaitUntilEleVisible(driver, labelWomenLedFVA);
                string fieldName = driver.FindElement(labelWomenLedFVA).Text;
                return fieldName;
            }
            else
            {
                WebDriverWaits.WaitUntilEleVisible(driver, labelWomenLedFR);
                string fieldName = driver.FindElement(labelWomenLedFR).Text;
                return fieldName;
            }
        }

        //Get Administration section
        public string GetAdminSectionName(string recType)
        {
            if (recType.Equals("CF"))
            {
                WebDriverWaits.WaitUntilEleVisible(driver, labelAdmSection);
                string secName = driver.FindElement(labelAdmSection).Text;
                return secName;
            }
            else if (recType.Equals("FVA"))
            {
                WebDriverWaits.WaitUntilEleVisible(driver, labelAdmSectionFVA);
                string secName = driver.FindElement(labelAdmSectionFVA).Text;
                return secName;
            }
            else
            {
                WebDriverWaits.WaitUntilEleVisible(driver, labelAdmSectionFR);
                string secName = driver.FindElement(labelAdmSectionFR).Text;
                return secName;
            }

        }

        // Clear mandatory values on add opprtunity page
        public void ClearMandatoryValuesOnAddOpportunity()
        {
            driver.FindElement(txtOpportunityName).Clear();
            driver.FindElement(txtClient).Clear();
            driver.FindElement(txtSubject).Clear();
        }
        // Get edit opportunity page heading
        public string GetEditOpportunityPageHeading()
        {
            WebDriverWaits.WaitUntilEleVisible(driver, labelOpportunityEdit, 60);
            string headingEditOpportunity = driver.FindElement(labelOpportunityEdit).Text;
            return headingEditOpportunity;
        }

        // Get prefilled opportunity name
        public string GetPrefilledOpportunityName()
        {
            WebDriverWaits.WaitUntilEleVisible(driver, txtOpportunityName, 60);
            string prefilledOpportunityName = driver.FindElement(txtOpportunityName).GetAttribute("value");
            return prefilledOpportunityName;
        }

        // Get prefilled client name
        public string GetPrefilledClientName()
        {
            WebDriverWaits.WaitUntilEleVisible(driver, txtClient, 60);
            string prefilledClientName = driver.FindElement(txtClient).GetAttribute("value");
            return prefilledClientName;
        }

        // Get prefilled opportunity subject
        public string GetPrefilledOpportunitySubject()
        {
            WebDriverWaits.WaitUntilEleVisible(driver, txtSubject, 60);
            string prefilledSubject = driver.FindElement(txtSubject).GetAttribute("value");
            return prefilledSubject;
        }

        // Get prefilled line of business
        public string GetPrefilledLineOfBusiness()
        {
            WebDriverWaits.WaitUntilEleVisible(driver, selectedLOBvalue, 60);
            string prefilledLOB = driver.FindElement(selectedLOBvalue).Text;
            return prefilledLOB;
        }
        //Click cancel button
        public void ClickCancelButton()
        {
            WebDriverWaits.WaitUntilEleVisible(driver, btnCancel);
            driver.FindElement(btnCancel).Click();
        }
        //------------------------
        public string AddOpportunities(string type, string file, int row)
        {
            ReadJSONData.Generate("Admin_Data.json");
            string dir = ReadJSONData.data.filePaths.testData;
            string excelPath = dir + file;
            Console.WriteLine("path:" + excelPath);

            //--------------------------Enter Opportunity details-----------------------------
            //Information Section           
            WebDriverWaits.WaitUntilEleVisible(driver, txtOpportunityName, 40);
            string valOpportunity = CustomFunctions.RandomValue();// "abc" +CustomFunctions.RandomValue();

            driver.FindElement(txtOpportunityName).SendKeys(valOpportunity);
            //driver.FindElement(txtClient).SendKeys(ReadJSONData.data.addOpportunityDetails.client);            
            driver.FindElement(txtClient).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 1));
            driver.FindElement(txtSubject).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 2));
            WebDriverWaits.WaitUntilEleVisible(driver, comboJobType);
            driver.FindElement(comboJobType).SendKeys(type);
            driver.FindElement(comboIndustryGroup).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 4));
            driver.FindElement(comboSector).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 5));
            driver.FindElement(comboClientOwnership).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 18));
            driver.FindElement(comboSubjectOwnership).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 19));

            //Additional Client/Subject
            driver.FindElement(comboAdditionalClient).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 6));
            driver.FindElement(comboAdditionalSubject).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 7));

            //Referral Information
            driver.FindElement(comboReferralType).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 8));

            //Compliance Section
            driver.FindElement(comboNonPublicInfo).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 9));
            driver.FindElement(comboBeneficialOwner).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 10));

            //Administration Section
            driver.FindElement(comboPrimaryOffice).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 11));
            driver.FindElement(txtLegalEntity).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 12));
            driver.FindElement(comboDisclosureStatus).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 13));

            if (driver.FindElement(comboRecordType).Text.Contains("FR"))
            {
                driver.FindElement(txtTotalDebt).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 17));
                driver.FindElement(comboEMEAInitiatives).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 29));
                driver.FindElement(comboLegalAdvisor).SendKeys(ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", row, 31));
            }

            else if (driver.FindElement(comboRecordType).Text.Contains("FVA"))
            {
                driver.FindElement(txtFee).SendKeys("20000");
                driver.FindElement(txtTotalAntRev).SendKeys("30000");
            }
            else
            {
                Console.WriteLine("CF or SC types ");
            }
            //Click Save button
            driver.FindElement(btnSave).Click();
            return valOpportunity;
        }

        //Validate the values of Women Led field

        public bool VerifyWomenLedValues()
        {
            IReadOnlyCollection<IWebElement> valRecordTypes = driver.FindElements(comboWomenLed);
            var actualValue = valRecordTypes.Select(x => x.Text).ToArray();
            //string[] expectedValue = {"CF", "Conflicts Check", "FAS","FR", "HL Internal Opportunity", "OPP DEL","SC"};
            string[] expectedValue = { "--None--", "Yes", "No" };
            bool isSame = true;

            if (expectedValue.Length != actualValue.Length)
            {
                return !isSame;
            }
            for (int rec = 0; rec < expectedValue.Length; rec++)
            {
                if (!expectedValue[rec].Equals(actualValue[rec]))
                {
                    isSame = false;
                    break;
                }
            }
            return isSame;
        }

        public string AddOpportunitiesForFVA(string type, string file)
        {
            ReadJSONData.Generate("Admin_Data.json");
            string dir = ReadJSONData.data.filePaths.testData;
            string excelPath = dir + file;
            Console.WriteLine("path:" + excelPath);
            //--------------------------Enter Opportunity details-----------------------------	
            //Information Section           	
            WebDriverWaits.WaitUntilEleVisible(driver, txtOpportunityName, 40);
            string valOpportunity = CustomFunctions.RandomValue();
            driver.FindElement(txtOpportunityName).SendKeys(valOpportunity);
            //driver.FindElement(txtClient).SendKeys(ReadJSONData.data.addOpportunityDetails.client);            	
            driver.FindElement(txtClient).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 1));
            driver.FindElement(txtSubject).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 2));
            WebDriverWaits.WaitUntilEleVisible(driver, comboJobType, 80);
            driver.FindElement(comboJobType).SendKeys(type);
            driver.FindElement(comboIndustryGroup).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 4));
            driver.FindElement(comboSector).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 5));
            driver.FindElement(comboClientOwnership).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 18));
            driver.FindElement(comboSubjectOwnership).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 19));
            Console.WriteLine("Subject");
            //Additional Client/Subject	
            driver.FindElement(comboAdditionalClient).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 6));
            driver.FindElement(comboAdditionalSubject).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 7));
            //Referral Information	
            driver.FindElement(comboReferralType).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 8));
            //Compliance Section	
            driver.FindElement(comboNonPublicInfo).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 9));
            driver.FindElement(comboBeneficialOwner).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 10));
            Console.WriteLine("owner");
            //Administration Section	
            driver.FindElement(comboPrimaryOffice).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 11));
            driver.FindElement(txtLegalEntity).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 12));
            driver.FindElement(comboDisclosureStatus).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 13));
            if (driver.FindElement(comboRecordType).Text.Contains("FR"))
            {
                Console.WriteLine("in if");
                driver.FindElement(txtTotalDebt).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 17));
                driver.FindElement(comboEMEAInitiatives).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 29));
            }
            else if (driver.FindElement(comboRecordType).Text.Contains("FVA"))
            {
                Console.WriteLine("in else if");
                driver.FindElement(txtFee).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 17));
            }
            else
            {
                Console.WriteLine("CF types ");
            }
            //Click Save button	
            driver.FindElement(btnSave).Click();
            WebDriverWaits.WaitUntilEleVisible(driver, msgFee, 80);
            string message = driver.FindElement(msgFee).Text;
            driver.FindElement(txtFee).Clear();
            driver.FindElement(txtFee).SendKeys("10000");
            driver.FindElement(btnSave).Click();
            return message;
        }

        public string AddOpportunitiesLightning(string type, string file)
        {
            ReadJSONData.Generate("Admin_Data.json");
            string dir = ReadJSONData.data.filePaths.testData;
            string excelPath = dir + file;
            Console.WriteLine("path:" + excelPath);

            //--------------------------Enter Opportunity details-----------------------------
            //Information Section           
            WebDriverWaits.WaitUntilEleVisible(driver, txtOpportunityNameL, 240);
            string valOpportunity = CustomFunctions.RandomValue();

            driver.FindElement(txtOpportunityNameL).SendKeys(valOpportunity);
            driver.FindElement(txtClientL).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 1));
            driver.FindElement(txtClientL).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//lightning-base-combobox/div/div[2]/ul/li[1]/lightning-base-combobox-item/span[2]/span[2]/lightning-base-combobox-formatted-text")).Click();
            driver.FindElement(txtSubjectL).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 2));
            driver.FindElement(txtSubjectL).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//flexipage-field[3]/slot/record_flexipage-record-field/div/span/slot/records-record-layout-lookup/lightning-lookup/lightning-lookup-desktop/lightning-grouped-combobox/div[1]/div/lightning-base-combobox/div/div[2]/ul/li[1]/lightning-base-combobox-item/span[2]/span[2]/lightning-base-combobox-formatted-text")).Click();
            Thread.Sleep(4000);

            //Select IG
            string valIG = ReadExcelData.ReadData(excelPath, "AddOpportunity", 4);
            Thread.Sleep(3000); WebDriverWaits.WaitUntilEleVisible(driver, btnIGL, 180);
            driver.FindElement(btnIGL).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//flexipage-field[6]/slot/record_flexipage-record-field/div/span/slot/records-record-picklist/records-form-picklist/lightning-picklist/lightning-combobox/div[1]/lightning-base-combobox/div/div[2]/lightning-base-combobox-item/span[2]/span[text()='" + valIG + "']")).Click();

            //Select Job Type
            WebDriverWaits.WaitUntilEleVisible(driver, btnJobTypeL, 80);
            driver.FindElement(btnJobTypeL).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//lightning-combobox/div[1]/lightning-base-combobox/div/div[2]/lightning-base-combobox-item/span[2]/span[text()='" + type + "']")).Click();

            //Select sector
            string valSector = ReadExcelData.ReadData(excelPath, "AddOpportunity", 5);
            driver.FindElement(comboSectorL).SendKeys(ReadExcelData.ReadData(excelPath, "AddOpportunity", 5));
            driver.FindElement(By.XPath("//flexipage-field[7]/slot/record_flexipage-record-field/div/span/slot/records-record-picklist/records-form-picklist/lightning-picklist/lightning-combobox/div[1]/lightning-base-combobox/div/div[2]/lightning-base-combobox-item/span[2]/span[text()='" + valSector + "']")).Click();

            //Select Primary Office
            string valPO = ReadExcelData.ReadData(excelPath, "AddOpportunity", 11);
            driver.FindElement(comboPrimaryOfficeL).SendKeys(valPO);
            driver.FindElement(By.XPath("//flexipage-field[1]/slot/record_flexipage-record-field/div/span/slot/records-record-picklist/records-form-picklist/lightning-picklist/lightning-combobox/div[1]/lightning-base-combobox/div/div[2]/lightning-base-combobox-item/span[2]/span[text()='" + valPO + "']")).Click();

            //Select Legal Entity
            string valEntity = ReadExcelData.ReadData(excelPath, "AddOpportunity", 12);
            driver.FindElement(txtLegalEntitiesL).SendKeys(valEntity);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//flexipage-component2[3]/slot/flexipage-field-section2/div/div/div/laf-progressive-container/slot/div/slot/flexipage-column2[2]/div/slot/flexipage-field[1]/slot/record_flexipage-record-field/div/span/slot/records-record-layout-lookup/lightning-lookup/lightning-lookup-desktop/lightning-grouped-combobox/div[1]/div/lightning-base-combobox/div/div[2]")).Click();

            //Select Referral Type  
            string valRefType = ReadExcelData.ReadData(excelPath, "AddOpportunity", 8);
            driver.FindElement(comboRefTypeL).SendKeys(valRefType);
            driver.FindElement(By.XPath("//flexipage-component2[8]/slot/flexipage-field-section2/div/div/div/laf-progressive-container/slot/div/slot/flexipage-column2[1]/div/slot/flexipage-field[1]/slot/record_flexipage-record-field/div/span/slot/records-record-picklist/records-form-picklist/lightning-picklist/lightning-combobox/div[1]/lightning-base-combobox/div/div[2]/lightning-base-combobox-item/span[2]/span[text()='" + valRefType + "']")).Click();

            //Select Additional Client
            driver.FindElement(comboAddClientL).SendKeys("No");
            driver.FindElement(By.XPath("//flexipage-component2[9]/slot/flexipage-field-section2/div/div/div/laf-progressive-container/slot/div/slot/flexipage-column2[1]/div/slot/flexipage-field/slot/record_flexipage-record-field/div/span/slot/records-record-picklist/records-form-picklist/lightning-picklist/lightning-combobox/div/lightning-base-combobox/div/div[2]/lightning-base-combobox-item/span[2]/span[text()='No']")).Click();

            //Select Additional Subject
            driver.FindElement(comboAddSubjectL).SendKeys("No");
            driver.FindElement(By.XPath("//flexipage-component2[9]/slot/flexipage-field-section2/div/div/div/laf-progressive-container/slot/div/slot/flexipage-column2[2]/div/slot/flexipage-field/slot/record_flexipage-record-field/div/span/slot/records-record-picklist/records-form-picklist/lightning-picklist/lightning-combobox/div[1]/lightning-base-combobox/div/div[2]/lightning-base-combobox-item/span[2]/span[text()='No']")).Click();

            //Select Beneficial Owner
            string valBenOwner = ReadExcelData.ReadData(excelPath, "AddOpportunity", 10);
            driver.FindElement(comboBenOwnerL).SendKeys(valBenOwner);
            driver.FindElement(By.XPath("//flexipage-component2[10]/slot/flexipage-field-section2/div/div/div/laf-progressive-container/slot/div/slot/flexipage-column2[1]/div/slot/flexipage-field[1]/slot/record_flexipage-record-field/div/span/slot/records-record-picklist/records-form-picklist/lightning-picklist/lightning-combobox/div[1]/lightning-base-combobox/div/div[2]/lightning-base-combobox-item/span[2]/span[text()='" + valBenOwner + "']")).Click();

            //Select Does HL have material            
            driver.FindElement(comboHLMaterialL).SendKeys(valBenOwner);
            driver.FindElement(By.XPath("//flexipage-component2[10]/slot/flexipage-field-section2/div/div/div/laf-progressive-container/slot/div/slot/flexipage-column2[2]/div/slot/flexipage-field[1]/slot/record_flexipage-record-field/div/span/slot/records-record-picklist/records-form-picklist/lightning-picklist/lightning-combobox/div[1]/lightning-base-combobox/div/div[2]/lightning-base-combobox-item/span[2]/span[text()='" + valBenOwner + "']")).Click();

            //Select Conf Agreement
            string valConf = ReadExcelData.ReadData(excelPath, "AddOpportunity", 23);
            Thread.Sleep(4000);
            //driver.FindElement(btnConfAgreeL).Click();
            driver.FindElement(btnConfAgreeL).SendKeys(valConf);
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//lightning-combobox/div/lightning-base-combobox/div/div[2]/lightning-base-combobox-item/span[2]/span[text()='" + valConf + "']")).Click();

            //Click Save button                           
            driver.FindElement(btnSaveL).Click();

            //
            return valOpportunity;
        }

    }
}



