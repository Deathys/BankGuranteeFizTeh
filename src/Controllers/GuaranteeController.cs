﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankGuranteeHack.Contracts;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BankGuranteeHack.Controllers
{
    [Route("api/[controller]")]
    public class GuaranteeController : Controller
    {
        // GET: api/values
        [HttpGet("contract/{contract}")]
        public ContractInfo GetContract(string contract)
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

        [HttpPost("setbank/{bankId}")]
        public Guid SetBank(Guid bankId)
        {
            return Guid.NewGuid();
        }

        [HttpGet("pay/{applicationId}")]
        public string Pay(Guid applicationId)
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
