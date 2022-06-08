namespace EmployeesApi.Domain;

public interface IManageEmployees
{
    Task<EmployeeDocumentResponse> CreateEmployeeAsync(EmployeeCreateRequest request);
}
