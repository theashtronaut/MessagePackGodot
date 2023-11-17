using MessagePack;

namespace MessagePackGodot;

// TODO support real_t = double?

public sealed class ColorFormatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Color>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Color value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(4);
        writer.Write(value.R);
        writer.Write(value.G);
        writer.Write(value.B);
        writer.Write(value.A);
    }

    public Godot.Color Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var r = default(float);
        var g = default(float);
        var b = default(float);
        var a = default(float);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    r = reader.ReadSingle();
                    break;
                case 1:
                    g = reader.ReadSingle();
                    break;
                case 2:
                    b = reader.ReadSingle();
                    break;
                case 3:
                    a = reader.ReadSingle();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Color(r, g, b, a);
        return result;
    }
}

public sealed class AabbFormatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Aabb>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Aabb value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(6);
        writer.Write(value.Position.X);
        writer.Write(value.Position.Y);
        writer.Write(value.Position.Z);
        writer.Write(value.Size.X);
        writer.Write(value.Size.Y);
        writer.Write(value.Size.Z);
    }

    public Godot.Aabb Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var posX = default(float);
        var posY = default(float);
        var posZ = default(float);
        var sizeX = default(float);
        var sizeY = default(float);
        var sizeZ = default(float);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    posX = reader.ReadSingle();
                    break;
                case 1:
                    posY = reader.ReadSingle();
                    break;
                case 2:
                    posZ = reader.ReadSingle();
                    break;
                case 3:
                    sizeX = reader.ReadSingle();
                    break;
                case 4:
                    sizeY = reader.ReadSingle();
                    break;
                case 5:
                    sizeZ = reader.ReadSingle();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Aabb(new Godot.Vector3(posX, posY, posZ), new Godot.Vector3(sizeX, sizeY, sizeZ));
        return result;
    }
}

public sealed class BasisFormatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Basis>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Basis value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(9);
        writer.Write(value.X.X);
        writer.Write(value.X.Y);
        writer.Write(value.X.Z);
        writer.Write(value.Y.X);
        writer.Write(value.Y.Y);
        writer.Write(value.Y.Z);
        writer.Write(value.Z.X);
        writer.Write(value.Z.Y);
        writer.Write(value.Z.Z);
    }

    public Godot.Basis Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var xx = default(float);
        var xy = default(float);
        var xz = default(float);
        var yx = default(float);
        var yy = default(float);
        var yz = default(float);
        var zx = default(float);
        var zy = default(float);
        var zz = default(float);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    xx = reader.ReadSingle();
                    break;
                case 1:
                    xy = reader.ReadSingle();
                    break;
                case 2:
                    xz = reader.ReadSingle();
                    break;
                case 3:
                    yx = reader.ReadSingle();
                    break;
                case 4:
                    yy = reader.ReadSingle();
                    break;
                case 5:
                    yz = reader.ReadSingle();
                    break;
                case 6:
                    zx = reader.ReadSingle();
                    break;
                case 7:
                    zy = reader.ReadSingle();
                    break;
                case 8:
                    zz = reader.ReadSingle();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Basis(new Godot.Vector3(xx, xy, xz), new Godot.Vector3(yx, yy, yz), new Godot.Vector3(zx, zy, zz));
        return result;
    }
}

public sealed class PlaneFormatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Plane>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Plane value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(4);
        writer.Write(value.Normal.X);
        writer.Write(value.Normal.Y);
        writer.Write(value.Normal.Z);
        writer.Write(value.D);
    }

    public Godot.Plane Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var a = default(float);
        var b = default(float);
        var c = default(float);
        var d = default(float);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    a = reader.ReadSingle();
                    break;
                case 1:
                    b = reader.ReadSingle();
                    break;
                case 2:
                    c = reader.ReadSingle();
                    break;
                case 3:
                    d = reader.ReadSingle();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Plane(a, b, c, d);
        return result;
    }
}

