using ComidaEmCasa.Core.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ComidaEmCasa.Core.Exceptions
{
    public class ExceptionCode : Exception
    {
        public ExceptionCode(ExceptionTags ex)
        {
            this.Code = ex;
        }
        private ExceptionTags _Code;
        public ExceptionTags Code
        {
            get { return _Code; }
            private set
            {
                _Code = value;
                Description = Code.GetDescription();
            }
        }
        public string Description { get; private set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(CreateDynamicData());
        }

        internal virtual ExpandoObject CreateDynamicData()
        {
            dynamic exo = new ExpandoObject();

            ((IDictionary<String, Object>)exo).Add("code", _Code);
            ((IDictionary<String, Object>)exo).Add("exception", Description);
            return exo;
        }

        public object ToErrorObj()
        {
            var error = new
            {
                code = _Code,
                exception = Description
            };
            return error;
        }
    }
}
