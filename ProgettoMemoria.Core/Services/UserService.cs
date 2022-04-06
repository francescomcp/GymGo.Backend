using GymGo.Core.Helpers;
using GymGo.Gateway.Models.User;
using GymGo.Gateway.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GymGo.Core.Services;

public interface IUserService
{
    Task<List<User>> GetAll();
    Task Save(PostUserRequest user);
    Task<User> GetById(string id);
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
}
public class UserService : IUserService
{
    public IUserRepository _repository;
    public AppSettings _appSettings;

    public UserService(IUserRepository repository, AppSettings appsettings)
    {
        _repository = repository;
        _appSettings = appsettings;
    }
    
    public Task<List<User>> GetAll() => _repository.GetAll();

    public async Task<User> GetById(string id) => await _repository.GetById(id);

    public async Task Save(PostUserRequest user) => await _repository.Save(user);

    public async Task<AuthenticateResponse>? Authenticate(AuthenticateRequest model)
    {
        var user = await _repository.Authenticate(model.Username, model.Password);

        // ritorno null se non trovo l'utente
        if (user == null) return null;

        // se l'autenticazione va a buon fine, ritorno un oggetto AuthenticateResponse
        var token = generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    private string generateJwtToken(User user)
    {
        // genero un token JWT valido per 7 giorni
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
