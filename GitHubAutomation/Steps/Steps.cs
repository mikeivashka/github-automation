﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubAutomation.Configuration;

namespace GitHubAutomation.Steps
{
    public class Steps
    {
        IWebDriver driver = Driver.DriverInstance.GetInstance();

        public void LoginGithub(string username, string password)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.OpenPage();
            loginPage.Login(username, password);
        }

        public bool IsLoggedIn(string username)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            return (loginPage.GetLoggedInUserName().Trim().ToLower().Equals(username));
        }

        public bool CreateNewRepository(string repositoryName, string repositoryDescription)
        {
            bool success = false;
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickOnCreateNewRepositoryButton();
            Pages.CreateNewRepositoryPage createNewRepositoryPage = new Pages.CreateNewRepositoryPage(driver);
            string expectedRepoName = createNewRepositoryPage.CreateNewRepository(repositoryName, repositoryDescription);
            if (expectedRepoName.Equals(createNewRepositoryPage.GetCurrentRepositoryName()))
            {
                success = true;
            }
            return success;
        }

        public bool CurrentRepositoryIsEmpty()
        {
            Pages.CreateNewRepositoryPage createNewRepositoryPage = new Pages.CreateNewRepositoryPage(driver);
            return createNewRepositoryPage.IsCurrentRepositoryEmpty();
        }
    }
}
