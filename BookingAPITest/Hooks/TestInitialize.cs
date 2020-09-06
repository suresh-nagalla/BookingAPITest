﻿using BookingAPITest.Base;
using System;
using System.Configuration;
using System.IO;
using TechTalk.SpecFlow;

namespace BookingAPITest.Hooks
{
   public class TestInitialize
    {
        private GlobalSettings _settings;
        public TestInitialize(GlobalSettings settings)
        {
            _settings = settings;
        }

        [BeforeScenario]
        public void TestSetup()
        {
            //_settings.BaseUrl = new Uri("https://restful-booker.herokuapp.com/");
            //_settings.httpClient.BaseAddress = _settings.BaseUrl;
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //string file = "ExtentReport.html";
            //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            ////Initialize Extent report before test starts
            //var htmlReporter = new ExtentHtmlReporter(path);
            //htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            ////Attach report to reporter
            //extent = new ExtentReports();
            //extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
           // extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //Create dynamic feature name
            //featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {

            //var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            //if (ScenarioContext.Current.TestError == null)
            //{
            //    if (stepType == "Given")
            //        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
            //    else if (stepType == "When")
            //        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
            //    else if (stepType == "Then")
            //        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
            //    else if (stepType == "And")
            //        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            //}
            //else if (ScenarioContext.Current.TestError != null)
            //{
            //    if (stepType == "Given")
            //        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
            //    else if (stepType == "When")
            //        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
            //    else if (stepType == "Then")
            //        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            //}
        }


        [BeforeScenario]
        public void Initialize()
        {
            //Create dynamic scenario name
            //scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }
    }
}
