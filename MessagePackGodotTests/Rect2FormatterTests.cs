using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class Rect2FormatterTests
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

    private static Godot.Rect2 TestCase1 => new(1f, 6f, 7f, 5f);
    private static Godot.Rect2 TestCase2 => new(6f, 4f, 5f, 1f);
    private static Godot.Rect2 TestCase3 => new(12f, 5f, 3f, 8f);
    
    

    [TestCaseSource(nameof(Rect2Cases))]
    public void Rect2FormatterTest(Godot.Rect2 rect2)
    {
        var rect2Serializer = MessagePackSerializer.Deserialize<Godot.Rect2>(MessagePackSerializer.Serialize(rect2));
        
        Assert.AreEqual(rect2, rect2Serializer);
    }

    public static Godot.Rect2[] Rect2Cases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(Rect2NullableCases))]
    public void Rect2NullableFormatterTest(Godot.Rect2? rect2)
    {
        var rect2Serializer = MessagePackSerializer.Deserialize<Godot.Rect2?>(MessagePackSerializer.Serialize(rect2));
        
        Assert.AreEqual(rect2, rect2Serializer);
    }
    
    public static Godot.Rect2?[] Rect2NullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(Rect2ArrayCases))]
    public void Rect2ArrayFormatterTest(Godot.Rect2[] rect2)
    {
        var rect2Serialized = MessagePackSerializer.Deserialize<Godot.Rect2[]>(MessagePackSerializer.Serialize(rect2));
        Assert.AreEqual(rect2, rect2Serialized);
    }

    public static Godot.Rect2[][] Rect2ArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(Rect2ArrayNullableCases))]
    public void Rect2ArrayNullableFormatterTest(Godot.Rect2?[] rect2)
    {
        var rect2Serialized = MessagePackSerializer.Deserialize<Godot.Rect2?[]>(MessagePackSerializer.Serialize(rect2));
        Assert.AreEqual(rect2, rect2Serialized);
    }

    public static Godot.Rect2?[][] Rect2ArrayNullableCases =
    {
        new Godot.Rect2?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void Rect2ListFormatterTest()
    {
        var rect2List = new List<Godot.Rect2>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var rect2Serialized = MessagePackSerializer.Deserialize<List<Godot.Rect2>>(MessagePackSerializer.Serialize(rect2List));
        Assert.AreEqual(rect2List, rect2Serialized);
    }
    
    [Test]
    public void Rect2ListNullableFormatterTest()
    {
        var rect2List = new List<Godot.Rect2?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var rect2Serialized = MessagePackSerializer.Deserialize<List<Godot.Rect2?>>(MessagePackSerializer.Serialize(rect2List));
        Assert.AreEqual(rect2List, rect2Serialized);
    }
}