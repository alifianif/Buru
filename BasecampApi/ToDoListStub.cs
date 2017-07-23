using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Buru.BasecampApi.Collections;
using Buru.BasecampApi.CreateRequests;

namespace Buru.BasecampApi
{
    public class ToDoListStub : ApiStubObject<ToDoList>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonIgnore]
        public int ProjectId
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("position")]
        public int Position { get; set; }
        [JsonProperty("completed_count")]
        public int NumberCompleted { get; set; }
        [JsonProperty("remaining_count")]
        public int NumberRemaining { get; set; }
        [JsonProperty("creator")]
        public PersonStub Creator { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }

        public override ToDoList GetDetail()
        {
            if (Api != null)
            {
                if (!string.IsNullOrEmpty(Url))
                {
                    return Api.GetResponseFromUrl<ToDoList>(Url);
                }
                return Api.ToDoLists.GetDetail(ProjectId, Id);
            }

            return null;
        }

        public ToDoListItem CreateToDo(string content, DateTime? dueAt = null, PersonStub assignee = null)
        {
            var createRequest = new ToDoListItemCreateRequest()
            {
                ProjectId = this.ProjectId,
                ToDoListId = this.Id,
                Content = content,
                DueAt = dueAt,
                Assignee = assignee
            };

            var item = Api.ToDoLists.Create(createRequest);
            return item;
        }

        public bool UpdateToDo(ToDoListItemStub item)
        {
            return Api.ToDoLists.Update(item);
        }


    }
}