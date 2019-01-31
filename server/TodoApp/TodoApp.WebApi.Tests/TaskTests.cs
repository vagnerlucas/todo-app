using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TodoApp.Application.Repositories.TaskRepository;
using TodoApp.Application.UseCases.Task;
using TodoApp.Domain;
using Xunit;
using Assert = Xunit.Assert;

namespace TodoApp.WebApi.Tests
{
    [TestClass]
    public class TaskTests
    {
        #region Data Mocking
        public static IEnumerable<object[]> GetEmptyTask()
        {
            yield return new object[]
            {
                new TaskInput()
            };
        }

        public TaskInput GetNewTask(string name)
        {
            return new TaskInput
            {
                Name = name,
                CreatedAt = DateTime.Now
            };
        }
        #endregion

        [Theory, MemberData(nameof(GetEmptyTask))]
        public async Task New_Task_Should_Have_Name(TaskInput task)
        {
            var mockTaskWriteOnlyRepository = new Mock<ITaskWriteOnlyRepository>();
            var sut = new TaskUseCase(null, mockTaskWriteOnlyRepository.Object);

            await Assert.ThrowsAsync<InvalidValueException>(() => sut.Create(Guid.NewGuid(), task));
        }

    }
}
