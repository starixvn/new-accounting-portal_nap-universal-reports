using NUnit.Framework;
using UniversalReports.Core.Factory;

namespace UniversalReports.Core.Tests.Factory
{
    public class CriteriaFactoryUniTests
    {
        [Test]
        public void Transform_HappyPath()
        {
            var input = new ModelWithThreeProperties { Property1 = "1", Property2 = 2, Property3 = 3.0m };
            var expected = new ModelWithThreeProperties { Property1 = "1", Property2 = 2, Property3 = 3.0m };

            var result = CriteriaFactory.Transform<ModelWithThreeProperties>(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Transform_MissOneProperty_ShouldReturnObjectWithoutMissingProperty()
        {
            var input = new ModelWithTwoProperties { Property1 = "1", Property2 = 2 };
            var expected = new ModelWithThreeProperties { Property1 = "1", Property2 = 2, Property3 = 0.0m };

            var result = CriteriaFactory.Transform<ModelWithThreeProperties>(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Transform_TooManyProperties_ShouldReturnObjectWithAllProperties()
        {
            var input = new ModelWithThreeProperties { Property1 = "1", Property2 = 2, Property3 = 3.0m };
            var expected = new ModelWithTwoProperties { Property1 = "1", Property2 = 2 };

            var result = CriteriaFactory.Transform<ModelWithTwoProperties>(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Transform_MixProperties_ShouldReturnObjectWithGrossProperties()
        {
            var input = new ModelWithThreeProperties { Property1 = "1", Property2 = 2, Property3 = 3.0m };
            var expected = new ExModelWithThreeProperties { Property2 = 2, Property3 = 3.0m, Property4 = null };

            var result = CriteriaFactory.Transform<ExModelWithThreeProperties>(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }

    internal class ModelWithTwoProperties
    {
        public string Property1 { get; set; }

        public int Property2 { get; set; }

        public override bool Equals(object obj)
        {
            var model = (ModelWithTwoProperties)obj;
            return model.Property1 == Property1
                && model.Property2 == Property2;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }

    internal class ModelWithThreeProperties
    {
        public string Property1 { get; set; }

        public int Property2 { get; set; }

        public decimal Property3 { get; set; }

        public override bool Equals(object obj)
        {
            var model = (ModelWithThreeProperties)obj;
            return model.Property1 == Property1
                && model.Property2 == Property2
                && model.Property3 == Property3;
        }

        public override int GetHashCode()
        {
            return 2;
        }
    }

    internal class ExModelWithThreeProperties
    {
        public string Property4 { get; set; }

        public int Property2 { get; set; }

        public decimal Property3 { get; set; }

        public override bool Equals(object obj)
        {
            var model = (ExModelWithThreeProperties)obj;
            return model.Property4 == Property4
                && model.Property2 == Property2
                && model.Property3 == Property3;
        }

        public override int GetHashCode()
        {
            return 3;
        }
    }
}