using DDD_Test_Project.Object;

namespace DDD_Test_Project.Test.Object
{
    public class Object
    {
        [InlineData(1, 1.0)] // 일반 부여
        [InlineData(4000, 2000.0)] // 최대 초과
        [InlineData(-2000, 0.0)] // 최소 초과
        [Theory(DisplayName = "DDD Value : Artist.Width<int> Value Test")]
        public void DDDTest_Width_int_Test(object value, double outValue)
        {
            // Arange

            // Act
            var width = new Width<int>(Convert.ToInt32(value));

            // Assert
            width.GetValue().Should().Be(outValue);
        }

        [InlineData(1.0, 1.0)] // 일반 부여
        [InlineData(4000.0, 2000.0)] // 최대 초과
        [InlineData(-2000.0, 0.0)] // 최소 초과
        [Theory(DisplayName = "DDD Value : Artist.Width<double> Value Test")]
        public void DDDTest_Width_double_Test(double value, double outValue)
        {
            // Arange

            // Act
            var width = new Width<double>(value);

            // Assert
            width.GetValue().Should().Be(outValue);
        }

        [InlineData(1.0, 0.0, 2.0, 1.0)] // 일반 부여
        [InlineData(1.0, 100.0, 200.0, 100.0)] // 최소 초과
        [InlineData(1.0, -100.0, -10.0, -10.0)] // 최대 초과
        [Theory(DisplayName = "DDD Value : Artist.Width<double> MinMax Value Test")]
        public void DDDTest_Width_double_MinMax_Test(double value, double minValue, double maxValue, double outValue)
        {
            // Arange

            // Act
            var width = new Width<double>(value, minValue, maxValue);

            // Assert
            width.GetValue().Should().Be(outValue);
        }

        [InlineData(1.0, 4000.0, 2.0, 1.0, "입력 값이 2000보다 큽니다.")] // 최소 예외
        [InlineData(1.0, 0.0, -100.0, 1.0, "입력 값이 0보다 작습니다.")] // 최대 예외
        [Theory(DisplayName = "DDD Value : Artist.Width<double> Exception Test")]
        public void DDDTest_Width_double_Exception_Test(double value, double minValue, double maxValue, double outValue, string exceptionMessage)
        {
            // Arange
            string exception = string.Empty;
            var width = new Width<double>(value);

            // Act
            try
            {
                width.SetMinMaxValue(minValue, maxValue);
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            // Assert
            width.GetValue().Should().Be(outValue);
            exception.Should().Be(exceptionMessage);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        public void Width_Constructor_ShouldThrowException(double minValue, double maxValue)
        {
            // Arrange

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Width<double>(0.0f, minValue, maxValue));
        }
    }
}
