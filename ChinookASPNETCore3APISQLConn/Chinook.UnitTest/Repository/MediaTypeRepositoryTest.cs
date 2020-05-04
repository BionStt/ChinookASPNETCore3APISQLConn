﻿using System;
using Chinook.MockData.Repositories;
using Chinook.Domain.Entities;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class MediaTypeRepositoryTest
    {
        private readonly MediaTypeRepository _repo;

        public MediaTypeRepositoryTest()
        {
            _repo = new MediaTypeRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public void MediaTypeGetAll()
        {
            // Act
            var mediaTypes = _repo.GetAll();

            // Assert
            Assert.Single(mediaTypes);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(MediaType)})]
        [Fact]
        public void DotMemoryUnitTest()
        {
            var repo = new MediaTypeRepository();

            repo.GetAll();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<MediaType>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}