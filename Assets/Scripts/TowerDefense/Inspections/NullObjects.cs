using System;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;
// ReSharper disable ArrangeNullCheckingPattern
// ReSharper disable UnusedMember.Global

namespace TowerDefense.Inspections
{
    public class NullObjects : MonoBehaviour
    {
        private MyMonoBehaviour behaviour1;
        private MyMonoBehaviour behaviour2;
        
        private void Awake()
        {
            behaviour1 = GetComponent<MyMonoBehaviour>();
            behaviour2 = GetComponent<MyMonoBehaviour>();
        }

        public void HighlightNativeObjectLifetimeCheck()
        {
            // Null comparison of a Unity Object will check the underlying native game object is still alive
            // Rider will highlight this implicit check with an inlay hint icon
            // -> Let the user know there is more going on than meets the eye!
            // Context action to use a more explicit form of lifetime check (implicit cast to bool)
            // Context action to use a standard C# null comparison with patterns or ReferenceEquals
            if (behaviour1 == null || behaviour2 != null)
            {
                // ... GetComponent ...
            }

            // Patterns do not call custom equality operators, so there is no lifetime check happening
            // Therefore, no highlight
            if (behaviour1 is null || behaviour2 is not {})
            {
                // ... GetComponent ...
            }
        }

        public void UnityObjectEqualityTypeSafety()
        {
            // The UnityEngine.Object.Equals(Object x, Object y) method will compare any two Unity Object based objects,
            // even if they are of different type. This is not likely to be correct, so Rider will warn if the types are
            // different
            Renderer coolRenderer = GetComponent<Renderer>();
            if (coolRenderer == transform)
            {
                // ...
            }
        }
        
        public void PessimisticNullCheckingInspections(MyMonoBehaviour mb)
        {
            // Only direct comparison with null uses the custom equality operators and performs the lifetime check.
            // Null coalescing and null propagation perform a simple C# null check, as do patterns.
            // Previous versions of Rider would warn if null coalescing or null propagation was used, highlighting a
            // "possibly unintended bypass of lifetime check"
            // However, this would highlight standard C# operations behaving just like standard C# operations, and is
            // confusing to new users. Highlighting when the lifetime check happens is more useful.
            
            // The previous inspections can be re-enabled in:
            // Settings | Editor | Inspection Settings | Inspection Severity | C# | Unity
            // by checking the group, or individual inspections:
            // "Possible unintended bypass of lifetime check of underlying Unity engine object"
            
            // ?? will bypass the lifetime check that `if (mb)` would perform, thanks to an implicit cast to bool
            // Alt+Enter convert to conditional expression will check the lifetime of the underlying lifetime
            // Use "Why is Rider suggesting this?" to find out more
            var behaviour = mb ?? gameObject.AddComponent<MyMonoBehaviour>();
            
            // ?. also bypasses the lifetime check. There is no QF available for this code
            if (behaviour?.CompareTag("Finish") == true)
            {
                // ...
            }
            
            // Return values from methods are checked in 2024.1
            behaviour = mb ?? GetMyMonoBehaviour();

            // Pattern matching is highlighted in 2024.1
            if (behaviour is null || behaviour is not {})
            {
                // ...
            }

            var result = behaviour switch
            {
                not null => true,
                _ => true
            };

            // Nested patterns are also supported
            if (behaviour is { gameObject: null })
            {
                // ...
            }
        }

        public void ChainingNull()
        {
            // behaviour1 might be null, or might be destroyed. We don't know
            var layer1 = behaviour1?.gameObject.layer;
            
            // behaviour2 calls UnannotatedOpt to perform lifetime check, but Rider doesn't know
            var layer2 = behaviour2.UnannotatedOpt()?.gameObject.layer;
            
            // Opt is annotated with [NotDestroyed] attribute, Rider knows it's performed a lifetime check
            // However, the return value can be null, so we need to check C# nullability
            // This attribute must be defined somewhere in your source code. See bottom of file
            var layer3 = behaviour1.Opt()?.gameObject.layer;
        }
        
        private MyMonoBehaviour GetMyMonoBehaviour() => GetComponent<MyMonoBehaviour>();
    }

    public static class UnityObjectExtension
    {
        // Also works with C# nullability
        [CanBeNull]
        public static T UnannotatedOpt<T>([CanBeNull] this T self) where T : UnityEngine.Object
        {
            return self == null ? null : self;
        }
        
        // Also works with C# nullability
        [CanBeNull]
        [return: NotDestroyed]
        public static T Opt<T>([CanBeNull] this T self) where T : UnityEngine.Object
        {
            return self == null ? null : self;
        }
    }
}

namespace JetBrains.Annotations
{
    [Conditional("JETBRAINS_ANNOTATIONS")]
    [AttributeUsage(AttributeTargets.ReturnValue)]
    public class NotDestroyedAttribute : Attribute
    {
    }
}