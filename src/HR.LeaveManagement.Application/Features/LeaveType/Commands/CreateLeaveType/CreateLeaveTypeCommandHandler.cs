using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository) : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository = leaveTypeRepository;

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data

            var leaveTypeValidator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);

            var validationResult = await leaveTypeValidator.ValidateAsync(request, cancellationToken);

            if(validationResult.Errors.Count != 0)
            {
                throw new BadRequestException("Invalid Leave Type", validationResult);
            }

            // convert to domain entity object
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

            // add to database
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

            // return record id
            return leaveTypeToCreate.Id;
        }
    }
}
