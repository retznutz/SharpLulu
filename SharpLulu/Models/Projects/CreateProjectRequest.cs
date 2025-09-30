using System.Text.Json.Serialization;

namespace SharpLulu.Models.Projects;

/// <summary>
/// Request model for creating a new project
/// </summary>
public class CreateProjectRequest
{
    /// <summary>
    /// Title of the project
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Description of the project
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Author information
    /// </summary>
    [JsonPropertyName("author")]
    public string? Author { get; set; }

    /// <summary>
    /// Project metadata
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object>? Metadata { get; set; }
}