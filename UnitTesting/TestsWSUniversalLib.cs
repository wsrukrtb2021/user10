using NUnit.Framework;
using UnitTesting;
using WSUniversalLib;

namespace UnitTesting
{
    [TestFixture]
    public class TestsWSUniversalLib
    {
        #region EasyTest
        [Test]
        public void GetQuantityForProduct_NonExistentProductType()
        {
            int request = -1;
            int response = new Calculation().GetQuantityForProduct(
                4, 1, 10, 20.5f, 40.4f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_NonExistentMaterialType()
        {
            int request = -1;
            int response = new Calculation().GetQuantityForProduct(
                2, 3, 10, 20.5f, 40.4f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_NonCorrectCount()
        {
            int request = -1;
            int response = new Calculation().GetQuantityForProduct(
                2, 2, -10, 20.5f, 40.4f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_NonCorrectWidth()
        {
            int request = -1;
            int response = new Calculation().GetQuantityForProduct(
                2, 2, 25, -20.5f, 40.4f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_NonCorrectLenght()
        {
            int request = -1;
            int response = new Calculation().GetQuantityForProduct(
                2, 2, 25, 20.5f, -40.4f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_CorrectDataOne()
        {
            int request = 9122;
            int response = new Calculation().GetQuantityForProduct(
                1, 2, 10, 20.5f, 40.4f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_CorrectDataTwo()
        {
            int request = 283145;
            int response = new Calculation().GetQuantityForProduct(
                3, 2, 45, 17.5f, 42.6f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_CorrectDataThree()
        {
            int request = 135005;
            int response = new Calculation().GetQuantityForProduct(
                1, 2, 56, 27.5f, 79.6f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_CorrectDataFourth()
        {
            int request = 185092;
            int response = new Calculation().GetQuantityForProduct(
                3, 2, 34, 12.5f, 51.6f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_CorrectDataFive()
        {
            int request = 364339;
            int response = new Calculation().GetQuantityForProduct(
                3, 1, 50, 15.5f, 55.6f
            );


            Assert.AreEqual(request, response);
        }

        #endregion

        #region HardTest

        [Test]
        public void GetQuantityForProduct_HardIncorrectWidth()
        {
            int request = -1;
            int response = new Calculation().GetQuantityForProduct(
                3, 1, 120, -515.57f, 355.26f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_HardIncorrectLenght()
        {
            int request = -1;
            int response = new Calculation().GetQuantityForProduct(
                3, 1, 710, 415.75f, -855.66f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_CorrectHardDataOne()
        {
            int request = 387514720;
            int response = new Calculation().GetQuantityForProduct(
                3, 1, 310, 415.45f, 355.86f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_CorrectHardDataTwo()
        {
            int request = 969626880;
            int response = new Calculation().GetQuantityForProduct(
                3, 1, 550, 815.55f, 255.66f
            );


            Assert.AreEqual(request, response);
        }

        [Test]
        public void GetQuantityForProduct_CorrectHardDataThree()
        {
            int request = 110239928;
            int response = new Calculation().GetQuantityForProduct(
                3, 1, 120, 195.54f, 555.64f
            );


            Assert.AreEqual(request, response);
        }

        #endregion

    }
}