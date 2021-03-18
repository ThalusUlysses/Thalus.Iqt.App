using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Thalus.Iqt.Core.Contracts;
using Thalus.Iqt.Core.Contracts.DTO;

namespace Thalus.Iqt.App.Json
{
    class IIqtExcludesConverter : JsonCreationConverter<IIqtExcludes>
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected override IIqtExcludes Create(Type objectType, JObject jObject)
        {
            return new IqtExcludesDTO();
        }
    }
}
