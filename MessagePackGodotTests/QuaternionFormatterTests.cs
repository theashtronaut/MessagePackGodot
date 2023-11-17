using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class QuaternionFormatterTests
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

    private static Godot.Quaternion TestCase1 => new(1f, 6f, 7f, 5f);
    private static Godot.Quaternion TestCase2 => new(6f, 4f, 5f, 1f);
    private static Godot.Quaternion TestCase3 => new(12f, 5f, 3f, 8f);
    
    

    [TestCaseSource(nameof(QuaternionCases))]
    public void QuaternionFormatterTest(Godot.Quaternion quaternion)
    {
        var quaternionSerializer = MessagePackSerializer.Deserialize<Godot.Quaternion>(MessagePackSerializer.Serialize(quaternion));
        
        Assert.AreEqual(quaternion, quaternionSerializer);
    }

    public static Godot.Quaternion[] QuaternionCases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(QuaternionNullableCases))]
    public void QuaternionNullableFormatterTest(Godot.Quaternion? quaternion)
    {
        var quaternionSerializer = MessagePackSerializer.Deserialize<Godot.Quaternion?>(MessagePackSerializer.Serialize(quaternion));
        
        Assert.AreEqual(quaternion, quaternionSerializer);
    }
    
    public static Godot.Quaternion?[] QuaternionNullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };
    
    [TestCaseSource(nameof(QuaternionArrayCases))]
    public void QuaternionArrayFormatterTest(Godot.Quaternion[] quaternion)
    {
        var quaternionSerialized = MessagePackSerializer.Deserialize<Godot.Quaternion[]>(MessagePackSerializer.Serialize(quaternion));
        Assert.AreEqual(quaternion, quaternionSerialized);
    }

    public static Godot.Quaternion[][] QuaternionArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };
    
    [TestCaseSource(nameof(QuaternionArrayNullableCases))]
    public void QuaternionArrayNullableFormatterTest(Godot.Quaternion?[] quaternion)
    {
        var quaternionSerialized = MessagePackSerializer.Deserialize<Godot.Quaternion?[]>(MessagePackSerializer.Serialize(quaternion));
        Assert.AreEqual(quaternion, quaternionSerialized);
    }

    public static Godot.Quaternion?[][] QuaternionArrayNullableCases =
    {
        new Godot.Quaternion?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void QuaternionListFormatterTest()
    {
        var quaternionList = new List<Godot.Quaternion>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var quaternionSerialized = MessagePackSerializer.Deserialize<List<Godot.Quaternion>>(MessagePackSerializer.Serialize(quaternionList));
        Assert.AreEqual(quaternionList, quaternionSerialized);
    }
    
    [Test]
    public void QuaternionListNullableFormatterTest()
    {
        var quaternionList = new List<Godot.Quaternion?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var quaternionSerialized = MessagePackSerializer.Deserialize<List<Godot.Quaternion?>>(MessagePackSerializer.Serialize(quaternionList));
        Assert.AreEqual(quaternionList, quaternionSerialized);
    }
}