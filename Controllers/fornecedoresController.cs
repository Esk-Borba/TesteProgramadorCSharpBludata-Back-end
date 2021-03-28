using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using testeProgramadorCSharp.Models;

namespace testeProgramadorCSharp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods:"*")]
    public class fornecedoresController : ApiController
    {
        // GET: api/fornecedores
        public IEnumerable<dynamic> Get()
        {
            using(testeProgramadorCSharpEntities bd = new testeProgramadorCSharpEntities())
            {
                var fornecedores = from forn in bd.fornecedores
                                   select new { forn.id, forn.empresa, nomeEmpresa = forn.empresas.nome_fantasia, forn.nome_fornecedor, forn.cpf_cnpj, forn.data_hora_cadastro, forn.telefone, forn.tipo_pessoa, forn.rg, forn.data_nascimento };
                return fornecedores.ToList();
            }

        }

        // GET: api/fornecedores/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/fornecedores
        public string Post([FromBody]fornecedores fornecedores)
        {
            using (testeProgramadorCSharpEntities bd = new testeProgramadorCSharpEntities())
            {
                bd.fornecedores.Add(fornecedores);
                bd.SaveChanges();
                return "Fornecedor salvo com sucesso";
            }
        }

        // PUT: api/fornecedores/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/fornecedores/5
        public void Delete(int id)
        {
        }
    }
}
