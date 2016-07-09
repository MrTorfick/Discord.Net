﻿using Newtonsoft.Json;

namespace Discord.API.Gateway
{
    public class ResumeParams
    {
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
        [JsonProperty("seq")]
        public int Sequence { get; set; }
    }
}