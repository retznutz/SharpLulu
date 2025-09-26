using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// Print job information
/// </summary>
public class PrintJob
{
    /// <summary>
    /// Print job identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Associated order identifier
    /// </summary>
    [JsonPropertyName("order_id")]
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Print job status
    /// </summary>
    [JsonPropertyName("status")]
    public PrintJobStatus Status { get; set; }

    /// <summary>
    /// Product being printed
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Quantity being printed
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// Print facility handling the job
    /// </summary>
    [JsonPropertyName("facility_id")]
    public string? FacilityId { get; set; }

    /// <summary>
    /// Date when print job was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date when printing started
    /// </summary>
    [JsonPropertyName("started_at")]
    public DateTime? StartedAt { get; set; }

    /// <summary>
    /// Date when printing completed
    /// </summary>
    [JsonPropertyName("completed_at")]
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// Estimated completion date
    /// </summary>
    [JsonPropertyName("estimated_completion")]
    public DateTime? EstimatedCompletion { get; set; }

    /// <summary>
    /// Quality check results
    /// </summary>
    [JsonPropertyName("quality_check")]
    public QualityCheckResult? QualityCheck { get; set; }
}

/// <summary>
/// Quality check result
/// </summary>
public class QualityCheckResult
{
    /// <summary>
    /// Whether the print passed quality check
    /// </summary>
    [JsonPropertyName("passed")]
    public bool Passed { get; set; }

    /// <summary>
    /// Quality score (0-100)
    /// </summary>
    [JsonPropertyName("score")]
    public int Score { get; set; }

    /// <summary>
    /// Quality check issues found
    /// </summary>
    [JsonPropertyName("issues")]
    public List<QualityIssue>? Issues { get; set; }

    /// <summary>
    /// Date of quality check
    /// </summary>
    [JsonPropertyName("checked_at")]
    public DateTime CheckedAt { get; set; }
}

/// <summary>
/// Quality issue found during printing
/// </summary>
public class QualityIssue
{
    /// <summary>
    /// Issue type
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Severity level
    /// </summary>
    [JsonPropertyName("severity")]
    public QualityIssueSeverity Severity { get; set; }

    /// <summary>
    /// Description of the issue
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Page number where issue was found (if applicable)
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// Location coordinates on the page
    /// </summary>
    [JsonPropertyName("location")]
    public PageLocation? Location { get; set; }
}

/// <summary>
/// Location on a page
/// </summary>
public class PageLocation
{
    /// <summary>
    /// X coordinate
    /// </summary>
    [JsonPropertyName("x")]
    public double X { get; set; }

    /// <summary>
    /// Y coordinate
    /// </summary>
    [JsonPropertyName("y")]
    public double Y { get; set; }

    /// <summary>
    /// Width of the affected area
    /// </summary>
    [JsonPropertyName("width")]
    public double? Width { get; set; }

    /// <summary>
    /// Height of the affected area
    /// </summary>
    [JsonPropertyName("height")]
    public double? Height { get; set; }
}

/// <summary>
/// PDF validation request
/// </summary>
public class PdfValidationRequest
{
    /// <summary>
    /// Product identifier to validate against
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Base64-encoded PDF content
    /// </summary>
    [JsonPropertyName("pdf_content")]
    public string PdfContent { get; set; } = string.Empty;

    /// <summary>
    /// PDF filename
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; set; } = string.Empty;

    /// <summary>
    /// Validation level
    /// </summary>
    [JsonPropertyName("validation_level")]
    public ValidationLevel ValidationLevel { get; set; } = ValidationLevel.Standard;
}

/// <summary>
/// PDF validation result
/// </summary>
public class PdfValidationResult
{
    /// <summary>
    /// Whether the PDF is valid for printing
    /// </summary>
    [JsonPropertyName("valid")]
    public bool Valid { get; set; }

    /// <summary>
    /// Validation score (0-100)
    /// </summary>
    [JsonPropertyName("score")]
    public int Score { get; set; }

    /// <summary>
    /// Validation issues found
    /// </summary>
    [JsonPropertyName("issues")]
    public List<ValidationIssue>? Issues { get; set; }

    /// <summary>
    /// PDF metadata
    /// </summary>
    [JsonPropertyName("metadata")]
    public PdfMetadata? Metadata { get; set; }

    /// <summary>
    /// Validation timestamp
    /// </summary>
    [JsonPropertyName("validated_at")]
    public DateTime ValidatedAt { get; set; }
}

/// <summary>
/// PDF validation issue
/// </summary>
public class ValidationIssue
{
    /// <summary>
    /// Issue type
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Severity level
    /// </summary>
    [JsonPropertyName("severity")]
    public ValidationSeverity Severity { get; set; }

    /// <summary>
    /// Issue description
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Page number where issue was found (if applicable)
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// Suggested fix
    /// </summary>
    [JsonPropertyName("suggested_fix")]
    public string? SuggestedFix { get; set; }
}

/// <summary>
/// PDF metadata
/// </summary>
public class PdfMetadata
{
    /// <summary>
    /// Number of pages
    /// </summary>
    [JsonPropertyName("page_count")]
    public int PageCount { get; set; }

    /// <summary>
    /// File size in bytes
    /// </summary>
    [JsonPropertyName("file_size")]
    public long FileSize { get; set; }

