using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixDemo
{
    public partial class DemoView : Form
    {
        /// <summary>
        /// The controller to receive ciew actions.
        /// </summary>
        private IDemoViewController controller;

        public DemoView(IDemoViewController controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        /// <summary>
        /// Displays a result of a uniary operation.
        /// </summary>
        /// <param name="result">The result to display.</param>
        public void DisplayUniaryResult(String result)
        {
            uniaryResultBox.Text = result;
        }

        /// <summary>
        /// Displays a result of a binary operation.
        /// </summary>
        /// <param name="result">The result to display.</param>
        public void DisplayBinaryResult(String result)
        {
            resultBox.Text = result;
        }

        /// <summary>
        /// Performs matrix addition.
        /// </summary>
        /// <param name="sender">The button pressed.</param>
        /// <param name="e">Details about the event.</param>
        private void addButton_Click(object sender, EventArgs e)
        {
            controller.MatrixAddition(leftMatrixBox.Text, rightMatrixBox.Text);
        }


        /// <summary>
        /// Performs matrix subtraction.
        /// </summary>
        /// <param name="sender">The button pressed.</param>
        /// <param name="e">Details about the event.</param>
        private void subtractButton_Click(object sender, EventArgs e)
        {
            controller.MatrixSubtraction(leftMatrixBox.Text, rightMatrixBox.Text);
        }

        /// <summary>
        /// Performs matrix multiplication.
        /// </summary>
        /// <param name="sender">The button pressed.</param>
        /// <param name="e">Details about the event.</param>
        private void multiplyButton_Click(object sender, EventArgs e)
        {
            controller.MatrixMultiplication(leftMatrixBox.Text, rightMatrixBox.Text);
        }

        /// <summary>
        /// Performs scalar multiplication.
        /// </summary>
        /// <param name="sender">The button pressed.</param>
        /// <param name="e">Details about the event.</param>
        private void scaleButton_Click(object sender, EventArgs e)
        {
            controller.MatrixScaling(leftMatrixBox.Text, rightMatrixBox.Text);
        }

        private void rrefButton_Click(object sender, EventArgs e)
        {
            controller.MatrixReduction(uniaryMatrixBox.Text);
        }

        private void determinantButton_Click(object sender, EventArgs e)
        {
            controller.MatrixDeterminant(uniaryMatrixBox.Text);
        }

        private void inverseButton_Click(object sender, EventArgs e)
        {
            controller.MatrixInversion(uniaryMatrixBox.Text);
        }

        private void transposeButton_Click(object sender, EventArgs e)
        {
            controller.MatrixTranspose(uniaryMatrixBox.Text);
        }
    }
}
