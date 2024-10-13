using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using WebApi.Data;
using WebApi.Enums;
using WebApi.Helper;
using WebApi.Models;
using WebApi.Services;
using WebApi.Structs;
using WebApiUnitTests.Helpers;

namespace WebApiUnitTests.Services
{
    [TestFixture]
    public class GameServiceTests
    {
        private  GameService? _gameService;
        private TestDataContextFactory _contextFactory;

        [SetUp]
        public void Setup()
        {
            _contextFactory = new TestDataContextFactory();
        }
        [Test]
        public void CreateGame_ValidGame_True()
        {
            //Arrange
            Game game = new()
            {
                Id = 1,
                Title = "Dummy tittle",
                IsActive = true
            };
            var context = _contextFactory.Create();
            _gameService = new GameService(context);

            //Act
            var result = _gameService.CreateGame(game).Result;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Data, Is.True);
                Assert.That(result.ErrorResponse, Is.Null);
                Assert.That(result.ExceptionMessage, Is.Null);
            });
        }

        [Test]
        public void CreateGame_InvalidGame_GameNoCreated()
        {
            //Arrange
            Game game = new()
            {
                Id = 1,
                Title = null!,
                IsActive = true
            };

            Mock dbContext =  new Mock(TheB)


            var context = _contextFactory.Create();

            _gameService = new GameService(context);

            //Act
            var result = _gameService.CreateGame(game).Result;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Data, Is.False);
                Assert.That(result.ErrorResponse, Is.EqualTo(ErrorMessagesHelper.GetErrorMessage(ErrorCode.GameNotCreated)));
                Assert.That(result.ExceptionMessage, Is.Null);
            });
        }

        [Test]
        public void GetGameById_OnlyActiveGameFlagTrue_ActiveGame()
        {
            //Arrange
            var context = _contextFactory.Create();
            context.Games.AddRange(
                [ new Game
                {
                    Id = 1,
                    Title = "Dummy tittle 1",
                    IsActive = true,
                },
                    new Game
                    {
                        Id = 2,
                        Title = "Dummy tittle 2",
                        IsActive = false,
                    }
                ]);
            context.SaveChanges();
            _gameService = new GameService(context);

            //Act
            var activeGameResultOnlyActiveGame = _gameService.GetGameById(1, true).Result;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(activeGameResultOnlyActiveGame.IsSuccess, Is.True);
                Assert.That(activeGameResultOnlyActiveGame.Data, Is.Not.Null);
                Assert.That(activeGameResultOnlyActiveGame.Data!.Id, Is.EqualTo(1));
                Assert.That(activeGameResultOnlyActiveGame.Data.Title, Is.EqualTo("Dummy tittle 1"));
                Assert.That(activeGameResultOnlyActiveGame.Data.IsActive, Is.True);
                Assert.That(activeGameResultOnlyActiveGame.ErrorResponse, Is.Null);
                Assert.That(activeGameResultOnlyActiveGame.ExceptionMessage, Is.Null);
            });
        }

        [Test]
        public void GetGameById_OnlyActiveGameFlagFalse_ActiveGame()
        {
            //Arrange
            var context = _contextFactory.Create();
            context.Games.AddRange([
                new Game
                {
                    Id = 1,
                    Title = "Dummy tittle 1",
                    IsActive = true,
                },
                new Game 
                {
                    Id = 2,
                    Title = "Dummy tittle 2",
                    IsActive = false,
                },
                ]);
            context.SaveChanges();
            _gameService = new GameService(context);

            //Act
            var activeGameResultAllGames = _gameService.GetGameById(1, false).Result;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(activeGameResultAllGames.IsSuccess, Is.True);
                Assert.That(activeGameResultAllGames.Data, Is.Not.Null);
                Assert.That(activeGameResultAllGames.Data!.Id, Is.EqualTo(1));
                Assert.That(activeGameResultAllGames.Data.Title, Is.EqualTo("Dummy tittle 1"));
                Assert.That(activeGameResultAllGames.Data.IsActive, Is.True);
                Assert.That(activeGameResultAllGames.ErrorResponse, Is.Null);
                Assert.That(activeGameResultAllGames.ExceptionMessage, Is.Null);
            });
        }

        [Test]
        public void GetGameById_OnlyActiveGameFlagTrue_GameNoExistsMessage()
        {
            //Arrange
            var context = _contextFactory.Create();
            context.Games.AddRange(
                [ new Game
                {
                    Id = 1,
                    Title = "Dummy tittle 1",
                    IsActive = true,
                },
                    new Game
                    {
                        Id = 2,
                        Title = "Dummy tittle 2",
                        IsActive = false,
                    }
                ]);
            context.SaveChanges();
            _gameService = new GameService(context);

            //Act
            var inactiveGameResultOnlyActiveGame = _gameService.GetGameById(2, true).Result;

            //Assert
            Assert.Multiple(() =>
            {
                //Get inactive game with onlyActiveGame flag true
                Assert.That(inactiveGameResultOnlyActiveGame.IsSuccess, Is.False);
                Assert.That(inactiveGameResultOnlyActiveGame.Data, Is.Null);
                Assert.That(inactiveGameResultOnlyActiveGame.ErrorResponse, Is.EqualTo(ErrorMessagesHelper.GetErrorMessage(ErrorCode.GameNoExists)));
                Assert.That(inactiveGameResultOnlyActiveGame.ExceptionMessage, Is.Null);
            });
        }

        [Test]
        public void GetGameById_OnlyActiveGameFlagFalse_InactiveGame()
        {
            //Arrange
            var context = _contextFactory.Create();
            context.Games.AddRange(
                [ new Game
                {
                    Id = 1,
                    Title = "Dummy tittle 1",
                    IsActive = true,
                },
                    new Game
                    {
                        Id = 2,
                        Title = "Dummy tittle 2",
                        IsActive = false,
                    }
                ]);
            context.SaveChanges();
            _gameService = new GameService(context);

            //Act
            var inactiveGameResultAllGames = _gameService.GetGameById(2, false).Result;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(inactiveGameResultAllGames.IsSuccess, Is.True);
                Assert.That(inactiveGameResultAllGames.Data, Is.Not.Null);
                Assert.That(inactiveGameResultAllGames.Data!.Id, Is.EqualTo(2));
                Assert.That(inactiveGameResultAllGames.Data.Title, Is.EqualTo("Dummy tittle 2"));
                Assert.That(inactiveGameResultAllGames.Data.IsActive, Is.False);
                Assert.That(inactiveGameResultAllGames.ErrorResponse, Is.Null);
                Assert.That(inactiveGameResultAllGames.ExceptionMessage, Is.Null);
            });

        }
    }
}