namespace Stations.Services.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Abstractions;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Moq;
    using Repository.Abstractions;
    using System.Collections.Generic;
    using MockQueryable.Moq;

    [TestClass]
    public class SearchStationTests
    {
        private ILookupStationsService _lookupStationsService;

        private Mock<IRepository<Station>> _stationsRepository;

        [TestInitialize]
        public void Init()
        {
            _stationsRepository = new Mock<IRepository<Station>>();
        }

        [TestMethod]
        public async Task SearchTopContains_NamePartLowerCase_ReturnUpperCase()
        {
            // arrange
            var stations = new List<Station>
            {
                new Station("TestTest", "tst"),
                new Station("TEST_", "tst_"),
                new Station("Name", "nm"),
                new Station("XyZ", "xyz")
            };
            _stationsRepository.Setup(s => s.AsQueryable()).Returns(stations.AsQueryable().BuildMock().Object);
            _lookupStationsService = new LookupStationsService(_stationsRepository.Object);

            // act
            var foundStations = (await _lookupStationsService.GetByAnyNamePartAsync("test")).ToArray();

            // assert
            CollectionAssert.AllItemsAreUnique(foundStations);
            CollectionAssert.AllItemsAreNotNull(foundStations);
            CollectionAssert.AllItemsAreInstancesOfType(foundStations, typeof(Station));
            CollectionAssert.AreEqual(foundStations.Select(s => s.Name).ToArray(), new []{"TEST_", "TestTest"});
            Assert.IsTrue(foundStations.Length == 2);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _stationsRepository = null;
            _lookupStationsService = null;
        }
    }
}
