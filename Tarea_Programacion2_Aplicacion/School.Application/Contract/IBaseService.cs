namespace School.Application.Contract;

public interface IBaseService<TDto, TCreateDto>
{
    ServiceResult GetAll();
    ServiceResult GetById(int id);
    ServiceResult Add(TCreateDto dto);
    ServiceResult Update(int id, TCreateDto dto);
    ServiceResult Delete(int id);
}
