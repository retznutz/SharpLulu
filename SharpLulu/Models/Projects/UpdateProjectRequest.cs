using System.Text.Json.Serialization;

namespace SharpLulu.Models.Projects;

/// <summary>
/// Request model for updating an existing project
/// </summary>
public class UpdateProjectRequest
{
    /// <summary>
    /// Title of the project
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Description of the project
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Project status
    /// </summary>
    [JsonPropertyName("status")]
    public ProjectStatus? Status { get; set; }

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