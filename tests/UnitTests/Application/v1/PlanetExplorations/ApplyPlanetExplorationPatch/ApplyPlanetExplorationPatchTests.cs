using Application.Interfaces;
using Application.v1.PlanetExplorations.ApplyPlanetExplorationPatchRequest;
using Domain.Entities;
using Domain.Exceptions;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Serialization;
using System.Net;
using UnitTests.Common;

namespace UnitTests.Application.v1.PlanetExplorations.ApplyPlanetExplorationPatch
{
    [TestClass]
    public class ApplyPlanetExplorationPatchTests
    {
        private readonly IXPandDataProvider dataProvider;
        private readonly ApplyPlanetExplorationPatchRequestHandler handler;

        public ApplyPlanetExplorationPatchTests()
        {
            var database = new Database();
            dataProvider = database.Context;
            handler = new ApplyPlanetExplorationPatchRequestHandler(dataProvider);
        }

        [TestMethod]
        public async Task Given_ValidApplyPlanetExplorationPatchRequest_When_HandlerIsCalled_Then_ReturnPlanetExploration()
        {
            // Arrange
            var request = new ApplyPlanetExplorationPatchRequest
            {
                PlanetExplorationId = 1,
                PatchDocument = new JsonPatchDocument<PlanetExploration>(
                    new List<Operation<PlanetExploration>>
                    {
                        new Operation<PlanetExploration>("replace", "/planetExplorationStatusId", null, Domain.Entities.Common.Enums.PlanetExplorationStatus.NotOk),
                        new Operation<PlanetExploration>("replace", "/observations", null, "Observations updated")
                    },
                    new DefaultContractResolver()
                ),
                UpdatedBy = "google-oauth2|102590899082590583530"
            };

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Should().NotBeNull();
            result.PlanetExplorationId.Should().Be(1);
        }

        [TestMethod]
        public async Task Given_ApplyPlanetExplorationPatchRequestWithUpdatedByDifferentThanPlanetExplorationCaptainId_When_HandlerIsCalled_Then_ThrowApiErrorExceptionWithForbiddenStatus()
        {
            // Arrange
            var request = new ApplyPlanetExplorationPatchRequest
            {
                PlanetExplorationId = 1,
                PatchDocument = new JsonPatchDocument<PlanetExploration>(
                    new List<Operation<PlanetExploration>>
                    {
                        new Operation<PlanetExploration>("replace", "/planetExplorationStatusId", null, Domain.Entities.Common.Enums.PlanetExplorationStatus.NotOk),
                        new Operation<PlanetExploration>("replace", "/observations", null, "Observations updated")
                    },
                    new DefaultContractResolver()
                ),
                UpdatedBy = "invalid/unauthorized user id"
            };

            // Act
            var act = () => handler.Handle(request, default);

            // Assert
            await act.Should().ThrowAsync<ApiErrorException>()
                .Where(e => e.StatusCode == HttpStatusCode.Forbidden);
        }

        [DataTestMethod]
        [DataRow("/invalidPath", "invalid-value")]
        [DataRow("/planetExplorationStatusId", "invalid-value")]
        public async Task Given_ApplyPlanetExplorationPatchRequestWithInvalidPatchDocument_When_HandlerIsCalled_Then_ThrowApiErrorExceptionWithBadRequestStatus(string path, string value)
        {
            // Arrange
            var request = new ApplyPlanetExplorationPatchRequest
            {
                PlanetExplorationId = 1,
                PatchDocument = new JsonPatchDocument<PlanetExploration>(
                    new List<Operation<PlanetExploration>>
                    {
                        new Operation<PlanetExploration>("replace", path, null, value)
                    },
                    new DefaultContractResolver()
                ),
                UpdatedBy = "google-oauth2|102590899082590583530"
            };

            // Act
            var act = () => handler.Handle(request, default);

            // Assert
            await act.Should().ThrowAsync<ApiErrorException>()
                .Where(e => e.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task Given_ApplyPlanetExplorationPatchRequestWithInvalidPatchDocument_When_HandlerIsCalled_Then_ThrowApiErrorExceptionWithBadRequestStatus()
        {
            // Arrange
            var request = new ApplyPlanetExplorationPatchRequest
            {
                PlanetExplorationId = 1,
                PatchDocument = new JsonPatchDocument<PlanetExploration>(
                    new List<Operation<PlanetExploration>>
                    {
                        new Operation<PlanetExploration>("replace", "/planetExplorationStatusId", null, "Invalid value")
                    },
                    new DefaultContractResolver()
                ),
                UpdatedBy = "google-oauth2|102590899082590583530"
            };

            // Act
            var act = () => handler.Handle(request, default);

            // Assert
            await act.Should().ThrowAsync<ApiErrorException>()
                .Where(e => e.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task Given_ApplyPlanetExplorationPatchRequestWithInvalidPlanetExplorationId_When_HandlerIsCalled_Then_ThrowApiErrorExceptionWithNotFoundStatus()
        {
            // Arrange
            var request = new ApplyPlanetExplorationPatchRequest
            {
                PlanetExplorationId = -1,
                PatchDocument = new JsonPatchDocument<PlanetExploration>(
                    new List<Operation<PlanetExploration>>
                    {
                        new Operation<PlanetExploration>("replace", "/planetExplorationStatusId", null, Domain.Entities.Common.Enums.PlanetExplorationStatus.NotOk),
                        new Operation<PlanetExploration>("replace", "/observations", null, "Observations updated")
                    },
                    new DefaultContractResolver()
                ),
                UpdatedBy = "google-oauth2|102590899082590583530"
            };

            // Act
            var act = () => handler.Handle(request, default);

            // Assert
            await act.Should().ThrowAsync<ApiErrorException>()
                .Where(e => e.StatusCode == HttpStatusCode.NotFound);
        }
    }
}
