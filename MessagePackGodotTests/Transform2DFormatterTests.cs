using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class Transform2DFormatterTests
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

    private static Godot.Transform2D TestCase1 => new(1f, new Godot.Vector2(1f, 2f), 7f, new Godot.Vector2(4f, 8f));
    private static Godot.Transform2D TestCase2 => new(6f, new Godot.Vector2(4f, 16f), 5f, new Godot.Vector2(7f, 1f));
    private static Godot.Transform2D TestCase3 => new(12f, new Godot.Vector2(5f, 8f), 3f, new Godot.Vector2(8f, 72f));
    
    

    [TestCaseSource(nameof(Transform2DCases))]
    public void Transform2DFormatterTest(Godot.Transform2D transform2D)
    {
        var transform2DSerializer = MessagePackSerializer.Deserialize<Godot.Transform2D>(MessagePackSerializer.Serialize(transform2D));
        
        Assert.AreEqual(transform2D, transform2DSerializer);
    }

    public static Godot.Transform2D[] Transform2DCases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(Transform2DNullableCases))]
    public void Transform2DNullableFormatterTest(Godot.Transform2D? transform2D)
    {
        var transform2DSerializer = MessagePackSerializer.Deserialize<Godot.Transform2D?>(MessagePackSerializer.Serialize(transform2D));
        
        Assert.AreEqual(transform2D, transform2DSerializer);
    }
    
    public static Godot.Transform2D?[] Transform2DNullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(Transform2DArrayCases))]
    public void Transform2DArrayFormatterTest(Godot.Transform2D[] transform2D)
    {
        var transform2DSerialized = MessagePackSerializer.Deserialize<Godot.Transform2D[]>(MessagePackSerializer.Serialize(transform2D));
        Assert.AreEqual(transform2D, transform2DSerialized);
    }

    public static Godot.Transform2D[][] Transform2DArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(Transform2DArrayNullableCases))]
    public void Transform2DArrayNullableFormatterTest(Godot.Transform2D?[] transform2D)
    {
        var transform2DSerialized = MessagePackSerializer.Deserialize<Godot.Transform2D?[]>(MessagePackSerializer.Serialize(transform2D));
        Assert.AreEqual(transform2D, transform2DSerialized);
    }

    public static Godot.Transform2D?[][] Transform2DArrayNullableCases =
    {
        new Godot.Transform2D?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void Transform2DListFormatterTest()
    {
        var transform2DList = new List<Godot.Transform2D>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var transform2DSerialized = MessagePackSerializer.Deserialize<List<Godot.Transform2D>>(MessagePackSerializer.Serialize(transform2DList));
        Assert.AreEqual(transform2DList, transform2DSerialized);
    }
    
    [Test]
    public void Transform2DListNullableFormatterTest()
    {
        var transform2DList = new List<Godot.Transform2D?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var transform2DSerialized = MessagePackSerializer.Deserialize<List<Godot.Transform2D?>>(MessagePackSerializer.Serialize(transform2DList));
        Assert.AreEqual(transform2DList, transform2DSerialized);
    }
}