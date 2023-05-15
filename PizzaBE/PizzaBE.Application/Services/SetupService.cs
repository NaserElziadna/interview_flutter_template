using AutoMapper;
using PizzaBE.Application.Interfaces;
using PizzaBE.Domain.Interfaces.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.Services
{
    public class SetupService : ISetupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SetupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateWorkerLoginAndRolesAsync()
        {
            await _unitOfWork.SeedDataAsync();
        }

    }
}
