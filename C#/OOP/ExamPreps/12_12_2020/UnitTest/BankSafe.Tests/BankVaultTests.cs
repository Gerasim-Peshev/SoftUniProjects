using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
            BankVault bankVault = new BankVault();
        }

        [Test]
        public void Ctor_Tests()
        {
            BankVault bankVault = new BankVault();
            Assert.AreEqual(new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            }, bankVault.VaultCells);
        }

        [Test]
        public void Add_Tests()
        {
            BankVault bankVault = new BankVault();

            Assert.Throws<ArgumentException> (()=>
            {
                bankVault.AddItem("C8", null);
            });

            bankVault.AddItem("C4", new Item("Misho", "4"));
            Assert.AreEqual(12, bankVault.VaultCells.Count);
            
            Assert.Throws<ArgumentException>(()=>
            {
                bankVault.AddItem("C4", new Item("Misho", "4"));
            });


            Assert.Throws<InvalidOperationException>(() =>
            {
                bankVault.AddItem("C2", new Item("Misho", "4"));
            });
        }

        [Test]
        public void Remove_Tests()
        {
            BankVault bankVault = new BankVault();
            bankVault.AddItem("A1", new Item("Misho", "1"));
            bankVault.AddItem("A2", new Item("Tony", "2"));

            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.RemoveItem("C8", new Item("Kotka", "6"));
            });
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.RemoveItem("A1", new Item("Tony", "2"));
            });
        }

        [Test]
        public void Successfull_Remove()
        {
            BankVault bankVault = new BankVault();
            bankVault.AddItem("A1", new Item("Misho", "1"));
            bankVault.RemoveItem("A1", new Item("Misho", "1"));
            Assert.AreSame(bankVault.VaultCells["A1"], null);
        }
    }
}