using System;
using System.Collections.Generic;

namespace TransactionalTransferSystem
{
    internal static class Program
    {
        private static void Main()
        {
            BankService bank = new BankService();

            bank.CreateAccount("A1", 5000);
            bank.CreateAccount("A2", 2000);

            try
            {
                bank.Transfer("A1", "A2", 1500);
                Console.WriteLine("Transfer successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Transfer failed: {ex.Message}");
            }

            bank.PrintBalances();
            bank.PrintAuditLog();
        }
    }

    // ===================== DOMAIN MODEL =====================

    internal sealed class BankAccount
    {
        public string AccountId { get; }
        public decimal Balance { get; private set; }

        public BankAccount(string id, decimal balance)
        {
            AccountId = id;
            Balance = balance;
        }

        public void Debit(decimal amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException();

            if (Balance < amount)
                throw new InsufficientFundsException();

            Balance -= amount;
        }

        public void Credit(decimal amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException();

            Balance += amount;
        }
    }

    // ===================== SERVICE =====================

    internal sealed class BankService
    {
        private readonly Dictionary<string, BankAccount> _accounts =
            new Dictionary<string, BankAccount>();

        private readonly List<AuditEntry> _auditLog =
            new List<AuditEntry>();

        private readonly object _lock = new object();

        public void CreateAccount(string id, decimal initialBalance)
        {
            _accounts[id] = new BankAccount(id, initialBalance);
        }

        // Atomic money transfer with rollback
        public void Transfer(string fromAcc, string toAcc, decimal amount)
        {
            if (!_accounts.ContainsKey(fromAcc) || !_accounts.ContainsKey(toAcc))
                throw new AccountNotFoundException();

            lock (_lock) // ensures atomicity
            {
                BankAccount source = _accounts[fromAcc];
                BankAccount destination = _accounts[toAcc];

                decimal sourceOriginalBalance = source.Balance;
                decimal destinationOriginalBalance = destination.Balance;

                try
                {
                    // Step 1: Debit
                    source.Debit(amount);

                    // Step 2: Credit
                    destination.Credit(amount);

                    // Record success
                    AddAudit(fromAcc, toAcc, amount, "SUCCESS");
                }
                catch (Exception)
                {
                    // Rollback to original balances
                    RestoreBalance(source, sourceOriginalBalance);
                    RestoreBalance(destination, destinationOriginalBalance);

                    AddAudit(fromAcc, toAcc, amount, "FAILED");

                    throw;
                }
            }
        }

        private static void RestoreBalance(BankAccount account, decimal original)
        {
            typeof(BankAccount)
                .GetProperty(nameof(BankAccount.Balance))
                ?.SetValue(account, original);
        }

        private void AddAudit(
            string from,
            string to,
            decimal amount,
            string status)
        {
            _auditLog.Add(new AuditEntry(
                from,
                to,
                amount,
                status,
                DateTime.UtcNow));
        }

        public void PrintBalances()
        {
            Console.WriteLine("\nAccount Balances:");
            foreach (var acc in _accounts.Values)
            {
                Console.WriteLine($"{acc.AccountId} : {acc.Balance}");
            }
        }

        public void PrintAuditLog()
        {
            Console.WriteLine("\nAudit Log:");
            foreach (var entry in _auditLog)
            {
                Console.WriteLine(entry);
            }
        }
    }

    // ===================== AUDIT =====================

    internal sealed class AuditEntry
    {
        public string FromAccount { get; }
        public string ToAccount { get; }
        public decimal Amount { get; }
        public string Status { get; }
        public DateTime Timestamp { get; }

        public AuditEntry(
            string from,
            string to,
            decimal amount,
            string status,
            DateTime timestamp)
        {
            FromAccount = from;
            ToAccount = to;
            Amount = amount;
            Status = status;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return $"{Timestamp:u} | {FromAccount} -> {ToAccount} | {Amount} | {Status}";
        }
    }

    // ===================== CUSTOM EXCEPTIONS =====================

    internal sealed class InsufficientFundsException : Exception
    {
        public InsufficientFundsException()
            : base("Insufficient balance") { }
    }

    internal sealed class InvalidAmountException : Exception
    {
        public InvalidAmountException()
            : base("Amount must be greater than zero") { }
    }

    internal sealed class AccountNotFoundException : Exception
    {
        public AccountNotFoundException()
            : base("Account not found") { }
    }
}
