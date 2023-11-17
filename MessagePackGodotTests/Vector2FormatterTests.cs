using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class Vector2FormatterTests
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

    private static Godot.Vector2 TestCase1 => new(1f, 6f);
    private static Godot.Vector2 TestCase2 => new(6f, 4f);
    private static Godot.Vector2 TestCase3 => new(12f, 5f);
    
    

    [TestCaseSource(nameof(Vector2Cases))]
    public void Vector2FormatterTest(Godot.Vector2 vector2)
    {
        var vector2Serializer = MessagePackSerializer.Deserialize<Godot.Vector2>(MessagePackSerializer.Serialize(vector2));
        
        Assert.AreEqual(vector2, vector2Serializer);
    }

    public static Godot.Vector2[] Vector2Cases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(Vector2NullableCases))]
    public void Vector2NullableFormatterTest(Godot.Vector2? vector2)
    {
        var vector2Serializer = MessagePackSerializer.Deserialize<Godot.Vector2?>(MessagePackSerializer.Serialize(vector2));
        
        Assert.AreEqual(vector2, vector2Serializer);
    }
    
    public static Godot.Vector2?[] Vector2NullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(Vector2ArrayCases))]
    public void Vector2ArrayFormatterTest(Godot.Vector2[] vector2)
    {
        var vector2Serialized = MessagePackSerializer.Deserialize<Godot.Vector2[]>(MessagePackSerializer.Serialize(vector2));
        Assert.AreEqual(vector2, vector2Serialized);
    }

    public static Godot.Vector2[][] Vector2ArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(Vector2ArrayNullableCases))]
    public void Vector2ArrayNullableFormatterTest(Godot.Vector2?[] vector2)
    {
        var vector2Serialized = MessagePackSerializer.Deserialize<Godot.Vector2?[]>(MessagePackSerializer.Serialize(vector2));
        Assert.AreEqual(vector2, vector2Serialized);
    }

    public static Godot.Vector2?[][] Vector2ArrayNullableCases =
    {
        new Godot.Vector2?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void Vector2ListFormatterTest()
    {
        var vector2List = new List<Godot.Vector2>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var vector2Serialized = MessagePackSerializer.Deserialize<List<Godot.Vector2>>(MessagePackSerializer.Serialize(vector2List));
        Assert.AreEqual(vector2List, vector2Serialized);
    }
    
    [Test]
    public void Vector2ListNullableFormatterTest()
    {
        var vector2List = new List<Godot.Vector2?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var vector2Serialized = MessagePackSerializer.Deserialize<List<Godot.Vector2?>>(MessagePackSerializer.Serialize(vector2List));
        Assert.AreEqual(vector2List, vector2Serialized);
    }
}