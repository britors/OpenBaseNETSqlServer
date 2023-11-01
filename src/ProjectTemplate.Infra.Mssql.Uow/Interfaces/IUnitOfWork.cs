﻿namespace ProjectTemplate.Infra.Mssql.Uow.Interfaces;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();

    Task CommitAsync();

    Task RoolbackAsync();
}