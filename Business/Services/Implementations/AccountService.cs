﻿using MasterAuth.Business.Helpers.Interfaces;
using MasterAuth.Business.Services.Base;
using MasterAuth.Business.Services.Interfaces;
using MasterAuth.Core.Configurations;
using MasterAuth.Core.DTO.Account;
using MasterAuth.Core.Entities.Account;
using MasterAuth.Database.Repository.Interfaces;

namespace MasterAuth.Business.Services.Implementations
{
    internal class AccountService : ServiceBase, IAccountService
    {
        #region Properties

        //private readonly JwtSettings _jwtSettings;
        private readonly IEmailHelper _emailHelper;

        #endregion

        #region Constructor

        public AccountService(IUnitOfWork unitOfWork, JwtSettings jwtSettings, IEmailHelper emailHelper) : base(unitOfWork)
        {
            //_jwtSettings = jwtSettings;
            _emailHelper = emailHelper;
        }

        #endregion

        #region Interface Members

        public async Task RegisterAsync(RegisterDto registerModel, CancellationToken cancellationToken = default)
        {
            if (await UnitOfWork.Repository<User>().ExistAsync(i => i.Email == registerModel.Email, cancellationToken))
            {
                throw new Exception("User already exist");
            }

            await UnitOfWork.Repository<User>().CreateAsync(new User
            {
                Email = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Phone = registerModel.Phone,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerModel.Password),
            }, cancellationToken);

            await UnitOfWork.SaveChangesAsync();

            await _emailHelper.SendRegistrationEmailAsync(new UserDto
            {
                Email = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
            });
        }

        public async Task ConfirmRegistrationAsync(string registrationToken, CancellationToken cancellationToken = default)
        {
            var user = await UnitOfWork.Repository<User>().GetFirstAsync(i => i.EmailToken == registrationToken, i => i, cancellationToken);
            if (user == null)
            {
                // add custom exception;
                throw new Exception("Token is invalid");
            }
            user.ActivatedDate = DateTime.UtcNow;
            await UnitOfWork.SaveChangesAsync();
        }

        //public async Task<AuthResultDto> LoginAsync(AuthDto auth, CancellationToken cancellationToken = default)
        //{
        //    var user = await UnitOfWork.Repository<User>().GetFirstAsync(u => u.Email == auth.Email
        //                                                                && u.Group.Name == auth.GroupName,
        //        u => new UserDto
        //        {
        //            Id = u.Id,
        //            Email = u.Email,
        //            FirstName = u.FirstName,
        //            LastName = u.LastName,
        //            GroupId = u.Group.Id,
        //            GroupName = u.Group.Name,
        //            Phone = u.Phone,
        //            Role = u.Role,
        //            FacultyId = u.Group.FacultyId,
        //            OrganizationId = u.Group.Faculty.OrganizationId
        //        }, cancellationToken);

        //    if (user == null && !await VerifyPasswordAsync(user.Email, auth.Password))
        //    {
        //        return AuthResultDto.Fail;
        //    }

        //    var refreshString = GenerateRefreshToken();
        //    var lifeTimeUpdate = DateTime.UtcNow.AddMinutes(_jwtSettings.RefreshLifetime);

        //    var currentRefresh = await UnitOfWork.Repository<RefreshToken>().GetFirstAsync(rt => rt.UserId == user.Id, rt => rt, cancellationToken);

        //    if (currentRefresh != null)
        //    {
        //        currentRefresh.Update(refreshString, lifeTimeUpdate);
        //        await UnitOfWork.Repository<RefreshToken>().UpdateAsync(currentRefresh);
        //    }
        //    else
        //    {
        //        await UnitOfWork.Repository<RefreshToken>().CreateAsync(new RefreshToken
        //        {
        //            Token = refreshString,
        //            UserId = user.Id,
        //            ExpiryTime = lifeTimeUpdate
        //        });
        //    }

        //    await UnitOfWork.SaveChangesAsync();

        //    return new AuthResultDto
        //    {
        //        Status = ActionStatus.Success,
        //        JwtToken = GenereteAccessToken(user),
        //        RefreshToken = refreshString,
        //        RefreshExpiry = lifeTimeUpdate,
        //        User = user
        //    };
        //}

