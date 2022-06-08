using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace EmployeesApi.Domain;

public class EmployeeLookup : ILookupEmployees, IManageEmployees
{
    private readonly EmployeesMongoDbAdapter _adapter;

    public EmployeeLookup(EmployeesMongoDbAdapter adapter)
    {
        _adapter = adapter;
    }

    public async Task<EmployeeDocumentResponse> CreateEmployeeAsync(EmployeeCreateRequest request)
    {
        var employeeToAdd = new Employee
        {
            Department = request.Department,
            Name = new NameInformation { FirstName = request.FirstName, LastName = request.LastName },
            Salary = request.StartingSalary
        };

        // This is a "side effect producing call"
        await _adapter.GetEmployeeCollection().InsertOneAsync(employeeToAdd);

        var response = new EmployeeDocumentResponse
        {
            Id = employeeToAdd.Id.ToString(),
            Department = employeeToAdd.Department,
            Name = new EmployeeNameInformation
            {
                FirstName = employeeToAdd.Name.FirstName,
                LastName = employeeToAdd.Name.LastName
            }
        };
        return response;
        
    }

    public async Task<List<EmployeeSummaryResponse>> GetAllEmployeeSummariesAsync()
    {
        var query =  _adapter.GetEmployeeCollection().AsQueryable()
            .OrderBy(e => e.Name.LastName)
             .Select(e => new EmployeeSummaryResponse
             {
                 Id = e.Id.ToString(),
                 Name = new EmployeeNameInformation { FirstName = e.Name.FirstName, LastName = e.Name.LastName }
             });


        // a thing we add here later.
        var response = await query.ToListAsync();
        return response;
    }

    public async Task<EmployeeDocumentResponse> GetEmployeeByIdAsync(string id)
    {

        // if we get here, that sucker is an ObjectID
        var bId = ObjectId.Parse(id);

        var projection = Builders<Employee>.Projection.Expression(emp => new EmployeeDocumentResponse
        {
            Id = emp.Id.ToString(),
            Department = emp.Department,
            Name = new EmployeeNameInformation
            {
                FirstName = emp.Name.FirstName,
                LastName = emp.Name.LastName
            }
        });

        var response = await _adapter.GetEmployeeCollection()
            .Find(e => e.Id == bId)
            .Project(projection).SingleOrDefaultAsync();

        return response;
    }
}
