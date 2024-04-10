using Newtonsoft.Json;

namespace Discord.API;

internal class PollAnswerCount
{
    [JsonProperty("id")]
    public ulong Id { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("me_voted")]
    public bool MeVoted { get; set; }
}
