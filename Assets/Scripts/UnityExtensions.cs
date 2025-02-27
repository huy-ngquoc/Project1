#nullable enable

namespace Game;

using System.Linq;
using UnityEngine;

public static class UnityExtension
{
    public static bool UnityAccess<T>(this T? obj, System.Action<T>? action)
        where T : UnityEngine.Object
    {
        if ((obj == null) || (action == null))
        {
            return false;
        }

        action(obj);
        return true;
    }

    public static TResult? UnityAccessRef<T, TResult>(this T? obj, System.Func<T, TResult>? func)
        where T : UnityEngine.Object
        where TResult : class?
    {
        if ((obj == null) || (func == null))
        {
            return default;
        }

        return func(obj);
    }

    public static TResult UnityAccessRef<T, TResult>(this T? obj, System.Func<T, TResult>? func, TResult defaultValue)
        where T : UnityEngine.Object
        where TResult : class?
    {
        var result = UnityAccessRef(obj, func);

        if (result == null)
        {
            return defaultValue;
        }

        return result;
    }

    public static TResult? UnityAccessVal<T, TResult>(this T? obj, System.Func<T, TResult>? func)
        where T : UnityEngine.Object
        where TResult : struct
    {
        if ((obj == null) || (func == null))
        {
            return default;
        }

        return func(obj);
    }

    public static TResult UnityAccessVal<T, TResult>(this T? obj, System.Func<T, TResult>? func, TResult defaultValue)
        where T : UnityEngine.Object
        where TResult : struct
    {
        var result = UnityAccessVal(obj, func);

        if (!result.HasValue)
        {
            return defaultValue;
        }

        return result.Value;
    }

    public static TUnityComponent? ResolveComponent<TUnityComponent>(this MonoBehaviour monoBehaviour)
        where TUnityComponent : UnityEngine.Component
    {
        TUnityComponent? result = null;

        var array = monoBehaviour.GetComponents<TUnityComponent>();
        if (array.Length <= 0)
        {
            Debug.LogAssertion($"No components of type `{typeof(TUnityComponent).FullName}` can be found in this MonoBehaviour of game object `{monoBehaviour.name}`!");
        }
        else if (array.Length > 1)
        {
            Debug.LogAssertion($"Two or more components of type `{typeof(TUnityComponent).FullName}` are found in this MonoBehaviour of game object `{monoBehaviour.name}`!");
        }
        else
        {
            result = array[0];
        }

        return result;
    }

    public static TUnityComponent? ResolveComponentInChildren<TUnityComponent>(this MonoBehaviour monoBehaviour)
        where TUnityComponent : UnityEngine.Component
    {
        TUnityComponent? result = null;

        var array = monoBehaviour.GetComponentsInChildren<TUnityComponent>(true);
        if (array.Length <= 0)
        {
            Debug.LogAssertion($"No components of type `{typeof(TUnityComponent).FullName}` can be found in this MonoBehaviour or its children of game object `{monoBehaviour.name}`!");
        }
        else if (array.Length > 1)
        {
            Debug.LogAssertion($"Two or more components of type `{typeof(TUnityComponent).FullName}` are found in this MonoBehaviour and its children of game object `{monoBehaviour.name}`!");
        }
        else
        {
            result = array[0];
        }

        return result;
    }

    public static TUnityComponent? ResolveComponentInChildren<TUnityComponent>(this MonoBehaviour monoBehaviour, string childObjName)
    where TUnityComponent : UnityEngine.Component
    {
        TUnityComponent? result = null;

        var array = monoBehaviour.GetComponentsInChildren<TUnityComponent>(true).Where(c => c.name == childObjName).ToArray();
        if (array.Length <= 0)
        {
            Debug.LogAssertion($"No components of type `{typeof(TUnityComponent).FullName}` can be found in this MonoBehaviour's children of game object `{monoBehaviour.name}` that have game object is `{childObjName}`!");
        }
        else if (array.Length > 1)
        {
            Debug.LogAssertion($"Two or more components of type `{typeof(TUnityComponent).FullName}` are found in this MonoBehaviour's children of game object `{monoBehaviour.name}` that have game object is `{childObjName}`!");
        }
        else
        {
            result = array[0];
        }

        return result;
    }
}
