using Simulator;
using Simulator.Maps;
using Xunit;

namespace TestSimulator
{
    public class PointTests
    {
        [Theory]
        [InlineData(0, 0, Direction.Up, 0, 1)]
        [InlineData(5, 5, Direction.Down, 5, 4)]
        [InlineData(3, 3, Direction.Left, 2, 3)]
        [InlineData(7, 2, Direction.Right, 8, 2)]
        public void Next_ShouldMoveCorrectly(int x, int y, Direction dir, int expectedX, int expectedY)
        {
            var p = new Point(x, y);
            var next = p.Next(dir);
            Assert.Equal(new Point(expectedX, expectedY), next);
        }

        [Theory]
        [InlineData(0, 0, Direction.Up, 1, 1)]
        [InlineData(5, 5, Direction.Down, 4, 4)]
        [InlineData(3, 3, Direction.Left, 2, 4)]
        [InlineData(7, 2, Direction.Right, 8, 1)]
        public void NextDiagonal_ShouldMoveCorrectly(int x, int y, Direction dir, int expectedX, int expectedY)
        {
            var p = new Point(x, y);
            var next = p.NextDiagonal(dir);
            Assert.Equal(new Point(expectedX, expectedY), next);
        }
    }

    public class RectangleTests
    {
        [Fact]
        public void Constructor_ShouldSwapCoordinatesIfNeeded()
        {
            var rect = new Rectangle(5, 5, 2, 3);
            Assert.Equal(2, rect.X1);
            Assert.Equal(3, rect.Y1);
            Assert.Equal(5, rect.X2);
            Assert.Equal(5, rect.Y2);
        }

        [Fact]
        public void Constructor_FlatRectangle_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(1, 2, 1, 5));
            Assert.Throws<ArgumentException>(() => new Rectangle(1, 2, 4, 2));
        }

        [Fact]
        public void Contains_ShouldDetectPointsCorrectly()
        {
            var rect = new Rectangle(0, 0, 5, 5);
            Assert.True(rect.Contains(new Point(0, 0)));
            Assert.True(rect.Contains(new Point(3, 4)));
            Assert.True(rect.Contains(new Point(5, 5)));
            Assert.False(rect.Contains(new Point(6, 0)));
            Assert.False(rect.Contains(new Point(0, 6)));
        }
    }

    public class ValidatorTests
    {
        [Theory]
        [InlineData("abc", 3, 5, '#', "Abc")]
        [InlineData("a", 3, 5, '#', "A##")]
        [InlineData("abcdef", 3, 5, '#', "Abcde")]
        [InlineData(null, 3, 5, '#', "###")]
        [InlineData("   xyz ", 3, 5, '#', "Xyz")]
        public void Shortener_ShouldWorkCorrectly(string input, int min, int max, char placeholder, string expected)
        {
            var result = Validator.Shortener(input, min, max, placeholder);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, 1, 10, 5)]
        [InlineData(0, 1, 10, 1)]
        [InlineData(15, 1, 10, 10)]
        public void Limiter_ShouldClampValues(int input, int min, int max, int expected)
        {
            var result = Validator.Limiter(input, min, max);
            Assert.Equal(expected, result);
        }
    }

    public class SmallSquareMapTests
    {
        [Theory]
        [InlineData(5)]
        [InlineData(20)]
        public void Constructor_ValidSizes_ShouldSetSize(int size)
        {
            var map = new SmallSquareMap(size);
            Assert.Equal(size, map.Size);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(21)]
        public void Constructor_InvalidSizes_ShouldThrow(int size)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
        }

        [Fact]
        public void Exist_ShouldReturnTrueForValidPoints()
        {
            var map = new SmallSquareMap(10);
            Assert.True(map.Exist(new Point(0, 0)));
            Assert.True(map.Exist(new Point(9, 9)));
        }

        [Fact]
        public void Exist_ShouldReturnFalseForInvalidPoints()
        {
            var map = new SmallSquareMap(10);
            Assert.False(map.Exist(new Point(-1, 0)));
            Assert.False(map.Exist(new Point(10, 5)));
            Assert.False(map.Exist(new Point(0, 10)));
        }
    }
}
