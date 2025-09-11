using MySolution.Domain.Entities;

namespace MySolution.Domain.UnitTests.Entities
{
    public class UserTests
    {
        //// Helper method to create a valid user instance for tests
        //private User CreateValidUser()
        //{
        //    return new User(
        //        Guid.NewGuid(),
        //        "Test User",
        //        "test@example.com",
        //        new byte[] { 1, 2, 3 },
        //        new byte[] { 4, 5, 6 },
        //        DateTime.UtcNow,
        //        null
        //    );
        //}

        //#region Constructor Tests

        //[Fact]
        //public void Constructor_ShouldCreateUser_WhenAllParametersAreValid()
        //{
        //    // Arrange
        //    var id = Guid.NewGuid();
        //    var name = "Valid User";
        //    var email = "valid@email.com";
        //    var hash = new byte[] { 1 };
        //    var salt = new byte[] { 1 };
        //    var created = DateTime.UtcNow;

        //    // Act
        //    var user = new User(id, name, email, hash, salt, created, null);

        //    // Assert
        //    Assert.NotNull(user);
        //    Assert.Equal(id, user.Id);
        //    Assert.Equal(name, user.Name);
        //    Assert.Equal(email, user.Email);
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //public void Constructor_ShouldThrowInvalidOperationException_WhenNameIsEmptyOrWhitespace(string invalidName)
        //{
        //    // Arrange, Act & Assert
        //    Assert.Throws<InvalidOperationException>(() => new User(
        //        Guid.NewGuid(),
        //        invalidName,
        //        "test@example.com",
        //        new byte[] { 1 },
        //        new byte[] { 1 },
        //        DateTime.UtcNow,
        //        null
        //    ));
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //public void Constructor_ShouldThrowInvalidOperationException_WhenEmailIsEmptyOrWhitespace(string invalidEmail)
        //{
        //    // Arrange, Act & Assert
        //    Assert.Throws<InvalidOperationException>(() => new User(
        //        Guid.NewGuid(),
        //        "Test User",
        //        invalidEmail,
        //        new byte[] { 1 },
        //        new byte[] { 1 },
        //        DateTime.UtcNow,
        //        null
        //    ));
        //}

        //[Fact]
        //public void Constructor_ShouldThrowInvalidOperationException_WhenPasswordHashIsNull()
        //{
        //    // Arrange, Act & Assert
        //    Assert.Throws<InvalidOperationException>(() => new User(
        //        Guid.NewGuid(),
        //        "Test User",
        //        "test@example.com",
        //        null!, // Invalid hash
        //        new byte[] { 1 },
        //        DateTime.UtcNow,
        //        null
        //    ));
        //}

        //[Fact]
        //public void Constructor_ShouldThrowInvalidOperationException_WhenPasswordSaltIsNull()
        //{
        //    // Arrange, Act & Assert
        //    Assert.Throws<InvalidOperationException>(() => new User(
        //        Guid.NewGuid(),
        //        "Test User",
        //        "test@example.com",
        //        new byte[] { 1 },
        //        null!, // Invalid salt
        //        DateTime.UtcNow,
        //        null
        //    ));
        //}
        //#endregion

        //#region Method Tests

        //[Fact]
        //public void UpdatePassword_ShouldUpdateHashAndSalt_WhenCalled()
        //{
        //    // Arrange
        //    var user = CreateValidUser();
        //    var newHash = new byte[] { 10, 20, 30 };
        //    var newSalt = new byte[] { 40, 50, 60 };

        //    // Act
        //    user.UpdatePassword(newHash, newSalt);

        //    // Assert
        //    Assert.Equal(newHash, user.PasswordHash);
        //    Assert.Equal(newSalt, user.PasswordSalt);
        //}

        //[Fact]
        //public void UpdateLastTimeActive_ShouldUpdateLastActiveProperty_ToCurrentUtcTime()
        //{
        //    // Arrange
        //    var user = CreateValidUser();
        //    var timeBeforeUpdate = DateTime.UtcNow;

        //    // Act
        //    user.UpdateLastTimeActive();

        //    // Assert
        //    Assert.NotNull(user.LastActive);
        //    Assert.True(user.LastActive >= timeBeforeUpdate);
        //}

        //[Fact]
        //public void UpdateProfile_ShouldUpdateNameAndEmail_WhenParametersAreValid()
        //{
        //    // Arrange
        //    var user = CreateValidUser();
        //    var newName = "Updated Name";
        //    var newEmail = "updated@example.com";

        //    // Act
        //    user.UpdateProfile(newName, newEmail);

        //    // Assert
        //    Assert.Equal(newName, user.Name);
        //    Assert.Equal(newEmail, user.Email);
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //public void UpdateProfile_ShouldThrowInvalidOperationException_WhenNameIsEmptyOrWhitespace(string invalidName)
        //{
        //    // Arrange
        //    var user = CreateValidUser();

        //    // Act & Assert
        //    Assert.Throws<InvalidOperationException>(() => user.UpdateProfile(invalidName, "new@email.com"));
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //public void UpdateProfile_ShouldThrowInvalidOperationException_WhenEmailIsEmptyOrWhitespace(string invalidEmail)
        //{
        //    // Arrange
        //    var user = CreateValidUser();

        //    // Act & Assert
        //    Assert.Throws<InvalidOperationException>(() => user.UpdateProfile("New Name", invalidEmail));
        //}
        //#endregion

    }
}
