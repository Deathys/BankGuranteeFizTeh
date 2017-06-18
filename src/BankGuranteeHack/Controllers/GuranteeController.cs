using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankGuranteeHack.Contracts;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BankGuranteeHack.Controllers
{
    [Route("api/[controller]")]
    public class GuranteeController : Controller
    {
        // GET: api/values
        [HttpGet("contract")]
        public ContractInfo GetContract()
        {
            return new ContractInfo {
                Amount = 8544.36M,
                Description = "Закупка лекарственных препаратов, которые предназначены для назначения пациенту",
                Customer = new Customer
                {
                    Inn = "7707089084",
                    Kpp = "770701001",
                    Name = "ДЕПАРТАМЕНТ ЗДРАВООХРАНЕНИЯ ГОРОДА МОСКВЫ"
                },
                Producer = new Producer
                {
                    Inn = "7726311464",
                    Kpp = "774850001",
                    Name = "АО \"Р - Фарм\""
                }
            };
        }

        
        [HttpGet("conditions")]
        public List<BankCondition> GetBankConditions(int id)
        {


            return new List<BankCondition> {
                new BankCondition {
                    Id = Guid.NewGuid(),
                    BankName = "ОАО «Сбербанк России»",
                    Commission = 15,
                },
                new BankCondition {
                    Id = Guid.NewGuid(),
                    BankName = "ОАО «Альфа-банк»",
                    Commission = 13,
                },
                new BankCondition {
                    Id = Guid.NewGuid(),
                    BankName = "АО КБ «Модульбанк»",
                    Commission = 12,
                },
            };
        }

        // POST api/values
        [HttpPost("setbank/{bankId}")]
        public void SetBank([FromBody]Guid bankId)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
