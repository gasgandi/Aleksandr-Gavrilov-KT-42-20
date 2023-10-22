using System.Collections.Generic;
using Aleksandr_Gavrilov_KT_42_20.Models;
using Xunit;


namespace AleksandrGavrilovKt_42_20.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT3120_True()
        {
            //arrange
            var testGroup = new Group
            {
                GroupName = "KT-31-20"
            };

            //act
            var result = testGroup.IsValidGroupName();

            //assert
            Assert.False(result);
        }
    }
}