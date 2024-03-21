using _9Concurency.BankingSystem;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace _9Concurrency.Tests
{
    public class Tests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void When_Amount_Is_Less_Or_Equal_To_Zero_Then_Deposit_Return_False(double amount)
        {
            //Arrange
            var account = new AccountNoProtected(1000, "Magnus", "Carlsen");

            //Act
            var result = account.Deposit(amount);

            //Assert
            result.Should().BeFalse();
        }


        [Theory]
        [InlineData(0.5)]
        [InlineData(100)]
        [InlineData(1000)]
        public void When_Amount_Is_Greater_Than_Zero_Then_Deposit_Return_True_And_Balance_Is_The_Expected(double amount)
        {
            //Arrange
            var initialBalance = 1000;
            var account = new AccountNoProtected(1000, "Magnus", "Carlsen", 1000);

            //Act
            var result = account.Deposit(amount);

            //Assert
            result.Should().BeTrue();
            account.UserBalance.Should().Be(initialBalance + amount);
        }

        [Fact]
        public void When_UserBalance_Is_Zero_Then_Withdraw_Return_False()
        {
            //Arrange
            var account = new AccountNoProtected(1000, "Magnus", "Carlsen");

            //Act
            var result = account.Withdraw(1);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void When_Amount_Is_Greater_Than_Balance_Then_Withdraw_Return_False()
        {
            //Arrange
            var initialBalance = 1000;
            var account = new AccountNoProtected(1000, "Magnus", "Carlsen", initialBalance);

            //Act
            var result = account.Withdraw(initialBalance + 100);

            //Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(500)]
        [InlineData(5)]
        public void When_Amount_Is_Less_Or_Equal_To_Balance_Then_Withdraw_Return_True_And_Balance_Is_The_Expected(double amount)
        {
            //Arrange
            var initialBalance = 1000;
            var account = new AccountNoProtected(1000, "Magnus", "Carlsen", initialBalance);

            //Act
            var result = account.Withdraw(amount);

            //Assert
            result.Should().BeTrue();
            account.UserBalance.Should().Be(initialBalance - amount);
        }

        [Fact]
        public async Task WhenMultipleWithdrawsOccurAtTheSameTime_The_UserBalance_Get_Corrupted()
        {
            //Arrange
            var initialBalance = 5000;
            var withdrawAmount = 10;
            var account = new AccountNoProtected(1000, "Magnus", "Carlsen", initialBalance);
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
            results.Count(x => x == true).Should().BeGreaterThan(500);
        }
    }
}