public sealed class ProjectionFormatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Projection>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Projection value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(16);
        writer.Write(value.X.X);
        writer.Write(value.X.Y);
        writer.Write(value.X.Z);
        writer.Write(value.X.W);
        writer.Write(value.Y.X);
        writer.Write(value.Y.Y);
        writer.Write(value.Y.Z);
        writer.Write(value.Y.W);
        writer.Write(value.Z.X);
        writer.Write(value.Z.Y);
        writer.Write(value.Z.Z);
        writer.Write(value.Z.W);
        writer.Write(value.W.X);
        writer.Write(value.W.Y);
        writer.Write(value.W.Z);
        writer.Write(value.W.W);
    }

    public Godot.Projection Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var xx = default(float);
        var xy = default(float);
        var xz = default(float);
        var xw = default(float);
        var yx = default(float);
        var yy = default(float);
        var yz = default(float);
        var yw = default(float);
        var zx = default(float);
        var zy = default(float);
        var zz = default(float);
        var zw = default(float);
        var wx = default(float);
        var wy = default(float);
        var wz = default(float);
        var ww = default(float);
        
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    xx = reader.ReadSingle();
                    break;
                case 1:
                    xy = reader.ReadSingle();
                    break;
                case 2:
                    xz = reader.ReadSingle();
                    break;
                case 3:
                    xw = reader.ReadSingle();
                    break;
                case 4:
                    yx = reader.ReadSingle();
                    break;
                case 5:
                    yy = reader.ReadSingle();
                    break;
                case 6:
                    yz = reader.ReadSingle();
                    break;
                case 7:
                    yw = reader.ReadSingle();
                    break;
                case 8:
                    zx = reader.ReadSingle();
                    break;
                case 9:
                    zy = reader.ReadSingle();
                    break;
                case 10:
                    zz = reader.ReadSingle();
                    break;
                case 11:
                    zw = reader.ReadSingle();
                    break;
                case 12:
                    wx = reader.ReadSingle();
                    break;
                case 13:
                    wy = reader.ReadSingle();
                    break;
                case 14:
                    wz = reader.ReadSingle();
                    break;
                case 15:
                    ww = reader.ReadSingle();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Projection(new Godot.Vector4(xx, xy, xz, xw), new Godot.Vector4(yx, yy, yz, yw), new Godot.Vector4(zx, zy, zz, zw), new Godot.Vector4(wx, wy, wz, ww));
        return result;
    }
}

public sealed class QuaternionFormatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Quaternion>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Quaternion value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(4);
        writer.Write(value.X);
        writer.Write(value.Y);
        writer.Write(value.Z);
        writer.Write(value.W);
    }

    public Godot.Quaternion Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var x = default(float);
        var y = default(float);
        var z = default(float);
        var w = default(float);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    x = reader.ReadSingle();
                    break;
                case 1:
                    y = reader.ReadSingle();
                    break;
                case 2:
                    z = reader.ReadSingle();
                    break;
                case 3:
                    w = reader.ReadSingle();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Quaternion(x, y, z, w);
        return result;
    }
}

public sealed class Rect2Formatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Rect2>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Rect2 value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(4);
        writer.Write(value.Position.X);
        writer.Write(value.Position.Y);
        writer.Write(value.Size.X);
        writer.Write(value.Size.Y);
    }

    public Godot.Rect2 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var x = default(float);
        var y = default(float);
        var width = default(float);
        var height = default(float);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    x = reader.ReadSingle();
                    break;
                case 1:
                    y = reader.ReadSingle();
                    break;
                case 2:
                    width = reader.ReadSingle();
                    break;
                case 3:
                    height = reader.ReadSingle();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Rect2(x, y, width, height);
        return result;
    }
}

public sealed class Rect2IFormatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Rect2I>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Rect2I value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(4);
        writer.Write(value.Position.X);
        writer.Write(value.Position.Y);
        writer.Write(value.Size.X);
        writer.Write(value.Size.Y);
    }

    public Godot.Rect2I Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var x = default(int);
        var y = default(int);
        var width = default(int);
        var height = default(int);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    x = reader.ReadInt32();
                    break;
                case 1:
                    y = reader.ReadInt32();
                    break;
                case 2:
                    width = reader.ReadInt32();
                    break;
                case 3:
                    height = reader.ReadInt32();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Rect2I(x, y, width, height);
        return result;
    }
}

public sealed class Transform2DFormatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Transform2D>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Transform2D value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(6);
        writer.Write(value.X.X);
        writer.Write(value.X.Y);
        writer.Write(value.Y.X);
        writer.Write(value.Y.Y);
        writer.Write(value.Origin.X);
        writer.Write(value.Origin.Y);
    }

    public Godot.Transform2D Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var xx = default(float);
        var xy = default(float);
        var yx = default(float);
        var yy = default(float);
        var originX = default(float);
        var originY = default(float);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    xx = reader.ReadSingle();
                    break;
                case 1:
                    xy = reader.ReadSingle();
                    break;
                case 2:
                    yx = reader.ReadSingle();
                    break;
                case 3:
                    yy = reader.ReadSingle();
                    break;
                case 4:
                    originX = reader.ReadSingle();
                    break;
                case 5:
                    originY = reader.ReadSingle();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Transform2D(xx, xy, yx, yy, originX, originY);
        return result;
    }
}

