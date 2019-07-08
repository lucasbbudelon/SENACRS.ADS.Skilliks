using System.Linq;
using Domain.Contracts.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace WebApi
{
    public class Authentication
    {
        private readonly HttpRequest _request;
        private readonly IUserService _userService;

        public User User { get; }

        public bool UserLoggedIn
        {
            get
            {
                return User != null;
            }
        }

        public Authentication(HttpRequest request, IUserService userService)
        {
            _request = request;
            _userService = userService;

            var userLoggedIn = GetHeader("user-logged-in");

            User = _userService.GetAll().FirstOrDefault(x=>x.Email.Equals(userLoggedIn));
        }

        private string GetHeader(string key)
        {
            string value = string.Empty;

            if (_request.Headers.Any(x => x.Key.Equals(key)))
            {
                value = _request.Headers.FirstOrDefault(x => x.Key.Equals(key)).Value.ToString();
            }

            return value;
        }
    }
}
