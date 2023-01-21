using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcSample.Web.Protos.v1;
using static GrpcSample.Web.Protos.v1.PersonService;

namespace GrpcSample.Web.Services.v1;

public class PersonGrpcService : PersonServiceBase
{
    private List<PersonReply> _people = new()
    {
        new PersonReply
        {
            Id = 1,
            FirstName = "Benyamin",
            LastName = "Moosavi"
        },
        new PersonReply
        {
            Id = 2,
            FirstName = "Omid",
            LastName = "Nazari"
        },
        new PersonReply
        {
            Id = 3,
            FirstName = "Reza",
            LastName = "Eyni"
        },
    };

    public override async Task CreatePerson(IAsyncStreamReader<CreatePersonRequest> requestStream, IServerStreamWriter<PersonReply> responseStream, ServerCallContext context)
    {
        int id = _people.Count();
        await foreach (var person in requestStream.ReadAllAsync())
        {
            PersonReply personReply = new()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Id = ++id,
            };
            _people.Add(personReply);
            await responseStream.WriteAsync(personReply);
        }
    }

    public override async Task<Empty> UpdatePerson(UpdatePersonRequest request, ServerCallContext context)
    {
        var personForUpdate = _people.Where(c => c.Id == request.Id).FirstOrDefault();
        personForUpdate.FirstName = request.FirstName;
        personForUpdate.LastName = request.LastName;
        return new Empty();
    }

    public override async Task<Empty> DeletePerson(IAsyncStreamReader<PersonByIdRequest> requestStream, ServerCallContext context)
    {
        await foreach (var person in requestStream.ReadAllAsync())
        {
            var personForDelete = _people.Where(c => c.Id == person.Id).FirstOrDefault();
            if (personForDelete != null)
            {
                _people.Remove(personForDelete);
            }
        }
        return new Empty();
    }

    public override async Task GetAll(Empty request, IServerStreamWriter<PersonReply> responseStream, ServerCallContext context)
    {
        foreach (var item in _people)
        {
            await responseStream.WriteAsync(item);
        }
    }

    public override async Task<PersonReply> GetPersonById(PersonByIdRequest request, ServerCallContext context)
    {
        throw new InvalidTimeZoneException("This Is My Invalid Timezoon Exception");
        var personForResponse = _people.Where(c => c.Id == request.Id).FirstOrDefault();

        if (personForResponse != null)
            return personForResponse;
        throw new RpcException(new Status(StatusCode.NotFound, $"Person with ID {request.Id} Not Found"), "Person Not Found Servier Layer");

    }
}
