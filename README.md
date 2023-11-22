# MessagePackGodot
MessagePack for C# support for the [Godot Engine](https://godotengine.org/)

Use with the [MessagePack-CSharp](https://www.nuget.org/packages/messagepack) package.

Supports Godot 4.x, tested on Godot 4.1.x.


# Usage
Install the [nuget package](https://www.nuget.org/packages/MessagePackGodot) through however you install packages in your project.

Use this code somewhere to set up the MessagePack default settings to include the GodotResolver
 ```cs
// initialize MessagePack resolvers
var resolver = MessagePack.Resolvers.CompositeResolver.Create(
   // enable extension packages first (and put any other extensions you use in this section)
   GodotResolver.Instance,

   // finally use standard (default) resolver
   MessagePack.Resolvers.StandardResolver.Instance
);
var options = MessagePackSerializerOptions.Standard.WithResolver(resolver);
            
// pass options every time to set as default
MessagePackSerializer.DefaultOptions = options;
```

Now you should be able to serialize the godot structs and anything that has an underlying godot struct should work as well.
