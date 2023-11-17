using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class Vector3IFormatterTests
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

    private static Godot.Vector3I TestCase1 => new(1, 6, 7);
    private static Godot.Vector3I TestCase2 => new(6, 4, 5);
    private static Godot.Vector3I TestCase3 => new(12, 5, 3);
    
    

    [TestCaseSource(nameof(Vector3ICases))]
    public void Vector3IFormatterTest(Godot.Vector3I vector3I)
    {
        var vector3ISerializer = MessagePackSerializer.Deserialize<Godot.Vector3I>(MessagePackSerializer.Serialize(vector3I));
        
        Assert.AreEqual(vector3I, vector3ISerializer);
    }

    public static Godot.Vector3I[] Vector3ICases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(Vector3INullableCases))]
    public void Vector3INullableFormatterTest(Godot.Vector3I? vector3I)
    {
        var vector3ISerializer = MessagePackSerializer.Deserialize<Godot.Vector3I?>(MessagePackSerializer.Serialize(vector3I));
        
        Assert.AreEqual(vector3I, vector3ISerializer);
    }
    
    public static Godot.Vector3I?[] Vector3INullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(Vector3IArrayCases))]
    public void Vector3IArrayFormatterTest(Godot.Vector3I[] vector3I)
    {
        var vector3ISerialized = MessagePackSerializer.Deserialize<Godot.Vector3I[]>(MessagePackSerializer.Serialize(vector3I));
        Assert.AreEqual(vector3I, vector3ISerialized);
    }

    public static Godot.Vector3I[][] Vector3IArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(Vector3IArrayNullableCases))]
    public void Vector3IArrayNullableFormatterTest(Godot.Vector3I?[] vector3I)
    {
        var vector3ISerialized = MessagePackSerializer.Deserialize<Godot.Vector3I?[]>(MessagePackSerializer.Serialize(vector3I));
        Assert.AreEqual(vector3I, vector3ISerialized);
    }

    public static Godot.Vector3I?[][] Vector3IArrayNullableCases =
    {
        new Godot.Vector3I?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void Vector3IListFormatterTest()
    {
        var vector3IList = new List<Godot.Vector3I>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var vector3ISerialized = MessagePackSerializer.Deserialize<List<Godot.Vector3I>>(MessagePackSerializer.Serialize(vector3IList));
        Assert.AreEqual(vector3IList, vector3ISerialized);
    }
    
    [Test]
    public void Vector3IListNullableFormatterTest()
    {
        var vector3IList = new List<Godot.Vector3I?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var vector3ISerialized = MessagePackSerializer.Deserialize<List<Godot.Vector3I?>>(MessagePackSerializer.Serialize(vector3IList));
        Assert.AreEqual(vector3IList, vector3ISerialized);
    }
}