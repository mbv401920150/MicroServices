using AutoMapper;
using FluentValidation.Validators;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using ServicesStore.Api.Book.App;
using ServicesStore.Api.Book.Model;
using ServicesStore.Api.Book.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using static ServicesStore.Api.Book.App.BookGet;
using static ServicesStore.Api.Book.App.BookGetList;

namespace ServicesStore.Api.Book.Test
{
    public class BooksServiceTest
    {
        private IEnumerable<LibraryBook> GetDataTest()
        {
            A.Configure<LibraryBook>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.BookGuid, () => Guid.NewGuid());

            var List = A.ListOf<LibraryBook>(30);
            List[0].BookGuid = Guid.Empty;

            return List;
        }

        private Mock<AppDbContext> CreateContext()
        {
            var testData = GetDataTest().AsQueryable();

            var dbSet = new Mock<DbSet<LibraryBook>>();
            dbSet.As<IQueryable<LibraryBook>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<LibraryBook>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<LibraryBook>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<LibraryBook>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<LibraryBook>>()
                .Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<LibraryBook>(testData.GetEnumerator()));

            dbSet.As<IQueryable<LibraryBook>>()
                .Setup(x => x.Provider)
                .Returns(new AsyncQueryProvider<LibraryBook>(testData.Provider));


            var context = new Mock<AppDbContext>();
            context.Setup(x => x.LibraryBooks).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void GetBooks()
        {
            var mockContext = CreateContext();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            RequestBookGetList request = new RequestBookGetList();
            HandlerBookGetList handler = new HandlerBookGetList(mockContext.Object, mapper);

            var list = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(list.Any());
        }

        [Fact]
        public async void GetBookByFilter()
        {
            var mockContext = CreateContext();
            var mapConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingTest()));

            var mapper = mapConfig.CreateMapper();

            RequestBookGet request = new RequestBookGet();
            request.LibraryBookGuid = Guid.Empty;
            HandlerBookGet handler = new HandlerBookGet(mockContext.Object, mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(result);
            Assert.True(result.BookGuid == Guid.Empty);
        }

        [Fact]
        public async void SaveBook()
        {
            System.Diagnostics.Debugger.Launch();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "testAppDb")
                .Options;

            var context = new AppDbContext(options);

            BookNew.RequestBookNew request = new BookNew.RequestBookNew()
            {
                Title = "My new book",
                PublishDate = DateTime.Now,
                AuthorBookGuid = Guid.Empty.ToString()
            };
            BookNew.HandlerBookNew handler = new BookNew.HandlerBookNew(context);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(result != null);
        }
    }
}
