namespace Test002.Test;

[TestClass]
public class MatrixRotationTests
{
    private MatrixRotator _rotator;

    [TestInitialize]
    public void SetUp()
    {
        _rotator = new MatrixRotator();
    }

    #region False case

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void SquareMatrixRotate90CounterClockwise_EmptyMatrix_ThrowsEmptyArgumentException()
    {
        int[,] input = new int[0, 0];
        _rotator.SquareMatrixRotate90CounterClockwise(input);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void SquareMatrixRotate90CounterClockwise_NonSquareMatrix_ThrowsNonSquareArgumentException()
    {
        int[,] input = new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };
        _rotator.SquareMatrixRotate90CounterClockwise(input);
    }

    #endregion

    #region True case

    [TestMethod]
    public void SquareMatrixRotate90CounterClockwise_SingleElementMatrix_RemainsUnchanged()
    {
        int[,] input = new int[,] { { 5 } };
        int[,] expected = new int[,] { { 5 } };

        int[,] result = _rotator.SquareMatrixRotate90CounterClockwise(input);

        AssertMatrixEquality(expected, result);
    }

    [TestMethod]
    public void SquareMatrixRotate90CounterClockwise_2x2Matrix_RotatesCorrectly()
    {
        int[,] input = new int[,]
        {
            { 1, 2 },
            { 3, 4 }
        };
        int[,] expected = new int[,]
        {
            { 2, 4 },
            { 1, 3 }
        };

        int[,] result = _rotator.SquareMatrixRotate90CounterClockwise(input);

        AssertMatrixEquality(expected, result);
    }

    [TestMethod]
    public void SquareMatrixRotate90CounterClockwise_3x3Matrix_RotatesCorrectly()
    {
        int[,] input = new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        int[,] expected = new int[,]
        {
            { 3, 6, 9 },
            { 2, 5, 8 },
            { 1, 4, 7 }
        };

        int[,] result = _rotator.SquareMatrixRotate90CounterClockwise(input);

        AssertMatrixEquality(expected, result);
    }

    [TestMethod]
    public void SquareMatrixRotate90CounterClockwise_4x4Matrix_RotatesCorrectly()
    {
        int[,] input = new int[,]
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        };
        int[,] expected = new int[,]
        {
            { 4, 8, 12, 16 },
            { 3, 7, 11, 15 },
            { 2, 6, 10, 14 },
            { 1, 5, 9, 13 }
        };

        int[,] result = _rotator.SquareMatrixRotate90CounterClockwise(input);

        AssertMatrixEquality(expected, result);
    }

    private void AssertMatrixEquality(int[,] expected, int[,] result)
    {
        int rows = expected.GetLength(0);
        int cols = expected.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Assert.AreEqual(expected[i, j], result[i, j], $"Equal at [{i},{j}]");
            }
        }
    }

    #endregion
}