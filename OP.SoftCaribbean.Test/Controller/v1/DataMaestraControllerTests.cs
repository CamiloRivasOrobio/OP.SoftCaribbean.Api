﻿using AutoMapper;
using FakeItEasy;
using OP.SoftCaribbean.Application.DTOs;
using OP.SoftCaribbean.Application.Features.DataMaestra.Queries.GetAllDataMasterQuery;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.WebAPI.Controllers.v1;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace OP.SoftCaribbean.Test.Controller.v1
{
    public class DataMaestraControllerTests
    {
        private readonly IRepositoryAsync<Domain.Entities.DataMaestra> _repositoryAsync;
        private readonly IMapper _mapper;

        public DataMaestraControllerTests()
        {
            _repositoryAsync = A.Fake<IRepositoryAsync<Domain.Entities.DataMaestra>>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async void DataMaestraController_GetDataMaestra_ReturnOk()
        {
            //Arrange
            var dataMaestra = A.Fake<ICollection<DataMaestraDto>>();
            var dataMaestraList = A.Fake<List<DataMaestraDto>>();
            A.CallTo(() => _mapper.Map<List<DataMaestraDto>>(dataMaestra)).Returns(dataMaestraList);
            var controller = new DataMaestraController();
            var getParameters = new GetAllDataMasterParameters() { PageNumber = 1, PageSize = 10 };

            //Act
            var result = await controller.Get(getParameters);

            //Assert
            //result;
        }
    }
}
