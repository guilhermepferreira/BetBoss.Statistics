using Moq;
using BetBoss.Statistics.Domain.Adapters;
using BetBoss.Statistics.Domain.Models;
using MassTransit;
using BetBoss.Statisstics.Application;
using Xunit;

namespace BetBos.Statistics.Tests
{
    public class CountryServiceTests
    {
        private readonly Mock<IApiFooteballAdapter> apiFooteballAdapterMock;
        private readonly Mock<IContryDbAdapter> contryDbAdapterMock;
        private readonly Mock<IPublishEndpoint> publishEndpointMock;
        private readonly CountryService countryService;

        public CountryServiceTests()
        {
            apiFooteballAdapterMock = new Mock<IApiFooteballAdapter>();
            contryDbAdapterMock = new Mock<IContryDbAdapter>();
            publishEndpointMock = new Mock<IPublishEndpoint>();
            countryService = new CountryService(apiFooteballAdapterMock.Object, contryDbAdapterMock.Object, publishEndpointMock.Object);
        }

        [Fact]
        public async Task InsertNewCountries_ShouldInsertCountries()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country { Id = 1, Name = "Country1" },
                new Country { Id = 2, Name = "Country2" }
            };

            contryDbAdapterMock.Setup(x => x.InsertCountry(It.IsAny<Country>()))
                .Returns(Task.CompletedTask);

            // Act
            await countryService.InsertNewCountries(countries);

            // Assert
            foreach (var country in countries)
            {
                contryDbAdapterMock.Verify(x => x.InsertCountry(It.Is<Country>(c => c.Id == country.Id && c.Name == country.Name)), Times.Once);
            }
        }
    }
}
