namespace InvestmentManagerApi.Business.Responses.User
{
    public class UserResponse
    {
        required public Guid Id { get; set; }
        required public string FirstName { get; set; }
        required public string LastName { get; set; }
        public int? Age { get; set; }

        public static UserResponse FromEntity(Data.Entities.User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
            };
        }
    }
}
