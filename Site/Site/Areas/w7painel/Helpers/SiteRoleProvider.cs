using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Site.Models;

namespace Site.Areas.w7painel.Helpers
{
    public class SiteRoleProvider : RoleProvider
    {
        private readonly SiteContext contexto;

        public SiteRoleProvider()
        {
            contexto = new SiteContext();
        }

        public override string[] GetRolesForUser(string username)
        {
            var usuarioLogado = contexto.Usuarios
                .Include("Grupo")
                .FirstOrDefault(u => u.Login == username);

            if (usuarioLogado == null)
                return new string[] { string.Empty };

            var permissoes = contexto.Grupos.Include("Permissoes").FirstOrDefault(x => x.Id == usuarioLogado.Grupo.Id).Permissoes.ToList();

            var retorno = new string[permissoes.Count];
            var i = 0;
            foreach (var permissao in permissoes)
            {
                retorno[i] = permissao.Chave;
                i++;
            }

            return retorno;

        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        #region Metodos não implementados

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}