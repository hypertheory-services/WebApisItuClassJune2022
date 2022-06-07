namespace EmployeesApi.Models;

public record CollectionResponse<T>
{
    public List<T> Data
    {
        get; set;
    } = new();
}

public record EmployeeSummaryResponse
{
    public EmployeeNameInformation Name
    {
        get; set;
    } = new();
    public string Id
    {
        get; set;
    } = "";
}
public record EmployeeDocumentResponse
{
    public string Id
    {
        get; set;
    } = string.Empty;

    public EmployeeNameInformation Name
    {
        get; set;
    } = new();

    public string Department
    {
        get; init;
    } = string.Empty;
}

public record EmployeeNameInformation
{
    public string FirstName
    {
        get; init;
    } = string.Empty;

    public string LastName
    {
        get; init;
    } = string.Empty;
}
