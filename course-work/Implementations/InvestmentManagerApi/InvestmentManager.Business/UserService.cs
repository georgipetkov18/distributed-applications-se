using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Query;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.User;
using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using InvestmentManagerApi.Shared;
using InvestmentManagerApi.Shared.Exceptions;
using InvestmentManagerApi.Shared.Utils;

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
                Email = request.Email,
                Password = PasswordManager.HashPassword(request.Password),
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

        public async Task<GetUsersResponse> GetUsersAsync(FilterParams parameters)
        {
            var response = new GetUsersResponse() { Users = new() };
            var users = await _unitOfWork.Users
                .GetAllAsync(
                    skipCount: (parameters.Page - 1) * Constants.DEFAULT_PAGE_SIZE,
                    takeCount: Constants.DEFAULT_PAGE_SIZE,
                    filter: parameters.Filter
                );

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
                Email = request.Email,
                Password = PasswordManager.HashPassword(request.Password),
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true,
            };

            await this._unitOfWork.Users.UpdateAsync(userEntity);
            await this._unitOfWork.SaveChangesAsync();
            return UserResponse.FromEntity(userEntity);
        }

        public async Task<UserResponse> UpdateUserAsync(Guid id, PatchUserRequest request)
        {
            var currentUser = await this._unitOfWork.Users.GetByIdAsync(id);

            if (currentUser == null)
            {
                throw new NotFoundException();
            }

            var userEntity = new User
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                Email = request.Email,
                Password = request.Password == null ? currentUser.Password : PasswordManager.HashPassword(request.Password),
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
