using Dama.POS.DAL;
using Dama.POS.DAL.Entities.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dama.POS.Web.Features.Users.EditUser;

public record EditUserCommand(User user) : IRequest;
public record GetByIdCommand(string id) : IRequest<User>;

public class EditUserHandler(DamaRozeDbContext dbContext) : IRequestHandler<EditUserCommand> {
    public async Task Handle(EditUserCommand request, CancellationToken cancellationToken)
    {

        User oldUser = await dbContext.Users.FirstOrDefaultAsync(c => c.Id == request.user.Id);

        if (oldUser == null)
        {
            throw new ArgumentException("User with provided Id can't be found");
        }

        request.user.CreatedDate = oldUser.CreatedDate;
        request.user.LastModifiedDate = oldUser.LastModifiedDate;
        request.user.CreatedById = oldUser.CreatedById;
        request.user.LastModifiedById = oldUser.LastModifiedById;

        dbContext.Entry(await dbContext.Set<User>().FindAsync(request.user.Id)).State = EntityState.Detached;
        dbContext.Entry(request.user).State = EntityState.Modified;
        await dbContext.SaveChangesAsync(cancellationToken);


        //var user = await dbContext.Users.SingleAsync(x => x.Name == request.CurrentName, cancellationToken);

        //user.Edit(request.NewName, true); // implement is enabled

        //await dbContext.SaveChangesAsync(cancellationToken);
    }

}

public class GetByIdHandler(DamaRozeDbContext dbContext) : IRequestHandler<GetByIdCommand,User>
{
    public async Task<User> Handle(GetByIdCommand request, CancellationToken cancellationToken)
    {

       return  await dbContext.Users.FirstOrDefaultAsync(c => c.Id == request.id);

     
    }

}

