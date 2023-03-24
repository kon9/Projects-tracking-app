using AutoMapper;
using MediatR;
using ProjectTracking.Application.Infrastructure.Exeptions;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectRepo _projectRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectCommandHandler(IMapper mapper, IProjectRepo projectRepo, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _projectRepo = projectRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepo.GetOneAsync(request.Id, cancellationToken);
            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            _mapper.Map(request, project);
            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
