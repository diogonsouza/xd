using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Admin.WebCommon
{
    public class ContractResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            if (!string.IsNullOrEmpty(objectType.Namespace) && objectType.Namespace.StartsWith("System.Data.Entity.Dynamic"))
            {
                var data = base.GetSerializableMembers(objectType.BaseType);
                return data;
            }
            return base.GetSerializableMembers(objectType);
        }
        protected override JsonProperty CreateProperty(MemberInfo member, Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            property.Ignored = false;
            return property;
        }

    }
}