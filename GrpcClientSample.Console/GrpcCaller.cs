using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using GrpcClientSample.Console.Interceptors;
using GrpcSample.Web.Protos.v1;
using Microsoft.Extensions.Logging;
using static GrpcSample.Web.Protos.v1.PersonService;

namespace GrpcClientSample.Console;

public class GrpcCaller
{
    private readonly PersonServiceClient _personServiceClient;

    public GrpcCaller(ILoggerFactory factory)
    {
        // از اولین ریکویست پینگ شروع میکند به ارسال شدن
        var handler = new SocketsHttpHandler
        {
            KeepAlivePingDelay = TimeSpan.FromSeconds(20),  // هر 20 ثانیه یک بار پینگ را برای سور ارسال میکند
            PooledConnectionIdleTimeout = TimeSpan.FromMinutes(10),  // بعد از ده دقیقه درخواستی نرفت بسته میشود
            KeepAlivePingTimeout = TimeSpan.FromSeconds(10), // اگر ده ثانیه بیشتر شد منتظر نمیماند
            EnableMultipleHttp2Connections = true // اگر تا صد ریکویست نتوانست جواب دهد میرود سراغ ایجاد کانکشن بعدی و صف ایجاد نمیکند
        };
        var channel = GrpcChannel.ForAddress("https://localhost:1010",
                                      new GrpcChannelOptions
                                      {
                                          LoggerFactory = factory,
                                          MaxReceiveMessageSize = 5_242_880, // 5Mg
                                          MaxSendMessageSize = 5_242_880,
                                          HttpHandler = handler,

                                      });

        _personServiceClient = new(channel.Intercept(new TraceInterceptor()));
    }

    public async Task ServerStreaming()
    {
        using var serverStreamingCall = _personServiceClient.GetAll(new Google.Protobuf.WellKnownTypes.Empty());
        await foreach (var item in serverStreamingCall.ResponseStream.ReadAllAsync())
        {
            System.Console.WriteLine($"{item.Id}\t {item.FirstName}\t {item.LastName} ");
        }

        var trailers = serverStreamingCall.GetTrailers(); // sync
        var header = await serverStreamingCall.ResponseHeadersAsync;
        System.Console.ReadLine();
    }

    public async Task ClientStreaming()
    {
        using var clientStreamingCall = _personServiceClient.DeletePerson();
        var peopleForDelete = new List<PersonByIdRequest>
        {
            new PersonByIdRequest{ Id = 1,},
            new PersonByIdRequest{Id = 2},
        };
        foreach (var item in peopleForDelete)
        {
            await clientStreamingCall.RequestStream.WriteAsync(item);
            System.Console.WriteLine($"Request for delete person {item.Id} sent");
        }

        await clientStreamingCall.RequestStream.CompleteAsync();
        var response = await clientStreamingCall.ResponseAsync;

    }

    public async Task BidirectionalStreaming()
    {
        using var biDirectionalCall = _personServiceClient.CreatePerson();

        List<CreatePersonRequest> personRequests = new()
        {
            new CreatePersonRequest
            {
                FirstName = "Benyamin",
                LastName = "Mousavi"
            },
            new CreatePersonRequest
            {
                   FirstName = "Ali",
                LastName = "Alie"
            }
        };

        foreach (var item in personRequests)
        {
            await biDirectionalCall.RequestStream.WriteAsync(item);
            System.Console.WriteLine($"Request sent for {item.FirstName} {item.LastName}");
        }

        await biDirectionalCall.RequestStream.CompleteAsync();

        await foreach (var item in biDirectionalCall.ResponseStream.ReadAllAsync())
        {
            System.Console.WriteLine($"{item.Id}\t");
        }

        var header = await biDirectionalCall.ResponseHeadersAsync;
        var trailers = biDirectionalCall.GetTrailers();
        System.Console.ReadLine();
    }

    public async Task Unary()
    {
        //try
        //{
        var unaryCall = _personServiceClient.GetPersonByIdAsync(new PersonByIdRequest
        {
            Id = 1
        }, deadline: DateTime.UtcNow.AddSeconds(10));

        var personReply = await unaryCall.ResponseAsync;
        System.Console.WriteLine($"{personReply.Id}");
        System.Console.ReadLine();
        //}
        //catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded)
        //{
        //    System.Console.WriteLine("Deadline");
        //    //ex.Trailers
        //    throw;
        //}
        //catch (RpcException ex)
        //{
        //    System.Console.WriteLine($"other ex: {ex.Message}");
        //    throw;
        //}

    }
}
