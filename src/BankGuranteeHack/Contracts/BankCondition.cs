using System;

namespace BankGuranteeHack.Contracts
{
    public class BankCondition
    {
        public Guid Id { get; set; }
        public string BankName { get; set; }
        public int Commission { get; set; }
    }
}
