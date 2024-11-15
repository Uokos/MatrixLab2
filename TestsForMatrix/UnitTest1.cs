using MatrixCalculation;

namespace TestsForMatrix
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void CorrectRowNumberInMatrixTest()
        {
            var matrixA = new Matrix<int>(new[,] { { 0, 1, 2 }, { 3, 4, 5 } });
            Assert.That(matrixA.Rows, Is.EqualTo(2));
        }

        [Test]
        public void CorrectColumnNumberInMatrixTest()
        {
            var matrixA = new Matrix<int>(new[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
            Assert.That(matrixA.Cols, Is.EqualTo(3));
        }

        [Test]
        public void MatrixAddition_ValidInput_ReturnsCorrectResult()
        {
            var matrixA = new Matrix<int>(new int[,] { { 1, 2 }, { 3, 4 } });
            var matrixB = new Matrix<int>(new int[,] { { 5, 6 }, { 7, 8 } });
            var expected = new Matrix<int>(new int[,] { { 6, 8 }, { 10, 12 } });

            var result = matrixA + matrixB;

            for (int i = 0; i < expected.Rows; i++)
            {
                for (int j = 0; j < expected.Cols; j++)
                {
                    Assert.AreEqual(expected[i, j], result[i, j]);
                }
            }
        }

        [Test]
        public void MatrixMultiplication_ValidInput_ReturnsCorrectResult()
        {
            var matrixA = new Matrix<int>(new int[,] { { 1, 2 }, { 3, 4 } });
            var matrixB = new Matrix<int>(new int[,] { { 5, 6 }, { 7, 8 } });
            var expected = new Matrix<int>(new int[,] { { 19, 22 }, { 43, 50 } });

            var result = matrixA * matrixB;

            for (int i = 0; i < expected.Rows; i++)
            {
                for (int j = 0; j < expected.Cols; j++)
                {
                    Assert.AreEqual(expected[i, j], result[i, j]);
                }
            }
        }

        [Test]
        public void MatrixAddition_DifferentDimensions_ThrowsException()
        {
            var matrixA = new Matrix<int>(new int[,] { { 1, 2 } });
            var matrixB = new Matrix<int>(new int[,] { { 3, 4 }, { 5, 6 } });

            Assert.Throws<ArgumentException>(() => { var result = matrixA + matrixB; });
        }

        [Test]
        public void MatrixMultiplication_IncompatibleDimensions_ThrowsException()
        {
            var matrixA = new Matrix<int>(new int[,] { { 1, 2 } });
            var matrixB = new Matrix<int>(new int[,] { { 3, 4 } });

            Assert.Throws<ArgumentException>(() => { var result = matrixA * matrixB; });
        }

        [Test]
        public void MatrixIndexing_GetAndSetValues_ReturnsCorrectValues()
        {
            var matrix = new Matrix<int>(2, 2);
            matrix[0, 0] = 42;

            Assert.AreEqual(42, matrix[0, 0]);
        }

        [Test]
        public void MatrixEquality_SameMatrices_ReturnsTrue()
        {
            var matrixA = new Matrix<int>(new int[,] { { 1, 2 }, { 3, 4 } });
            var matrixB = new Matrix<int>(new int[,] { { 1, 2 }, { 3, 4 } });

            for (int i = 0; i < matrixA.Rows; i++)
            {
                for (int j = 0; j < matrixA.Cols; j++)
                {
                    Assert.AreEqual(matrixA[i, j], matrixB[i, j]);
                }
            }
        }

        [Test]
        public void MatrixEquality_DifferentMatrices_ReturnsFalse()
        {
            var matrixA = new Matrix<int>(new int[,] { { 1, 2 }, { 3, 4 } });
            var matrixB = new Matrix<int>(new int[,] { { 5, 6 }, { 7, 8 } });

            Assert.AreNotEqual(matrixA, matrixB);
        }

        [Test]
        public void MatrixAddition_WithFloatValues_ReturnsCorrectResult()
        {
            var matrixA = new Matrix<float>(new float[,] { { 1.1f, 2.2f }, { 3.3f, 4.4f } });
            var matrixB = new Matrix<float>(new float[,] { { 0.9f, 1.8f }, { 2.7f, 3.6f } });
            var expected = new Matrix<float>(new float[,] { { 2.0f, 4.0f }, { 6.0f, 8.0f } });

            var result = matrixA + matrixB;

            for (int i = 0; i < expected.Rows; i++)
            {
                for (int j = 0; j < expected.Cols; j++)
                {
                    Assert.AreEqual(expected[i, j], result[i, j]);
                }
            }
        }
    }
}