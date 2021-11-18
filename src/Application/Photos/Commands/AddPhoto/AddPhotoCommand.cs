using MediatR;
using Microsoft.EntityFrameworkCore;
using ExchangeAGram.Application.Common.Attributes;
using ExchangeAGram.Application.Common.Constants;
using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Application.Common.Models;
using ExchangeAGram.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeAGram.Application.Photos.Commands.AddPhoto
{
    //[CustomAuthorize(Roles = Roles.Admin)]
    //public class AddPhotoCommand : IRequest<CommandResult>
    //{
    //    public string Name { get; set; }
    //}

    //class AddPhotoCommandHandler : IRequestHandler<AddPhotoCommand, CommandResult>
    //{
    //    private readonly IApplicationDbContext _context;

    //    public AddPhotoCommandHandler(IApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<CommandResult> Handle(AddPhotoCommand request, CancellationToken cancellationToken)
    //    {
    //        bool duplicatePhoto = await _context.Photos.AnyAsync(a => a.Name.ToLower() == request.Name.ToLower(), cancellationToken);

    //        if (duplicatePhoto)
    //        {
    //            return new CommandResult
    //            {
    //                Message = "Photo already exists",
    //                Success = false
    //            };
    //        }

    //        var newPhoto = new Photo
    //        {
    //            Name = request.Name
    //        };

    //        await _context.Photos.AddAsync(newPhoto, cancellationToken);
    //        await _context.SaveChangesAsync(cancellationToken);

    //        return new CommandResult
    //        {
    //            Data = newPhoto.Id,
    //            Message = "Photo added",
    //            Success = true
    //        };
    //    }
    //}
}
