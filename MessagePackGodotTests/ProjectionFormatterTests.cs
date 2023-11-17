using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class ProjectionFormatterTests
{
    [SetUp]
    public void SetUp()
    {
        // initialize MessagePack resolvers
        var resolver = MessagePack.Resolvers.CompositeResolver.Create(
            // enable extension packages first
            GodotResolver.Instance,

            // finally use standard (default) resolver
            MessagePack.Resolvers.StandardResolver.Instance
        );
        var options = MessagePackSerializerOptions.Standard.WithResolver(resolver);
            
        // pass options every time to set as default
        MessagePackSerializer.DefaultOptions = options;
    }

    private static Godot.Projection TestCase1 => new(new Godot.Vector4(1f, 5f, 8f, 6f), new Godot.Vector4(8f, 8f, 6f, 12f), new Godot.Vector4(12f, 12f, 78f, 12f), new Godot.Vector4(1f, 75f, 5f, 4f));
    private static Godot.Projection TestCase2 => new(new Godot.Vector4(12f, 52f, 82f, 62f), new Godot.Vector4(82f, 82f, 62f, 122f), new Godot.Vector4(122f, 122f, 782f, 122f), new Godot.Vector4(12f, 725f, 52f, 24f));
    private static Godot.Projection TestCase3 => new(new Godot.Vector4(31f, 35f, 38f, 36f), new Godot.Vector4(38f, 38f, 36f, 312f), new Godot.Vector4(312f, 312f, 378f, 312f), new Godot.Vector4(31f, 375f, 5f, 34f));
    
    

    [TestCaseSource(nameof(ProjectionCases))]
    public void ProjectionFormatterTest(Godot.Projection projection)
    {
        var projectionSerializer = MessagePackSerializer.Deserialize<Godot.Projection>(MessagePackSerializer.Serialize(projection));
        
        Assert.AreEqual(projection, projectionSerializer);
    }

    public static Godot.Projection[] ProjectionCases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(ProjectionNullableCases))]
    public void ProjectionNullableFormatterTest(Godot.Projection? projection)
    {
        var projectionSerializer = MessagePackSerializer.Deserialize<Godot.Projection?>(MessagePackSerializer.Serialize(projection));
        
        Assert.AreEqual(projection, projectionSerializer);
    }
    
    public static Godot.Projection?[] ProjectionNullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(ProjectionArrayCases))]
    public void ProjectionArrayFormatterTest(Godot.Projection[] projection)
    {
        var projectionSerialized = MessagePackSerializer.Deserialize<Godot.Projection[]>(MessagePackSerializer.Serialize(projection));
        Assert.AreEqual(projection, projectionSerialized);
    }

    public static Godot.Projection[][] ProjectionArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(ProjectionArrayNullableCases))]
    public void ProjectionArrayNullableFormatterTest(Godot.Projection?[] projection)
    {
        var projectionSerialized = MessagePackSerializer.Deserialize<Godot.Projection?[]>(MessagePackSerializer.Serialize(projection));
        Assert.AreEqual(projection, projectionSerialized);
    }

    public static Godot.Projection?[][] ProjectionArrayNullableCases =
    {
        new Godot.Projection?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void ProjectionListFormatterTest()
    {
        var projectionList = new List<Godot.Projection>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var projectionSerialized = MessagePackSerializer.Deserialize<List<Godot.Projection>>(MessagePackSerializer.Serialize(projectionList));
        Assert.AreEqual(projectionList, projectionSerialized);
    }
    
    [Test]
    public void ProjectionListNullableFormatterTest()
    {
        var projectionList = new List<Godot.Projection?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var projectionSerialized = MessagePackSerializer.Deserialize<List<Godot.Projection?>>(MessagePackSerializer.Serialize(projectionList));
        Assert.AreEqual(projectionList, projectionSerialized);
    }
}