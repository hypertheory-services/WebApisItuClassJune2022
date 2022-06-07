namespace EmployeesApi.Domain;

public interface ILookupEmployees
{
    Task<EmployeeDocumentResponse> GetEmployeeByIdAsync(string id);
}
