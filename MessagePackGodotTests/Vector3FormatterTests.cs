using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class Vector3FormatterTests
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

    private static Godot.Vector3 TestCase1 => new(1f, 6f, 7f);
    private static Godot.Vector3 TestCase2 => new(6f, 4f, 5f);
    private static Godot.Vector3 TestCase3 => new(12f, 5f, 3f);
    
    

    [TestCaseSource(nameof(Vector3Cases))]
    public void Vector3FormatterTest(Godot.Vector3 vector3)
    {
        var vector3Serializer = MessagePackSerializer.Deserialize<Godot.Vector3>(MessagePackSerializer.Serialize(vector3));
        
        Assert.AreEqual(vector3, vector3Serializer);
    }

    public static Godot.Vector3[] Vector3Cases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(Vector3NullableCases))]
    public void Vector3NullableFormatterTest(Godot.Vector3? vector3)
    {
        var vector3Serializer = MessagePackSerializer.Deserialize<Godot.Vector3?>(MessagePackSerializer.Serialize(vector3));
        
        Assert.AreEqual(vector3, vector3Serializer);
    }
    
    public static Godot.Vector3?[] Vector3NullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(Vector3ArrayCases))]
    public void Vector3ArrayFormatterTest(Godot.Vector3[] vector3)
    {
        var vector3Serialized = MessagePackSerializer.Deserialize<Godot.Vector3[]>(MessagePackSerializer.Serialize(vector3));
        Assert.AreEqual(vector3, vector3Serialized);
    }

    public static Godot.Vector3[][] Vector3ArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(Vector3ArrayNullableCases))]
    public void Vector3ArrayNullableFormatterTest(Godot.Vector3?[] vector3)
    {
        var vector3Serialized = MessagePackSerializer.Deserialize<Godot.Vector3?[]>(MessagePackSerializer.Serialize(vector3));
        Assert.AreEqual(vector3, vector3Serialized);
    }

    public static Godot.Vector3?[][] Vector3ArrayNullableCases =
    {
        new Godot.Vector3?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void Vector3ListFormatterTest()
    {
        var vector3List = new List<Godot.Vector3>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var vector3Serialized = MessagePackSerializer.Deserialize<List<Godot.Vector3>>(MessagePackSerializer.Serialize(vector3List));
        Assert.AreEqual(vector3List, vector3Serialized);
    }
    
    [Test]
    public void Vector3ListNullableFormatterTest()
    {
        var vector3List = new List<Godot.Vector3?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var vector3Serialized = MessagePackSerializer.Deserialize<List<Godot.Vector3?>>(MessagePackSerializer.Serialize(vector3List));
        Assert.AreEqual(vector3List, vector3Serialized);
    }
}