public sealed class Transform3DFormatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Transform3D>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Transform3D value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(12);
        writer.Write(value.Basis.X.X);
        writer.Write(value.Basis.X.Y);
        writer.Write(value.Basis.X.Z);
        writer.Write(value.Basis.Y.X);
        writer.Write(value.Basis.Y.Y);
        writer.Write(value.Basis.Y.Z);
        writer.Write(value.Basis.Z.X);
        writer.Write(value.Basis.Z.Y);
        writer.Write(value.Basis.Z.Z);
        writer.Write(value.Origin.X);
        writer.Write(value.Origin.Y);
        writer.Write(value.Origin.Z);
    }

    public Godot.Transform3D Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var xx = default(float);
        var xy = default(float);
        var xz = default(float);
        var yx = default(float);
        var yy = default(float);
        var yz = default(float);
        var zx = default(float);
        var zy = default(float);
        var zz = default(float);
        var originX = default(float);
        var originY = default(float);
        var originZ = default(float);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    xx = reader.ReadSingle();
                    break;
                case 1:
                    xy = reader.ReadSingle();
                    break;
                case 2:
                    xz = reader.ReadSingle();
                    break;
                case 3:
                    yx = reader.ReadSingle();
                    break;
                case 4:
                    yy = reader.ReadSingle();
                    break;
                case 5:
                    yz = reader.ReadSingle();
                    break;
                case 6:
                    zx = reader.ReadSingle();
                    break;
                case 7:
                    zy = reader.ReadSingle();
                    break;
                case 8:
                    zz = reader.ReadSingle();
                    break;
                case 9:
                    originX = reader.ReadSingle();
                    break;
                case 10:
                    originY = reader.ReadSingle();
                    break;
                case 11:
                    originZ = reader.ReadSingle();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Transform3D(xx, yx, zx, xy, yy, zy, xz, yz, zz, originX, originY, originZ);
        return result;
    }
}

public sealed class Vector2Formatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Vector2>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Vector2 value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(2);
        writer.Write(value.X);
        writer.Write(value.Y);
    }

    public Godot.Vector2 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var x = default(float);
        var y = default(float);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    x = reader.ReadSingle();
                    break;
                case 1:
                    y = reader.ReadSingle();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Vector2(x, y);
        return result;
    }
}

public sealed class Vector2IFormatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Vector2I>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Vector2I value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(2);
        writer.Write(value.X);
        writer.Write(value.Y);
    }

    public Godot.Vector2I Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var x = default(int);
        var y = default(int);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    x = reader.ReadInt32();
                    break;
                case 1:
                    y = reader.ReadInt32();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Vector2I(x, y);
        return result;
    }
}

public sealed class Vector3Formatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Vector3>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Vector3 value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(3);
        writer.Write(value.X);
        writer.Write(value.Y);
        writer.Write(value.Z);
    }

    public Godot.Vector3 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var x = default(float);
        var y = default(float);
        var z = default(float);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    x = reader.ReadSingle();
                    break;
                case 1:
                    y = reader.ReadSingle();
                    break;
                case 2:
                    z = reader.ReadSingle();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Vector3(x, y, z);
        return result;
    }
}

public sealed class Vector3IFormatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Vector3I>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Vector3I value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(3);
        writer.Write(value.X);
        writer.Write(value.Y);
        writer.Write(value.Z);
    }

    public Godot.Vector3I Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var x = default(int);
        var y = default(int);
        var z = default(int);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    x = reader.ReadInt32();
                    break;
                case 1:
                    y = reader.ReadInt32();
                    break;
                case 2:
                    z = reader.ReadInt32();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Vector3I(x, y, z);
        return result;
    }
}

public sealed class Vector4Formatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Vector4>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Vector4 value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(4);
        writer.Write(value.X);
        writer.Write(value.Y);
        writer.Write(value.Z);
        writer.Write(value.W);
    }

    public Godot.Vector4 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var x = default(float);
        var y = default(float);
        var z = default(float);
        var w = default(float);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    x = reader.ReadSingle();
                    break;
                case 1:
                    y = reader.ReadSingle();
                    break;
                case 2:
                    z = reader.ReadSingle();
                    break;
                case 3:
                    w = reader.ReadSingle();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Vector4(x, y, z, w);
        return result;
    }
}

public sealed class Vector4IFormatter : MessagePack.Formatters.IMessagePackFormatter<Godot.Vector4I>
{
    public void Serialize(ref MessagePackWriter writer, Godot.Vector4I value, MessagePackSerializerOptions options)
    {
        writer.WriteArrayHeader(4);
        writer.Write(value.X);
        writer.Write(value.Y);
        writer.Write(value.Z);
        writer.Write(value.W);
    }

    public Godot.Vector4I Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.IsNil)
            throw new InvalidOperationException("type code is null, struct not supported");

        var length = reader.ReadArrayHeader();
        var x = default(int);
        var y = default(int);
        var z = default(int);
        var w = default(int);
        for (int i = 0; i < length; i++)
        {
            switch (i)
            {
                case 0:
                    x = reader.ReadInt32();
                    break;
                case 1:
                    y = reader.ReadInt32();
                    break;
                case 2:
                    z = reader.ReadInt32();
                    break;
                case 3:
                    w = reader.ReadInt32();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var result = new Godot.Vector4I(x, y, z, w);
        return result;
    }
}
