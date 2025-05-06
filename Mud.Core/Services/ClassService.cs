using Mud.Core.Dto.Class;
using Mud.Core.Entities;
using Mud.Core.IRepositories;
using Mud.Core.IServices;

namespace Mud.Core.Services;

public class ClassService : IClassService
{
    private readonly IClassRepository _classRepository;
    
    public ClassService(IClassRepository classRepository)
    {
        _classRepository = classRepository;
    }

    // Gets all classes from the database
    public async Task<List<ClassResponse>> GetAllAsync()
    {
        List<Class> classes = await _classRepository.GetAllAsync();
        List<ClassResponse> classResponses = classes.Select(c => c.ToResponse()).ToList();
        
        return classResponses;
    }
}