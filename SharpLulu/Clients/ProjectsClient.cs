using SharpLulu.Common;
using SharpLulu.Configuration;
using SharpLulu.Models.Projects;

namespace SharpLulu.Clients;

/// <summary>
/// Client for managing projects in the Lulu API
/// </summary>
public class ProjectsClient : BaseClient
{
    /// <summary>
    /// Creates a new instance of ProjectsClient
    /// </summary>
    /// <param name="httpClient">HTTP client instance</param>
    /// <param name="options">Client configuration options</param>
    public ProjectsClient(HttpClient httpClient, LuluClientOptions options) 
        : base(httpClient, options)
    {
    }

    /// <summary>
    /// Gets a paginated list of projects
    /// </summary>
    /// <param name="page">Page number (0-based)</param>
    /// <param name="size">Number of items per page</param>
    /// <param name="status">Filter by project status</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Paginated list of projects</returns>
    public async Task<PagedResponse<Project>?> GetProjectsAsync(
        int page = 0, 
        int size = 20, 
        ProjectStatus? status = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"page={page}",
            $"size={size}"
        };

        if (status.HasValue)
        {
            queryParams.Add($"status={status.Value.ToString().ToLowerInvariant()}");
        }

        var endpoint = $"/v1/projects?{string.Join("&", queryParams)}";
        return await GetAsync<PagedResponse<Project>>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Gets a specific project by ID
    /// </summary>
    /// <param name="projectId">Project identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Project details</returns>
    public async Task<Project?> GetProjectAsync(string projectId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(projectId))
            throw new ArgumentException("Project ID cannot be null or empty", nameof(projectId));

        var endpoint = $"/v1/projects/{projectId}";
        return await GetAsync<Project>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Creates a new project
    /// </summary>
    /// <param name="request">Project creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Created project</returns>
    public async Task<Project?> CreateProjectAsync(CreateProjectRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.Title))
            throw new ArgumentException("Project title is required", nameof(request));

        var endpoint = "/v1/projects";
        return await PostAsync<Project>(endpoint, request, cancellationToken);
    }

    /// <summary>
    /// Updates an existing project
    /// </summary>
    /// <param name="projectId">Project identifier</param>
    /// <param name="request">Project update request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Updated project</returns>
    public async Task<Project?> UpdateProjectAsync(string projectId, UpdateProjectRequest request, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(projectId))
            throw new ArgumentException("Project ID cannot be null or empty", nameof(projectId));

        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var endpoint = $"/v1/projects/{projectId}";
        return await PutAsync<Project>(endpoint, request, cancellationToken);
    }

    /// <summary>
    /// Deletes a project
    /// </summary>
    /// <param name="projectId">Project identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if successful</returns>
    public async Task<bool> DeleteProjectAsync(string projectId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(projectId))
            throw new ArgumentException("Project ID cannot be null or empty", nameof(projectId));

        var endpoint = $"/v1/projects/{projectId}";
        return await DeleteAsync(endpoint, cancellationToken);
    }

    /// <summary>
    /// Archives a project
    /// </summary>
    /// <param name="projectId">Project identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Updated project</returns>
    public async Task<Project?> ArchiveProjectAsync(string projectId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(projectId))
            throw new ArgumentException("Project ID cannot be null or empty", nameof(projectId));

        var request = new UpdateProjectRequest
        {
            Status = ProjectStatus.Archived
        };

        return await UpdateProjectAsync(projectId, request, cancellationToken);
    }

    /// <summary>
    /// Activates a project
    /// </summary>
    /// <param name="projectId">Project identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Updated project</returns>
    public async Task<Project?> ActivateProjectAsync(string projectId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(projectId))
            throw new ArgumentException("Project ID cannot be null or empty", nameof(projectId));

        var request = new UpdateProjectRequest
        {
            Status = ProjectStatus.Active
        };

        return await UpdateProjectAsync(projectId, request, cancellationToken);
    }
}