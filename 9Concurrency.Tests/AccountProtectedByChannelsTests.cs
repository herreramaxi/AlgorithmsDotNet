using _9Concurency.BankingSystem;
using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace _9Concurrency.Tests
{
    public class AccountProtectedByChannelsTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void When_Amount_Is_Less_Or_Equal_To_Zero_Then_Deposit_Return_False(double amount)
        {
            //Arrange
            var account = new AccountProtectedByChannels(1000, "Magnus", "Carlsen");

            //Act
            var result = account.Deposit(amount);

            //Assert
            result.Should().BeFalse();
        }


        [Theory]
        //[InlineData(0.5)]
        [InlineData(100)]
        //[InlineData(1000)
        public void When_Amount_Is_Greater_Than_Zero_Then_Deposit_Return_True_And_Balance_Is_The_Expected(double amount)
        {
            //Arrange
            var initialBalance = 1000;
            var account = new AccountProtectedByChannels(1000, "Magnus", "Carlsen", 1000);

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
            var account = new AccountProtectedByChannels(1000, "Magnus", "Carlsen");

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
            var account = new AccountProtectedByChannels(1000, "Magnus", "Carlsen", initialBalance);

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
            var account = new AccountProtectedByChannels(1000, "Magnus", "Carlsen", initialBalance);

            //Act
            var result = account.Withdraw(amount);

            //Assert
            result.Should().BeTrue();
            account.UserBalance.Should().Be(initialBalance - amount);
        }
        [Fact]
        public void Test_Concurrent_Deposit_And_Withdraw()
        {
            var initialBalance = 1000.0;
            var iterations = 1000;
            var threadsCount = 10;
            var amount = 10.0;
            var account = new AccountProtectedByChannels(123, "John", "Doe", initialBalance);

            var depositTasks = new Task[threadsCount];
            var withdrawTasks = new Task[threadsCount];

            for (int i = 0; i < threadsCount; i++)
            {
                depositTasks[i] = Task.Run(async () =>
                {
                    for (int j = 0; j < iterations; j++)
                    {
                        account.Deposit(amount);
                    }
                });

                withdrawTasks[i] = Task.Run(async () =>
                {
                    for (int j = 0; j < iterations; j++)
                    {
                        account.Withdraw(amount);
                    }
                });
            }

            Task.WaitAll(depositTasks.Concat(withdrawTasks).ToArray());

            // Account balance should remain the same if operations were thread-safe

            account.UserBalance.Should().Be(initialBalance);
        }
    }
}
