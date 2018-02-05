using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.IO
{
    sealed class BinConverter : SerializationBinder
    {
        public override Type BindToType(string targetAssemblyName, string targetTypeName)
        {
            Type typeToDeserialize = null;

            // For each assemblyName/typeName that you want to deserialize to 
            // a different type, set typeToDeserialize to the desired type.
            String runtimeAssembly = Assembly.GetExecutingAssembly().FullName;
            String runtimeType = "Version1Type";

            if (targetAssemblyName == runtimeAssembly && targetTypeName == runtimeType)
            {
                // To use a type from a different assembly version,  
                // change the version number. 
                // To do this, uncomment the following line of code. 
                // assemblyName = assemblyName.Replace("1.0.0.0", "2.0.0.0");

                // To use a different type from the same assembly,  
                // change the type name.
                targetTypeName = "Version2Type";
            }

            // The following line of code returns the type.
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}", targetTypeName, targetAssemblyName));

            return typeToDeserialize;
        }
    }
}