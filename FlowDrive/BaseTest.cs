using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest.Queries;

namespace FlowDrive
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            FlowDriveApp.StartApp();
            Func<AppQuery, AppQuery> iAgreeButtonQuery = (c => c.Marked("I Agree"));
            var iAgreeElement = FlowDriveApp.app.Query(iAgreeButtonQuery).Any();
            if (iAgreeElement)
            {
                FlowDriveApp.app.Tap(iAgreeButtonQuery);
            }
        }
    }
}
