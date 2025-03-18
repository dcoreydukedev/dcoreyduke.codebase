/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Interfaces.Auth;
using System.Collections.Generic;

namespace DCoreyDuke.CodeBase.Auth
{
    public class AuthRole : IAuthRole
    {
      
        private string? _name = string.Empty;
        private List<AuthPermission>? _permissions;

        private AuthRole()
        {
           
        }

        public AuthRole(string name) :this()
        {
            _name = name;
            _permissions = new List<AuthPermission>();
        }

        public AuthRole(string name, List<IAuthPermission> permissions) :this()
        {
            _name = name;
            _permissions = new List<AuthPermission>();
            foreach (var permission in permissions)
            {
                _permissions.Add(new AuthPermission(permission));
            }

        }

        public AuthRole(string name, List<AuthPermission> permissions) :this()
        {
            _name = name;
            _permissions = permissions;
        }

        public AuthRole(IAuthRole role) : this()
        {
            var _role = role as AuthRole;
            _name = _role.Name ?? string.Empty;
            _permissions = new List<AuthPermission>();
            foreach (var permission in _role.Permissions)
            {
                _permissions.Add(new AuthPermission(permission));
            }
        }

        public string Name
        {
            get
            {
                if(!string.IsNullOrEmpty(_name))
                {
                    return _name;
                }
                else
                {
                    return string.Empty;
                }
            }
           
        }

        public ICollection<AuthPermission> Permissions
        {
            get
            {
                if (_permissions != null && _permissions.Count > 0)
                {
                    return _permissions;
                }
                else
                {
                    return new List<AuthPermission>();
                }
            }
        }

        public void AddPermission(AuthPermission permission)
        {
            if (_permissions == null)
            {
                _permissions = new List<AuthPermission>();
            }
            _permissions.Add(permission);
        }
        public void RemovePermission(AuthPermission permission)
        {
            if (_permissions != null && _permissions.Count > 0)
            {
                _permissions.Remove(permission);
            }
        }
        public bool HasPermission(AuthPermission permission)
        {
            if (_permissions != null && _permissions.Count > 0)
            {
                return _permissions.Contains(permission);
            }
            else
            {
                return false;
            }
        }
    }
}
