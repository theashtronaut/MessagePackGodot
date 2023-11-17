using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class Vector2IFormatterTests
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

    private static Godot.Vector2I TestCase1 => new(1, 6);
    private static Godot.Vector2I TestCase2 => new(6, 4);
    private static Godot.Vector2I TestCase3 => new(12, 5);
    
    

    [TestCaseSource(nameof(Vector2ICases))]
    public void Vector2IFormatterTest(Godot.Vector2I vector2I)
    {
        var vector2ISerializer = MessagePackSerializer.Deserialize<Godot.Vector2I>(MessagePackSerializer.Serialize(vector2I));
        
        Assert.AreEqual(vector2I, vector2ISerializer);
    }

    public static Godot.Vector2I[] Vector2ICases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(Vector2INullableCases))]
    public void Vector2INullableFormatterTest(Godot.Vector2I? vector2I)
    {
        var vector2ISerializer = MessagePackSerializer.Deserialize<Godot.Vector2I?>(MessagePackSerializer.Serialize(vector2I));
        
        Assert.AreEqual(vector2I, vector2ISerializer);
    }
    
    public static Godot.Vector2I?[] Vector2INullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(Vector2IArrayCases))]
    public void Vector2IArrayFormatterTest(Godot.Vector2I[] vector2I)
    {
        var vector2ISerialized = MessagePackSerializer.Deserialize<Godot.Vector2I[]>(MessagePackSerializer.Serialize(vector2I));
        Assert.AreEqual(vector2I, vector2ISerialized);
    }

    public static Godot.Vector2I[][] Vector2IArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(Vector2IArrayNullableCases))]
    public void Vector2IArrayNullableFormatterTest(Godot.Vector2I?[] vector2I)
    {
        var vector2ISerialized = MessagePackSerializer.Deserialize<Godot.Vector2I?[]>(MessagePackSerializer.Serialize(vector2I));
        Assert.AreEqual(vector2I, vector2ISerialized);
    }

    public static Godot.Vector2I?[][] Vector2IArrayNullableCases =
    {
        new Godot.Vector2I?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void Vector2IListFormatterTest()
    {
        var vector2IList = new List<Godot.Vector2I>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var vector2ISerialized = MessagePackSerializer.Deserialize<List<Godot.Vector2I>>(MessagePackSerializer.Serialize(vector2IList));
        Assert.AreEqual(vector2IList, vector2ISerialized);
    }
    
    [Test]
    public void Vector2IListNullableFormatterTest()
    {
        var vector2IList = new List<Godot.Vector2I?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var vector2ISerialized = MessagePackSerializer.Deserialize<List<Godot.Vector2I?>>(MessagePackSerializer.Serialize(vector2IList));
        Assert.AreEqual(vector2IList, vector2ISerialized);
    }
}