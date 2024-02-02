namespace H5APITest
{
    public class UnitTest1
    {
        [Fact]
        public void TestAssertTrue()
        {
            Assert.True(1 == 1);
        }
        [Fact]
        public void TestAssertFalse()
        {
            Assert.False(1 == 1);
        }
    }
}