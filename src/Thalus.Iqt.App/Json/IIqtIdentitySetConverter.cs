using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Thalus.Iqt.Core.Contracts;
using Thalus.Iqt.Core.Contracts.DTO;

namespace Thalus.Iqt.App.Json
{
    class IIqtIdentitySetConverter : JsonCreationConverter<IIqtIdentitySet>
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected override IIqtIdentitySet Create(Type objectType, JObject jObject)
        {
            return new IqtIdentitySetDTO();
        }
    }
}
