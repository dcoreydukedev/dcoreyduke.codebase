/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Interfaces.Auth;
using System.Collections.Generic;
using System.Linq;

namespace DCoreyDuke.CodeBase.Auth
{
    public class AuthUser : IAuthUser
    {
        private readonly string? _username;
        private readonly string? _email;
        private readonly string? _password;
        private List<AuthRole>? _roles;
        private readonly AuthRole? _role;

        private AuthUser()
        {

        }

        public AuthUser(string username, string password) : this()
        {
            _username = username;
            _email = string.Empty;
            _password = password;
            _roles = new List<AuthRole>();
            _role = null;
        }

        public AuthUser(string username, string email, string password) : this()
        {
            _username = username;
            _email = email;
            _password = password;
            _roles = new List<AuthRole>();
            _role = null;
        }

        public AuthUser(string username, string email, string password, AuthRole role) : this()
        {
            _username = username;
            _email = email;
            _password = password;
            _role = _role;
            AddRole(role);
        }

        public AuthUser(string username, string email, string password, List<IAuthRole> roles) : this()
        {
            _username = username;
            _email = email;
            _password = password;
            _roles = new List<AuthRole>();
            foreach (var role in roles)
            {
                _roles.Add(new AuthRole(role));
            }

            _role = _roles.First();
        }

        public AuthUser(string username, string email, string password, List<AuthRole> roles) : this()
        {
            _username = username;
            _email = email;
            _password = password;
            _roles = roles;
            _role = _roles.First();
        }

        public AuthUser(IAuthUser user) : this()
        {
            var _user = user as AuthUser;
            _username = _user!.Username ?? string.Empty;
            _email = _user.Email ?? string.Empty;
            _password = _user.Password ?? string.Empty;
            _roles = new List<AuthRole>();
            foreach (var role in _user.Roles)
            {
                _roles.Add(new AuthRole(role));
            }
            _role = _roles.First();
        }

        public string Username
        {
            get
            {
                if (!string.IsNullOrEmpty(_username))
                {
                    return _username;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string Email
        {
            get
            {
                if (!string.IsNullOrEmpty(_email))
                {
                    return _email;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string Password
        {
            get
            {
                if (!string.IsNullOrEmpty(_password))
                {
                    return _password;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public ICollection<AuthRole> Roles
        {
            get
            {
                if (_roles != null)
                {
                    return _roles;
                }
                else
                {
                    return new List<AuthRole>();
                }
            }
        }

        public void AddRole(AuthRole role)
        {
            if (_roles == null)
            {
                _roles = new List<AuthRole>();
            }
            _roles.Add(role);
        }

        public void RemoveRole(AuthRole role)
        {
            if (_roles == null)
            {
                return;
            }
            _roles.Remove(role);
        }

        public bool HasRole(string roleName)
        {
            if(_roles == null)
            {
                return false;
            }
            foreach (var role in _roles)
            {
                if (role.Name == roleName)
                {
                    return true;
                }
            }
            return false;
        }

    }

}
