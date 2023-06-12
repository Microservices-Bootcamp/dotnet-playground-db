using System.Text.Json.Serialization;

namespace src.Products.Integrations
{
    public class GithubBranch
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("commit")]
        public Commit Commit { get; set; }
        [JsonPropertyName("protected")]
        public bool IsProtected { get; set; }
    }
    public class Commit
    {
        [JsonPropertyName("sha")]
        public string Sha { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}