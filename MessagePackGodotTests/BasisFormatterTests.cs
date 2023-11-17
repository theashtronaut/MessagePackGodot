using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class BasisFormatterTests
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
    
    private static Godot.Basis TestCase1 => new(6f, 8f, 1f, 3f, 5f, 2f, 7f, 2f, 48f);
    private static Godot.Basis TestCase2 => new(1f, 2f, 6f, 9f, 1f, 6f, 8f, 1f, 18f);
    private static Godot.Basis TestCase3 => new(5f, 4f, 4f, 2f, 7f, 2f, 4f, 6f, 15f);
    


    [TestCaseSource(nameof(BasisCases))]
    public void BasisFormatterTest(Godot.Basis basis)
    {
        var basisSerializer = MessagePackSerializer.Deserialize<Godot.Basis>(MessagePackSerializer.Serialize(basis));
        
        Assert.AreEqual(basis, basisSerializer);
    }
    
    public static Godot.Basis[] BasisCases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };

    [TestCaseSource(nameof(BasisNullableCases))]
    public void BasisNullableFormatterTest(Godot.Basis? basis)
    {
        var basisSerializer = MessagePackSerializer.Deserialize<Godot.Basis?>(MessagePackSerializer.Serialize(basis));
        
        Assert.AreEqual(basis, basisSerializer);
    }
    
    public static Godot.Basis?[] BasisNullableCases =
    {
        new Godot.Basis(1f, 2f, 6f, 9f, 1f, 6f, 8f, 1f, 18f),
        null,
        new Godot.Basis(6f, 8f, 1f, 3f, 5f, 2f, 7f, 2f, 48f)
    };
    
    [TestCaseSource(nameof(BasisArrayCases))]
    public void BasisArrayFormatterTest(Godot.Basis[] basis)
    {
        var basisSerialized = MessagePackSerializer.Deserialize<Godot.Basis[]>(MessagePackSerializer.Serialize(basis));
        Assert.AreEqual(basis, basisSerialized);
    }

    public static Godot.Basis[][] BasisArrayCases =
    {
        new[] {
            new Godot.Basis(6f, 8f, 1f, 3f, 5f, 2f, 7f, 2f, 48f),
            new Godot.Basis(1f, 2f, 6f, 9f, 1f, 6f, 8f, 1f, 18f),
            new Godot.Basis(5f, 4f, 4f, 2f, 7f, 2f, 4f, 6f, 15f)
        }
    };
    
    [TestCaseSource(nameof(BasisArrayNullableCases))]
    public void BasisArrayNullableFormatterTest(Godot.Basis?[] basis)
    {
        var basisSerialized = MessagePackSerializer.Deserialize<Godot.Basis?[]>(MessagePackSerializer.Serialize(basis));
        Assert.AreEqual(basis, basisSerialized);
    }

    public static Godot.Basis?[][] BasisArrayNullableCases =
    {
        new Godot.Basis?[] {
            new Godot.Basis(6f, 8f, 1f, 3f, 5f, 2f, 7f, 2f, 48f),
            null,
            new Godot.Basis(1f, 2f, 6f, 9f, 1f, 6f, 8f, 1f, 18f),
            new Godot.Basis(5f, 4f, 4f, 2f, 7f, 2f, 4f, 6f, 15f),
            null
        }
    };

    [Test]
    public void BasisListFormatterTest()
    {
        var basisList = new List<Godot.Basis>()
        {
            new Godot.Basis(6f, 8f, 1f, 3f, 5f, 2f, 7f, 2f, 48f),
            new Godot.Basis(1f, 2f, 6f, 9f, 1f, 6f, 8f, 1f, 18f),
            new Godot.Basis(5f, 4f, 4f, 2f, 7f, 2f, 4f, 6f, 15f)
        };
        
        var basisSerialized = MessagePackSerializer.Deserialize<List<Godot.Basis>>(MessagePackSerializer.Serialize(basisList));
        Assert.AreEqual(basisList, basisSerialized);
    }
    
    [Test]
    public void BasisListNullableFormatterTest()
    {
        var basisList = new List<Godot.Basis?>()
        {
            new Godot.Basis(6f, 8f, 1f, 3f, 5f, 2f, 7f, 2f, 48f),
            null,
            new Godot.Basis(1f, 2f, 6f, 9f, 1f, 6f, 8f, 1f, 18f),
            new Godot.Basis(5f, 4f, 4f, 2f, 7f, 2f, 4f, 6f, 15f),
            null
        };
        
        var basisSerialized = MessagePackSerializer.Deserialize<List<Godot.Basis?>>(MessagePackSerializer.Serialize(basisList));
        Assert.AreEqual(basisList, basisSerialized);
    }
}