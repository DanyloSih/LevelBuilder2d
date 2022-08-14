using System;
using System.Collections.Generic;
using UnityEngine;

namespace InspectorAddons
{
    [Serializable]
    public class InterfaceComponent<InterfaceT> : InterfaceObject<InterfaceT, Component>
        where InterfaceT: class
    {
        public static List<InterfaceT> GetInterfaces(
            List<InterfaceComponent<InterfaceT>> interfaceComponents)
        {
            List<InterfaceT> interfaces = new List<InterfaceT>();
            foreach (var item in interfaceComponents)
                interfaces.Add(item.Interface);

            return interfaces;
        }
    }
}
