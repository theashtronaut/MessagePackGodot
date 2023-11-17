using Godot;
using MessagePack;
using MessagePack.Formatters;

namespace MessagePackGodot;

public sealed class GodotResolver : IFormatterResolver
{
    public static readonly IFormatterResolver Instance = new GodotResolver();
    
    // GetFormatter<T>'s get cost should be minimized so use type cache.
    public IMessagePackFormatter<T>? GetFormatter<T>()
    {
        return FormatterCache<T>.Formatter;
    }

    private static class FormatterCache<T>
    {
        public static readonly IMessagePackFormatter<T>? Formatter;

        // generic's static constructor should be minimized for reduce type generation size!
        // use outer helper method.
        static FormatterCache() => Formatter = (IMessagePackFormatter<T>?)GodotResolverGetFormatterHelper.GetFormatter(typeof(T));
    }
}


internal static class GodotResolverGetFormatterHelper
{
    private static readonly Dictionary<Type, object> FormatterMap = new()
    {
        // standard
        { typeof(Color), new ColorFormatter() },
        { typeof(Aabb), new AabbFormatter() },
        { typeof(Basis), new BasisFormatter() },
        { typeof(Plane), new PlaneFormatter() },
        { typeof(Projection), new ProjectionFormatter() },
        { typeof(Quaternion), new QuaternionFormatter() },
        { typeof(Rect2), new Rect2Formatter() },
        { typeof(Rect2I), new Rect2IFormatter() },
        { typeof(Transform2D), new Transform2DFormatter() },
        { typeof(Transform3D), new Transform3DFormatter() },
        { typeof(Vector2), new Vector2Formatter() },
        { typeof(Vector2I), new Vector2IFormatter() },
        { typeof(Vector3), new Vector3Formatter() },
        { typeof(Vector3I), new Vector3IFormatter() },
        { typeof(Vector4), new Vector4Formatter() },
        { typeof(Vector4I), new Vector4IFormatter() },

        // standard nullable
        { typeof(Color?), new StaticNullableFormatter<Color>(new ColorFormatter()) },
        { typeof(Aabb?), new StaticNullableFormatter<Aabb>(new AabbFormatter())  },
        { typeof(Basis?), new StaticNullableFormatter<Basis>(new BasisFormatter())  },
        { typeof(Plane?), new StaticNullableFormatter<Plane>(new PlaneFormatter())  },
        { typeof(Projection?), new StaticNullableFormatter<Projection>(new ProjectionFormatter())  },
        { typeof(Quaternion?), new StaticNullableFormatter<Quaternion>(new QuaternionFormatter())  },
        { typeof(Rect2?), new StaticNullableFormatter<Rect2>(new Rect2Formatter()) },
        { typeof(Rect2I?),new StaticNullableFormatter<Rect2I>(new Rect2IFormatter()) },
        { typeof(Transform2D?), new StaticNullableFormatter<Transform2D>(new Transform2DFormatter())  },
        { typeof(Transform3D?), new StaticNullableFormatter<Transform3D>(new Transform3DFormatter())  },
        { typeof(Vector2?), new StaticNullableFormatter<Vector2>(new Vector2Formatter())  },
        { typeof(Vector2I?), new StaticNullableFormatter<Vector2I>(new Vector2IFormatter()) },
        { typeof(Vector3?), new StaticNullableFormatter<Vector3>(new Vector3Formatter())  },
        { typeof(Vector3I?), new StaticNullableFormatter<Vector3I>(new Vector3IFormatter())  },
        { typeof(Vector4?), new StaticNullableFormatter<Vector4>(new Vector4Formatter())  },
        { typeof(Vector4I?), new StaticNullableFormatter<Vector4I>(new Vector4IFormatter()) },
        
        // standard + array
        { typeof(Color[]), new ArrayFormatter<Color>()},
        { typeof(Aabb[]), new ArrayFormatter<Aabb>() },
        { typeof(Basis[]), new ArrayFormatter<Basis>() },
        { typeof(Plane[]), new ArrayFormatter<Plane>() },
        { typeof(Projection[]), new ArrayFormatter<Projection>() },
        { typeof(Quaternion[]), new ArrayFormatter<Quaternion>() },
        { typeof(Rect2[]), new ArrayFormatter<Rect2>()},
        { typeof(Rect2I[]),new ArrayFormatter<Rect2I>()},
        { typeof(Transform2D[]), new ArrayFormatter<Transform2D>() },
        { typeof(Transform3D[]), new ArrayFormatter<Transform3D>() },
        { typeof(Vector2[]), new ArrayFormatter<Vector2>() },
        { typeof(Vector2I[]), new ArrayFormatter<Vector2I>()},
        { typeof(Vector3[]), new ArrayFormatter<Vector3>() },
        { typeof(Vector3I[]), new ArrayFormatter<Vector3I>() },
        { typeof(Vector4[]), new ArrayFormatter<Vector4>() },
        { typeof(Vector4I[]), new ArrayFormatter<Vector4I>()},
        
        // standard + array nullable
        { typeof(Color?[]), new ArrayFormatter<Color?>()},
        { typeof(Aabb?[]), new ArrayFormatter<Aabb?>() },
        { typeof(Basis?[]), new ArrayFormatter<Basis?>() },
        { typeof(Plane?[]), new ArrayFormatter<Plane?>() },
        { typeof(Projection?[]), new ArrayFormatter<Projection?>() },
        { typeof(Quaternion?[]), new ArrayFormatter<Quaternion?>() },
        { typeof(Rect2?[]), new ArrayFormatter<Rect2?>()},
        { typeof(Rect2I?[]),new ArrayFormatter<Rect2I?>()},
        { typeof(Transform2D?[]), new ArrayFormatter<Transform2D?>() },
        { typeof(Transform3D?[]), new ArrayFormatter<Transform3D?>() },
        { typeof(Vector2?[]), new ArrayFormatter<Vector2?>() },
        { typeof(Vector2I?[]), new ArrayFormatter<Vector2I?>()},
        { typeof(Vector3?[]), new ArrayFormatter<Vector3?>() },
        { typeof(Vector3I?[]), new ArrayFormatter<Vector3I?>() },
        { typeof(Vector4?[]), new ArrayFormatter<Vector4?>() },
        { typeof(Vector4I?[]), new ArrayFormatter<Vector4I?>()},
        
        // standard + list
        { typeof(List<Color>), new ListFormatter<Color>()},
        { typeof(List<Aabb>), new ListFormatter<Aabb>() },
        { typeof(List<Basis>), new ListFormatter<Basis>() },
        { typeof(List<Plane>), new ListFormatter<Plane>() },
        { typeof(List<Projection>), new ListFormatter<Projection>() },
        { typeof(List<Quaternion>), new ListFormatter<Quaternion>() },
        { typeof(List<Rect2>), new ListFormatter<Rect2>()},
        { typeof(List<Rect2I>),new ListFormatter<Rect2I>()},
        { typeof(List<Transform2D>), new ListFormatter<Transform2D>() },
        { typeof(List<Transform3D>), new ListFormatter<Transform3D>() },
        { typeof(List<Vector2>), new ListFormatter<Vector2>() },
        { typeof(List<Vector2I>), new ListFormatter<Vector2I>()},
        { typeof(List<Vector3>), new ListFormatter<Vector3>() },
        { typeof(List<Vector3I>), new ListFormatter<Vector3I>() },
        { typeof(List<Vector4>), new ListFormatter<Vector4>() },
        { typeof(List<Vector4I>), new ListFormatter<Vector4I>()},
        
        // standard + list nullable
        { typeof(List<Color?>), new ListFormatter<Color?>()},
        { typeof(List<Aabb?>), new ListFormatter<Aabb?>() },
        { typeof(List<Basis?>), new ListFormatter<Basis?>() },
        { typeof(List<Plane?>), new ListFormatter<Plane?>() },
        { typeof(List<Projection?>), new ListFormatter<Projection?>() },
        { typeof(List<Quaternion?>), new ListFormatter<Quaternion?>() },
        { typeof(List<Rect2?>), new ListFormatter<Rect2?>()},
        { typeof(List<Rect2I?>),new ListFormatter<Rect2I?>()},
        { typeof(List<Transform2D?>), new ListFormatter<Transform2D?>() },
        { typeof(List<Transform3D?>), new ListFormatter<Transform3D?>() },
        { typeof(List<Vector2?>), new ListFormatter<Vector2?>() },
        { typeof(List<Vector2I?>), new ListFormatter<Vector2I?>()},
        { typeof(List<Vector3?>), new ListFormatter<Vector3?>() },
        { typeof(List<Vector3I?>), new ListFormatter<Vector3I?>() },
        { typeof(List<Vector4?>), new ListFormatter<Vector4?>() },
        { typeof(List<Vector4I?>), new ListFormatter<Vector4I?>()},

    };

    internal static object? GetFormatter(Type t)
    {
        if (FormatterMap.TryGetValue(t, out var formatter))
            return formatter;
        
        // If type can not get, must return null for fallback mechanism.
        return null;
    }
}
