using MediatR;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Interfaces;

namespace ProjectTracking.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProjectRepo _projectRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProjectCommandHandler(IProjectRepo projectRepo, IUnitOfWork unitOfWork)
        {
            _projectRepo = projectRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            await _projectRepo.DeleteAsync(request.Id);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
