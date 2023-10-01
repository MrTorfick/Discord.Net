using Discord.API;
using Discord.Models;
using Discord.Rest;

namespace Discord;

public static class Users
{
    public static Task<T?> FetchUserAsync<T>(
        this IEntityProvider<T, IUser, IUserModel> provider,
        ulong id, RequestOptions? options = null, CancellationToken token = default)
        where T : class, IUser, IConstructable<IUserModel>
        => provider.ExecuteAndConstructAsync(Routes.GetUser(id), options, token);

    public static Task<T> FetchCurrentUserAsync<T>(
        this IEntityProvider<T, ISelfUser, IUserModel> provider,
        RequestOptions? options = null, CancellationToken token = default)
        where T : class, ISelfUser, IConstructable<IUserModel>
    {
        return provider.ExecuteAndConstructAsync(
            Routes.GetCurrentUser,
            options, token
        )!;
    }

    public static Task<T?> ModifyCurrentUserAsync<T>(
        this IEntityProvider<T, ISelfUser, IUserModel> provider,
        PropertiesOrModel<ModifySelfUserProperties, API.ModifyCurrentUserParams> properties,
        RequestOptions? options = null, CancellationToken token = default)
        where T : class, ISelfUser, IModifyable<ModifySelfUserProperties>, IConstructable<IUserModel>
    {
        return provider.ExecuteAndConstructAsync(
            Routes.ModifyCurrentUser(properties.Model),
            options, token
        );
    }

    public static Task<T?> GetCurrentUserGuildMemberAsync<T>(
        this IEntityProvider<T, IGuildUser, IMemberModel> provider,
        EntityOrId<ulong, IGuild> guild,
        RequestOptions? options = null, CancellationToken token = default)
        where T : class, IGuildUser, IConstructable<IMemberModel>
    {
        return provider.ExecuteAndConstructAsync(
            Routes.GetCurrentUserGuildMember(guild.Id),
            options, token
        );
    }

    public static Task LeaveGuildAsync(
        this IDiscordClient client,
        EntityOrId<ulong, IGuild> guild,
        RequestOptions? options = null, CancellationToken token = default)
    {
        return client.RestApiClient.ExecuteAsync(Routes.LeaveGuild(guild.Id), options ?? default, token);
    }

    public static Task<T> CreateDMAsync<T>(
        this IEntityProvider<T, IDMChannel, IDMChannelModel> provider,
        EntityOrId<ulong, IUser> recipient,
        RequestOptions? options = null, CancellationToken token = default)
        where T : class, IDMChannel, IConstructable<IDMChannelModel>
    {
        return provider.ExecuteAndConstructAsync(
            Routes.CreateDM(
                new() { RecipientId = recipient.Id }
            ),
            options, token
        );
    }
}