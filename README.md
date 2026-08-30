[![](https://img.shields.io/nuget/v/soenneker.managers.base.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.managers.base/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.managers.base/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.managers.base/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.managers.base.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.managers.base/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.managers.base/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.managers.base/actions/workflows/codeql.yml)

# Soenneker.Managers.Base

An abstract base class for managers that need Redis access, the current user context, and a shared logger.

## Install

```bash
dotnet add package Soenneker.Managers.Base
```

## What you get

- `BaseManager` exposes `RedisUtil`, `UserContext`, `Logger`, and an `IsAdmin` shortcut to derived classes.
- `IBaseManager` is an empty marker interface for identifying manager services.

## Usage

```csharp
public sealed class OrdersManager : BaseManager, IOrdersManager
{
    public OrdersManager(
        IRedisUtil redisUtil,
        ILogger<BaseManager> logger,
        IUserContext userContext)
        : base(redisUtil, logger, userContext)
    {
    }

    public bool CanManageOrders(string orderId)
    {
        Logger.LogInformation("Checking access to order {OrderId}", orderId);
        return IsAdmin;
    }
}
```

Register the concrete manager with the lifetime appropriate to its dependencies. In web applications that normally means scoped, because the user context is request-specific.

This package does not provide authorization by itself. `IsAdmin` only reflects `IUserContext.IsAdmin()`; enforce the application's authorization policy in the manager or at the request boundary.
