using FluentAssertions;
using Xunit;
using StatePattern.Models;

namespace StatePattern.UnitTests
{
    public class DocumentTests
    {
        [Fact]
        public void Order_WhenCreated_ShouldBeDraft()
        {
            // Arrange

            // Act
            Document document = new Document();

            // Assert
            document.State.Should().Be(DocumentState.Draft);
        }

        [Fact]
        public void Publish_WhenDraft_ShouldBeModeration()
        {
            // Arrange
            Document document = new Document();

            // Act
            document.Publish();

            // Assert
            document.State.Should().Be(DocumentState.Moderation);
        }

        [Fact]
        public void Publish_WhenModerationRoleIsAdmin_ShouldBePublished()
        {
            // Arrange
            CurrentUser.Role = "admin";

            Document document = new Document();
            document.ChangeState(DocumentState.Moderation);

            // Act
            document.Publish();

            // Assert
            document.State.Should().Be(DocumentState.Published);
        }

        [Fact]
        public void Publish_WhenModerationRoleIsNotAdmin_ShouldBeModeration()
        {
            // Arrange
            CurrentUser.Role = "";

            Document document = new Document();
            document.ChangeState(DocumentState.Moderation);

            // Act
            document.Publish();

            // Assert
            document.State.Should().Be(DocumentState.Moderation);
        }
    }
}
