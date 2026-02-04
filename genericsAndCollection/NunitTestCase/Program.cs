using NUnit.Framework;
using System;

[TestFixture] // Required attribute for test class
public class UnitTest
{
    // Test for valid deposit amount
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        // Arrange
        Program account = new Program(1000m);

        // Act
        account.Deposit(500m);

        // Assert (only ONE assert as required)
        Assert.AreEqual(1500m, account.Balance);
    }

    // Test for negative deposit amount
    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        // Arrange
        Program account = new Program(1000m);

        // Act & Assert (exception expected)
        Assert.AreEqual(
            "Deposit amount cannot be negative",
            Assert.Throws<Exception>(() => account.Deposit(-200m))!.Message
        );
    }

    // Test for valid withdrawal amount
    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        // Arrange
        Program account = new Program(1000m);

        // Act
        account.Withdraw(400m);

        // Assert (only ONE assert)
        Assert.AreEqual(600m, account.Balance);
    }

    // Test for withdrawal with insufficient funds
    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        // Arrange
        Program account = new Program(500m);

        // Act & Assert (exception expected)
        Assert.AreEqual(
            "Insufficient funds.",
            Assert.Throws<Exception>(() => account.Withdraw(800m))!.Message
        );
    }
}
