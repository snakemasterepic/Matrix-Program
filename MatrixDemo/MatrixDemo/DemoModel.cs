using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixDemo.RTW;

namespace MatrixDemo
{
    /// <summary>
    /// The DemoModel class processes different operations and returns the results to the controller.
    /// </summary>
    class DemoModel
    {
        /// <summary>
        /// Performs a uniary operation on a matrix.
        /// </summary>
        /// <param name="m">The matrix to operate on.</param>
        /// <returns>The result of the operatio.</returns>
        private delegate Matrix UniaryOp(Matrix m);

        /// <summary>
        /// Performs a binary operation on two matrices.
        /// </summary>
        /// <param name="l">The left hand matrix.</param>
        /// <param name="r">The right hand matrix.</param>
        /// <returns>The operation applied to the two matrices.</returns>
        private delegate Matrix BinaryOp(Matrix l, Matrix r);

        /// <summary>
        /// Converts from a matrix to a string for display.
        /// </summary>
        /// <param name="m">The matrix to convert.</param>
        /// <returns>The string to display.</returns>
        private String StringFromMatrix(Matrix m)
        {
            StringBuilder sb = new StringBuilder();
            for (int i=0; i<m.Rows; i++)
            {
                if (i != 0)
                    sb.Append("\r\n");
                for (int j=0; j<m.Cols; j++)
                {
                    if (j != 0)
                        sb.Append(' ');
                    sb.Append("" + m[i, j]);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converts a String to a matrix for computations.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>A matrix containing the entries in s.</returns>
        private Matrix MatrixFromString(String s)
        {
            s = s.Trim();
            String[] rows = s.Split('\n');
            int rowCount = rows.Length;
            int colCount = rows[0].Trim().Split(' ').Length;
            Matrix ret = new Matrix(rowCount, colCount);
            for (int i=0; i<rowCount; i++)
            {
                String row = rows[i].Trim();
                String[] entries = row.Split(' ');
                for (int j=0; j<entries.Length; j++)
                {
                    ret[i, j] = Convert.ToDouble(entries[j].Trim());
                }
            }
            return ret;
        }

        /// <summary>
        /// Performs a uniary operation on a matrix.
        /// </summary>
        /// <param name="mat">A String representing the matrix to operate on.</param>
        /// <param name="op">The operation to perform.</param>
        /// <returns>A String representing the result.</returns>
        private String PerformUniaryOperation(String mat, UniaryOp op)
        {
            Matrix m = MatrixFromString(mat);
            Matrix res = op(m);
            if (res == null)
                return "-";
            else
                return StringFromMatrix(res);
        }

        /// <summary>
        /// Performs a binary operation on two matrices.
        /// </summary>
        /// <param name="lhs">A String representation of the left hand side.</param>
        /// <param name="rhs">A String representation of the right hand side.</param>
        /// <param name="op">The operation to perform.</param>
        /// <returns>A String representing the result of the operation.</returns>
        private String PerformBinaryOperation(String lhs, String rhs, BinaryOp op)
        {
            Matrix l = MatrixFromString(lhs);
            Matrix r = MatrixFromString(rhs);
            Matrix res = op(l, r);
            if (res == null)
                return "-";
            else
                return StringFromMatrix(res);
        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="lhs">A String representing the lhs.</param>
        /// <param name="rhs">A String representing the rhs.</param>
        /// <returns>A String representing the sum.</returns>
        public String AddMatrices(String lhs, String rhs)
        {
            return PerformBinaryOperation(lhs, rhs, (Matrix l, Matrix r) => l + r);
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="lhs">A String representing the lhs.</param>
        /// <param name="rhs">A String representing the rhs.</param>
        /// <returns>A String representing the difference.</returns>
        public String SubtractMatrices(String lhs, String rhs)
        {
            return PerformBinaryOperation(lhs, rhs, (Matrix l, Matrix r) => l - r);
        }

        /// <summary>
        /// Scales one matrix by a scalar.
        /// </summary>
        /// <param name="lhs">The scalar.</param>
        /// <param name="rhs">The string representing the matrix.</param>
        /// <returns>A string representing the scalar.</returns>
        public String ScaleMatrix(String lhs, String rhs)
        {
            Matrix m = MatrixFromString(rhs);
            Double s = Convert.ToDouble(lhs);
            Matrix res = s * m;
            return StringFromMatrix(res);
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="lhs">A String representing the lhs.</param>
        /// <param name="rhs">A String representing the rhs.</param>
        /// <returns>A String representing the product.</returns>
        public String MultiplyMatrices(String lhs, String rhs)
        {
            return PerformBinaryOperation(lhs, rhs, (Matrix l, Matrix r) => l * r);
        }

        /// <summary>
        /// Reduces a matrix.
        /// </summary>
        /// <param name="mat">A representation of the matrix.</param>
        /// <returns>A representation of the result matrix.</returns>
        public String ReduceMatrix(String mat)
        {
            return PerformUniaryOperation(mat, (Matrix m) => m.RREF());
        }

        /// <summary>
        /// Inverts a matrix.
        /// </summary>
        /// <param name="mat">A representation of the matrix.</param>
        /// <returns>A representation of the result matrix.</returns>
        public String InvertMatrix(String mat)
        {
            return PerformUniaryOperation(mat, (Matrix m) => m.Inverse());
        }

        /// <summary>
        /// Transposes a matrix.
        /// </summary>
        /// <param name="mat">A representation of the matrix.</param>
        /// <returns>A representation of the result matrix.</returns>
        public String TransposeMatrix(String mat)
        {
            return PerformUniaryOperation(mat, (Matrix m) => m.Transpose());
        }

        /// <summary>
        /// Calculates the determinant of a matrix.
        /// </summary>
        /// <param name="mat">A String representing the matrix of which to take the determinant.</param>
        /// <returns>The determinant of the matrix represented as a string.</returns>
        public String GetDeterminant(String mat)
        {
            Matrix m = MatrixFromString(mat);
            return "" + m.Determinant();
        }
        
    }
}
