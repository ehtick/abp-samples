using EventOrganizer.Events;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EventOrganizer
{
    [Mapper]
    public partial class EventCreationDtoToEventMapper : MapperBase<EventCreationDto, Event>
    {
        public override partial Event Map(EventCreationDto source);
        public override partial void Map(EventCreationDto source, Event destination);
    }

    [Mapper]
    public partial class EventToEventDtoMapper : MapperBase<Event, EventDto>
    {
        public override partial EventDto Map(Event source);
        public override partial void Map(Event source, EventDto destination);
    }

    [Mapper]
    public partial class EventToEventDetailDtoMapper : MapperBase<Event, EventDetailDto>
    {
        public override partial EventDetailDto Map(Event source);
        public override partial void Map(Event source, EventDetailDto destination);
    }

    [Mapper]
    public partial class EventAttendeeToEventAttendeeDtoMapper : MapperBase<EventAttendee, EventAttendeeDto>
    {
        public override partial EventAttendeeDto Map(EventAttendee source);
        public override partial void Map(EventAttendee source, EventAttendeeDto destination);
    }
}
