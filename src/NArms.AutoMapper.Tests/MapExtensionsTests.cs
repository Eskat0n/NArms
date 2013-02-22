namespace NArms.AutoMapper.Tests
{
    using NUnit.Framework;
    using global::AutoMapper;

    [TestFixture]
    public class MapExtensionsTests
    {
        private class SourceObject
        {
            public int IntValue { get; set; }

            public string StringValue { get; set; }

            public int FirstValue { get; set; }
        }
        
        private class DestinationObject
        {
            public int IntValue { get; set; }

            public string StringValue { get; set; }

            public int SecondValue { get; set; }
        }

        private class StubProfile : Profile
        {
            protected override void Configure()
            {
                CreateMap<SourceObject, DestinationObject>()
                    .ForMember(x => x.SecondValue, x => x.MapFrom(z => z.FirstValue));
            }
        }

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            Mapper.AddProfile<StubProfile>();
        }

        [Test]
        public void ShouldMapToImplicitlySpecifiedType()
        {
            var sourceObject = new SourceObject { IntValue = 5, StringValue = "five", FirstValue = 10 };

            var destinationObject = sourceObject.MapTo() as DestinationObject;

            Assert.NotNull(destinationObject);
            Assert.AreEqual(sourceObject.IntValue, destinationObject.IntValue);
            Assert.AreEqual(sourceObject.StringValue, destinationObject.StringValue);
            Assert.AreEqual(sourceObject.FirstValue, destinationObject.SecondValue);
        }
    }
}
