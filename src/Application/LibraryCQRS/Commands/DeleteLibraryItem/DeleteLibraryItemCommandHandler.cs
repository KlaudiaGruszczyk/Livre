﻿using Application.BooksCQRS.Commands.DeleteBook;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.LibraryCQRS.Commands.DeleteLibraryItem
{
    public class DeleteLibraryItemCommandHandler : IRequestHandler<DeleteLibraryItemCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteLibraryItemCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteLibraryItemCommand command, CancellationToken cancellationToken)
        {
            var item = await _dbContext.UsersLibraryItems.Where(a => a.LibraryItemId == command.LibraryItemId).FirstOrDefaultAsync();
            if (item == null) return default;
            _dbContext.UsersLibraryItems.Remove(item);
            await _dbContext.SaveChangesAsync();
            return (int)item.LibraryItemId;
        }
    }
}
