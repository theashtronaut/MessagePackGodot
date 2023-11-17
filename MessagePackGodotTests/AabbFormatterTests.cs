using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class AabbFormatterTests
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
    
    private static Godot.Aabb TestCase1 => new(1f, 8f, 7f, 20f, 159f, 1f);
    private static Godot.Aabb TestCase2 => new(26f, 28f, 1f, 200f, 19f, 6f);
    private static Godot.Aabb TestCase3 => new(6f, 88f, 12f, 2f, 9f, 65f);

    [TestCaseSource(nameof(AabbCases))]
    public void AabbFormatterTest(Godot.Aabb aabb)
    {
        var aabbSerialized = MessagePackSerializer.Deserialize<Godot.Aabb>(MessagePackSerializer.Serialize(aabb));
        
        Assert.AreEqual(aabb, aabbSerialized);
    }
    
    public static Godot.Aabb[] AabbCases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(AabbNullableCases))]
    public void AabbNullableFormatterTest(Godot.Aabb? aabb)
    {
        var aabbSerialized = MessagePackSerializer.Deserialize<Godot.Aabb?>(MessagePackSerializer.Serialize(aabb));
        
        Assert.AreEqual(aabb, aabbSerialized);
    }
    
    public static Godot.Aabb?[] AabbNullableCases =
    {
        new Godot.Aabb(26f, 28f, 1f, 200f, 19f, 6f),
        null,
        new Godot.Aabb(1f, 8f, 7f, 20f, 159f, 1f)
    };
    
    [TestCaseSource(nameof(AabbArrayCases))]
    public void AabbArrayFormatterTest(Godot.Aabb[] aabb)
    {
        var aabbSerialized = MessagePackSerializer.Deserialize<Godot.Aabb[]>(MessagePackSerializer.Serialize(aabb));
        Assert.AreEqual(aabb, aabbSerialized);
    }

    public static Godot.Aabb[][] AabbArrayCases =
    {
        new[] {
            new Godot.Aabb(1f, 8f, 7f, 20f, 159f, 1f),
            new Godot.Aabb(26f, 28f, 1f, 200f, 19f, 6f),
            new Godot.Aabb(6f, 88f, 12f, 2f, 9f, 65f)
        }
    };
    
    [TestCaseSource(nameof(AabbArrayNullableCases))]
    public void AabbArrayNullableFormatterTest(Godot.Aabb?[] aabb)
    {
        var aabbSerialized = MessagePackSerializer.Deserialize<Godot.Aabb?[]>(MessagePackSerializer.Serialize(aabb));
        Assert.AreEqual(aabb, aabbSerialized);
    }

    public static Godot.Aabb?[][] AabbArrayNullableCases =
    {
        new Godot.Aabb?[] {
            new Godot.Aabb(1f, 8f, 7f, 20f, 159f, 1f),
            null,
            new Godot.Aabb(26f, 28f, 1f, 200f, 19f, 6f),
            new Godot.Aabb(6f, 88f, 12f, 2f, 9f, 65f),
            null
        }
    };

    [Test]
    public void AabbListFormatterTest()
    {
        var aabbList = new List<Godot.Aabb>()
        {
            new Godot.Aabb(1f, 8f, 7f, 20f, 159f, 1f),
            new Godot.Aabb(26f, 28f, 1f, 200f, 19f, 6f),
            new Godot.Aabb(6f, 88f, 12f, 2f, 9f, 65f)
        };
        
        var aabbSerialized = MessagePackSerializer.Deserialize<List<Godot.Aabb>>(MessagePackSerializer.Serialize(aabbList));
        Assert.AreEqual(aabbList, aabbSerialized);
    }
    
    [Test]
    public void AabbListNullableFormatterTest()
    {
        var aabbList = new List<Godot.Aabb?>()
        {
            new Godot.Aabb(1f, 8f, 7f, 20f, 159f, 1f),
            null,
            new Godot.Aabb(26f, 28f, 1f, 200f, 19f, 6f),
            new Godot.Aabb(6f, 88f, 12f, 2f, 9f, 65f),
            null
        };
        
        var aabbSerialized = MessagePackSerializer.Deserialize<List<Godot.Aabb?>>(MessagePackSerializer.Serialize(aabbList));
        Assert.AreEqual(aabbList, aabbSerialized);
    }
}