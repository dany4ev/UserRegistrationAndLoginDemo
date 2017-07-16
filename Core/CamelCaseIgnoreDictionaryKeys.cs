using Newtonsoft.Json.Serialization;
using System;

namespace UserRegistrationAndLoginDemo.Api.Core.Infrastructure
{

    public class CamelCaseIgnoreDictionaryKeys : CamelCasePropertyNamesContractResolver
    {
        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
            var contract = base.CreateDictionaryContract(objectType);

            contract.DictionaryKeyResolver = propertyName => propertyName;

            return contract;
        }
    }
}