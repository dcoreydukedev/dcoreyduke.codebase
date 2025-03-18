/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Interfaces.Auth;

namespace DCoreyDuke.CodeBase.Auth
{
    public class AuthPermission : IAuthPermission
    {
        private string? _name;

        private AuthPermission()
        {
        }

        public AuthPermission(string name) :this()
        {
            _name = name;
        }

        public AuthPermission(IAuthPermission permission) : this()
        {
            var _permission = permission as AuthPermission;
            _name = _permission!.Name ?? string.Empty;
        }

        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(_name))
                {
                    return _name;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }

}
