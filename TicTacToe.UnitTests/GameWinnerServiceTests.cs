using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Services;
using NUnit.Framework;

namespace TicTacToe.UnitTests
{
    [TestFixture]
    public class GameWinnerServiceTests
    {
        IGameWinnerService _gameWinnerService;
        private char[,] _gameBoard;

        [SetUp]
        public void SetupUnitTest()
        {
            _gameWinnerService = new GameWinnerService();
            _gameBoard = new char[3, 3]
                  {
                      {' ', ' ', ' '},
                      {' ', ' ', ' '},
                      {' ', ' ', ' '}
                  };
        }

        [Test]
        public void NeitherPlayerHasThreeInARow()
        {
            const char expected = ' ';            
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PlayerWithAllSpacesInTopRowIsWinner()
        {
            const char expected = 'X';
            for (var rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                _gameBoard[0, rowIndex] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [Test]
        public void PlayerWithAllSpacesInColumnIsWinner()
        {
            const char expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                _gameBoard[columnIndex, 0] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
