using _9Concurency.BankingSystem;
using FluentAssertions;
using System;
using System.Linq;
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
            var accountTypes = (AccountType[])Enum.GetValues(typeof(AccountType));

            foreach (var accountType in accountTypes)
            {
                //Arrange
                var account = AccountFactory.Create(accountType, 1000, "Magnus", "Carlsen");

                //Act
                var result = account.Deposit(amount);

                //Assert
                result.Should().BeFalse();
            }
        }


        [Theory]
        [InlineData(0.5)]
        [InlineData(100)]
        [InlineData(1000)]
        public void When_Amount_Is_Greater_Than_Zero_Then_Deposit_Return_True_And_Balance_Is_The_Expected(double amount)
        {
            var accountTypes = (AccountType[])Enum.GetValues(typeof(AccountType));

            foreach (var accountType in accountTypes)
            {
                //Arrange
                var initialBalance = 1000;
                var account = AccountFactory.Create(accountType, 1000, "Magnus", "Carlsen", 1000);

                //Act
                var result = account.Deposit(amount);

                //Assert
                result.Should().BeTrue();
                account.UserBalance.Should().Be(initialBalance + amount);
            }
        }

        [Fact]
        public void When_UserBalance_Is_Zero_Then_Withdraw_Return_False()
        {
            var accountTypes = (AccountType[])Enum.GetValues(typeof(AccountType));

            foreach (var accountType in accountTypes)
            {
                //Arrange
                var account = AccountFactory.Create(accountType, 1000, "Magnus", "Carlsen");

                //Act
                var result = account.Withdraw(1);

                //Assert
                result.Should().BeFalse();
            }
        }

        [Fact]
        public void When_Amount_Is_Greater_Than_Balance_Then_Withdraw_Return_False()
        {
            var accountTypes = (AccountType[])Enum.GetValues(typeof(AccountType));

            foreach (var accountType in accountTypes)
            {
                //Arrange
                var initialBalance = 1000;
                var account = AccountFactory.Create(accountType, 1000, "Magnus", "Carlsen", initialBalance);

                //Act
                var result = account.Withdraw(initialBalance + 100);

                //Assert
                result.Should().BeFalse();
            }
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(500)]
        [InlineData(5)]
        public void When_Amount_Is_Less_Or_Equal_To_Balance_Then_Withdraw_Return_True_And_Balance_Is_The_Expected(double amount)
        {
            var accountTypes = (AccountType[])Enum.GetValues(typeof(AccountType));

            foreach (var accountType in accountTypes)
            {
                //Arrange
                var initialBalance = 1000;
                var account = AccountFactory.Create(accountType, 1000, "Magnus", "Carlsen", initialBalance);

                //Act
                var result = account.Withdraw(amount);

                //Assert
                result.Should().BeTrue();
                account.UserBalance.Should().Be(initialBalance - amount);
            }
        }

        [Fact]
        public void Test_Concurrent_Deposit_And_Withdraw()
        {
            var accountTypes = (AccountType[])Enum.GetValues(typeof(AccountType));

            foreach (var accountType in accountTypes)
            {
                const int initialBalance = 1000;
                const int iterations = 1000;
                const int threadsCount = 10;
                var account = AccountFactory.Create(accountType, 123, "John", "Doe", initialBalance);

                var depositTasks = new Task[threadsCount];
                var withdrawTasks = new Task[threadsCount];

                for (int i = 0; i < threadsCount; i++)
                {
                    depositTasks[i] = Task.Run(() =>
                    {
                        for (int j = 0; j < iterations; j++)
                        {
                            account.Deposit(10);
                        }
                    });

                    withdrawTasks[i] = Task.Run(() =>
                    {
                        for (int j = 0; j < iterations; j++)
                        {
                            account.Withdraw(10);
                        }
                    });
                }

                Task.WaitAll(depositTasks.Concat(withdrawTasks).ToArray());

                if (account is AccountProtectedByChannels accountProtectedByChannels)
                {
                    accountProtectedByChannels.CompleteWriterChannel();
                }

                if (account is AccountNoProtected)
                {
                    Assert.NotEqual(initialBalance, account.UserBalance);
                    return;
                }
                
                // Account balance should remain the same if operations were thread-safe
                Assert.Equal(initialBalance, account.UserBalance);
            }
        }
    }
}