﻿using NUnit.Framework;
using SF_Automation.Pages;
using SF_Automation.Pages.Common;
using SF_Automation.Pages.Opportunity;
using SF_Automation.TestData;
using SF_Automation.UtilityFunctions;
using System;
using System.Globalization;

namespace SF_Automation.TestCases.Opportunity
{
    class TMTT0013767_TMTT0013772_TMTT0014070_TMTT0014796_NBCFormLightening_HeadersAndReqFields_SubmitforReview_EmailTemplate_DateSubmitted : BaseClass
    {
        ExtentReport extentReports = new ExtentReport();
        LoginPage login = new LoginPage();
        OpportunityHomePage opportunityHome = new OpportunityHomePage();
        AddOpportunityPage addOpportunity = new AddOpportunityPage();
        UsersLogin usersLogin = new UsersLogin();
        OpportunityDetailsPage opportunityDetails = new OpportunityDetailsPage();
        NBCForm form = new NBCForm();
        CNBCForm cnbc = new CNBCForm();
        AdditionalClientSubjectsPage clientSubjectsPage = new AdditionalClientSubjectsPage();

        public static string fileTC1232 = "T1232_NBCFormSubmitforReview.xlsx";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Initialize();
            ExtentReportHelper();
            ReadJSONData.Generate("Admin_Data.json");
            extentReports.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [Test]
        public void NBCFormSubmitforReview()
        {
            try
            {
                //Get path of Test data file
                string excelPath = ReadJSONData.data.filePaths.testData + fileTC1232;
                Console.WriteLine(excelPath);

                //Validating Title of Login Page
                Assert.AreEqual(WebDriverWaits.TitleContains(driver, "Login | Salesforce"), true);
                extentReports.CreateLog(driver.Title + " is displayed ");

                // Calling Login function                
                login.LoginApplication();

                // Validate user logged in                   
                Assert.AreEqual(login.ValidateUser().Equals(ReadJSONData.data.authentication.loggedUser), true);
                extentReports.CreateLog("User " + login.ValidateUser() + " is able to login ");

                //Login as Standard User and validate the user
                string valUser = ReadExcelData.ReadData(excelPath, "Users", 1);
                usersLogin.SearchUserAndLogin(valUser);
                string stdUser = login.ValidateUser();
                Assert.AreEqual(stdUser.Contains(valUser), true);
                extentReports.CreateLog("User: " + stdUser + " logged in ");

                //Call function to open Add Opportunity Page
                opportunityHome.ClickOpportunity();
                string valRecordType = ReadExcelData.ReadData(excelPath, "AddOpportunity", 25);
                Console.WriteLine("valRecordType:" + valRecordType);
                opportunityHome.SelectLOBAndClickContinue(valRecordType);

                //Validating Title of New Opportunity Page
                Assert.AreEqual(WebDriverWaits.TitleContains(driver, "Opportunity Edit: New Opportunity ~ Salesforce - Unlimited Edition", 60), true);
                extentReports.CreateLog(driver.Title + " is displayed ");

                //Calling AddOpportunities function                
                string valJobType = ReadExcelData.ReadDataMultipleRows(excelPath, "AddOpportunity", 2, 3);
                string value = addOpportunity.AddOpportunities(valJobType, fileTC1232);
                Console.WriteLine("value : " + value);

                //Call function to enter Internal Team details and validate Opportunity detail page
                clientSubjectsPage.EnterStaffDetails(fileTC1232);
                Assert.AreEqual(WebDriverWaits.TitleContains(driver, "Opportunity: " + value + " ~ Salesforce - Unlimited Edition"), true);
                extentReports.CreateLog(driver.Title + " is displayed ");

                //Validating Opportunity details page 
                string opportunityNumber = opportunityDetails.ValidateOpportunityDetails();
                Assert.IsNotNull(opportunityDetails.ValidateOpportunityDetails());
                extentReports.CreateLog("Opportunity with number : " + opportunityDetails.ValidateOpportunityDetails() + " is created ");

                //Fetch values of Opportunity Name, Client, Subject and Job Type
                string oppNum = opportunityDetails.GetOppNumber();
                string clientName = opportunityDetails.GetClient();
                string clientOwnership = opportunityDetails.GetClientOwnership();
                string subjectName = opportunityDetails.GetSubject();
                string subjectOwnership = opportunityDetails.GetSubjectOwnership();
                string jobType = opportunityDetails.GetJobType();
                string IG = opportunityDetails.GetIG();
                Console.WriteLine(jobType);

                //Call function to update HL -Internal Team details
                opportunityDetails.UpdateInternalTeamDetails(fileTC1232);

                //Logout of user and validate Admin login
                usersLogin.UserLogOut();
                Assert.AreEqual(login.ValidateUser().Equals(ReadJSONData.data.authentication.loggedUser), true);
                extentReports.CreateLog("User " + login.ValidateUser() + " is able to login ");

                //Search for created opportunity
                opportunityHome.SearchOpportunity(value);

                //update CC and NBC checkboxes 
                opportunityDetails.UpdateOutcomeDetails(fileTC1232);
                opportunityDetails.UpdateCCOnly();
                opportunityDetails.UpdatePitchDate();

                //Login as Standard User and validate the user
                usersLogin.SearchUserAndLogin(valUser);
                string stdUser1 = login.ValidateUser();
                Assert.AreEqual(stdUser1.Contains(valUser), true);
                extentReports.CreateLog("User: " + stdUser1 + " logged in ");

                //Search for created opportunity
                opportunityHome.SearchOpportunity(value);

                //Click on NBC page and validate title of page
                string title = opportunityDetails.ClickNBCFormL();
                Assert.AreEqual("Public Sensitivity", title);
                extentReports.CreateLog("NBC Form page is displayed with default tab : " + title + " ");

                //Validate pre populated fields on NBC form
                string oppNBC = form.ValidateOppName();
                Assert.AreEqual(oppNum, oppNBC);
                extentReports.CreateLog("Opportunity Name: " + oppNBC + " in NBC form matches with Opportunity details page ");

                string clientComp = form.ValidateClientCompanyHeader();
                Assert.AreEqual("Client Company", clientComp);
                extentReports.CreateLog("Field with name " + clientComp + " is displayed on the header of NBC page ");

                string clientOwner = form.ValidateClientOwnershipHeader();
                Assert.AreEqual("Client Ownership", clientOwner);
                extentReports.CreateLog("Field with name " + clientOwner + " is displayed on the header of NBC page ");

                string subComp = form.ValidateSubjectCompanyHeader();
                Assert.AreEqual("Subject Company", subComp);
                extentReports.CreateLog("Field with name " + subComp + " is displayed on the header of NBC page ");

                string subOwner = form.ValidateSubjectOwnershipHeader();
                Assert.AreEqual("Subject Ownership", subOwner);
                extentReports.CreateLog("Field with name " + subOwner + " is displayed on the header of NBC page ");

                string jobTypeHeader = form.ValidateJobTypeHeader();
                Assert.AreEqual("Job Type", jobTypeHeader);
                extentReports.CreateLog("Field with name " + jobTypeHeader + " is displayed on the header of NBC page ");

                string indGroup = form.ValidateIGHeader();
                Assert.AreEqual("Primary Industry Group", indGroup);
                extentReports.CreateLog("Field with name " + indGroup + " is displayed on the header of NBC page ");

                string clientNBC = form.ValidateClient();
                Assert.AreEqual(clientName, clientNBC);
                extentReports.CreateLog("Client Company: " + clientNBC + " in NBC form matches with Opportunity details page ");

                string valClientOwner = form.ValidateClientOwnership();
                Assert.AreEqual(clientOwnership, valClientOwner);
                extentReports.CreateLog("Client Ownership: " + valClientOwner + " in NBC form matches with Opportunity details page ");

                string subjectNBC = form.ValidateSubject();
                Assert.AreEqual(subjectName, subjectNBC);
                extentReports.CreateLog("Subject Company: " + subjectNBC + " in NBC form matches with Opportunity details page ");

                string valSubjectOwner= form.ValidateSubjectOwnership();
                Assert.AreEqual(subjectOwnership, valSubjectOwner);
                extentReports.CreateLog("Subject Ownership: " + valSubjectOwner + " in NBC form matches with Opportunity details page ");

                string jobTypeNBC = form.ValidateJobType();
                Assert.AreEqual(jobType, jobTypeNBC);
                extentReports.CreateLog("Job Type: " + jobTypeNBC + " in NBC form matches with Opportunity details page ");

                string valIG = form.ValidateIG();
                Assert.AreEqual(IG, valIG);
                extentReports.CreateLog("Job Type: " + valIG + " in NBC form matches with Opportunity details page ");
                
                //Select the Review Submission button
                form.ClickReviewSubmission();

                //Validate mandatory validations for Opportunity Overview tab 
                string txtOppOverview = form.ClickOpportunityOverview();
                Assert.AreEqual("Opportunity Overview", txtOppOverview);
                extentReports.CreateLog("Tab with name " + txtOppOverview + " is displayed upon clicking the tab. ");

                string actTransOverValidation = form.GetFieldsValidationsOfOppOverview();
                Console.WriteLine(actTransOverValidation);
                string expTransOverValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 1);
                Assert.AreEqual(expTransOverValidation, actTransOverValidation);
                extentReports.CreateLog("Validation: " + actTransOverValidation + " is displayed for Transaction Overview field ");

                string actTotalDebt = form.GetValidationOfTotalDebt();
                Console.WriteLine(actTotalDebt);
                string expTotalDebtVal = ReadExcelData.ReadData(excelPath, "NBCForm", 33);
                Assert.AreEqual(expTotalDebtVal, actTotalDebt);
                extentReports.CreateLog("Validation: " + actTotalDebt + " is displayed for Total Debt field ");

                string actEstVal = form.GetValidationOfEstVal();
                Console.WriteLine(actEstVal);
                string expEstVal = ReadExcelData.ReadData(excelPath, "NBCForm", 34);
                Assert.AreEqual(expEstVal, actEstVal);
                extentReports.CreateLog("Validation: " + actEstVal + " is displayed for Estimated Valuation field ");

                string actCurrentStatusVal = form.GetValidationOfCurrentStatus();
                Console.WriteLine(actCurrentStatusVal);
                string expCurrentStatusVal = ReadExcelData.ReadData(excelPath, "NBCForm", 35);
                Assert.AreEqual(expCurrentStatusVal, actCurrentStatusVal);
                extentReports.CreateLog("Validation: " + actCurrentStatusVal + " is displayed for Current Status field ");

                string actValuationExpVal = form.GetValidationOfValuationExp();
                string expValuationExpVal = ReadExcelData.ReadData(excelPath, "NBCForm", 36);
                Assert.AreEqual(expValuationExpVal, actValuationExpVal);
                extentReports.CreateLog("Validation: " + actValuationExpVal + " is displayed for Valuation Expectations field ");

                string actCompanyDescVal = form.GetValidationOfCompDesc();
                string expCompanyDescVal = ReadExcelData.ReadData(excelPath, "NBCForm", 37);
                Assert.AreEqual(expCompanyDescVal, actCompanyDescVal);
                extentReports.CreateLog("Validation: " + actCompanyDescVal + " is displayed for Company Description field ");

                string actRealEstateVal = form.GetValidationOfRealEstateAngle();
                string expRealEstateVal = ReadExcelData.ReadData(excelPath, "NBCForm", 38);
                Assert.AreEqual(expRealEstateVal, actRealEstateVal);
                extentReports.CreateLog("Validation: " + actRealEstateVal + " is displayed for Real Estate Angle field ");

                string actOwnershipVal = form.GetValidationOfOwnershipAndCapStr();
                string expOwnershipVal = ReadExcelData.ReadData(excelPath, "NBCForm", 39);
                Assert.AreEqual(expOwnershipVal, actOwnershipVal);
                extentReports.CreateLog("Validation: " + actOwnershipVal + " is displayed for Ownership and Capital Structure field ");

                string actAsiaAngleVal = form.GetValidationOfAsiaAngle();
                string expAsiaAngleVal = ReadExcelData.ReadData(excelPath, "NBCForm", 40);
                Assert.AreEqual(expAsiaAngleVal, actAsiaAngleVal);
                extentReports.CreateLog("Validation: " + actAsiaAngleVal + " is displayed for Asia Angle field ");

                string actRiskFactVal = form.GetValidationOfRiskFactors();
                string expRiskFactVal = ReadExcelData.ReadData(excelPath, "NBCForm", 41);
                Assert.AreEqual(expRiskFactVal, actRiskFactVal);
                extentReports.CreateLog("Validation: " + actRiskFactVal + " is displayed for Risk Factors field ");

                string actIntAngleVal = form.GetValidationOfInternationalAngle();
                string expIntAngleVal = ReadExcelData.ReadData(excelPath, "NBCForm", 42);
                Assert.AreEqual(expIntAngleVal, actIntAngleVal);
                extentReports.CreateLog("Validation: " + actIntAngleVal + " is displayed for International Angle field ");

                //Click Financials tab and validate its mandatory validations 
                string txtFinancials = form.ClickFinancialsTab();
                Assert.AreEqual("Financials", txtFinancials);
                extentReports.CreateLog("Tab with name " + txtFinancials + " is displayed upon clicking Financials tab. ");

                string actCapMktValidation = form.GetValidationOfCapMarketConsulted();
                string expCapMktValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 43);
                Assert.AreEqual(expCapMktValidation, actCapMktValidation);
                extentReports.CreateLog("Validation: " + actCapMktValidation + " is displayed for Capital Markets Consulted field ");

