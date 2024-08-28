using Domain.Entities;

namespace Backend.Tests.Domain;

public class DomainTests
{
    [Fact]
    public void UlidCreatedOnInstanciationTest()
    {
        //Arange & Act
        var adm = new Admin(
            "Paulo",
            "Henrique",
            "mail@test.com",
            "123456",
            new DateOnly(1998, 4, 29),
            Gender.Male);


        //Assert
        Assert.Equal(typeof(Ulid), adm.Id.GetType());
    }
    
    
}