using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class Vector4IFormatterTests
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

    private static Godot.Vector4I TestCase1 => new(1, 6, 7, 5);
    private static Godot.Vector4I TestCase2 => new(6, 4, 5, 1);
    private static Godot.Vector4I TestCase3 => new(12, 5, 3, 8);
    
    

    [TestCaseSource(nameof(Vector4ICases))]
    public void Vector4IFormatterTest(Godot.Vector4I vector4I)
    {
        var vector4ISerializer = MessagePackSerializer.Deserialize<Godot.Vector4I>(MessagePackSerializer.Serialize(vector4I));
        
        Assert.AreEqual(vector4I, vector4ISerializer);
    }

    public static Godot.Vector4I[] Vector4ICases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(Vector4INullableCases))]
    public void Vector4INullableFormatterTest(Godot.Vector4I? vector4I)
    {
        var vector4ISerializer = MessagePackSerializer.Deserialize<Godot.Vector4I?>(MessagePackSerializer.Serialize(vector4I));
        
        Assert.AreEqual(vector4I, vector4ISerializer);
    }
    
    public static Godot.Vector4I?[] Vector4INullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(Vector4IArrayCases))]
    public void Vector4IArrayFormatterTest(Godot.Vector4I[] vector4I)
    {
        var vector4ISerialized = MessagePackSerializer.Deserialize<Godot.Vector4I[]>(MessagePackSerializer.Serialize(vector4I));
        Assert.AreEqual(vector4I, vector4ISerialized);
    }

    public static Godot.Vector4I[][] Vector4IArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(Vector4IArrayNullableCases))]
    public void Vector4IArrayNullableFormatterTest(Godot.Vector4I?[] vector4I)
    {
        var vector4ISerialized = MessagePackSerializer.Deserialize<Godot.Vector4I?[]>(MessagePackSerializer.Serialize(vector4I));
        Assert.AreEqual(vector4I, vector4ISerialized);
    }

    public static Godot.Vector4I?[][] Vector4IArrayNullableCases =
    {
        new Godot.Vector4I?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void Vector4IListFormatterTest()
    {
        var vector4IList = new List<Godot.Vector4I>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var vector4ISerialized = MessagePackSerializer.Deserialize<List<Godot.Vector4I>>(MessagePackSerializer.Serialize(vector4IList));
        Assert.AreEqual(vector4IList, vector4ISerialized);
    }
    
    [Test]
    public void Vector4IListNullableFormatterTest()
    {
        var vector4IList = new List<Godot.Vector4I?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var vector4ISerialized = MessagePackSerializer.Deserialize<List<Godot.Vector4I?>>(MessagePackSerializer.Serialize(vector4IList));
        Assert.AreEqual(vector4IList, vector4ISerialized);
    }
}