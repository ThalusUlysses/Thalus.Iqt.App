using System;
using System.Linq;
using System.Reflection;

namespace Thalus.Contracts
{
    public static class ObjectExtension
    {
        public static bool CanAssign(this object tp, object dataType)
        {
            return tp.GetType().IsAssignableFrom(dataType.GetType());
        }

        public static bool CanAssign<TType>(this object o)
        {
            return typeof(TType).CanAssign(o);
        }
    }
    
    public static class AppDomainExtensions
    {
        public static TType Create<TType>(this AppDomain asm,string type,params object[] parameters)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(i => i.GetTypes());

            var typeCreate = types.Where(i => i.Name.Equals(type, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();//.FirstOrDefault(i=> i == typeof(TType));

            if (parameters == null || !parameters.Any())
            {
                return (TType)Activator.CreateInstance(typeCreate);
            }
            return (TType) Activator.CreateInstance(typeCreate, parameters);
        }
    }
}


