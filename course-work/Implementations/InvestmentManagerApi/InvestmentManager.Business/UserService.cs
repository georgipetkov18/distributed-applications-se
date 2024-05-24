﻿using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.User;
using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
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
            return new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
            };
        }

        public async Task<GetUsersResponse> GetUsersAsync()
        {
            var response = new GetUsersResponse() { Users = new() };
            var users = await _unitOfWork.Users.GetAllAsync();

            foreach (var user in users)
            {
                response.Users.Add(new()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                });
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
