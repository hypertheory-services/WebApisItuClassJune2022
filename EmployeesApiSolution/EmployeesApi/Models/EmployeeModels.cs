namespace EmployeesApi.Models;

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
