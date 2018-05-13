using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixDemo.RTW;

namespace MatrixDemo
{
    /// <summary>
    /// The DemoController class takes operations from the view and processes them to display the results.
    /// </summary>
    public class DemoController : IDemoViewController
    {
        /// <summary>
        /// This controller's view.
        /// </summary>
        private DemoView view;
        /// <summary>
        /// Accesses the controller's view.
        /// </summary>
        public DemoView View { get { return view; } }
        /// <summary>
        /// The model for the program.
        /// </summary>
        private DemoModel model;

        /// <summary>
        /// Initializes the controller.
        /// </summary>
        public DemoController()
        {
            view = new DemoView(this);
            model = new DemoModel();
        }

        /// <summary>
        /// Processes a binary operation on two strings.
        /// </summary>
        /// <param name="lhs">The left hand side.</param>
        /// <param name="rhs">The right hand side.</param>
        /// <returns>A string representing the result.</returns>
        private delegate String BinaryProcess(String lhs, String rhs);

        /// <summary>
        /// Performs a binary operation and displays the results (or exceptions) to the view.
        /// </summary>
        /// <param name="lhs">The left hand side of the operation.</param>
        /// <param name="rhs">The right hand side of the operation.</param>
        /// <param name="op">The operation to perform,</param>
        private void DoBinaryOperation(String lhs, String rhs, BinaryProcess op)
        {
            try
            {
                String res = op(lhs, rhs);
                view.DisplayBinaryResult(res);
            }
            catch (BadDimensionException e)
            {
                view.DisplayBinaryResult(e.Message);
            }
            catch (Exception e)
            {
                view.DisplayBinaryResult("Error");
            }
        }

        /// <summary>
        /// Processes a uniary operation on a string.
        /// </summary>
        /// <param name="mat">The string to process</param>
        /// <returns>A String representing the result.</returns>
        private delegate String UniaryProcess(String mat);

        /// <summary>
        /// Performs a uniary operation and displays the results (or exceptions) to the view.
        /// </summary>
        /// <param name="mat">The string for the operation.</param>
        /// <param name="op">The operation to perform,</param>
        private void DoUniaryOperation(String mat, UniaryProcess op)
        {
            try
            {
                String res = op(mat);
                view.DisplayUniaryResult(res);
            }
            catch (BadDimensionException e)
            {
                view.DisplayUniaryResult(e.Message);
            }
            catch (Exception e)
            {
                view.DisplayUniaryResult("Error");
            }
        }

        /// <summary>
        /// Called when matrix addition is to be performed.
        /// </summary>
        /// <param name="lhs">The left hand side of the addition.</param>
        /// <param name="rhs">the right hand side of the addition.</param>
        public void MatrixAddition(string lhs, string rhs)
        {
            DoBinaryOperation(lhs, rhs, (String l, String r) => model.AddMatrices(l, r));
        }
        /// <summary>
        /// Called when matrix subtraction is to be performed.
        /// </summary>
        /// <param name="lhs">The left hand side of the subtraction.</param>
        /// <param name="rhs">The right hand side of the subtraction.</param>
        public void MatrixSubtraction(string lhs, string rhs)
        {
            DoBinaryOperation(lhs, rhs, (String l, String r) => model.SubtractMatrices(l, r));
        }
        /// <summary>
        /// Called when scalar multiplication is to be performed.
        /// </summary>
        /// <param name="lhs">The left hand side of the scaling.</param>
        /// <param name="rhs">The right hand side of the scaling</param>
        public void MatrixScaling(string lhs, string rhs)
        {
            DoBinaryOperation(lhs, rhs, (String l, String r) => model.ScaleMatrix(l, r));
        }
        /// <summary>
        /// Called when matrix multiplication is to be performed.
        /// </summary>
        /// <param name="lhs">The left hand side of the multiplication.</param>
        /// <param name="rhs">The right hand side of the multiplication.</param>
        public void MatrixMultiplication(string lhs, string rhs)
        {
            DoBinaryOperation(lhs, rhs, (String l, String r) => model.MultiplyMatrices(l, r));
        }
        /// <summary>
        /// Called for reducing a matrix to RREF.
        /// </summary>
        /// <param name="mat">The matrix to reduce.</param>
        public void MatrixReduction(string mat)
        {
            DoUniaryOperation(mat, (String m) => model.ReduceMatrix(m));
        }
        /// <summary>
        /// Called for inverting a matrix.
        /// </summary>
        /// <param name="mat">The matrix to invert.</param>
        public void MatrixInversion(string mat)
        {
            DoUniaryOperation(mat, (String m) => model.InvertMatrix(m));
        }
        /// <summary>
        /// Called for taking the determinant of a matrix.
        /// </summary>
        /// <param name="mat">The matrix whose determinant to calculate.</param>
        public void MatrixDeterminant(string mat)
        {
            DoUniaryOperation(mat, (String m) => model.GetDeterminant(m));
        }
        /// <summary>
        /// Called for taking the transpose of a matrix.
        /// </summary>
        /// <param name="mat">The matrix to transpose.</param>
        public void MatrixTranspose(string mat)
        {
            DoUniaryOperation(mat, (String m) => model.TransposeMatrix(m));
        }
    }
}
