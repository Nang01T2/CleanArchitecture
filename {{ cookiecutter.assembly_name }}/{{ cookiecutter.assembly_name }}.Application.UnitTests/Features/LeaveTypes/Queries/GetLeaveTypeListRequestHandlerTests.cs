using AutoMapper;
using {{ cookiecutter.assembly_name }}.Application.Contracts.Persistence;
using {{ cookiecutter.assembly_name }}.Application.DTOs.LeaveType;
using {{ cookiecutter.assembly_name }}.Application.Features.LeaveTypes.Handlers.Queries;
using {{ cookiecutter.assembly_name }}.Application.Features.LeaveTypes.Requests.Queries;
using {{ cookiecutter.assembly_name }}.Application.Profiles;
using {{ cookiecutter.assembly_name }}.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace {{ cookiecutter.assembly_name }}.Application.UnitTests.Features.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        public GetLeaveTypeListRequestHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
