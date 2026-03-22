namespace School.Application.Core;

public abstract class BaseService
{
    protected ServiceResult Success(object? data = null, string message = "Success")
    {
        return new ServiceResult
        {
            IsSuccess = true,
            Message = message,
            Data = data
        };
    }

    protected ServiceResult Fail(string message)
    {
        return new ServiceResult
        {
            IsSuccess = false,
            Message = message
        };
    }
}
