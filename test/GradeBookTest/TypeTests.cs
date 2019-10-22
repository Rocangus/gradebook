using GradeBook;
using System;
using Xunit;

namespace GradeBookTest
{

    public class TypeTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Henning";
            var upper = MakeUppercase(name);

            Assert.Equal("Henning", name);
            Assert.Equal("HENNING", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private void SetInt(ref Int32 x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // arrange
            var book1 = GetBook("Book1");
            GetBookSetName(out book1, "New Name");
            // act


            // assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(out Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            // arrange
            var book1 = GetBook("Book1");
            GetBookSetName(book1, "New Name");
            // act


            // assert
            Assert.Equal("Book1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book1");
            SetName(book1, "New Name");
            // act


            // assert
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");
            // act


            // assert
            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            // arrange
            var book1 = GetBook("Book1");
            var book2 = book1;
            // act


            // assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
            
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
