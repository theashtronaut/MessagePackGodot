using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class PlaneFormatterTests
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

    private static Godot.Plane TestCase1 => new(1f, 6f, 7f, 5f);
    private static Godot.Plane TestCase2 => new(6f, 4f, 5f, 1f);
    private static Godot.Plane TestCase3 => new(12f, 5f, 3f, 8f);
    
    

    [TestCaseSource(nameof(PlaneCases))]
    public void PlaneFormatterTest(Godot.Plane plane)
    {
        var planeSerializer = MessagePackSerializer.Deserialize<Godot.Plane>(MessagePackSerializer.Serialize(plane));
        
        Assert.AreEqual(plane, planeSerializer);
    }

    public static Godot.Plane[] PlaneCases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(PlaneNullableCases))]
    public void PlaneNullableFormatterTest(Godot.Plane? plane)
    {
        var planeSerializer = MessagePackSerializer.Deserialize<Godot.Plane?>(MessagePackSerializer.Serialize(plane));
        
        Assert.AreEqual(plane, planeSerializer);
    }
    
    public static Godot.Plane?[] PlaneNullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(PlaneArrayCases))]
    public void PlaneArrayFormatterTest(Godot.Plane[] plane)
    {
        var planeSerialized = MessagePackSerializer.Deserialize<Godot.Plane[]>(MessagePackSerializer.Serialize(plane));
        Assert.AreEqual(plane, planeSerialized);
    }

    public static Godot.Plane[][] PlaneArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(PlaneArrayNullableCases))]
    public void PlaneArrayNullableFormatterTest(Godot.Plane?[] plane)
    {
        var planeSerialized = MessagePackSerializer.Deserialize<Godot.Plane?[]>(MessagePackSerializer.Serialize(plane));
        Assert.AreEqual(plane, planeSerialized);
    }

    public static Godot.Plane?[][] PlaneArrayNullableCases =
    {
        new Godot.Plane?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void PlaneListFormatterTest()
    {
        var planeList = new List<Godot.Plane>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var planeSerialized = MessagePackSerializer.Deserialize<List<Godot.Plane>>(MessagePackSerializer.Serialize(planeList));
        Assert.AreEqual(planeList, planeSerialized);
    }
    
    [Test]
    public void PlaneListNullableFormatterTest()
    {
        var planeList = new List<Godot.Plane?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var planeSerialized = MessagePackSerializer.Deserialize<List<Godot.Plane?>>(MessagePackSerializer.Serialize(planeList));
        Assert.AreEqual(planeList, planeSerialized);
    }
}