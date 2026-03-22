using School.Application.Contract;
using School.Application.Core;
using School.Application.Dtos.Department;
using School.Infrastructure.Exceptions;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Models;

namespace School.Application.Service;

public class DepartmentService : BaseService, IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public ServiceResult GetAll()
    {
        var departments = _departmentRepository.GetAll()
            .Select(department => new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code
            })
            .ToList();

        return Success(departments);
    }

    public ServiceResult GetById(int id)
    {
        if (id <= 0)
        {
            return Fail("Id is required.");
        }

        var department = _departmentRepository.GetById(id);

        if (department is null)
        {
            return Fail("Department not found.");
        }

        var dto = new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Code = department.Code
        };

        return Success(dto);
    }

    public ServiceResult Add(SaveDepartmentDto dto)
    {
        var validation = Validate(dto);

        if (!validation.IsSuccess)
        {
            return validation;
        }

        try
        {
            var model = new DepartmentModel
            {
                Name = dto.Name.Trim(),
                Code = dto.Code.Trim()
            };

            var department = _departmentRepository.Create(model);

            var result = new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code
            };

            return Success(result, "Department created.");
        }
        catch (DepartmentException ex)
        {
            return Fail(ex.Message);
        }
    }

    public ServiceResult Update(int id, SaveDepartmentDto dto)
    {
        if (id <= 0)
        {
            return Fail("Id is required.");
        }

        var validation = Validate(dto);

        if (!validation.IsSuccess)
        {
            return validation;
        }

        try
        {
            var model = new DepartmentModel
            {
                Name = dto.Name.Trim(),
                Code = dto.Code.Trim()
            };

            var department = _departmentRepository.Edit(id, model);

            var result = new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code
            };

            return Success(result, "Department updated.");
        }
        catch (DepartmentException ex)
        {
            return Fail(ex.Message);
        }
    }

    public ServiceResult Delete(int id)
    {
        if (id <= 0)
        {
            return Fail("Id is required.");
        }

        var deleted = _departmentRepository.Delete(id);

        if (!deleted)
        {
            return Fail("Department not found.");
        }

        return Success(null, "Department deleted.");
    }

    private ServiceResult Validate(SaveDepartmentDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return Fail("Name is required.");
        }

        if (dto.Name.Trim().Length < 3)
        {
            return Fail("Name must contain at least 3 characters.");
        }

        if (string.IsNullOrWhiteSpace(dto.Code))
        {
            return Fail("Code is required.");
        }

        if (dto.Code.Trim().Length < 2)
        {
            return Fail("Code must contain at least 2 characters.");
        }

        return Success();
    }
}
