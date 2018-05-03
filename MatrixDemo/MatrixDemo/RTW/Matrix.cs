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
        /// The number of rows in the matrix
        /// </summary>
        public int Rows
        {
            get
            {
                return entries.GetLength(0);
            }
        }
        /// <summary>
        /// The number of columns in the matrix
        /// </summary>
        public int Cols
        {
            get
            {
                return entries.GetLength(1);
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
        /// <exception cref="ArgumentException">Thrown if either or both of the dimensions is negative.</exception>
        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Both dimensions must be positive.");
            entries = new double[rows, cols];
        }



        /// <summary>
        /// Creates a matrix and populates it with entries from a given array of doubles.  The matrix is not backed by the 2-dimensional array of doubles, so changes in one will not affect the other.  For a Matrix backed by the array of doubles, use <see cref="operator double[,]"/>.
        /// </summary>
        /// <param name="e">The entries to use to populate the matrix.</param>
        /// <seealso cref="operator double[,]"/>
        public Matrix(double[,] e)
        {
            entries = new double[e.GetLength(0), e.GetLength(1)];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
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
            double[,] ret = new double[Rows, Cols];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
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
            Matrix ret = new Matrix
            {
                entries = e
            };
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

        /// <summary>
        /// Returns the message for incompatible dimensions on uniary operations.
        /// </summary>
        /// <returns>The message for incompatible dimensions on uniary matrix operations.</returns>
        private String BadDimensionMessage()
        {
            return "Incompatible Dimension: " + Rows + "x" + Cols;
        }

        /// <summary>
        /// Checks to make sure that this matrix is square.
        /// </summary>
        /// <exception cref="BadDimensionMessage">Thrown when this matrix is not square.</exception>
        private void CheckSquare()
        {
            if (Rows != Cols)
                throw new BadDimensionException(BadDimensionMessage());
        }

        // Row Operations

        /// <summary>
        /// Swaps two rows.
        /// </summary>
        /// <param name="r1">The first row to swap.</param>
        /// <param name="r2">The second row to swap.</param>
        private void RowSwap(int r1, int r2)
        {
            for (int c = 0; c < Cols; c++)
            {
                double temp = entries[r1, c];
                entries[r1, c] = entries[r2, c];
                entries[r2, c] = temp;
            }
        }

        /// <summary>
        /// Scales row r by scalar s.
        /// </summary>
        /// <param name="r">The row to scale.</param>
        /// <param name="s">The scalar by which to scale the row.</param>
        private void RowScale(int r, double s)
        {
            for (int c = 0; c < Cols; c++)
            {
                entries[r, c] = s * entries[r, c];
            }
        }

        /// <summary>
        /// Adds s copies of r1 to r2.
        /// </summary>
        /// <param name="r2">The row to add.</param>
        /// <param name="r2">The row to be added to.</param>
        /// <param name="s">The scalar by which to multiply the row to be added.</param>
        private void RowAdd(int r1, int r2, double s)
        {
            for (int c = 0; c < Cols; c++)
            {
                entries[r2, c] = entries[r2, c] + s * entries[r1, c];
            }
        }

        /// <summary>
        /// Converts this matrix to Reduced Row Echelon Form.
        /// </summary>
        public void Reduce()
        {
            int pivot = 0;
            int row = 0;
            while (row < Rows && pivot < Cols)
            {
                // Attempt to place a nonzero entry in the pivot spot
                if (entries[row, pivot] == 0)
                {
                    int row2 = row + 1;
                    while (row2 < Rows && entries[row2, pivot] == 0)
                    {
                        row2++;
                    }
                    // If nonzero entry found in the column, swap the row tobring it up.
                    if (row2 < Rows)
                    {
                        RowSwap(row, row2);
                    }
                }
                // If nonzero entry in the pivot spot, turn it to a 1 and zero out the rest of the column.
                if (entries[row, pivot] != 0)
                {
                    // Scale the row.
                    RowScale(row, 1 / entries[row, pivot]);
                    // Zero out the other rows
                    for (int row2=0; row2<Rows; row2++)
                    {
                        if (row == row2)
                            continue; // Don't zero out the row itself.
                        RowAdd(row, row2, -entries[row2, pivot]);
                    }
                    // Increment the row
                    row++;
                }
                // Increment the pivot
                pivot++;
            }
        }

        /// <summary>
        /// Returns the Reduced Row Echelon form of this matrix.  This matrix its4elf is unaltered.
        /// </summary>
        /// <returns>the reduced row echelon form of this matrix.</returns>
        public Matrix RREF()
        {
            Matrix ret = new Matrix(entries);
            ret.Reduce();
            return ret;
        }

        /// <summary>
        /// Calculates the determinant of this matrix.
        /// </summary>
        /// <returns>the determinant of this matrix.</returns>
        /// <exception cref="BadDimensionException">Thrown when the matrix is not square.</exception>
        public double Determinant()
        {
            CheckSquare();
            // Initialize variable to track changes in the determinant of the matrix as row operations are performed to convert a copy of this matrix to an upper triangular matrix.
            double det = 1;
            // Initialize temporary matrix to convert to upper triangular.
            Matrix temp = new Matrix(entries);

            // Convert copy of this matrix to upper triangular form.

            for (int col=0; col<Cols; col++)
            {
                // Place a nonzero entry in the main diagonal.
                if (entries[col,col] == 0)
                {
                    int row = col + 1;
                    while (row<Rows && entries[row,col]==0)
                    {
                        row++;
                    }
                    if (row >= Rows)
                    {
                        return 0; // The main diagonal has to have a zero entry, so the determinant is zero.
                    }
                    else
                    {
                        RowSwap(row, col);
                        det = -det;
                    }
                }
                // Zero out everything below
                for (int row=col+1; row<Rows; row++)
                {
                    RowAdd(col, row, -entries[row, col] / entries[col, col]);
                }
                // Multiply by the entry on the main diagonal.
                det *= entries[col, col];
            }
            return det;
        }

        /// <summary>
        /// Returns the inverse of this matrix if it exists.
        /// </summary>
        /// <returns>Returns the inverse of this matrix if it exists, null otherwise.</returns>
        /// <exception cref="BadDimensionException">Thrown when the matrix is not square.</exception>
        public Matrix Inverse()
        {
            CheckSquare();
            // Create a matrix with the left hand side being this matrix and the right hand side being the identity.
            Matrix temp = new Matrix(Rows * 2, Cols);
            for (int r=0; r<Rows; r++)
            {
                for (int c=0; c<Cols; c++)
                {
                    temp[r, c] = entries[r, c];
                }
                temp[r, r + Cols] = 1;
            }
            // Perform Gausian elimination.
            temp.Reduce();
            // Copy the right hand side of the matrix into a return matrix.
            Matrix ret = new Matrix(Rows, Cols);
            for (int r=0; r<Rows; r++)
            {
                if (temp[r, r] == 0)
                    return null; // The left hand side of the matrix is not the identity, so the determinant does not exist.
                for (int c=0; c<Cols; c++)
                {
                    ret[r, c] = temp[r, c + Cols];
                }
            }
            return ret;
        }

        /// <summary>
        /// Returns the tramspose of this matrix.
        /// </summary>
        /// <returns>The transpose of this matrix.</returns>
        public Matrix Transpose()
        {
            return MatrixFromSource(Cols, Rows, (int r, int c) => entries[c, r]);
        }

        /// <summary>
        /// Returns a String representation of this matrix.
        /// </summary>
        /// <returns>a String representation of this matrix.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int r=0; r<Rows; r++)
            {
                if (r != 0)
                    sb.Append("\n");
                sb.Append("[");
                for (int c=0; c<Cols; c++)
                {
                    if (c != 0)
                        sb.Append(", ");
                    sb.Append(entries[r, c]);
                }
                sb.Append("]");
            }
            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the hash code for this matrix.
        /// </summary>
        /// <returns>The hash code used for hashmaps.  <note type="warning">This hash function is not cryptographically secure.</note></returns>
        public override int GetHashCode()
        {
            return entries.GetHashCode();
        }

        /// <summary>
        /// Returns true if this matrix is equal to the other matrix.
        /// </summary>
        /// <param name="obj">The object to compare to this matrix.</param>
        /// <returns>True if the objects are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Matrix m)
            {
                return entries.Equals(m.entries);
            }
            else
            {
                return false;
            }
        }

    }
}
