using System.Text.Json.Serialization;

namespace SharpLulu.Models.Projects;

/// <summary>
/// Represents a project in the Lulu system
/// </summary>
public class Project
{
    /// <summary>
    /// Unique identifier for the project
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

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
    /// Project status
    /// </summary>
    [JsonPropertyName("status")]
    public ProjectStatus Status { get; set; }

    /// <summary>
    /// Date and time when the project was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date and time when the project was last updated
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

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

/// <summary>
/// Project status enumeration
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProjectStatus
{
    /// <summary>
    /// Project is in draft status
    /// </summary>
    Draft,

    /// <summary>
    /// Project is active and ready for printing
    /// </summary>
    Active,

    /// <summary>
    /// Project has been archived
    /// </summary>
    Archived,

    /// <summary>
    /// Project has been completed
    /// </summary>
    Completed
}