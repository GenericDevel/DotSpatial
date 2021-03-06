
using System.Collections.Generic;
using NUnit.Framework;

namespace DotSpatial.Projections.Tests.Projected
{
    /// <summary>
    /// This class contains all the tests for the GaussKrugerPulkovo1942 category of Projected coordinate systems
    /// </summary>
    [TestFixture]
    public class GaussKrugerPulkovo1942
    {
        [Test]
        [TestCaseSource("GetProjections")]
        public void GaussKrugerPulkovo1942ProjectedTests(ProjectionInfoDesc pInfo)
        {
            Tester.TestProjection(pInfo.ProjectionInfo);
            Assert.AreEqual(false, pInfo.ProjectionInfo.IsLatLon);
        }

        private static IEnumerable<ProjectionInfoDesc> GetProjections()
        {
            return ProjectionInfoDesc.GetForCoordinateSystemCategory(KnownCoordinateSystems.Projected.GaussKrugerPulkovo1942);
        }
    }
}