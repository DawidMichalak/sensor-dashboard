using Microsoft.Extensions.Caching.Memory;
using Moq;
using NUnit.Framework.Internal;
using sensor.Application.Contracts;
using sensor.Application.Contracts.Persistence;
using sensor.Application.Readings.Handlers;
using sensor.Application.Readings.Queries;
using sensor.Domain.Exceptions;

namespace UnitTests.Application.Handlers
{
    public class GetReadingsQueryHandlerTests
    {
        private GetReadingsQueryHandler _sut;
        private Mock<IReadingsRepository> _repositoryMock;

        [SetUp]
        public void SetUp()
        {
            var cache = new MemoryCache(new MemoryCacheOptions());
            _repositoryMock = new Mock<IReadingsRepository>();
            _sut = new GetReadingsQueryHandler(_repositoryMock.Object, cache);
        }

        [Test]
        public void Handle_WhenBeginDateGreaterThanEndDate_ThrowsException()
        {
            var request = new GetReadingsQuery
            {
                BeginDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2021, 1, 1)
            };

            Assert.ThrowsAsync<InvalidDateRangeException>(async () => await _sut.Handle(request, CancellationToken.None));
        }

        [Test]
        public async Task Handle_WhenBeginDateLessThanEndDate_ReturnsReadingsDtoList()
        {
            var request = new GetReadingsQuery
            {
                BeginDate = new DateTime(2021, 1, 1),
                EndDate = new DateTime(2022, 1, 1)
            };

            var readings = new List<ReadingsDto>
            {
                new ReadingsDto(),
            };

            _repositoryMock.Setup(x => x.GetAllReadingsAsync(request.BeginDate, request.EndDate))
                .ReturnsAsync(readings);

            var result = await _sut.Handle(request, CancellationToken.None);

            Assert.That(result, Is.EqualTo(readings));
        }
    }
}
