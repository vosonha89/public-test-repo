namespace Test002;

/// <summary>
/// Maxing rotation class.
/// </summary>
public class MatrixRotator
{
    /// <summary>
    /// Square matrix rotation by 90 degrees counter-clockwise.
    /// </summary>
    /// <param name="matrix">The input square matrix.</param>
    /// <returns>The rotated matrix.</returns>
    /// <exception cref="ArgumentException">Thrown if the matrix is empty or not square.</exception>
    public int[,] SquareMatrixRotate90CounterClockwise(int[,] matrix)
    {
        int rows = matrix.GetLength(0); // Rows
        if (rows == 0) // Strict validation: Ensure it's not empty'
        {
            throw new ArgumentException("Input matrix cannot be empty (0 x 0).", nameof(matrix));
        }

        if (matrix.GetLength(1) != rows) // Strict validation: Ensure it's exactly n x n (square)
        {
            throw new ArgumentException(
                $"Input matrix must be square (n x n). Got {rows} rows but {matrix.GetLength(1)} columns.",
                nameof(matrix));
        }

        int[,] rotatedMaxtrix = new int[rows, rows];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                rotatedMaxtrix[rows - 1 - j, i] = matrix[i, j];
            }
        }

        return rotatedMaxtrix;
    }
}