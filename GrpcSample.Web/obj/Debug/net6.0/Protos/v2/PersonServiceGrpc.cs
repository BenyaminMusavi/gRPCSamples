// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/v2/PersonService.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcSample.Web.Protos.v2 {
  public static partial class PersonService
  {
    static readonly string __ServiceName = "GrpcSample.v2.PersonService";

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
    static readonly grpc::Marshaller<global::GrpcSample.Web.Protos.v2.CreatePersonRequest> __Marshaller_GrpcSample_v2_CreatePersonRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcSample.Web.Protos.v2.CreatePersonRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcSample.Web.Protos.v2.PersonReply> __Marshaller_GrpcSample_v2_PersonReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcSample.Web.Protos.v2.PersonReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcSample.Web.Protos.v2.UpdatePersonRequest> __Marshaller_GrpcSample_v2_UpdatePersonRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcSample.Web.Protos.v2.UpdatePersonRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcSample.Web.Protos.v2.PersonByIdRequest> __Marshaller_GrpcSample_v2_PersonByIdRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcSample.Web.Protos.v2.PersonByIdRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcSample.Web.Protos.v2.CreatePersonRequest, global::GrpcSample.Web.Protos.v2.PersonReply> __Method_CreatePerson = new grpc::Method<global::GrpcSample.Web.Protos.v2.CreatePersonRequest, global::GrpcSample.Web.Protos.v2.PersonReply>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "CreatePerson",
        __Marshaller_GrpcSample_v2_CreatePersonRequest,
        __Marshaller_GrpcSample_v2_PersonReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcSample.Web.Protos.v2.UpdatePersonRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdatePerson = new grpc::Method<global::GrpcSample.Web.Protos.v2.UpdatePersonRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdatePerson",
        __Marshaller_GrpcSample_v2_UpdatePersonRequest,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcSample.Web.Protos.v2.PersonByIdRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeletePerson = new grpc::Method<global::GrpcSample.Web.Protos.v2.PersonByIdRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "DeletePerson",
        __Marshaller_GrpcSample_v2_PersonByIdRequest,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcSample.Web.Protos.v2.PersonByIdRequest, global::GrpcSample.Web.Protos.v2.PersonReply> __Method_GetPersonById = new grpc::Method<global::GrpcSample.Web.Protos.v2.PersonByIdRequest, global::GrpcSample.Web.Protos.v2.PersonReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetPersonById",
        __Marshaller_GrpcSample_v2_PersonByIdRequest,
        __Marshaller_GrpcSample_v2_PersonReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::GrpcSample.Web.Protos.v2.PersonReply> __Method_GetAll = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::GrpcSample.Web.Protos.v2.PersonReply>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetAll",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_GrpcSample_v2_PersonReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcSample.Web.Protos.v2.PersonServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of PersonService</summary>
    [grpc::BindServiceMethod(typeof(PersonService), "BindService")]
    public abstract partial class PersonServiceBase
    {
      /// <summary>
      /// Bidirectional
      /// </summary>
      /// <param name="requestStream">Used for reading requests from the client.</param>
      /// <param name="responseStream">Used for sending responses back to the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>A task indicating completion of the handler.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task CreatePerson(grpc::IAsyncStreamReader<global::GrpcSample.Web.Protos.v2.CreatePersonRequest> requestStream, grpc::IServerStreamWriter<global::GrpcSample.Web.Protos.v2.PersonReply> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Unary
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdatePerson(global::GrpcSample.Web.Protos.v2.UpdatePersonRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Client Stream
      /// </summary>
      /// <param name="requestStream">Used for reading requests from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeletePerson(grpc::IAsyncStreamReader<global::GrpcSample.Web.Protos.v2.PersonByIdRequest> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Unary
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcSample.Web.Protos.v2.PersonReply> GetPersonById(global::GrpcSample.Web.Protos.v2.PersonByIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Server Stream
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="responseStream">Used for sending responses back to the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>A task indicating completion of the handler.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetAll(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::IServerStreamWriter<global::GrpcSample.Web.Protos.v2.PersonReply> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(PersonServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CreatePerson, serviceImpl.CreatePerson)
          .AddMethod(__Method_UpdatePerson, serviceImpl.UpdatePerson)
          .AddMethod(__Method_DeletePerson, serviceImpl.DeletePerson)
          .AddMethod(__Method_GetPersonById, serviceImpl.GetPersonById)
          .AddMethod(__Method_GetAll, serviceImpl.GetAll).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, PersonServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CreatePerson, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::GrpcSample.Web.Protos.v2.CreatePersonRequest, global::GrpcSample.Web.Protos.v2.PersonReply>(serviceImpl.CreatePerson));
      serviceBinder.AddMethod(__Method_UpdatePerson, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcSample.Web.Protos.v2.UpdatePersonRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdatePerson));
      serviceBinder.AddMethod(__Method_DeletePerson, serviceImpl == null ? null : new grpc::ClientStreamingServerMethod<global::GrpcSample.Web.Protos.v2.PersonByIdRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeletePerson));
      serviceBinder.AddMethod(__Method_GetPersonById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcSample.Web.Protos.v2.PersonByIdRequest, global::GrpcSample.Web.Protos.v2.PersonReply>(serviceImpl.GetPersonById));
      serviceBinder.AddMethod(__Method_GetAll, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::GrpcSample.Web.Protos.v2.PersonReply>(serviceImpl.GetAll));
    }

  }
}
#endregion
