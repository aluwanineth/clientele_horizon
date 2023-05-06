using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Polly_C.Horizon.Models.Integration.v1;
using Polly_C.Horizon.Models.v1;

namespace Polly_C.Horizon.Utilities
{
    public static class DataStructureToJSONSchema
    {
        public static string GetMessagePolicyV1Schema()
        {
            JSchemaGenerator generator = new JSchemaGenerator();
            generator.GenerationProviders.Add(new StringEnumGenerationProvider());
            JSchema schema = generator.Generate(typeof(MessagePolicyV1));
            return schema.ToString();
        }

    }
}