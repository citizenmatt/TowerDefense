using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace TowerDefense.Inspections.OdinInspector
{
    // Serialised fields are recognised, highlighted and marked as in use
    public class OdinSerialisationDemo : SerializedMonoBehaviour
    {
        [OdinSerialize] public MyGenericClass<int, int> OdinSerializedField1;
        [OdinSerialize] public MyGenericClass<Vector3, Quaternion> OdinSerializedField2;
        [OdinSerialize] public MyGenericClass<int, GameObject> OdinSerializedField3;
        [OdinSerialize] public MyGenericClass<string, List<string>> OdinSerializedField4;
        [OdinSerialize] public MyGenericClass<string, string> OdinSerializedField5;
        
        // Serialised. Marked as assigned, not used
        public List<MyClass> unitySerialisedField1;
        public Dictionary<string, MyClass> unitySerialisedField2;
    }
    
    public class MyGenericClass<T1, T2>
    {
        public T1 First;
        public T2 Second;
    }
    
    [Serializable]
    public class MyClass
    {
        public string name;
        public float value;
    }
}