using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// Print job status enumeration
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PrintJobStatus
{
    /// <summary>
    /// Print job is queued
    /// </summary>
    Queued,

    /// <summary>
    /// Print job is being processed
    /// </summary>
    Processing,

    /// <summary>
    /// Print job is being printed
    /// </summary>
    Printing,

    /// <summary>
    /// Print job completed successfully
    /// </summary>
    Completed,

    /// <summary>
    /// Print job failed
    /// </summary>
    Failed,

    /// <summary>
    /// Print job was cancelled
    /// </summary>
    Cancelled
}