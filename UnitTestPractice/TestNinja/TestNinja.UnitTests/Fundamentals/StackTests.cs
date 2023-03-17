using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class StackTests
    {
        private TestNinja.Fundamentals.Stack<string> stack;

        [SetUp]
        public void SetUp()
        {
            stack = new TestNinja.Fundamentals.Stack<string>();
        }

        #region PushTests

        [Test]
        public void Push_WhenArgumentIsNull_ThrowArgumentNullException()
        {
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_StackEmpty_CountReturnsZero()
        {
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Push_StackIsNotEmpty_CountReturnsValue()
        {
            stack.Push("Test");
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        #endregion

        #region PopTests

        [Test]
        public void Pop_WhenStackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithObjects_RemoveObjectOnTheTop()
        {
            stack.Push("Test1");
            stack.Push("Test2");
            stack.Push("Test3");

            stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(2));
            Assert.That(stack.Peek(), Is.EqualTo("Test2"));
        }

        #endregion

        #region PeekTests

        [Test]
        public void Peek_WhenStackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithObjects_GetObjectOnTheTop()
        {
            stack.Push("Test1");
            stack.Push("Test2");
            stack.Push("Test3");

            Assert.That(stack.Peek(), Is.EqualTo("Test3"));
            Assert.That(stack.Count, Is.EqualTo(3));
        }

        #endregion
    }
}
