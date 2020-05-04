﻿using System;
using Chinook.MockData.Repositories;
using Chinook.Domain.Entities;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class InvoiceRepositoryTest
    {
        private readonly InvoiceRepository _repo;

        public InvoiceRepositoryTest()
        {
            _repo = new InvoiceRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public void InvoiceGetAll()
        {
            // Act
            var invoices = _repo.GetAll();

            // Assert
            Assert.Single(invoices);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(Invoice)})]
        [Fact]
        public void DotMemoryUnitTest()
        {
            var repo = new InvoiceRepository();

            repo.GetAll();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<Invoice>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}