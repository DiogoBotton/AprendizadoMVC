using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMCV.Controllers {
    public class AbstractController : Controller {
        protected const string SESSION_CLIENTE_EMAIL = "cliente_email";
        protected const string SESSION_CLIENTE_NOME = "cliente_nome";
        protected const string SESSION_CLIENTE_TIPO = "cliente_tipo";

        protected string ObterUsuarioSession () {
            var tipoUsuario = HttpContext.Session.GetString (SESSION_CLIENTE_EMAIL);
            if (!string.IsNullOrEmpty (tipoUsuario)) {
                return tipoUsuario;
            }
            return "";
        }
        protected string ObterUsuarioTipoSession () {
            var emailCliente = HttpContext.Session.GetString (SESSION_CLIENTE_TIPO);
            if (!string.IsNullOrEmpty (emailCliente)) {
                return emailCliente;
            }
            return "";
        }
        protected string ObterUsuarioNomeSession () {
            var nomeCliente = HttpContext.Session.GetString (SESSION_CLIENTE_NOME);
            if (!string.IsNullOrEmpty (nomeCliente)) {
                return nomeCliente;
            }
            return "";
        }
    }
}