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
    public class MonitorViewModelTests
    {
        private MonitorViewModel systemUnderTest;

        private Mock<IAdminList> mockAdminList;

        private Mock<ICourseList> mockCourseList;

        MockRepository mockRepository = new MockRepository(MockBehavior.Strict);

        [SetUp]
        public void SetUp()
        {
            //this.mockAdminList = this.mockRepository.Create<IAdminList>();
            //this.mockCourseList = this.mockRepository.Create<ICourseList>();
            //this.systemUnderTest = new MonitorViewModel(this.mockAdminList.Object, this.mockCourseList.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }


    }
}
