using Moq;
using NUnit.Framework;
using StarCinema.Models;
using System;
using System.Collections.Generic;

namespace StarCinemaTests.PagingInfoTests
{
    [TestFixture]
    public class PagingInfoTests
    {
        PagingInfo pagingInfo;
        [SetUp]
        public void Setup()
        { 

        }

        [Test]
        public void CalculateTotalPages_ShouldReturn0_TotalCount0()
        {
            pagingInfo = new PagingInfo(0, 0,5);
            pagingInfo.ItemsPerPage = 5;

            int result = pagingInfo.TotalPages;

            Assert.AreEqual(0, result);
        }
        [Test]
        public void CalculateTotalPages_ShouldThrowException_ItemsPerPage0()
        {
            Assert.Throws<DivideByZeroException>(() => new PagingInfo(0, 0, 0));
        }
        private class TestModel
        {

        }
    }

    
}