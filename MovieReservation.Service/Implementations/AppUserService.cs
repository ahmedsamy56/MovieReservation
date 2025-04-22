using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Data.Helpers;
using MovieReservation.Infrustructure.Context;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Service.Implementations
{
    public class AppUserService : IAppUserService
    {

        #region Fields
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailsService _emailsService;
        private readonly AppDbContext _applicationDBContext;
        #endregion

        #region Constructors
        public AppUserService(UserManager<AppUser> userManager,
                                      IHttpContextAccessor httpContextAccessor,
                                      IEmailsService emailsService,
                                      AppDbContext applicationDBContext)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _emailsService = emailsService;
            _applicationDBContext = applicationDBContext;
        }
        #endregion


        #region Functions
        public async Task<string> AddUserAsync(AppUser user, string password)
        {
            var trans = await _applicationDBContext.Database.BeginTransactionAsync();
            try
            {
                var existUser = await _userManager.FindByEmailAsync(user.Email);
                if (existUser != null) return "EmailIsExist";
                //Create
                var createResult = await _userManager.CreateAsync(user, password);
                if (!createResult.Succeeded)
                    return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());

                await _userManager.AddToRoleAsync(user, SD.UserRole);

                //Send Confirm  
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var resquestAccessor = _httpContextAccessor.HttpContext.Request;
                var returnUrl = resquestAccessor.Scheme + "://" + resquestAccessor.Host + $"/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
                var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation </a>";

                await _emailsService.SendEmail(user.Email, message, "ConFirm Email");

                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }


        public async Task<int> GetUsersCountAsync(DateTime? from, DateTime? to)
        {
            var query = _userManager.Users.AsQueryable();

            if (from.HasValue)
            {
                query = query.Where(u => u.CreatedAt >= from.Value);
            }

            if (to.HasValue)
            {
                query = query.Where(u => u.CreatedAt <= to.Value);
            }

            return await query.CountAsync();
        }
        #endregion
    }
}
