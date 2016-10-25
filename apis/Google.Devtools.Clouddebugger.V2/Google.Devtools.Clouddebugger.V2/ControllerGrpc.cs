// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: google/devtools/clouddebugger/v2/controller.proto
// Original file comments:
// Copyright 2016 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;

namespace Google.Devtools.Clouddebugger.V2 {
  /// <summary>
  ///  The Controller service provides the API for orchestrating a collection of
  ///  debugger agents to perform debugging tasks. These agents are each attached
  ///  to a process of an application which may include one or more replicas.
  ///
  ///  The debugger agents register with the Controller to identify the application
  ///  being debugged, the Debuggee. All agents that register with the same data,
  ///  represent the same Debuggee, and are assigned the same `debuggee_id`.
  ///
  ///  The debugger agents call the Controller to retrieve  the list of active
  ///  Breakpoints. Agents with the same `debuggee_id` get the same breakpoints
  ///  list. An agent that can fulfill the breakpoint request updates the
  ///  Controller with the breakpoint result. The controller selects the first
  ///  result received and discards the rest of the results.
  ///  Agents that poll again for active breakpoints will no longer have
  ///  the completed breakpoint in the list and should remove that breakpoint from
  ///  their attached process.
  ///
  ///  The Controller service does not provide a way to retrieve the results of
  ///  a completed breakpoint. This functionality is available using the Debugger
  ///  service.
  /// </summary>
  public static class Controller2
  {
    static readonly string __ServiceName = "google.devtools.clouddebugger.v2.Controller2";

    static readonly Marshaller<global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeRequest> __Marshaller_RegisterDebuggeeRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeRequest.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeResponse> __Marshaller_RegisterDebuggeeResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeResponse.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsRequest> __Marshaller_ListActiveBreakpointsRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsRequest.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsResponse> __Marshaller_ListActiveBreakpointsResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsResponse.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointRequest> __Marshaller_UpdateActiveBreakpointRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointRequest.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointResponse> __Marshaller_UpdateActiveBreakpointResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointResponse.Parser.ParseFrom);

    static readonly Method<global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeRequest, global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeResponse> __Method_RegisterDebuggee = new Method<global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeRequest, global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeResponse>(
        MethodType.Unary,
        __ServiceName,
        "RegisterDebuggee",
        __Marshaller_RegisterDebuggeeRequest,
        __Marshaller_RegisterDebuggeeResponse);

    static readonly Method<global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsRequest, global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsResponse> __Method_ListActiveBreakpoints = new Method<global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsRequest, global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsResponse>(
        MethodType.Unary,
        __ServiceName,
        "ListActiveBreakpoints",
        __Marshaller_ListActiveBreakpointsRequest,
        __Marshaller_ListActiveBreakpointsResponse);

