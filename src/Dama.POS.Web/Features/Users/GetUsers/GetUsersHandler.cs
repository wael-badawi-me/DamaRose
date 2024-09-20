using Dama.POS.DAL;
using Dama.POS.DAL.Entities.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Dama.POS.Web.Features.Users.GetUsers;

public record GetUsersQuery(int skip, int take, string search) : IRequest<IEnumerable<User>>;

public class GetUsersHandler(DamaRozeDbContext dbContext) : IRequestHandler<GetUsersQuery, IEnumerable<User>> {
    public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.search))
        {
            return await dbContext.Users.Skip(request.skip).Take(request.take).Where(c =>
                 c.Name.Contains(request.search) ||
                 c.Password.Contains(request.search) ||
                 c.IsEnabled.ToString().Contains(request.search)
                 ).ToListAsync(cancellationToken);
        }
        else
        {
            return await dbContext.Users.Skip(request.skip).Take(request.take).ToListAsync(cancellationToken);
        }
    }
}