        //public async Task<AuthResultDto> UpdateRefreshTokenAsync(TokenUpdateDto tokenPair, CancellationToken cancellationToken = default)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var claimsPrincipal = tokenHandler.ValidateToken(tokenPair.AccessToken, new TokenValidationParameters
        //    {
        //        ValidIssuer = _jwtSettings.Issuer,
        //        ValidAudience = _jwtSettings.Audience,
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Key)),
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateIssuerSigningKey = true,
        //        ValidateLifetime = false,
        //    },
        //    out SecurityToken validatedToken);

        //    var jwt = validatedToken as JwtSecurityToken;
        //    var refreshInstance = await UnitOfWork.Repository<RefreshToken>().GetFirstAsync(i => i.Token == tokenPair.RefreshToken, i => i, cancellationToken);
        //    var isUserIdValid = Guid.TryParse(claimsPrincipal?.FindFirst("Id")?.Value, out Guid UserId);
        //    var userInstance = await UnitOfWork.Repository<User>().GetFirstAsync(i => i.Id == UserId, i => new UserDto
        //    {
        //        Id = i.Id,
        //        Email = i.Email,
        //        GroupId = i.GroupId,
        //        Role = i.Role
        //    }, cancellationToken);

        //    ValidateTokens(jwt, refreshInstance, UserId);

        //    if (!isUserIdValid)
        //    {
        //        throw new SecurityTokenException("Invalid claims.");
        //    }

        //    if (userInstance == null)
        //    {
        //        // Item not found exception
        //        throw new Exception("User doesn't exist");
        //    }

        //    if (refreshInstance.ExpiryTime < DateTime.UtcNow)
        //    {
        //        await UnitOfWork.Repository<RefreshToken>().DeleteAsync(i => i.Id == refreshInstance.Id, cancellationToken);
        //        await UnitOfWork.SaveChangesAsync();
        //    }

        //    return await Authenticate(userInstance, claimsPrincipal.Claims.ToArray());
        //}

        #endregion

        #region Helpers

        private async Task<bool> VerifyPasswordAsync(string email, string password)
        {
            var userPassword = await UnitOfWork.Repository<User>().GetFirstAsync(i => i.Email == email, i => i.PasswordHash);
            return BCrypt.Net.BCrypt.Verify(password, userPassword);
        }

        //private void ValidateTokens(JwtSecurityToken jwt, RefreshToken refresh, Guid userId)
        //{
        //    if (jwt == null || !jwt.Header.Alg.Equals(SecurityAlgorithms.EcdsaSha512))
        //    {
        //        throw new SecurityTokenException("Received jwt is invalid");
        //    }

        //    if (refresh == null)
        //    {
        //        throw new SecurityTokenException("Received refresh is invalid");
        //    }

        //    if (refresh.UserId != userId)
        //    {
        //        throw new SecurityTokenException("Received refresh token doesn't match user");
        //    }
        //}

        //private async Task<AuthResultDto> Authenticate(UserDto user, Claim[] claims)
        //{
        //    var accessString = GenereteAccessToken(user, claims);
        //    var refreshString = GenerateRefreshToken();
        //    var lifeTimeUpdate = DateTime.UtcNow.AddMinutes(_jwtSettings.RefreshLifetime);

        //    var refreshInstance = await UnitOfWork.Repository<RefreshToken>().GetFirstAsync(i => i.UserId == user.Id, i => i);
        //    if (refreshInstance != null)
        //    {
        //        refreshInstance.Update(refreshString, lifeTimeUpdate);
        //        await UnitOfWork.Repository<RefreshToken>().UpdateAsync(refreshInstance);
        //        await UnitOfWork.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        throw new SecurityTokenException("Refresh token doesn't match user.");
        //    }

        //    return new AuthResultDto
        //    {
        //        Status = ActionStatus.Success,
        //        JwtToken = accessString,
        //        RefreshToken = refreshString,
        //        RefreshExpiry = lifeTimeUpdate
        //    };
        //}

        //private string GenereteAccessToken(UserDto user, Claim[] claims = default)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var tokenDescriptor = new SecurityTokenDescriptor()
        //    {
        //        Subject = new ClaimsIdentity(claims ?? new Claim[]
        //        {
        //            new Claim(Constants.Claims.UserId, user.Id.ToString()),
        //            new Claim(Constants.Claims.GroupId, user.GroupId.ToString()),
        //            new Claim(ClaimTypes.Email, user.Email),
        //            new Claim(ClaimTypes.Role, user.Role.ToString()),
        //            new Claim(Constants.Claims.FacultyId, user.FacultyId.ToString()),
        //            new Claim(Constants.Claims.OrganizationId, user.OrganizationId.ToString())
        //        }),
        //        Audience = _jwtSettings.Audience,
        //        Issuer = _jwtSettings.Issuer,
        //        Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.Lifetime),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Key)), SecurityAlgorithms.HmacSha512)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

        //private string GenerateRefreshToken()
        //{
        //    var randomNumber = new byte[32];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(randomNumber);
        //        return Convert.ToBase64String(randomNumber);
        //    }
        //}

        #endregion
    }
}