    static readonly Method<global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointRequest, global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointResponse> __Method_UpdateActiveBreakpoint = new Method<global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointRequest, global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointResponse>(
        MethodType.Unary,
        __ServiceName,
        "UpdateActiveBreakpoint",
        __Marshaller_UpdateActiveBreakpointRequest,
        __Marshaller_UpdateActiveBreakpointResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Google.Devtools.Clouddebugger.V2.ControllerReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Controller2</summary>
    public abstract class Controller2Base
    {
      /// <summary>
      ///  Registers the debuggee with the controller service.
      ///
      ///  All agents attached to the same application should call this method with
      ///  the same request content to get back the same stable `debuggee_id`. Agents
      ///  should call this method again whenever `google.rpc.Code.NOT_FOUND` is
      ///  returned from any controller method.
      ///
      ///  This allows the controller service to disable the agent or recover from any
      ///  data loss. If the debuggee is disabled by the server, the response will
      ///  have `is_disabled` set to `true`.
      /// </summary>
      public virtual global::System.Threading.Tasks.Task<global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeResponse> RegisterDebuggee(global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeRequest request, ServerCallContext context)
      {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
      }

      /// <summary>
      ///  Returns the list of all active breakpoints for the debuggee.
      ///
      ///  The breakpoint specification (location, condition, and expression
      ///  fields) is semantically immutable, although the field values may
      ///  change. For example, an agent may update the location line number
      ///  to reflect the actual line where the breakpoint was set, but this
      ///  doesn't change the breakpoint semantics.
      ///
      ///  This means that an agent does not need to check if a breakpoint has changed
      ///  when it encounters the same breakpoint on a successive call.
      ///  Moreover, an agent should remember the breakpoints that are completed
      ///  until the controller removes them from the active list to avoid
      ///  setting those breakpoints again.
      /// </summary>
      public virtual global::System.Threading.Tasks.Task<global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsResponse> ListActiveBreakpoints(global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsRequest request, ServerCallContext context)
      {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
      }

      /// <summary>
      ///  Updates the breakpoint state or mutable fields.
      ///  The entire Breakpoint message must be sent back to the controller
      ///  service.
      ///
      ///  Updates to active breakpoint fields are only allowed if the new value
      ///  does not change the breakpoint specification. Updates to the `location`,
      ///  `condition` and `expression` fields should not alter the breakpoint
      ///  semantics. These may only make changes such as canonicalizing a value
      ///  or snapping the location to the correct line of code.
      /// </summary>
      public virtual global::System.Threading.Tasks.Task<global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointResponse> UpdateActiveBreakpoint(global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointRequest request, ServerCallContext context)
      {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for Controller2</summary>
    public class Controller2Client : ClientBase<Controller2Client>
    {
      /// <summary>Creates a new client for Controller2</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public Controller2Client(Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Controller2 that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public Controller2Client(CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected Controller2Client() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected Controller2Client(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      ///  Registers the debuggee with the controller service.
      ///
      ///  All agents attached to the same application should call this method with
      ///  the same request content to get back the same stable `debuggee_id`. Agents
      ///  should call this method again whenever `google.rpc.Code.NOT_FOUND` is
      ///  returned from any controller method.
      ///
      ///  This allows the controller service to disable the agent or recover from any
      ///  data loss. If the debuggee is disabled by the server, the response will
      ///  have `is_disabled` set to `true`.
      /// </summary>
      public virtual global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeResponse RegisterDebuggee(global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return RegisterDebuggee(request, new CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///  Registers the debuggee with the controller service.
      ///
      ///  All agents attached to the same application should call this method with
      ///  the same request content to get back the same stable `debuggee_id`. Agents
      ///  should call this method again whenever `google.rpc.Code.NOT_FOUND` is
      ///  returned from any controller method.
      ///
      ///  This allows the controller service to disable the agent or recover from any
      ///  data loss. If the debuggee is disabled by the server, the response will
      ///  have `is_disabled` set to `true`.
      /// </summary>
      public virtual global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeResponse RegisterDebuggee(global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeRequest request, CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_RegisterDebuggee, null, options, request);
      }
      /// <summary>
      ///  Registers the debuggee with the controller service.
      ///
      ///  All agents attached to the same application should call this method with
      ///  the same request content to get back the same stable `debuggee_id`. Agents
      ///  should call this method again whenever `google.rpc.Code.NOT_FOUND` is
      ///  returned from any controller method.
      ///
      ///  This allows the controller service to disable the agent or recover from any
      ///  data loss. If the debuggee is disabled by the server, the response will
      ///  have `is_disabled` set to `true`.
      /// </summary>
      public virtual AsyncUnaryCall<global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeResponse> RegisterDebuggeeAsync(global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return RegisterDebuggeeAsync(request, new CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///  Registers the debuggee with the controller service.
      ///
      ///  All agents attached to the same application should call this method with
      ///  the same request content to get back the same stable `debuggee_id`. Agents
      ///  should call this method again whenever `google.rpc.Code.NOT_FOUND` is
      ///  returned from any controller method.
      ///
      ///  This allows the controller service to disable the agent or recover from any
      ///  data loss. If the debuggee is disabled by the server, the response will
      ///  have `is_disabled` set to `true`.
      /// </summary>
      public virtual AsyncUnaryCall<global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeResponse> RegisterDebuggeeAsync(global::Google.Devtools.Clouddebugger.V2.RegisterDebuggeeRequest request, CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_RegisterDebuggee, null, options, request);
      }
      /// <summary>
      ///  Returns the list of all active breakpoints for the debuggee.
      ///
      ///  The breakpoint specification (location, condition, and expression
      ///  fields) is semantically immutable, although the field values may
      ///  change. For example, an agent may update the location line number
      ///  to reflect the actual line where the breakpoint was set, but this
      ///  doesn't change the breakpoint semantics.
      ///
      ///  This means that an agent does not need to check if a breakpoint has changed
      ///  when it encounters the same breakpoint on a successive call.
      ///  Moreover, an agent should remember the breakpoints that are completed
      ///  until the controller removes them from the active list to avoid
      ///  setting those breakpoints again.
      /// </summary>
      public virtual global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsResponse ListActiveBreakpoints(global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return ListActiveBreakpoints(request, new CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///  Returns the list of all active breakpoints for the debuggee.
      ///
      ///  The breakpoint specification (location, condition, and expression
      ///  fields) is semantically immutable, although the field values may
      ///  change. For example, an agent may update the location line number
      ///  to reflect the actual line where the breakpoint was set, but this
      ///  doesn't change the breakpoint semantics.
      ///
      ///  This means that an agent does not need to check if a breakpoint has changed
      ///  when it encounters the same breakpoint on a successive call.
      ///  Moreover, an agent should remember the breakpoints that are completed
      ///  until the controller removes them from the active list to avoid
      ///  setting those breakpoints again.
      /// </summary>
      public virtual global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsResponse ListActiveBreakpoints(global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsRequest request, CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ListActiveBreakpoints, null, options, request);
      }
      /// <summary>
      ///  Returns the list of all active breakpoints for the debuggee.
      ///
      ///  The breakpoint specification (location, condition, and expression
      ///  fields) is semantically immutable, although the field values may
      ///  change. For example, an agent may update the location line number
      ///  to reflect the actual line where the breakpoint was set, but this
      ///  doesn't change the breakpoint semantics.
      ///
      ///  This means that an agent does not need to check if a breakpoint has changed
      ///  when it encounters the same breakpoint on a successive call.
      ///  Moreover, an agent should remember the breakpoints that are completed
      ///  until the controller removes them from the active list to avoid
      ///  setting those breakpoints again.
      /// </summary>
      public virtual AsyncUnaryCall<global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsResponse> ListActiveBreakpointsAsync(global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return ListActiveBreakpointsAsync(request, new CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///  Returns the list of all active breakpoints for the debuggee.
      ///
      ///  The breakpoint specification (location, condition, and expression
      ///  fields) is semantically immutable, although the field values may
      ///  change. For example, an agent may update the location line number
      ///  to reflect the actual line where the breakpoint was set, but this
      ///  doesn't change the breakpoint semantics.
      ///
      ///  This means that an agent does not need to check if a breakpoint has changed
      ///  when it encounters the same breakpoint on a successive call.
      ///  Moreover, an agent should remember the breakpoints that are completed
      ///  until the controller removes them from the active list to avoid
      ///  setting those breakpoints again.
      /// </summary>
      public virtual AsyncUnaryCall<global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsResponse> ListActiveBreakpointsAsync(global::Google.Devtools.Clouddebugger.V2.ListActiveBreakpointsRequest request, CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ListActiveBreakpoints, null, options, request);
      }
      /// <summary>
      ///  Updates the breakpoint state or mutable fields.
      ///  The entire Breakpoint message must be sent back to the controller
      ///  service.
      ///
      ///  Updates to active breakpoint fields are only allowed if the new value
      ///  does not change the breakpoint specification. Updates to the `location`,
      ///  `condition` and `expression` fields should not alter the breakpoint
      ///  semantics. These may only make changes such as canonicalizing a value
      ///  or snapping the location to the correct line of code.
      /// </summary>
      public virtual global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointResponse UpdateActiveBreakpoint(global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return UpdateActiveBreakpoint(request, new CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///  Updates the breakpoint state or mutable fields.
      ///  The entire Breakpoint message must be sent back to the controller
      ///  service.
      ///
      ///  Updates to active breakpoint fields are only allowed if the new value
      ///  does not change the breakpoint specification. Updates to the `location`,
      ///  `condition` and `expression` fields should not alter the breakpoint
      ///  semantics. These may only make changes such as canonicalizing a value
      ///  or snapping the location to the correct line of code.
      /// </summary>
      public virtual global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointResponse UpdateActiveBreakpoint(global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointRequest request, CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateActiveBreakpoint, null, options, request);
      }
      /// <summary>
      ///  Updates the breakpoint state or mutable fields.
      ///  The entire Breakpoint message must be sent back to the controller
      ///  service.
      ///
      ///  Updates to active breakpoint fields are only allowed if the new value
      ///  does not change the breakpoint specification. Updates to the `location`,
      ///  `condition` and `expression` fields should not alter the breakpoint
      ///  semantics. These may only make changes such as canonicalizing a value
      ///  or snapping the location to the correct line of code.
      /// </summary>
      public virtual AsyncUnaryCall<global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointResponse> UpdateActiveBreakpointAsync(global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return UpdateActiveBreakpointAsync(request, new CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///  Updates the breakpoint state or mutable fields.
      ///  The entire Breakpoint message must be sent back to the controller
      ///  service.
      ///
      ///  Updates to active breakpoint fields are only allowed if the new value
      ///  does not change the breakpoint specification. Updates to the `location`,
      ///  `condition` and `expression` fields should not alter the breakpoint
      ///  semantics. These may only make changes such as canonicalizing a value
      ///  or snapping the location to the correct line of code.
      /// </summary>
      public virtual AsyncUnaryCall<global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointResponse> UpdateActiveBreakpointAsync(global::Google.Devtools.Clouddebugger.V2.UpdateActiveBreakpointRequest request, CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateActiveBreakpoint, null, options, request);
      }
      protected override Controller2Client NewInstance(ClientBaseConfiguration configuration)
      {
        return new Controller2Client(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    public static ServerServiceDefinition BindService(Controller2Base serviceImpl)
    {
      return ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_RegisterDebuggee, serviceImpl.RegisterDebuggee)
          .AddMethod(__Method_ListActiveBreakpoints, serviceImpl.ListActiveBreakpoints)
          .AddMethod(__Method_UpdateActiveBreakpoint, serviceImpl.UpdateActiveBreakpoint).Build();
    }

  }
}
#endregion