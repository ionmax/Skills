using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class ReservationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            Assert.That(result);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNotAdminButMadeBy_ReturnsTrue()
        {
            //Arrange
            var user = new User { IsAdmin = false };
            var reservation = new Reservation { MadeBy = user };

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.That(result);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNotAdminAndNotMadeBy_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });

            //Assert
            Assert.That(result, Is.False);
        }
    }
}