    /// <summary>
    /// PDF version
    /// </summary>
    [JsonPropertyName("pdf_version")]
    public string? PdfVersion { get; set; }

    /// <summary>
    /// Color profile
    /// </summary>
    [JsonPropertyName("color_profile")]
    public string? ColorProfile { get; set; }

    /// <summary>
    /// Resolution in DPI
    /// </summary>
    [JsonPropertyName("resolution")]
    public int? Resolution { get; set; }

    /// <summary>
    /// Whether the PDF contains fonts
    /// </summary>
    [JsonPropertyName("embedded_fonts")]
    public bool EmbeddedFonts { get; set; }

    /// <summary>
    /// Whether the PDF contains images
    /// </summary>
    [JsonPropertyName("contains_images")]
    public bool ContainsImages { get; set; }
}

/// <summary>
/// Print quality requirements for a product
/// </summary>
public class PrintQualityRequirements
{
    /// <summary>
    /// Product identifier
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Minimum resolution in DPI
    /// </summary>
    [JsonPropertyName("min_resolution")]
    public int MinResolution { get; set; }

    /// <summary>
    /// Maximum file size in bytes
    /// </summary>
    [JsonPropertyName("max_file_size")]
    public long MaxFileSize { get; set; }

    /// <summary>
    /// Supported color profiles
    /// </summary>
    [JsonPropertyName("color_profiles")]
    public List<string> ColorProfiles { get; set; } = new();

    /// <summary>
    /// Required bleed area in points
    /// </summary>
    [JsonPropertyName("bleed_area")]
    public double BleedArea { get; set; }

    /// <summary>
    /// Safe area margin in points
    /// </summary>
    [JsonPropertyName("safe_area")]
    public double SafeArea { get; set; }

    /// <summary>
    /// Whether fonts must be embedded
    /// </summary>
    [JsonPropertyName("fonts_embedded")]
    public bool FontsEmbedded { get; set; }

    /// <summary>
    /// Supported PDF versions
    /// </summary>
    [JsonPropertyName("pdf_versions")]
    public List<string> PdfVersions { get; set; } = new();
}

/// <summary>
/// Print facility information
/// </summary>
public class PrintFacility
{
    /// <summary>
    /// Facility identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Facility name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Country code
    /// </summary>
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// City
    /// </summary>
    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Supported product types
    /// </summary>
    [JsonPropertyName("supported_products")]
    public List<string> SupportedProducts { get; set; } = new();

    /// <summary>
    /// Average production time in days
    /// </summary>
    [JsonPropertyName("avg_production_days")]
    public int AvgProductionDays { get; set; }

    /// <summary>
    /// Whether facility is currently active
    /// </summary>
    [JsonPropertyName("active")]
    public bool Active { get; set; }
}

/// <summary>
/// Production time estimate request
/// </summary>
public class ProductionTimeRequest
{
    /// <summary>
    /// Product identifier
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Quantity to produce
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// Preferred facility (optional)
    /// </summary>
    [JsonPropertyName("facility_id")]
    public string? FacilityId { get; set; }

    /// <summary>
    /// Rush order flag
    /// </summary>
    [JsonPropertyName("rush_order")]
    public bool RushOrder { get; set; }
}

/// <summary>
/// Production time estimate
/// </summary>
public class ProductionTimeEstimate
{
    /// <summary>
    /// Estimated production days
    /// </summary>
    [JsonPropertyName("production_days")]
    public int ProductionDays { get; set; }

    /// <summary>
    /// Earliest start date
    /// </summary>
    [JsonPropertyName("earliest_start")]
    public DateTime EarliestStart { get; set; }

    /// <summary>
    /// Estimated completion date
    /// </summary>
    [JsonPropertyName("estimated_completion")]
    public DateTime EstimatedCompletion { get; set; }

    /// <summary>
    /// Rush order surcharge (if applicable)
    /// </summary>
    [JsonPropertyName("rush_surcharge")]
    public int? RushSurcharge { get; set; }

    /// <summary>
    /// Recommended facility
    /// </summary>
    [JsonPropertyName("recommended_facility")]
    public string? RecommendedFacility { get; set; }
}

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

/// <summary>
/// Quality issue severity
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum QualityIssueSeverity
{
    /// <summary>
    /// Low severity issue
    /// </summary>
    Low,

    /// <summary>
    /// Medium severity issue
    /// </summary>
    Medium,

    /// <summary>
    /// High severity issue
    /// </summary>
    High,

    /// <summary>
    /// Critical issue that prevents printing
    /// </summary>
    Critical
}

/// <summary>
/// PDF validation level
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ValidationLevel
{
    /// <summary>
    /// Basic validation
    /// </summary>
    Basic,

    /// <summary>
    /// Standard validation
    /// </summary>
    Standard,

    /// <summary>
    /// Comprehensive validation
    /// </summary>
    Comprehensive
}

/// <summary>
/// Validation issue severity
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ValidationSeverity
{
    /// <summary>
    /// Information only
    /// </summary>
    Info,

    /// <summary>
    /// Warning that should be addressed
    /// </summary>
    Warning,

    /// <summary>
    /// Error that prevents printing
    /// </summary>
    Error
}