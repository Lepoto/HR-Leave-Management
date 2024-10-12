﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;


namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypeDetailsHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
            
        }

        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the database

            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // verify the existance of leaveType

            if (leaveType == null)
            {
                throw new NotFoundException(
                    nameof(LeaveType),
                    request.Id);
            }

            // convert data object to DTO object

            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveType);


            // return the data
            return data;

        }
    }
}
