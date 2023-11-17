using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class Transform3DFormatterTests
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

    private static Godot.Transform3D TestCase1 => new(new Godot.Vector3(1f, 5f, 8f), new Godot.Vector3(8f, 8f, 6f), new Godot.Vector3(12f, 12f, 78f), new Godot.Vector3(1f, 75f, 5f));
    private static Godot.Transform3D TestCase2 => new(new Godot.Vector3(12f, 52f, 82f), new Godot.Vector3(82f, 82f, 62f), new Godot.Vector3(122f, 122f, 782f), new Godot.Vector3(12f, 725f, 52f));
    private static Godot.Transform3D TestCase3 => new(new Godot.Vector3(31f, 35f, 38f), new Godot.Vector3(38f, 38f, 36f), new Godot.Vector3(312f, 312f, 378f), new Godot.Vector3(31f, 375f, 5f));
    
    

    [TestCaseSource(nameof(Transform3DCases))]
    public void Transform3DFormatterTest(Godot.Transform3D transform3D)
    {
        var transform3DSerializer = MessagePackSerializer.Deserialize<Godot.Transform3D>(MessagePackSerializer.Serialize(transform3D));
        
        Assert.AreEqual(transform3D, transform3DSerializer);
    }

    public static Godot.Transform3D[] Transform3DCases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(Transform3DNullableCases))]
    public void Transform3DNullableFormatterTest(Godot.Transform3D? transform3D)
    {
        var transform3DSerializer = MessagePackSerializer.Deserialize<Godot.Transform3D?>(MessagePackSerializer.Serialize(transform3D));
        
        Assert.AreEqual(transform3D, transform3DSerializer);
    }
    
    public static Godot.Transform3D?[] Transform3DNullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(Transform3DArrayCases))]
    public void Transform3DArrayFormatterTest(Godot.Transform3D[] transform3D)
    {
        var transform3DSerialized = MessagePackSerializer.Deserialize<Godot.Transform3D[]>(MessagePackSerializer.Serialize(transform3D));
        Assert.AreEqual(transform3D, transform3DSerialized);
    }

    public static Godot.Transform3D[][] Transform3DArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(Transform3DArrayNullableCases))]
    public void Transform3DArrayNullableFormatterTest(Godot.Transform3D?[] transform3D)
    {
        var transform3DSerialized = MessagePackSerializer.Deserialize<Godot.Transform3D?[]>(MessagePackSerializer.Serialize(transform3D));
        Assert.AreEqual(transform3D, transform3DSerialized);
    }

    public static Godot.Transform3D?[][] Transform3DArrayNullableCases =
    {
        new Godot.Transform3D?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void Transform3DListFormatterTest()
    {
        var transform3DList = new List<Godot.Transform3D>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var transform3DSerialized = MessagePackSerializer.Deserialize<List<Godot.Transform3D>>(MessagePackSerializer.Serialize(transform3DList));
        Assert.AreEqual(transform3DList, transform3DSerialized);
    }
    
    [Test]
    public void Transform3DListNullableFormatterTest()
    {
        var transform3DList = new List<Godot.Transform3D?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var transform3DSerialized = MessagePackSerializer.Deserialize<List<Godot.Transform3D?>>(MessagePackSerializer.Serialize(transform3DList));
        Assert.AreEqual(transform3DList, transform3DSerialized);
    }
}