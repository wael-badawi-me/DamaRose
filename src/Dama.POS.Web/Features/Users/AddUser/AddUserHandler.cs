﻿using Dama.POS.Web.Application.Database;
using MediatR;

namespace Dama.POS.Web.Features.Users.AddUser;

public record AddUserCommand(string Username, string Password) : IRequest;

public class AddUserHandler(DamaDbContext dbContext) : IRequestHandler<AddUserCommand> {
    public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.Username, request.Password);

        dbContext.Users.Add(user);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}