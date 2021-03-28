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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class empresasController : ApiController
    {
        // GET: api/empresas
        public IEnumerable<dynamic> Get()
        {
            using(testeProgramadorCSharpEntities bd = new testeProgramadorCSharpEntities())
            {
                var empresas = from emp in bd.empresas
                               select new { emp.id, emp.uf, emp.nome_fantasia, emp.cnpj };
                return empresas.ToList();
            }
        }

        // GET: api/empresas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/empresas
        public string Post([FromBody]empresas empresas)
        {
            using(testeProgramadorCSharpEntities bd = new testeProgramadorCSharpEntities())
            {
                bd.empresas.Add(empresas);
                bd.SaveChanges();
                return "Empresa salva com sucesso";
            }
        }

        // PUT: api/empresas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/empresas/5
        public void Delete(int id)
        {
        }
    }
}
