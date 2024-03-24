using _9Concurency.BankingSystem;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace _9Concurrency.Tests
{
    public class AccountWithLockTests
    {
        [Fact]
        public void Test_Concurrent_Deposit_And_Withdraw()
        {
            var initialBalance = 1000.0;
            var threadsCount = 10;
            var iterations = 1000;
            var amount = 10.0;
            var depositTasks = new Task[threadsCount];
            var withdrawTasks = new Task[threadsCount];
            var account = new AccountWithLock(1234, "Magnus", "Carlsen", initialBalance);

            for (var i = 0; i < threadsCount; i++)
            {
                depositTasks[i] = Task.Run(() =>
                {
                    for (var j = 0; j < iterations; j++)
                    {
                        account.Deposit(amount);
                    }
                });

                withdrawTasks[i] = Task.Run(() =>
                {
                    for (var j = 0; j < iterations; j++)
                    {
                        account.Withdraw(amount);
                    }
                });
            }

            Task.WaitAll(depositTasks.Concat(withdrawTasks).ToArray());

            initialBalance.Should().Be(account.UserBalance);
        }

        [Fact]
        public async Task WhenMultipleWithdrawsOccurAtTheSameTime_The_UserBalance_Get_Corrupted()
        {
            //Arrange
            var initialBalance = 5000;
            var withdrawAmount = 10;
            var account = new AccountWithLock(1000, "Magnus", "Carlsen", initialBalance);
            var tasks = new List<Task<bool>>();

            for (var i = 0; i < 600; i++)
            {
                var task = Task.Run(() =>
                {
                    return account.Withdraw(withdrawAmount);
                    //for (var j = 0; j < 5; j++)
                    //{
                    //    Thread.Sleep(5);
                    //    var internalResult = account.Withdraw(withdrawAmount);
                    //    if (!internalResult) return false;
                    //}

                    //return true;
                });
                tasks.Add(task);
            }

            //Act
            var results = await Task.WhenAll(tasks);

            //Assert
            results.Count(x => x == true).Should().Be(500);
        }
    }
}
