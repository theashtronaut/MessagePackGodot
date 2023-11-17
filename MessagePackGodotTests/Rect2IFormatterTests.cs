using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class Rect2IFormatterTests
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

    private static Godot.Rect2I TestCase1 => new(1, 6, 7, 5);
    private static Godot.Rect2I TestCase2 => new(6, 4, 5, 1);
    private static Godot.Rect2I TestCase3 => new(12, 5, 3, 8);
    
    

    [TestCaseSource(nameof(Rect2ICases))]
    public void Rect2IFormatterTest(Godot.Rect2I rect2I)
    {
        var rect2ISerializer = MessagePackSerializer.Deserialize<Godot.Rect2I>(MessagePackSerializer.Serialize(rect2I));
        
        Assert.AreEqual(rect2I, rect2ISerializer);
    }

    public static Godot.Rect2I[] Rect2ICases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(Rect2INullableCases))]
    public void Rect2INullableFormatterTest(Godot.Rect2I? rect2I)
    {
        var rect2ISerializer = MessagePackSerializer.Deserialize<Godot.Rect2I?>(MessagePackSerializer.Serialize(rect2I));
        
        Assert.AreEqual(rect2I, rect2ISerializer);
    }
    
    public static Godot.Rect2I?[] Rect2INullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(Rect2IArrayCases))]
    public void Rect2IArrayFormatterTest(Godot.Rect2I[] rect2I)
    {
        var rect2ISerialized = MessagePackSerializer.Deserialize<Godot.Rect2I[]>(MessagePackSerializer.Serialize(rect2I));
        Assert.AreEqual(rect2I, rect2ISerialized);
    }

    public static Godot.Rect2I[][] Rect2IArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(Rect2IArrayNullableCases))]
    public void Rect2IArrayNullableFormatterTest(Godot.Rect2I?[] rect2I)
    {
        var rect2ISerialized = MessagePackSerializer.Deserialize<Godot.Rect2I?[]>(MessagePackSerializer.Serialize(rect2I));
        Assert.AreEqual(rect2I, rect2ISerialized);
    }

    public static Godot.Rect2I?[][] Rect2IArrayNullableCases =
    {
        new Godot.Rect2I?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void Rect2IListFormatterTest()
    {
        var rect2IList = new List<Godot.Rect2I>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var rect2ISerialized = MessagePackSerializer.Deserialize<List<Godot.Rect2I>>(MessagePackSerializer.Serialize(rect2IList));
        Assert.AreEqual(rect2IList, rect2ISerialized);
    }
    
    [Test]
    public void Rect2IListNullableFormatterTest()
    {
        var rect2IList = new List<Godot.Rect2I?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var rect2ISerialized = MessagePackSerializer.Deserialize<List<Godot.Rect2I?>>(MessagePackSerializer.Serialize(rect2IList));
        Assert.AreEqual(rect2IList, rect2ISerialized);
    }
}