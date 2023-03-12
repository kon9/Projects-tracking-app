using MediatR;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectRepo _projectRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectCommandHandler(IProjectRepo projectRepo, IUnitOfWork unitOfWork)
        {
            _projectRepo = projectRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                ProjectName = request.ProjectName,
                CustomerCompanyName = request.CustomerCompanyName,
                PerformerCompanyName = request.PerformerCompanyName,
                ProjectPriority = request.ProjectPriority,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };
            await _projectRepo.AddAsync(project, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return project.Id;
        }
    }
}
