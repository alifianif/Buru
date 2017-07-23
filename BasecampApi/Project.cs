using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Buru.BasecampApi.Managers;
using Buru.BasecampApi.CreateRequests;

namespace Buru.BasecampApi
{
    public class Project : ProjectStub
    {
        [JsonProperty("creator")]
        public PersonStub Creator { get; set; }
        [JsonProperty("accesses")]
        public ItemMeta AccessInfo { get; set; }
        [JsonProperty("attachments")]
        public ItemMeta AttachmentInfo { get; set; }
        /*[JsonProperty("calendar_events")]
        public ItemMeta CalendarEventInfo { get; set; }
        [JsonProperty("documents")]
        public ItemMeta DocumentInfo { get; set; }*/
        [JsonProperty("topics")]
        public ItemMeta TopicInfo { get; set; }
        [JsonProperty("todolists")]
        public ItemMeta ToDoListInfo { get; set; }

        /*public Message CreateMessage(MessageCreateRequest request)
        {
            request.ProjectId = this.Id;
            return Api.Messages.Create(request);
        }

        public Message CreateMessage(Message mesage)
        {
            var createRequest = new MessageCreateRequest();
            ModelCopier.CopyModel(mesage, createRequest);
            return Api.Messages.Create(createRequest);
        }

        public void UpdateCalendarEvent(Message mesage)
        {
            Api.Messages.Update(mesage);
        }*/

        private IEnumerable<Attachment> _attachments;
        [JsonIgnore]
        public IEnumerable<Attachment> Attachments
        {
            get
            {
                if (_attachments == null && Api != null)
                {
                    _attachments = Api.Attachments.GetForProject(this.Id);
                }
                return _attachments;
            }
            internal set
            {
                _attachments = value;
            }
        }

        /*private IEnumerable<DocumentStub> _documents;
        [JsonIgnore]
        public IEnumerable<DocumentStub> Documents
        {
            get
            {
                if (_documents == null && Api != null)
                {
                    _documents = Api.Documents.GetForProject(this.Id);
                }
                return _documents;
            }
            internal set
            {
                _documents = value;
            }
        }

        /*[JsonIgnore]
        public IEnumerable<Topic> Messages
        {
            get
            {
                return Topics.Where(t => t.TopicableItem.Type == "Message");
            }
        }

        private IEnumerable<Topic> _topics;
        [JsonIgnore]
        public IEnumerable<Topic> Topics
        {
            get
            {
                if (_topics == null && Api != null)
                {
                    _topics = Api.Topics.GetTopicsForProject(this.Id);
                }
                return _topics;
            }
            internal set
            {
                _topics = value;
            }
        }*/

        private IEnumerable<PersonStub> _people;
        [JsonIgnore]
        public IEnumerable<PersonStub> People
        {
            get
            {
                if (_people == null && Api != null)
                {
                    _people = Api.Accesses.GetPeopleWithAccessToProject(this.Id);
                }
                return _people;
            }
            internal set
            {
                _people = value;
            }
        }

        /*private ProjectCalendarEventCollection _calendarEvents;
        [JsonIgnore]
        public ProjectCalendarEventCollection CalendarEvents
        {
            get
            {
                if (_calendarEvents == null)
                {
                    var collection = new ProjectCalendarEventCollection();
                    collection.Api = Api;
                    collection.Project = this;
                    _calendarEvents = collection;
                }
                return _calendarEvents;
            }
            internal set
            {
                _calendarEvents = value;
                if (_calendarEvents != null)
                {
                    _calendarEvents.Api = Api;
                    _calendarEvents.Project = this;
                }
            }
        }*/

        public Upload UploadFile(string filePath)
        {
            var token = Api.Attachments.CreateAttachmentToken(filePath);
            return Api.Uploads.CreateForProject(this.Id, string.Empty, token);
        }

        /*public IEnumerable<Event> GetEvents(DateTime since)
        {
            return Api.Events.GetForProject(this.Id, since);
        }*/

        public bool GrantAccess(int personId)
        {
            return Api.Accesses.GrantAccessToProject(this.Id, new int[] { personId });
        }

        public bool GrantAccess(IEnumerable<int> peopleIds)
        {
            return Api.Accesses.GrantAccessToProject(this.Id, peopleIds);
        }

        public bool GrantAccess(PersonStub person)
        {
            return Api.Accesses.GrantAccessToProject(this, new PersonStub[] { person });
        }

        public bool GrantAccess(IEnumerable<PersonStub> people)
        {
            return Api.Accesses.GrantAccessToProject(this, people);
        }

        public bool GrantAccess(string emailAddress)
        {
            return Api.Accesses.GrantAccessToProject(this, new string[] { emailAddress });
        }

        public bool GrantAccess(IEnumerable<string> emailAddresses)
        {
            return Api.Accesses.GrantAccessToProject(this, emailAddresses);
        }

        public ToDoListStub CreateToDoList(string name, string description = "")
        {
            var createRequest = new ToDoListCreateRequest()
            {
                Name = name,
                Description = description,
                ProjectId = this.Id
            };
            var list = Api.ToDoLists.Create(createRequest);
            return list;
        }

        public bool UpdateToDoList(ToDoListStub list)
        {
            return Api.ToDoLists.Update(list);
        }

        /*public CalendarEventStub CreateCalendarEvent(CalendarEventCreateRequest request)
        {
            return Api.Calendars.CreateEventForProject(this.Id, request);
        }

        public CalendarEventStub CreateCalendarEvent(CalendarEventStub calendarEvent)
        {
            var createRequest = new CalendarEventCreateRequest();
            ModelCopier.CopyModel(calendarEvent, createRequest);
            return Api.Calendars.CreateEventForProject(this.Id, createRequest);
        }

        public void UpdateCalendarEvent(CalendarEventStub calendarEvent)
        {
            Api.Calendars.UpdateEventForProject(this.Id, calendarEvent);
        }*/

        [JsonIgnore]
        public IEnumerable<ToDoListStub> ToDoLists
        {
            get
            {
                var list = new List<ToDoListStub>();
                if (ActiveToDoLists != null)
                {
                    list.AddRange(ActiveToDoLists);
                }
                if (CompletedToDoLists != null)
                {
                    list.AddRange(CompletedToDoLists);
                }
                return list;
            }
        }

        private List<ToDoListStub> _activetoDoLists;
        [JsonIgnore]
        public IEnumerable<ToDoListStub> ActiveToDoLists
        {
            get
            {
                if (_activetoDoLists == null && Api != null)
                {
                    _activetoDoLists = Api.ToDoLists.GetActiveForProject(Id).ToList();
                }

                return _activetoDoLists;
            }
        }

        private List<ToDoListStub> _completedToDoLists;
        [JsonIgnore]
        public IEnumerable<ToDoListStub> CompletedToDoLists
        {
            get
            {
                if (_completedToDoLists == null && Api != null)
                {
                    _completedToDoLists = Api.ToDoLists.GetCompletedForProject(Id).ToList();
                }

                return _completedToDoLists;
            }
        }
    }
}