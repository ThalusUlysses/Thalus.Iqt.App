using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Thalus.Iqt.Core.Contracts;
using Thalus.Iqt.Core.Contracts.DTO;

namespace Thalus.Iqt.App.Json
{
    class IIqtIdentityConverter : JsonCreationConverter<IIqtIdentity>
    {
        public override void WriteJson(JsonWriter writer,object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected override IIqtIdentity Create(Type objectType, JObject jObject)
        {
            return new IqtIdentityDTO();
        }
    }
}
