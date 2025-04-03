using Microsoft.Extensions.Logging;
using Soenneker.Managers.Base.Abstract;
using Soenneker.Redis.Util.Abstract;
using Soenneker.Utils.UserContext.Abstract;

namespace Soenneker.Managers.Base;

/// <inheritdoc cref="IBaseManager"/>
public abstract class BaseManager : IBaseManager
{
    /// <summary>
    /// Gets the current user context, which provides information about the authenticated user.
    /// </summary>
    protected IUserContext UserContext { get; }

    /// <summary>
    /// Gets the logger instance specific to the <see cref="BaseManager"/> class.
    /// </summary>
    protected ILogger<BaseManager> Logger { get; }

    /// <summary>
    /// Gets the Redis utility service for caching and distributed data operations.
    /// </summary>
    protected IRedisUtil RedisUtil { get; }

    /// <summary>
    /// Gets a value indicating whether the current user has administrative privileges.
    /// </summary>
    protected bool IsAdmin => UserContext.IsAdmin();

    protected BaseManager(IRedisUtil redisUtil, ILogger<BaseManager> logger, IUserContext userContext)
    {
        UserContext = userContext;
        Logger = logger;
        RedisUtil = redisUtil;
    }
}