using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class StackTests
    {
        [Test]
        public void Push_ArgumentIsNull_ThrowArgumentNullException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArgument_AddTheObjectToStack()
        {
            var stack = new Fundamentals.Stack<string>();

            stack.Push("a"); // Calling the method and using "a" as an argument

            Assert.That(stack.Count, Is.EqualTo(1)); // Verify that the stack now has a count of 1, meaning it is added. 
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(stack.Count, Is.EqualTo(0));

        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);

        }

        [Test]
        public void Pop_StackWithAFewObjects_ReturnsObjectOnTop()
        {
            // Arrange
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            // Act
            var result = stack.Pop();

            // Assert
            Assert.That(result, Is.EqualTo("c"));

        }

        [Test]
        public void Pop_StackWithAFewObjects_RemovesObjectOnTheTop()
        {
            // Arrange
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            // Act
            stack.Pop();

            // Assert
            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowsInavlidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithObjects_ReturnsObjectOnTop()
        {
            // Arrange
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Peek_StackWithObjects_DoesNotRemoveObjectOnTop()
        {
            // Arrange
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            Assert.That(stack.Count, Is.EqualTo(3));
        }

    }
}
