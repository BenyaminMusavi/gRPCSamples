using Grpc.Core;
using Grpc.Core.Interceptors;

namespace GrpcClientSample.Console.Interceptors;

public class TraceInterceptor : Interceptor
{
    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        System.Console.WriteLine($"Start at {DateTime.Now}");
        return continuation(request, context);
    }
}

public class ExceptionIHandelingnterceptor : Interceptor
{
    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        try
        {
            return continuation(request, context);
        }
        catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded)
        {
            System.Console.WriteLine("Deadline");
            //ex.Trailers
            throw;
        }
        catch (RpcException ex)
        {
            System.Console.WriteLine($"other ex: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"other ex: {ex.Message}");
            throw;
        }
    }
}
