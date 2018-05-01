using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Reinventing The Wheel (only for the purposes of demonstrating the features of the language)
/// </summary>
namespace MatrixDemo.RTW
{


    /// <summary>
    /// The matrix class stores a matrix of doubles.  It uses an indexer to access elements and properties for readonly values of rows and columns.  It also uses operator overloading to support matrix additoin, matrix subtraction, matrix inversion, scalar multiplication, and matrix multiplication.  In addition, it has several methods to perform operations including transposition, reducing to reduced row echelon form, inversion, and computing determinants.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// The source delegate provides a quick way of describing how each entry in a matrix is to be constructed.  It is used for populating matrices according to a particular rule (such as entrywise addition of two matrices' entries.
        /// </summary>
        /// <param name="r">The row index to populate.</param>
        /// <param name="c">the column index to populate.</param>
        /// <returns>The entry at the specified row and column index in the resulting matrix.</returns>
        private delegate double Source(int r, int c);

        /// <summary>
        /// The entries in the matrix
        /// </summary>
        private double[,] entries;

        /// <summary>
        /// The number of rows
        /// </summary>
        private int rows;

        /// <summary>
        /// The number of columns
        /// </summary>
        private int cols;

        /// <summary>
        /// The number of rows in the matrix
        /// </summary>
        public int Rows
        {
            get
            {
                return rows;
            }
        }
        /// <summary>
        /// The number of columns in the matrix
        /// </summary>
        public int Cols
        {
            get
            {
                return cols;
            }
        }

        /// <summary>
        /// Accesses a specific entry in the matrix.
        /// </summary>
        /// <param name="row">the row of the entry to access.</param>
        /// <param name="col">the column of the entry to access.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the row or column index is out of bounds.</exception>
        /// <returns></returns>
        public double this[int row, int col]
        {
            get
            {
                ValidateRange(row, col);
                return entries[row, col];
            }
            set
            {
                ValidateRange(row, col);
                entries[row, col] = value;
            }
        }

