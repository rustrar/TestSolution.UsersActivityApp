using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UsersActivityApp.Business.Concrete;
using UsersActivityApp.Core.Entities.Concrete;
using UsersActivityApp.DataAccess.Abstract;

namespace UsersActivityApp.UnitTests
{
  class UserActivityServiceTests
  {
    [Test]
    [TestCase(1, "01.01.2000", "01.31.2001")]
    [TestCase(3000, "12.31.1990", "01.01.1991")]
    [TestCase(40000, "06.06.2014", null)]
    public void AddUserActivity_ShouldInvokeOneTime(int userId, DateTime regDate, DateTime? lastActivity)
    {
      //arrange
      var userActivity = new UserActivity(userId, regDate, lastActivity);

      var userEfRepository = new Mock<IUserActivityRepository>();
      userEfRepository.Setup(x => x.Add(userActivity)).Verifiable();

      var service = new UserActivityService(userEfRepository.Object);

      //act
      service.Add(userActivity);

      //assert
      userEfRepository.Verify(x => x.Add(userActivity), Times.Once);
    }

    [Test]
    public void AddUserActivities_ShouldInvokeOneTime()
    {
      //arrange
      List<UserActivity> list = new List<UserActivity>();
      list.Add(new UserActivity(1, DateTime.Now, DateTime.Now));
      list.Add(new UserActivity(2, DateTime.Now.AddYears(-10), DateTime.Now.AddYears(-8)));
      list.Add(new UserActivity(50000, new DateTime(2000, 12, 31)));           

      var userEfRepository = new Mock<IUserActivityRepository>();
      userEfRepository.Setup(x => x.AddList(list)).Verifiable();

      var service = new UserActivityService(userEfRepository.Object);

      //act
      service.AddList(list);

      //assert
      userEfRepository.Verify(x => x.AddList(list), Times.Once);
    }

    [Test]
    public void AddNonValidUserActivity_ShouldNotValidate()
    {
      //arrange
      var userId = 0;
      var regDate = DateTime.Now;
      var lastActivity = DateTime.Now;


      var userActivity = new UserActivity(userId, regDate, lastActivity);

      var validationContext = new ValidationContext(userActivity, null, null);
      var validationResultList = new List<ValidationResult>();

      var expectedMessage = "The field Id must be between 1 and 2147483647.";
      //act
      var isValid = Validator.TryValidateObject(userActivity, validationContext, validationResultList, true);
      var message = validationResultList.FirstOrDefault()?.ErrorMessage;

      //assert
      Assert.IsFalse(isValid);
      Assert.AreEqual(message, expectedMessage);
    }
  }
}
