using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Application.Common.Models;
using ExchangeAGram.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeAGram.Application.Photos.Commands.UploadPhoto
{
    public class UploadPhotoCommand : IRequest
    {
        public byte[] FileBytes { get; set; }
        public string FileName { get; set; }
    }

    class UploadPhotoCommandHandler : IRequestHandler<UploadPhotoCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISystemFileService _systemFileService;
        private readonly SystemFileSettings _systemFileSettings;
        private readonly ICurrentUserService _currentUserService;

        public UploadPhotoCommandHandler(IApplicationDbContext context,
                                              ISystemFileService systemFileService,
                                              IOptions<SystemFileSettings> options,
                                              ICurrentUserService currentUserService)
        {
            _context = context;
            _systemFileService = systemFileService;
            _systemFileSettings = options.Value;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(UploadPhotoCommand request, CancellationToken cancellationToken)
        {
            _systemFileService.EnsureDirectory(_systemFileSettings.FileDirectory);

            string fullFilePath = _systemFileService.CombinePaths(_systemFileSettings.FileDirectory, request.FileName);

            _systemFileService.SaveFileBytes(request.FileBytes, fullFilePath);

            var newPhoto = new Photo
            {
                Extension = _systemFileService.GetFileExtension(request.FileName),
                Name = _systemFileService.RemoveExtensionFromFile(request.FileName),
                Path = fullFilePath,
                UserId = Guid.Parse(_currentUserService.UserId)
            };

            await _context.Photos.AddAsync(newPhoto, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
