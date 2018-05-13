using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixDemo
{ 
    /// <summary>
    /// The IDemoViewController interface provides a MatrixController the ability to receive messages from the view.
    /// </summary>
    public interface IDemoViewController
    {
        /// <summary>
        /// Called when matrix addition is to be performed.
        /// </summary>
        /// <param name="lhs">The left hand side of the addition.</param>
        /// <param name="rhs">the right hand side of the addition.</param>
        void MatrixAddition(String lhs, String rhs);
        /// <summary>
        /// Called when matrix subtraction is to be performed.
        /// </summary>
        /// <param name="lhs">The left hand side of the subtraction.</param>
        /// <param name="rhs">The right hand side of the subtraction.</param>
        void MatrixSubtraction(String lhs, String rhs);
        /// <summary>
        /// Called when scalar multiplication is to be performed.
        /// </summary>
        /// <param name="lhs">The left hand side of the scaling.</param>
        /// <param name="rhs">The right hand side of the scaling</param>
        void MatrixScaling(String lhs, String rhs);
        /// <summary>
        /// Called when matrix multiplication is to be performed.
        /// </summary>
        /// <param name="lhs">The left hand side of the multiplication.</param>
        /// <param name="rhs">The right hand side of the multiplication.</param>
        void MatrixMultiplication(String lhs, String rhs);
        /// <summary>
        /// Called for reducing a matrix to RREF.
        /// </summary>
        /// <param name="mat">The matrix to reduce.</param>
        void MatrixReduction(String mat);
        /// <summary>
        /// Called for inverting a matrix.
        /// </summary>
        /// <param name="mat">The matrix to invert.</param>
        void MatrixInversion(String mat);
        /// <summary>
        /// Called for taking the determinant of a matrix.
        /// </summary>
        /// <param name="mat">The matrix whose determinant to calculate.</param>
        void MatrixDeterminant(String mat);
        /// <summary>
        /// Called for taking the transpose of a matrix.
        /// </summary>
        /// <param name="mat">The matrix to transpose.</param>
        void MatrixTranspose(String mat);
        
    }
}
