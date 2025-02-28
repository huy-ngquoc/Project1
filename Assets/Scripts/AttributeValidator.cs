#if UNITY_EDITOR

#nullable enable

namespace Game;

using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class AttributeValidator
{
    static AttributeValidator()
    {
        // Run validation every time scripts reload
        TwoAttributesCannotSameField<ReadOnlyInInspectorAttribute, HideInInspector>();
        TwoAttributesCannotSameField<ReadOnlyInInspectorAttribute, ResolveComponentAttribute>();
        TwoAttributesCannotSameField<ReadOnlyInInspectorAttribute, ResolveComponentInChildrenAttribute>();
        TwoAttributesCannotSameField<ResolveComponentAttribute, ResolveComponentInChildrenAttribute>();
    }

    private static void TwoAttributesCannotSameField<TAttribute1, TAttribute2>()
        where TAttribute1 : Attribute
        where TAttribute2 : Attribute
    {
        foreach (MonoScript script in MonoImporter.GetAllRuntimeMonoScripts())
        {
            var scriptType = script.GetClass();
            if (scriptType == null || !scriptType.IsSubclassOf(typeof(MonoBehaviour)))
            {
                continue;
            }

            // Get all serialized fields in the class
            var fields = scriptType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                // Check if both attributes are present
                var hasAttributeA = field.GetCustomAttributes(typeof(TAttribute1), false).Any();
                var hasAttributeB = field.GetCustomAttributes(typeof(TAttribute2), false).Any();

                if (hasAttributeA && hasAttributeB)
                {
                    Debug.LogError($"[Attribute Conflict] Field '{field.Name}' in '{scriptType.Name}' cannot have both attributes [`{typeof(TAttribute1).FullName}`] and [`{typeof(TAttribute2).FullName}`]!");
                }
            }
        }
    }
}
#endif
