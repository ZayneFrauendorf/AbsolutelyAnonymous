using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsolutelyAnonymousZF.Tests
{
    using AbsolutelyAnonymousZF.Data_Access;
    using AbsolutelyAnonymousZF.ViewModels;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class ListViewModelTests
    {
        ListViewModel systemUnderTest;

        private Mock<IQueryList> mockQueryList;

        [SetUp]
        public void SetUp()
        {
            this.mockQueryList = new Mock<IQueryList>(MockBehavior.Strict);
            this.systemUnderTest = new ListViewModel(this.mockQueryList.Object);
        }

        [Test]
        public void AllQueries_Always_PerformsExpectedWork()
        {
            var returnValue = new List<Query>();
            this.mockQueryList.Setup(p => p.GetAll()).Returns(returnValue);
            var x = this.systemUnderTest.AllQueries;
            this.mockQueryList.VerifyAll();
        }
    }
}
