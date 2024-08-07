// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: demo.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Demo {
  public static partial class MiniDemo
  {
    static readonly string __ServiceName = "demo.MiniDemo";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Demo.SumRequestDto> __Marshaller_demo_SumRequestDto = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Demo.SumRequestDto.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Demo.SumResultDto> __Marshaller_demo_SumResultDto = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Demo.SumResultDto.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Demo.SumArrayRequestDto> __Marshaller_demo_SumArrayRequestDto = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Demo.SumArrayRequestDto.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Demo.AccumulatedElementDto> __Marshaller_demo_AccumulatedElementDto = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Demo.AccumulatedElementDto.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Demo.SumRequestDto, global::Demo.SumResultDto> __Method_Sum = new grpc::Method<global::Demo.SumRequestDto, global::Demo.SumResultDto>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Sum",
        __Marshaller_demo_SumRequestDto,
        __Marshaller_demo_SumResultDto);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Demo.SumArrayRequestDto, global::Demo.SumResultDto> __Method_SumArray = new grpc::Method<global::Demo.SumArrayRequestDto, global::Demo.SumResultDto>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SumArray",
        __Marshaller_demo_SumArrayRequestDto,
        __Marshaller_demo_SumResultDto);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Demo.AccumulatedElementDto, global::Demo.SumResultDto> __Method_SumStream = new grpc::Method<global::Demo.AccumulatedElementDto, global::Demo.SumResultDto>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "SumStream",
        __Marshaller_demo_AccumulatedElementDto,
        __Marshaller_demo_SumResultDto);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Demo.SumArrayRequestDto, global::Demo.SumResultDto> __Method_SumArrayDetailStream = new grpc::Method<global::Demo.SumArrayRequestDto, global::Demo.SumResultDto>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "SumArrayDetailStream",
        __Marshaller_demo_SumArrayRequestDto,
        __Marshaller_demo_SumResultDto);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Demo.AccumulatedElementDto, global::Demo.SumResultDto> __Method_Accumulate = new grpc::Method<global::Demo.AccumulatedElementDto, global::Demo.SumResultDto>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "Accumulate",
        __Marshaller_demo_AccumulatedElementDto,
        __Marshaller_demo_SumResultDto);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Demo.DemoReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for MiniDemo</summary>
    public partial class MiniDemoClient : grpc::ClientBase<MiniDemoClient>
    {
      /// <summary>Creates a new client for MiniDemo</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public MiniDemoClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for MiniDemo that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public MiniDemoClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected MiniDemoClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected MiniDemoClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Demo.SumResultDto Sum(global::Demo.SumRequestDto request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Sum(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Demo.SumResultDto Sum(global::Demo.SumRequestDto request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Sum, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Demo.SumResultDto> SumAsync(global::Demo.SumRequestDto request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SumAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Demo.SumResultDto> SumAsync(global::Demo.SumRequestDto request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Sum, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Demo.SumResultDto SumArray(global::Demo.SumArrayRequestDto request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SumArray(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Demo.SumResultDto SumArray(global::Demo.SumArrayRequestDto request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SumArray, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Demo.SumResultDto> SumArrayAsync(global::Demo.SumArrayRequestDto request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SumArrayAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Demo.SumResultDto> SumArrayAsync(global::Demo.SumArrayRequestDto request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SumArray, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncClientStreamingCall<global::Demo.AccumulatedElementDto, global::Demo.SumResultDto> SumStream(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SumStream(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncClientStreamingCall<global::Demo.AccumulatedElementDto, global::Demo.SumResultDto> SumStream(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_SumStream, null, options);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::Demo.SumResultDto> SumArrayDetailStream(global::Demo.SumArrayRequestDto request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SumArrayDetailStream(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::Demo.SumResultDto> SumArrayDetailStream(global::Demo.SumArrayRequestDto request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_SumArrayDetailStream, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncDuplexStreamingCall<global::Demo.AccumulatedElementDto, global::Demo.SumResultDto> Accumulate(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Accumulate(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncDuplexStreamingCall<global::Demo.AccumulatedElementDto, global::Demo.SumResultDto> Accumulate(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_Accumulate, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override MiniDemoClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new MiniDemoClient(configuration);
      }
    }

  }
}
#endregion
