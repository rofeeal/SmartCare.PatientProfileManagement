using MediatR;
using MongoDB.Driver;
using Newtonsoft.Json;
using SmartCare.PatientProfileManagement.Domain.Entites;
using SmartCare.PatientProfileManagement.Domain.Events;
using SmartCare.PatientProfileManagement.Domain.Interfaces.Repository;
using SmartCare.PatientProfileManagement.Infrastructure.EventStore;
using SmartCare.PatientProfileManagement.Infrastructure.Interfaces.Database;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Infrastructure.Repositories
{
    public class EventStoreRepository : IPatientProfileCommandRepository
    {
        private readonly IMongoCollection<EventDocument> _eventCollection;
        private readonly IMediator _mediator;

        public EventStoreRepository(IMongoDatabaseSettings settings, IMediator mediator)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _eventCollection = database.GetCollection<EventDocument>(settings.PatientProfileEventsCollectionName);
            _mediator = mediator;
        }

        public async Task<ResultWithData<Guid>> AddAsync(PatientProfile patient)
        {
            try
            {
                var eventDocument = new EventDocument
                {
                    EventId = Guid.NewGuid(),
                    EventType = "PatientProfileCreated",
                    EntityId = patient.Id,
                    EventData = JsonConvert.SerializeObject(patient),
                    Timestamp = DateTime.UtcNow
                };

                await _eventCollection.InsertOneAsync(eventDocument);

                await _mediator.Publish(new PatientProfileCreatedEvent(patient));

                return ResultWithData<Guid>.Success(patient.Id);
            }
            catch (Exception ex)
            {
                return ResultWithData<Guid>.Error(ex.Message);
            }
        }

        public async Task<ResultWithData<Guid>> UpdateAsync(PatientProfile patient)
        {
            try
            {
                var eventDocument = new EventDocument
                {
                    EventId = Guid.NewGuid(),
                    EventType = "PatientProfileUpdated",
                    EntityId = patient.Id,
                    EventData = JsonConvert.SerializeObject(patient),
                    Timestamp = DateTime.UtcNow
                };

                await _eventCollection.InsertOneAsync(eventDocument);

                await _mediator.Publish(new PatientProfileUpdatedEvent(patient));

                return ResultWithData<Guid>.Success(patient.Id);
            }
            catch (Exception ex)
            {
                return ResultWithData<Guid>.Error(ex.Message);
            }
        }

        public async Task<Result> DeleteAsync(Guid patientId)
        {
            try
            {
                var eventDocument = new EventDocument
                {
                    EventId = Guid.NewGuid(),
                    EventType = "PatientProfileDeleted",
                    EntityId = patientId,
                    EventData = string.Empty,
                    Timestamp = DateTime.UtcNow
                };

                await _eventCollection.InsertOneAsync(eventDocument);

                await _mediator.Publish(new PatientProfileDeletedEvent(patientId));

                return new Result { Succeeded = true };
            }
            catch (Exception ex)
            {
                return new Result { Succeeded = false, Message = ex.Message };
            }
        }

        Task<Result> IPatientProfileCommandRepository.DeleteAsync(Guid patientId)
        {
            throw new NotImplementedException();
        }
    }
}
