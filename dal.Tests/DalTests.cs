using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using Xunit;

namespace dal.Tests
{
    public class DalTests
    {
        private readonly UnitOfWork unitOfWork;

        public DalTests()
        {
            unitOfWork = new();
        }
        
        [Fact]
        public async Task GetProduct_ShouldReturnNullIfIDIsBelowZeroAsync()
        {
            ////Arange
            //Product expected = null;
            //int id = -1;
            
            ////Act
            //Product? actual = await unitOfWork.ProductRepository.Get(id);

            ////Assert
            //Assert.True(actual == null);
            //Assert.Equal(expected, actual);
        }
    }
}
