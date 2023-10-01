using Discord.Net.Rest;
using System.Text;
using System.Text.Json.Serialization;

namespace Discord.API.Rest;

internal class CreateWebhookMessageParams
{
    [JsonPropertyName("content")]
    public Optional<string> Content { get; set; }

    [JsonPropertyName("nonce")]
    public Optional<string> Nonce { get; set; }

    [JsonPropertyName("tts")]
    public Optional<bool> IsTTS { get; set; }

    [JsonPropertyName("embeds")]
    public Optional<Embed[]> Embeds { get; set; }

    [JsonPropertyName("username")]
    public Optional<string> Username { get; set; }

    [JsonPropertyName("avatar_url")]
    public Optional<string> AvatarUrl { get; set; }

    [JsonPropertyName("allowed_mentions")]
    public Optional<AllowedMentions> AllowedMentions { get; set; }

    [JsonPropertyName("flags")]
    public Optional<MessageFlags> Flags { get; set; }

    [JsonPropertyName("components")]
    public Optional<API.ActionRowComponent[]> Components { get; set; }

    [JsonPropertyName("file")]
    public Optional<MultipartFile> File { get; set; }

    [JsonPropertyName("thread_name")]
    public Optional<string> ThreadName { get; set; }

    public IReadOnlyDictionary<string, object> ToDictionary()
    {
        var d = new Dictionary<string, object>();

        if (File.IsSpecified)
        {
            d["file"] = File.Value;
        }

        var payload = new Dictionary<string, object>
        {
            ["content"] = Content
        };

        if (IsTTS.IsSpecified)
            payload["tts"] = IsTTS.Value.ToString();
        if (Nonce.IsSpecified)
            payload["nonce"] = Nonce.Value;
        if (Username.IsSpecified)
            payload["username"] = Username.Value;
        if (AvatarUrl.IsSpecified)
            payload["avatar_url"] = AvatarUrl.Value;
        if (Embeds.IsSpecified)
            payload["embeds"] = Embeds.Value;
        if (AllowedMentions.IsSpecified)
            payload["allowed_mentions"] = AllowedMentions.Value;
        if (Components.IsSpecified)
            payload["components"] = Components.Value;
        if (ThreadName.IsSpecified)
            payload["thread_name"] = ThreadName.Value;

        var json = new StringBuilder();
        using (var text = new StringWriter(json))
        using (var writer = new JsonTextWriter(text))
            _serializer.Serialize(writer, payload);

        d["payload_json"] = json.ToString();

        return d;
    }
}