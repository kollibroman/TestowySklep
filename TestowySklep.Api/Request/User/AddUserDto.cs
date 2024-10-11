namespace TestowySklep.Api.Request.User;

public record AddUserDto(int Id, string Name, string Email, int Age, bool IsMale);