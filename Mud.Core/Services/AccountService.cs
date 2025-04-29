using Mud.Core.Dto.Account;
using Mud.Core.Entities;
using Mud.Core.IRepositories;
using Mud.Core.IServices;
using Mud.Core.Exceptions;

namespace Mud.Core.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITokenService _tokenService;

    public AccountService(IAccountRepository accountRepository, ITokenService tokenService)
    {
        _accountRepository = accountRepository;
        _tokenService = tokenService;
    }

    public async Task<AccountResponse> RegisterAsync(RegisterDto registerDto)
    {
        if (await _accountRepository.UsernameExistsAsync(registerDto.Username))
        {
            Console.WriteLine($"Account with that username already exists. Username: {registerDto.Username}");
            throw new AlreadyExistsException($"Username already exists. Username: {registerDto.Username}");
        }
            
        string hash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

        var account = new Account()
        {
            Username = registerDto.Username.ToLower(),
            PasswordHash = hash
        };

        var createdAcc = await _accountRepository.AddAsync(account);

        if (!await _accountRepository.IsSavedAsync())
            throw new DbSavingFailedException("Failed to save account to the database.");
            
        string token = _tokenService.GenerateToken(createdAcc);

        return createdAcc.ToResponse(token);
    }
        
    public async Task<AccountResponse> LoginAsync(LoginDto loginDto)
    {
        var existingAcc = await _accountRepository.GetByUsernameAsync(loginDto.Username)
                          ?? throw new UnauthorizedAccessException("Username or password is invalid.");
            
        var hash = BCrypt.Net.BCrypt.HashPassword(loginDto.Password, existingAcc.PasswordHash);
            
        if (existingAcc.PasswordHash != hash)
            throw new UnauthorizedAccessException("Username or password is invalid.");
            
        string token = _tokenService.GenerateToken(existingAcc);
            
        return existingAcc.ToResponse(token);
    }
}