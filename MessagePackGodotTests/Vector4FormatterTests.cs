using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class Vector4FormatterTests
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

    private static Godot.Vector4 TestCase1 => new(1f, 6f, 7f, 5f);
    private static Godot.Vector4 TestCase2 => new(6f, 4f, 5f, 1f);
    private static Godot.Vector4 TestCase3 => new(12f, 5f, 3f, 8f);
    
    

    [TestCaseSource(nameof(Vector4Cases))]
    public void Vector4FormatterTest(Godot.Vector4 vector4)
    {
        var vector4Serializer = MessagePackSerializer.Deserialize<Godot.Vector4>(MessagePackSerializer.Serialize(vector4));
        
        Assert.AreEqual(vector4, vector4Serializer);
    }

    public static Godot.Vector4[] Vector4Cases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(Vector4NullableCases))]
    public void Vector4NullableFormatterTest(Godot.Vector4? vector4)
    {
        var vector4Serializer = MessagePackSerializer.Deserialize<Godot.Vector4?>(MessagePackSerializer.Serialize(vector4));
        
        Assert.AreEqual(vector4, vector4Serializer);
    }
    
    public static Godot.Vector4?[] Vector4NullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(Vector4ArrayCases))]
    public void Vector4ArrayFormatterTest(Godot.Vector4[] vector4)
    {
        var vector4Serialized = MessagePackSerializer.Deserialize<Godot.Vector4[]>(MessagePackSerializer.Serialize(vector4));
        Assert.AreEqual(vector4, vector4Serialized);
    }

    public static Godot.Vector4[][] Vector4ArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(Vector4ArrayNullableCases))]
    public void Vector4ArrayNullableFormatterTest(Godot.Vector4?[] vector4)
    {
        var vector4Serialized = MessagePackSerializer.Deserialize<Godot.Vector4?[]>(MessagePackSerializer.Serialize(vector4));
        Assert.AreEqual(vector4, vector4Serialized);
    }

    public static Godot.Vector4?[][] Vector4ArrayNullableCases =
    {
        new Godot.Vector4?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void Vector4ListFormatterTest()
    {
        var vector4List = new List<Godot.Vector4>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var vector4Serialized = MessagePackSerializer.Deserialize<List<Godot.Vector4>>(MessagePackSerializer.Serialize(vector4List));
        Assert.AreEqual(vector4List, vector4Serialized);
    }
    
    [Test]
    public void Vector4ListNullableFormatterTest()
    {
        var vector4List = new List<Godot.Vector4?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var vector4Serialized = MessagePackSerializer.Deserialize<List<Godot.Vector4?>>(MessagePackSerializer.Serialize(vector4List));
        Assert.AreEqual(vector4List, vector4Serialized);
    }
}