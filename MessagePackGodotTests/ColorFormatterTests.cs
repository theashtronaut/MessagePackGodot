using System.Collections.Generic;
using MessagePack;
using MessagePackGodot;
using NUnit.Framework;

namespace MessagePackGodotTests;

[TestFixture]
public class ColorFormatterTests
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
    
    private static Godot.Color TestCase1 => new(1f, 6f, 7f, 5f);
    private static Godot.Color TestCase2 => new(6f, 4f, 5f);
    private static Godot.Color TestCase3 => new(12f, 5f, 3f, 8f);

    [TestCaseSource(nameof(ColorCases))]
    public void ColorFormatterTest(Godot.Color color)
    {
        var colorSerialized = MessagePackSerializer.Deserialize<Godot.Color>(MessagePackSerializer.Serialize(color));
        
        Assert.AreEqual(color, colorSerialized);
    }
    
    public static Godot.Color[] ColorCases =
    {
        TestCase1,
        TestCase2,
        TestCase3
    };
    
    [TestCaseSource(nameof(ColorNullableCases))]
    public void ColorNullableFormatterTest(Godot.Color? color)
    {
        var colorSerialized = MessagePackSerializer.Deserialize<Godot.Color?>(MessagePackSerializer.Serialize(color));
        
        Assert.AreEqual(color, colorSerialized);
    }

    public static Godot.Color?[] ColorNullableCases =
    {
        TestCase1,
        null,
        TestCase2,
        TestCase3,
        null
    };

    [TestCaseSource(nameof(ColorArrayCases))]
    public void ColorArrayFormatterTest(Godot.Color[] colors)
    {
        var colorsSerialized = MessagePackSerializer.Deserialize<Godot.Color[]>(MessagePackSerializer.Serialize(colors));
        Assert.AreEqual(colors, colorsSerialized);
    }

    public static Godot.Color[][] ColorArrayCases =
    {
        new[] {
            TestCase1,
            TestCase2,
            TestCase3
        }
    };

    [TestCaseSource(nameof(ColorArrayNullableCases))]
    public void ColorArrayNullableFormatterTest(Godot.Color?[] colors)
    {
        var colorsSerialized = MessagePackSerializer.Deserialize<Godot.Color?[]>(MessagePackSerializer.Serialize(colors));
        Assert.AreEqual(colors, colorsSerialized);
    }
    
    public static Godot.Color?[][] ColorArrayNullableCases =
    {
        new Godot.Color?[] {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        }
    };

    [Test]
    public void ColorListFormatterTest()
    {
        var colorList = new List<Godot.Color>()
        {
            TestCase1,
            TestCase2,
            TestCase3
        };
        
        var colorsSerialized = MessagePackSerializer.Deserialize<List<Godot.Color>>(MessagePackSerializer.Serialize(colorList));
        Assert.AreEqual(colorList, colorsSerialized);
    }

    [Test]
    public void ColorListNullableFormatterTest()
    {
        var colorList = new List<Godot.Color?>()
        {
            TestCase1,
            null,
            TestCase2,
            TestCase3,
            null
        };
        
        var colorsSerialized = MessagePackSerializer.Deserialize<List<Godot.Color?>>(MessagePackSerializer.Serialize(colorList));
        Assert.AreEqual(colorList, colorsSerialized);
    }
}