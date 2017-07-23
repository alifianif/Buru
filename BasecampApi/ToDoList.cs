using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buru.BasecampApi.Collections;
using Newtonsoft.Json;
using Buru.BasecampApi.CreateRequests;

namespace Buru.BasecampApi
{
    public class ToDoList : ToDoListStub
    {

        private ToDoListItemCollection _todos;
        [JsonProperty("todos")]
        public ToDoListItemCollection ToDos
        {
            get
            {
                if (_todos == null)
                {
                    _todos = new ToDoListItemCollection();
                    _todos.Api = Api;
                    _todos.List = this;
                }
                return _todos;
            }
            internal set
            {
                _todos = value;
                if (_todos != null)
                {
                    _todos.Api = Api;
                    _todos.List = this;
                }

            }
        }

    }
}