                string actExistingFinValidation = form.GetValidationOfExistingFin();
                string expExistingFinValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 44);
                Assert.AreEqual(expExistingFinValidation, actExistingFinValidation);
                extentReports.CreateLog("Validation: " + actExistingFinValidation + " is displayed for Existing Financial Arrangement Notes field ");

                string actFinSubjectValidation = form.GetValidationOfFinancialsSubject();
                string expFinSubjectValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 45);
                Assert.AreEqual(expFinSubjectValidation, actFinSubjectValidation);
                extentReports.CreateLog("Validation: " + actFinSubjectValidation + " is displayed for Financials Subject to Audit field ");

                string actNoFinValidation = form.GetValidationOfNoFinancials();
                string expNoFinValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 46);
                Assert.AreEqual(expNoFinValidation, actNoFinValidation);
                extentReports.CreateLog("Validation: " + actNoFinValidation + " is displayed for No Financials field ");

                //Click Fees tab and validate its mandatory validations 
                string txtFees = form.ClickFeesTab();
                Assert.AreEqual("Fees", txtFees);
                extentReports.CreateLog("Tab with name " + txtFees + " is displayed upon clicking Fees tab. ");

                string actRetainerValidation = form.GetValidationOfRetainer();
                string expRetainerValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 47);
                Assert.AreEqual(expRetainerValidation, actRetainerValidation);
                extentReports.CreateLog("Validation: " + actRetainerValidation + " is displayed for Retainer field ");

                string actRetainerFeeValidation = form.GetValidationOfRetainerFee();
                string expRetainerFeeValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 48);
                Assert.AreEqual(expRetainerFeeValidation, actRetainerFeeValidation);
                extentReports.CreateLog("Validation: " + actRetainerFeeValidation + " is displayed for Retainer Fee field ");

                string actProgressFeeValidation = form.GetValidationOfProgressFee();
                string expProgressFeeValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 49);
                Assert.AreEqual(expProgressFeeValidation, actProgressFeeValidation);
                extentReports.CreateLog("Validation: " + actProgressFeeValidation + " is displayed for Progress Fee field ");

                string actMinFeeValidation = form.GetValidationOfMinimumFee();
                string expMinFeeValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 64);
                Assert.AreEqual("Fees: Estimated Fee (MM) should not be 0 and greater than 100 MM", actMinFeeValidation);
                extentReports.CreateLog("Validation: " + actMinFeeValidation + " is displayed for Minimum Fee (MM) field ");

                //string actTxnFeeValidation = form.GetValidationOfTxnFee();
                //string expTxnFeeValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 50);
                //Assert.AreEqual(expTxnFeeValidation, actTxnFeeValidation);
                //extentReports.CreateLog("Validation: " + actTxnFeeValidation + " is displayed for Transaction Fee field ");

                string actTxnValueValidation = form.GetValidationOfEstTxnValue();
                string expTxnValueValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 65);
                Assert.AreEqual("Estimated Transaction Value (MM ) should be greater than 0", actTxnValueValidation);
                extentReports.CreateLog("Validation: " + actTxnValueValidation + " is displayed for Estimated Transaction Value (MM) field ");
                                
                //Click Pitch tab and validate its mandatory validations 
                string txtPitch = form.ClickPitchTab();
                Assert.AreEqual("Pitch", txtPitch);
                extentReports.CreateLog("Tab with name " + txtPitch + " is displayed upon clicking Pitch tab. ");

                string actPitchValidation = form.GetValidationOfPitch();
                string expPitchValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 51);
                Assert.AreEqual(expPitchValidation, actPitchValidation);
                extentReports.CreateLog("Validation: " + actPitchValidation + " is displayed for Will There Be a Pitch? field ");

                string actHLCompValidation = form.GetValidationOfHLComp();
                string expHLCompValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 52);
                Assert.AreEqual(expHLCompValidation, actHLCompValidation);
                extentReports.CreateLog("Validation: " + actHLCompValidation + " is displayed for HL Competition field ");

                string actLockupsValidation = form.GetValidationOfLockups();
                string expLockupsValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 53);
                Assert.AreEqual(expLockupsValidation, actLockupsValidation);
                extentReports.CreateLog("Validation: " + actLockupsValidation + " is displayed for Lockups on Future M&A on Financing work field ");

                string actExistingRelValidation = form.GetValidationOfExistingRel();
                string expExistingRelValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 54);
                Assert.AreEqual(expExistingRelValidation, actExistingRelValidation);
                extentReports.CreateLog("Validation: " + actExistingRelValidation + " is displayed for Existing Relationships field ");

                string actExistingOrRepeatValidation = form.GetValidationOfExistingOrRepeatClient();
                string expExistingOrRepeatValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 55);
                Assert.AreEqual(expExistingOrRepeatValidation, actExistingOrRepeatValidation);
                extentReports.CreateLog("Validation: " + actExistingOrRepeatValidation + " is displayed for Existing or Repeat Client? field ");

                string actTASValidation = form.GetValidationOfTASBridgeAssist();
                string expTASValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 56);
                Assert.AreEqual(expTASValidation, actTASValidation);
                extentReports.CreateLog("Validation: " + actTASValidation + " is displayed for TAS/Bridge Assistance Benefit? field ");

                string actOutsideValidation = form.GetValidationOfOutsideCouncil();
                string expOutsideValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 57);
                Assert.AreEqual(expOutsideValidation, actOutsideValidation);
                extentReports.CreateLog("Validation: " + actOutsideValidation + " is displayed for Outside Council field ");

                //Click Fairness/Admin Checklist tab and validate its mandatory validations 
                string txtFairness = form.ClickFairnessAdminChecklistTab();
                Assert.AreEqual("Fairness/Admin Checklist", txtFairness);
                extentReports.CreateLog("Tab with name " + txtFairness + " is displayed upon clicking Fairness/Admin Checklist tab. ");

                string actFairnessOpinionValidation = form.GetValidationOfFairnessOpinion();
                string expFairnessOpinionValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 58);
                Assert.AreEqual(expFairnessOpinionValidation, actFairnessOpinionValidation);
                extentReports.CreateLog("Validation: " + actFairnessOpinionValidation + " is displayed for Fairness Opinion Provided field ");

                //Click Public Sensitivity tab and validate its mandatory validations 
                string txtPublic = form.ClickPublicSensitivityTab();
                Assert.AreEqual("Public Sensitivity", txtPublic);
                extentReports.CreateLog("Tab with name " + txtPublic + " is displayed upon clicking Public Sensitivity tab. ");

                string actAValidation = form.GetValidationOfA();
                string expAValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 59);
                Assert.AreEqual(expAValidation, actAValidation);
                extentReports.CreateLog("Validation: " + actAValidation + " is displayed for A field ");

                string actBValidation = form.GetValidationOfB();
                string expBValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 60);
                Assert.AreEqual(expBValidation, actBValidation);
                extentReports.CreateLog("Validation: " + actBValidation + " is displayed for B field ");

                string actCValidation = form.GetValidationOfC();
                string expCValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 61);
                Assert.AreEqual(expCValidation, actCValidation);
                extentReports.CreateLog("Validation: " + actCValidation + " is displayed for C field ");

                string actDValidation = form.GetValidationOfD();
                string expDValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 62);
                Assert.AreEqual(expDValidation, actDValidation);
                extentReports.CreateLog("Validation: " + actCValidation + " is displayed for D field ");

                string actGroupValidation = form.GetValidationOfGroupHeadApproval();
                string expGroupValidation = ReadExcelData.ReadData(excelPath, "NBCForm", 63);
                Assert.AreEqual(expGroupValidation, actGroupValidation);
                extentReports.CreateLog("Validation: " + actGroupValidation + " is displayed for Group Head Approval field ");

                //Save all the mandatory fields details in all tabs.
                form.ClickOpportunityOverview();
                form.SaveAllReqFieldsInOppOverview(fileTC1232);

                form.ClickFinancialsTab();
                form.SaveAllReqFieldsInFinancialsOverview(fileTC1232);

                form.ClickFeesTab();
                form.SaveAllReqFieldsInFees(fileTC1232);

                form.ClickPitchTab();
                form.SaveAllReqFieldsInPitch(fileTC1232);

                form.ClickFairnessAdminChecklistTab();
                form.SaveAllReqFieldsInFairnessAdminChecklist(fileTC1232);

                form.ClickPublicSensitivityTab();
                form.SaveAllReqFieldsInPublicSenstivity(fileTC1232);

                form.UpdateReviewSubmissionAndUpdateReferralFee();
                extentReports.CreateLog("All mandatory values are saved ");
                form.ClickFairnessAdminChecklistTab();
                string txtAdmin = form.ClickAdministrativeTab();
                Assert.AreEqual("Administrative", txtAdmin);
                extentReports.CreateLog("Tab with name " + txtAdmin + " is displayed upon clicking the Administrative tab. ");

                form.UpdateAdministrativeTab(fileTC1232);

                //Validate title of Email Template page
                string pageTitle = form.ClickSubmitButton();              
                Assert.AreEqual("Send Email", pageTitle);
                extentReports.CreateLog(pageTitle + " page is displayed upon clicking Submit for Review ");

                //Validate Opportunity Name in Email and navigate to Opportunity details page
                string emailOppName = form.GetOpportunityName();
                Assert.AreEqual(value, emailOppName);
                extentReports.CreateLog(" Email Template with Opportunity " + emailOppName + " is displayed ");
                           
                form.SwitchFrame();
                usersLogin.UserLogOut();
                //Login as CAO User i.e., Brian Miller                
                string valCAOUser = ReadExcelData.ReadData(excelPath, "Users", 2);
                usersLogin.SearchUserAndLogin(valCAOUser);
                string caoUser = login.ValidateUser();
                Assert.AreEqual(caoUser.Contains(valCAOUser), true);
                extentReports.CreateLog("User: " + caoUser + " logged in ");

                //Search for the same Opportunity                
                opportunityHome.SearchOpportunity(value);
                opportunityDetails.ClickNBCFormL();

                //Click on reveiew tab and Get Date Submitted value                
                string tabName = form.ClickReviewTab();
                Assert.AreEqual("Review", tabName);
                extentReports.CreateLog("Tab with name: " + tabName + " is displayed upon clicking Review tab ");

                string date = form.GetDateSubmitted();
                Console.WriteLine(DateTime.Now.ToString("M/d/yyyy", CultureInfo.InvariantCulture));
                Assert.AreEqual(DateTime.Now.ToString("M/d/yyyy", CultureInfo.InvariantCulture), date);
                extentReports.CreateLog("Date Submitted with value: " + date + " is displayed ");
               
                //Validate Submit for Review button before approval
                string submit = form.ValidateSubmitForReviewButton();
                Assert.AreEqual("Submit for Review button is displayed", submit);
                extentReports.CreateLog(submit + " for CAO user before approval ");                
               
                //Update Grade and validate the same
                string grade = form.UpdateGrade();
                Assert.AreEqual("A+", grade);
                extentReports.CreateLog("Grade with value: " + grade + " is updated ");

                //Validate Submit for Review button before approval
                string submit1 = form.ValidateSubmitForReviewButton();
                Assert.AreEqual("Submit for Review button is not displayed", submit1);
                extentReports.CreateLog(submit1 + " for CAO user after approval ");
                form.SwitchFrame();
                usersLogin.UserLogOut();

                //Login as Admin and validate NBC Approved checkbox
                //Search for the same Opportunity                
                opportunityHome.SearchOpportunity(value);
                string check = opportunityDetails.ValidateNBCApprovedCheckbox();
                Assert.AreEqual("NBC Approved checkbox is checked", check);
                extentReports.CreateLog(check + " after approving NBC Form ");

                usersLogin.UserLogOut();
                driver.Quit();                        
             
        }
            catch (Exception e)
            {
                extentReports.CreateLog(e.Message);
                usersLogin.UserLogOut();
                usersLogin.UserLogOut();
                driver.Quit();
            }                
    }
}
}

    

