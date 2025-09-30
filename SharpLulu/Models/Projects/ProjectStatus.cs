using System.Text.Json.Serialization;

namespace SharpLulu.Models.Projects;

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