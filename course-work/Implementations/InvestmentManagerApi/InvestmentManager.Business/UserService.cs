using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.User;
using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using InvestmentManagerApi.Shared;
using InvestmentManagerApi.Shared.Exceptions;

namespace InvestmentManagerApi.Business
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> CreateUserAsync(CreateUpdateUserRequest request)
        {
            var userEntity = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true
            };

            this._unitOfWork.Users.Insert(userEntity);
            await _unitOfWork.SaveChangesAsync();

            return UserResponse.FromEntity(userEntity);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id) ?? throw new NotFoundException();
            _unitOfWork.Users.Delete(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserResponse> GetUserAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id) ?? throw new NotFoundException();
            return UserResponse.FromEntity(user);
        }

        public async Task<GetUsersResponse> GetUsersAsync(int page)
        {
            var response = new GetUsersResponse() { Users = new() };
            var users = await _unitOfWork.Users.GetAllAsync((page - 1) * Constants.DEFAULT_PAGE_SIZE, Constants.DEFAULT_PAGE_SIZE);

            foreach (var user in users)
            {
                response.Users.Add(UserResponse.FromEntity(user));
            }

            return response;
        }

        public async Task<UserResponse> UpdateUserAsync(Guid id, CreateUpdateUserRequest request)
        {
            if (!await this._unitOfWork.Users.ExistsAsync(id))
            {
                throw new NotFoundException();
            }
            var userEntity = new User
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true,
            };

            await this._unitOfWork.Users.UpdateAsync(userEntity);
            await this._unitOfWork.SaveChangesAsync();
            return UserResponse.FromEntity(userEntity);
        }
    }
}
