using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UsersActivityApp.Business.Concrete;
using UsersActivityApp.Core.Entities.Concrete;
using UsersActivityApp.DataAccess.Abstract;

namespace UsersActivityApp.UnitTests
{
  class MetricsCalculationTests
  {
    [Test]
    public void CalculateRR_ShouldReturn_0_Pct()
    {
      //arrange
      List<UserActivity> list = new List<UserActivity>();
      list.Add(new UserActivity(1, DateTime.Now, null));
      list.Add(new UserActivity(2, DateTime.Now.AddDays(-6), DateTime.Now));
      list.Add(new UserActivity(3, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(4)));
      list.Add(new UserActivity(4, DateTime.Now, DateTime.Now.AddDays(6)));

      var userEfRepository = new Mock<IUserActivityRepository>();

      var service = new MetricsCalculationService(userEfRepository.Object);
      var expected = 0m;

      //act
      var actual = service.CalculateRR(list);

      //assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CalculateRR_ShouldReturn_50_Pct()
    {
      //arrange
      List<UserActivity> list = new List<UserActivity>();
      list.Add(new UserActivity(1, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-4)));
      list.Add(new UserActivity(2, DateTime.Now.AddDays(-14), DateTime.Now.AddDays(-8)));
      list.Add(new UserActivity(3, DateTime.Now.AddDays(-7), DateTime.Now));
      list.Add(new UserActivity(4, DateTime.Now.AddDays(-14), DateTime.Now.AddDays(-7)));

      var userEfRepository = new Mock<IUserActivityRepository>();

      var service = new MetricsCalculationService(userEfRepository.Object);
      var expected = 50m;

      //act
      var actual = service.CalculateRR(list);

      //assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CalculateRR_ShouldReturn_100_Pct()
    {
      //arrange
      List<UserActivity> list = new List<UserActivity>();
      list.Add(new UserActivity(1, DateTime.Now, null));
      list.Add(new UserActivity(2, DateTime.Now.AddDays(-6), DateTime.Now));
      list.Add(new UserActivity(3, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(4)));
      list.Add(new UserActivity(4, DateTime.Now.AddDays(-7), DateTime.Now));
      list.Add(new UserActivity(5, DateTime.Now.AddDays(-14), DateTime.Now.AddDays(-7)));

      var userEfRepository = new Mock<IUserActivityRepository>();

      var service = new MetricsCalculationService(userEfRepository.Object);
      var expected = 100m;

      //act
      var actual = service.CalculateRR(list);

      //assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CalculateLifeTime_ShouldReturn_EmptyList()
    {
      //arrange
      List<UserActivity> list = new List<UserActivity>();
      list.Add(new UserActivity(1, DateTime.Now, null));
      list.Add(new UserActivity(2, DateTime.Now.AddDays(-10), null));
      list.Add(new UserActivity(3, DateTime.Now.AddMonths(-10), null));
      list.Add(new UserActivity(4, DateTime.Now.AddYears(-10), null));

      var userEfRepository = new Mock<IUserActivityRepository>();

      var service = new MetricsCalculationService(userEfRepository.Object);
      var expected = new List<int>();

      //act
      var actual = service.CalculateLT(list);

      //assert
      Assert.AreEqual(expected.Count, actual.Count);
    }

    [Test]
    public void CalculateLifeTime_ShouldReturn_ListCount_One()
    {
      //arrange
      List<UserActivity> list = new List<UserActivity>();
      list.Add(new UserActivity(1, DateTime.Now, null));
      list.Add(new UserActivity(2, DateTime.Now, null));
      list.Add(new UserActivity(3, DateTime.Now, DateTime.Now));

      var userEfRepository = new Mock<IUserActivityRepository>();

      var service = new MetricsCalculationService(userEfRepository.Object);
      var expected = new List<int> { 0 };

      //act
      var actual = service.CalculateLT(list);

      //assert
      Assert.AreEqual(expected.Count, actual.Count);
      Assert.AreEqual(expected.First(), actual.First());
    }

    [Test]
    public void CalculateLifeTime_ShouldReturn_ListCount_two()
    {
      //arrange
      List<UserActivity> list = new List<UserActivity>();
      list.Add(new UserActivity(1, DateTime.Now, null));
      list.Add(new UserActivity(2, DateTime.Now.AddDays(-1), DateTime.Now));
      list.Add(new UserActivity(3, DateTime.Now.AddDays(-50), DateTime.Now.AddDays(-10)));

      var userEfRepository = new Mock<IUserActivityRepository>();

      var service = new MetricsCalculationService(userEfRepository.Object);
      var expected = new List<int> { 1, 40 };

      //act
      var actual = service.CalculateLT(list);

      //assert
      Assert.AreEqual(expected.Count, actual.Count);
      Assert.AreEqual(expected.First(), actual.First());
      Assert.AreEqual(expected.Last(), actual.Last());
    }
  }
}
