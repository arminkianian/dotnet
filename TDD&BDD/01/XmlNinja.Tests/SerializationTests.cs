using FluentAssertions;

namespace XmlNinja.Tests
{
    public class SerializationTests
    {
        [Fact]
        public void serialize_empty_tag_for_empty_object()
        {
            // Arrange
            var customer = new Customer();
            var expected = "<Customer></Customer>";

            // Act
            var serialized = NinjaSerializer.Serialize(customer);

            // Assert
            serialized.Should().Be(expected);
        }

        [Fact]
        public void serialize_empty_string_for_null_values()
        {
            // Act
            var serialized = NinjaSerializer.Serialize(null);

            // Assert
            serialized.Should().BeEmpty();
        }

        [Fact]
        public void serialize_flat_object()
        {
            var person = new Person("Armin", "Kianian");
            var expected = @"<Person><FirstName>Armin</FirstName><LastName>Kianian</LastName></Person>";

            // Act
            var serialized = NinjaSerializer.Serialize(person);

            // Assert
            serialized.Should().Be(expected);
        }

        class Customer { }
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
        }

    }
}