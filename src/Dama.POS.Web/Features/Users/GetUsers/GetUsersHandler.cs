using Dama.POS.DAL;
using Dama.POS.DAL.Entities.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dama.POS.Web.Features.Users.GetUsers;

public record GetUsersQuery : IRequest<IEnumerable<User>>;

public class GetUsersHandler(DamaRozeDbContext dbContext) : IRequestHandler<GetUsersQuery, IEnumerable<User>> {
    public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Users.ToListAsync(cancellationToken);
    }
}
