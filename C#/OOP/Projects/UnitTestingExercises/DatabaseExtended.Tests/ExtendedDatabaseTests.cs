using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using System;
    using ExtendedDatabase;


    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestConstructorSourceData")]
        public void Constructor_Should_Create_Database_Positive_Test(
            Person[] people,
            int expectedCount)
        {
            Database database = new Database(people);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestAddSourceData")]
        public void Add_Should_Add_Database_Positive_Test(
            Person[] peopleCtor,
            Person[] peopleAdd,
            int expectedCount)
        {
            Database database = new Database(peopleCtor);

            foreach (var person in peopleAdd)
            {
                database.Add(person);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestAddSourceDataInvalide")]
        public void Add_Should_Return_InvalidOperationExeption_NegativeTest(
            Person[] peopleCtor,
            Person[] peopleAdd)
        {
            Database database = new Database(peopleCtor);
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var person in peopleAdd)
                {
                    database.Add(person);
                }
            });
        }

        [TestCaseSource("TestCaseRemoveData")]
        public void Remove_Should_Remove_With_Valid_Data_Positive_Test(
            Person[] peopleCtor,
            Person[] peopleAdd,
            int expected)
        {
            Database database = new Database(peopleCtor);

            foreach (var person in peopleAdd)
            {
                database.Add(person);
            }

            database.Remove();

            Assert.AreEqual(expected, database.Count);
        }

        [TestCaseSource("TestCaseRemoveData")]
        public void Remove_Should_Remove_Empty_Database_Negative_Test(
            Person[] peopleCtor,
            Person[] peopleAdd,
            int expected)
        {
            Database database = new Database(peopleCtor);

            foreach (var person in peopleAdd)
            {
                database.Add(person);
            }

            database.Remove();
            database.Remove();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCaseSource("TestCaseFindByUsername")]
        public void Find_By_Username_Valid_Data_Positive_Test(
            Person[] peopleCtor,
            Person personToFind)
        {
            Database database = new Database(peopleCtor);

            var result = database.FindByUsername(personToFind.UserName);

            Assert.AreEqual(personToFind.UserName, result.UserName);
        }

        [TestCaseSource("TestCaseFindByUsernameInvalid")]
        public void Find_By_Username_Valid_Data_Negative_Test(
            Person[] peopleCtor,
            Person personToFind)
        {
            Database database = new Database(peopleCtor);

            Assert.Throws<InvalidOperationException>(() =>
            {
                var result = database.FindByUsername(personToFind.UserName);
            });
        }

        [Test]
        public void Find_By_Username_Valid_Data_Negative_Test2()
        {
            Database database = new Database(new Person[] {new Person(1, "Miho")});



            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            });
        }

        [TestCaseSource("TestCaseFindById")]
        public void Find_By_Id_Positive_Test(
            Person[] peopleCtor,
            Person personToFind)
        {
            Database database = new Database(peopleCtor);

            var result = database.FindById(personToFind.Id);

            Assert.AreEqual(personToFind.Id, result.Id);
        }

        [Test]
        public void Find_By_Id_ArgumentOutExeption_Negative_Test()
        {
            Database database = new Database(new Person[] {new Person(1, "Miho")});

            var person = new Person(-4, "Johny");

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(person.Id);
            });
        }

        [Test]
        public void Find_By_Id_InvalidOperationExeption_Negative_Test()
        {
            Database database = new Database(new Person[] {new Person(1, "Miho")});

            var person = new Person(4, "Mike");

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(person.Id);
            });
        }

        [Test]
        public void AddRange_Return_ArgumentExeption_Negative_Test()
        {
            var people = new Person[]
            {
                new Person(3, "Miho2"),
                new Person(4, "Dony2"),
                new Person(5, "Dony3"),
                new Person(6, "Dony4"),
                new Person(7, "Dony5"),
                new Person(8, "Dony6"),
                new Person(9, "Dony7"),
                new Person(10, "Dony8"),
                new Person(11, "Dony9"),
                new Person(12, "Miho10"),
                new Person(13, "Dony11"),
                new Person(14, "Dony12"),
                new Person(15, "Dony13"),
                new Person(16, "Dony14"),
                new Person(17, "Dony15"),
                new Person(18, "Dony16"),
                new Person(19, "Dony17"),
                new Person(20, "Dony18"),
            };

            Assert.Throws<ArgumentException>(() =>
            {
                Database database = new Database(people);
            });
        }

        [Test]
        public void AddRange_Return_Positive_Test()
        {
            var people = new Person[]
            {
                new Person(1, "Miho"),
                new Person(2, "Tony"),
                new Person(3, "Meet"),
                new Person(4, "You")
            };
            Database database = new Database(people);

            Assert.AreEqual(4, database.Count);
        }

        public static IEnumerable<TestCaseData> TestCaseFindById()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Miho"),
                        new Person(2, "Tony"),
                        new Person(3, "Meet"),
                        new Person(4, "You")
                    },
                    new Person(4, "You")
                ),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Miho"),
                        new Person(2, "Tony"),
                        new Person(3, "Meet"),
                        new Person(4, "You")
                    },
                    new Person(3, "Meet")
                )
            };

            foreach (var testCaseData in testCases)
            {
                yield return testCaseData;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseFindByUsernameInvalid()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Miho"),
                        new Person(2, "Tony"),
                        new Person(3, "Meet"),
                        new Person(4, "You")
                    },
                    new Person(5, "Ataka")
                ),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Miho"),
                        new Person(2, "Tony"),
                        new Person(3, "Meet"),
                        new Person(4, "You")
                    },
                    new Person(6, "Mix")
                )
            };

            foreach (var testCaseData in testCases)
            {
                yield return testCaseData;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseFindByUsername()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Miho"),
                        new Person(2, "Tony"),
                        new Person(3, "Meet"),
                        new Person(4, "You")
                    },
                    new Person(4, "You")
                ),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Miho"),
                        new Person(2, "Tony"),
                        new Person(3, "Meet"),
                        new Person(4, "You")
                    },
                    new Person(3, "Meet")
                )
            };

            foreach (var testCaseData in testCases)
            {
                yield return testCaseData;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseRemoveData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Miho")
                    },
                    new Person[]
                    {
                        new Person(3,"Miho2"),


                    },
                    1
                    ),
                new TestCaseData(
                    new Person[]
                    {

                    },
                    new Person[]
                    {
                        new Person(3,"Miho2"),
                        new Person(4, "Dony2"),
                    },
                    1
                ),
                new TestCaseData(
                    new Person[]
                    {

                    },
                    new Person[]
                    {
                        new Person(1,"Miho"),
                        new Person(2, "Tony")
                    },
                    1
                    )
            };

            foreach (var testCaseData in testCases)
            {
                yield return testCaseData;
            }
        }

        public static IEnumerable<TestCaseData> TestAddSourceDataInvalide()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Miho"),
                        new Person(2, "Dony")
                    },
                    new Person[]
                    {
                        new Person(3,"Miho2"),
                        new Person(4, "Dony2"),
                        new Person(5, "Dony2"),
                        new Person(6, "Dony2"),
                        new Person(7, "Dony2"),
                        new Person(8, "Dony2"),
                        new Person(9, "Dony2"),
                        new Person(10, "Dony2"),
                        new Person(11, "Dony2"),

                    }
                    ),
                new TestCaseData(
                    new Person[]
                    {

                    },
                    new Person[]
                    {
                        new Person(3,"Miho2"),
                        new Person(4, "Dony2"),
                        new Person(5, "Dony3"),
                        new Person(6, "Dony4"),
                        new Person(7, "Dony5"),
                        new Person(8, "Dony6"),
                        new Person(9, "Dony7"),
                        new Person(10, "Dony8"),
                        new Person(11, "Dony9"),
                        new Person(12,"Miho10"),
                        new Person(13, "Dony11"),
                        new Person(14, "Dony12"),
                        new Person(15, "Dony13"),
                        new Person(16, "Dony14"),
                        new Person(17, "Dony15"),
                        new Person(18, "Dony16"),
                        new Person(19, "Dony17"),
                        new Person(20, "Dony18"),
                    }
                ),
                new TestCaseData(
                    new Person[]
                    {

                    },
                    new Person[]
                    {
                        new Person(1,"Miho"),
                        new Person(1, "Tony")
                    }
                    )
            };

            foreach (var testCaseData in testCases)
            {
                yield return testCaseData;
            }
        }

        public static IEnumerable<TestCaseData> TestAddSourceData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Miho"),
                        new Person(2, "Dony")
                    },
                    new Person[]
                    {
                        new Person(3,"Miho2"),
                        new Person(4, "Dony2")
                    },
                    4),
                new TestCaseData(
                    new Person[]
                    {

                    },
                    new Person[]
                    {
                        new Person(1,"Toni")
                    },
                    1
                )
            };

            foreach (var testCaseData in testCases)
            {
                yield return testCaseData;
            }
        }

        public static IEnumerable<TestCaseData> TestConstructorSourceData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Miho"),
                        new Person(2, "Dony")
                    },
                    2),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1,"Toni")
                    },
                    1)
            };

            foreach (var testCaseData in testCases)
            {
                yield return testCaseData;
            }
        }
    }
}