        /// <summary>
        /// Ensures that the given index is within the bounds of the matrix.
        /// </summary>
        /// <param name="row">the row index.</param>
        /// <param name="col">the column index.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the row or column index is out of bounds.</exception>
        private void ValidateRange(int row, int col)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                throw new IndexOutOfRangeException("Index was outside the bounds of the matrix.");
        }

        /// <summary>
        /// Creates a zero matrix with the specified number of rows and columns.
        /// </summary>
        /// <param name="rows">the number of rows for the matrix.</param>
        /// <param name="cols">the number of columns for the matrix.</param>
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            entries = new double[Rows, Cols];
        }



        /// <summary>
        /// Creates a matrix and populates it with entries from a given array of doubles.  The matrix is not backed by the 2-dimensional array of doubles, so changes in one will not affect the other.  For a Matrix backed by the array of doubles, use <see cref="operator double[,]"/>.
        /// </summary>
        /// <param name="e">The entries to use to populate the matrix.</param>
        /// <seealso cref="operator double[,]"/>
        public Matrix(double[,] e)
        {
            rows = e.GetLength(0);
            cols = e.GetLength(1);
            entries = new double[Rows, Cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    entries[i, j] = e[i, j];
                }
            }
        }

        /// <summary>
        /// Default constructor used for Matrix is private and does not instantiate any fields.
        /// </summary>
        private Matrix()
        {

        }

        /// <summary>
        /// Returns a 2-dimensional array of doubles reflecting the entries in the matrix.  The resulting 2-dimensional array is not backed by the matrix, so changes in one will not affect the other.  For a backed 2-dimensional array of doubles, use <see cref="operator Matrix"/>.
        /// </summary>
        /// <returns>A copy of the entries of the Matrix.</returns>
        /// <seealso cref="operator Matrix"/>
        public double[,] GetEntries()
        {
            double[,] ret = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ret[i, j] = entries[i, j];
                }
            }
            return ret;
        }

        /// <summary>
        /// Converts a Matrix to a 2-dimensional array of doubles.  The resulting 2-dimensional array is backed by the matrix, so changes in one will affect the other.  For a 2-dimensional array of entries not backed by the matrix, use <see cref="GetEntries"/>.
        /// </summary>
        /// <param name="m">the matrix to convert.</param>
        /// <seealso cref="GetEntries"/>
        public static implicit operator double[,] (Matrix m)
        {
            return m.entries;
        }

        /// <summary>
        /// Converts a 2-dimensional array of doubles to a matrix.  The resulting matrix is backed by the array, so changes in one will affect the other.  For a Matrix not backed by the 2-dimensional array of entries, use <see cref="Matrix.Matrix(double[,])"/>.
        /// </summary>
        /// <param name="e">The 2-dimensional array of doubles to convert.</param>
        /// <seealso cref="Matrix.Matrix(double[,])"/>
        public static implicit operator Matrix(double[,] e)
        {
            Matrix ret = new Matrix();
            ret.rows = e.GetLength(0);
            ret.cols = e.GetLength(1);
            return ret;
        }

        /// <summary>
        /// Returns the message to accompany a BadDimensionException thrown by the matrix for binary operations.
        /// </summary>
        /// <param name="lhs">The left hand side of the attempted operation.</param>
        /// <param name="rhs">The right hand side of the attempted operation.</param>
        /// <returns>The message for the BadDimensionException to be thrown.</returns>
        private static String BadDimensionMessage(Matrix lhs, Matrix rhs)
        {
            return "Incompatible dimensions: " + lhs.Rows + "x" + lhs.Cols + " and " + rhs.Rows + "x" + rhs.Cols;
        }

        /// <summary>
        /// Checks for bad dimensions on addition or subtraction operations.
        /// </summary>
        /// <param name="lhs">The left hand side of the operation.</param>
        /// <param name="rhs">The right hand side of the operation.</param>
        /// <exception cref="BadDimensionException">Thrown when the two matrices are incompatible for matrix addition or subtraction.</exception>
        private static void CheckDimensionsAddition(Matrix lhs, Matrix rhs)
        {
            if (lhs.Rows != rhs.Rows || lhs.Cols != rhs.Cols)
                throw new BadDimensionException(BadDimensionMessage(lhs, rhs));
        }

        /// <summary>
        /// Creates a Matrix from a given source of entries.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="cols">The number of columns in the matrix.</param>
        /// <param name="s">The source of entries.</param>
        /// <returns>A matrix populated by using <code>s</code> to determine each entry.</returns>
        private static Matrix MatrixFromSource(int rows, int cols, Source s)
        {
            Matrix ret = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ret[i, j] = s(i, j);
                }
            }
            return ret;
        }

        /// <summary>
        /// Returns the matrix sum of the two matrices.
        /// </summary>
        /// <param name="lhs">The left hand side of the addition.</param>
        /// <param name="rhs">The right hand side of the addition.</param>
        /// <returns>The sum of the two matrices.</returns>
        /// <exception cref="BadDimensionException">Thrown when the two matrices are of different dimensions.</exception>
        public static Matrix operator +(Matrix lhs, Matrix rhs)
        {
            CheckDimensionsAddition(lhs, rhs);
            return MatrixFromSource(lhs.Rows, rhs.Cols, (int r, int c) => lhs[r, c] + rhs[r, c]);
        }

        /// <summary>
        /// Returns the matrix difference of the two matrices.
        /// </summary>
        /// <param name="lhs">The left hand side of the subtraction.</param>
        /// <param name="rhs">The right hand side of the subtraction.</param>
        /// <returns>The difference of the two matrices.</returns>
        /// <exception cref="BadDimensionException">Thrown when the two matrices are of different dimensions.</exception>
        public static Matrix operator -(Matrix lhs, Matrix rhs)
        {
            CheckDimensionsAddition(lhs, rhs);
            return MatrixFromSource(lhs.Rows, rhs.Cols, (int r, int c) => lhs[r, c] + rhs[r, c]);
        }

        /// <summary>
        /// Takes the opposite of the given matrix.
        /// </summary>
        /// <param name="m">The Matrix to find the opposite of.</param>
        /// <returns>The opposite of the given matrix.  Subtracting <code>m</code> from another matrix is equivalent to adding <code>-m</code> to it.</returns>
        public static Matrix operator -(Matrix m)
        {
            return MatrixFromSource(m.Rows, m.Cols, (int r, int c) => -m[r, c]);
        }

        /// <summary>
        /// Scales a matrix by a scalar.
        /// </summary>
        /// <param name="s">The scalar by which to scale the matrix.</param>
        /// <param name="m">The matrix to be scaled.</param>
        /// <returns>A matrix containing each entry in <code>m</code> scaled by <code>s</code>.</returns>
        public static Matrix operator *(double s, Matrix m)
        {
            return MatrixFromSource(m.Rows, m.Cols, (int r, int c) => s * m[r, c]);
        }

        /// <summary>
        /// Performs matrix multiplication.
        /// </summary>
        /// <param name="lhs">The left hand side of the multiplication.</param>
        /// <param name="rhs">The right hand  side of the multiplication.</param>
        /// <returns>The product of the two matrices.</returns>
        /// <exception cref="BadDimensionException">Thrown if the number of columns in the left hand side is different from the number of rows in the right hand side.</exception>
        public static Matrix operator *(Matrix lhs, Matrix rhs)
        {
            if (lhs.Cols != rhs.Rows)
                throw new BadDimensionException(BadDimensionMessage(lhs, rhs));
            return MatrixFromSource(lhs.Rows, rhs.Cols, (int r, int c) =>
            {
                double res = 0;
                for (int k = 0; k < lhs.Cols; k++)
                {
                    res += lhs[r, k] * rhs[k, c];
                }
                return res;
            });
        }

    }
}
