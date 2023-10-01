
/* Unmerged change from project 'Discord.Net.V4.Core (net7.0)'
Before:
using System.Text.Json.Serialization;
After:
using Discord.API.Activity;
using System.Text.Json.Serialization;
*/
using System.Text.Json.Serialization;

namespace Discord.API;

public sealed class GuildWidgetMember
{
    [JsonPropertyName("id")]
    public int Position { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("discriminator")]
    public string Discriminator { get; set; }

    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }

    [JsonPropertyName("status")]
    public UserStatus Status { get; set; }

    [JsonPropertyName("activity")]
    public Optional<Activity> Activity { get; set; }

    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; set; }
}