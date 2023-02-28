using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriverBasics.WebDriver;
using SeleniumWebDriverBasics.WebObjects;
using static System.Net.WebRequestMethods;

namespace SeleniumWebDriverBasics.Tests
{
    [TestFixture]
    public class YandexUnitTests : BaseTest
    {
        private readonly LoginPage loginPage = new LoginPage();
        private readonly EmailPage emailPage = new EmailPage();

        [Test]
        public void GetLoggedInToYandex()
        {
            //Act
            var actualAccountName = emailPage.GetActualUserName();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedAccountName, actualAccountName);
        }

        [Test]
        public void DraftEmailIsPresentInDraftFolder()
        {
            //Act
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.SaveEmailToDraftFolder();

            var actualSubject = emailPage.GetActualSubject();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
        }

        [Test]
        public void GetSubjectAddresseeBodyFromDraftEmail()
        {
            //Act
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.SaveEmailToDraftFolder();

            var actualAddressee = emailPage.GetActualAddressee();
            var actualSubject = emailPage.GetActualSubject();
            var actualMessageBody = emailPage.GetActualMessageBody();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
            Assert.AreEqual(ExpectedResults.expectedAddressee, actualAddressee);
            Assert.AreEqual(ExpectedResults.expectedMessageBody, actualMessageBody);
        }

        [Test]
        public void SentDraftEmailIsPresentInSentFolder()
        {
            //Act
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.SaveEmailToDraftFolder();
            emailPage.GoToDraftEmails();
            emailPage.SendDraftEmail();

            var actualSubject = emailPage.GetActualSubject();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
        }

        [Test]
        public void SentNewEmailIsPresentInSentFolder()
        {
            //Act
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.SendCreatedEmail();

            var actualSubject = emailPage.GetActualSubject();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
        }

        [Test]
        public void SentEmailIsNotPresentInDraftFolder()
        {
            //Act
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.SendCreatedEmail();
            emailPage.GoToDraftEmails();

            var actualDraftInfoMessage = emailPage.GetActualDraftInfoMessage();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedDraftInfoMessage, actualDraftInfoMessage);
        }

        [Test]
        public void SentEmailIsNotPresentInTrashFolder()
        {
            //Act
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.SendCreatedEmail();
            emailPage.GoToTrashEmails();

            var actualTrashInfoMessage = emailPage.GetActualTrashInfoMessage();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedTrashInfoMessage, actualTrashInfoMessage);
        }

        [Test]
        public void DeletedEmailIsNotPresentInDrafts()
        {
            //Act
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.SaveEmailToDraftFolder();
            emailPage.GoToDraftEmails();
            emailPage.DeleteAllEmails();

            var actualDraftInfoMessage = emailPage.GetActualDraftInfoMessage();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedDraftInfoMessage, actualDraftInfoMessage);
        }

        [Test]
        public void DeletedEmailIsNotPresentInTrash()
        {
            //Act
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.SaveEmailToDraftFolder();
            emailPage.GoToDraftEmails();
            emailPage.DeleteAllEmails();
            emailPage.GoToTrashEmails();
            emailPage.DeleteAllEmails();

            var actualTrashInfoMessage = emailPage.GetActualTrashInfoMessage();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedTrashInfoMessage, actualTrashInfoMessage);
        }

        [Test]
        public void GetLoggedOutFromYandex()
        {
            //Act
            emailPage.GoToSignOutForm();

            var actualTitleAfterLogout = loginPage.GetActualLoginMessage(); ;

            //Assert
            Assert.AreEqual(ExpectedResults.expectedTitleAfterLogout, actualTitleAfterLogout);
        }

        [Test]
        public void DeletionEmailWithDragAndDrop()
        {
            //Act
            emailPage.CreateEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.SaveEmailToDraftFolder();
            emailPage.GoToDraftEmails();
            emailPage.MoveDraftEmailToTrashFolder();
            emailPage.GoToTrashFolder();

            var actualSubject = emailPage.GetActualSubject();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
        }
    }
}
