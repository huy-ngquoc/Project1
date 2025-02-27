#nullable enable

namespace Game;

using System.Runtime.CompilerServices;
using Debug = UnityEngine.Debug;
using DisallowNullAttribute = System.Diagnostics.CodeAnalysis.DisallowNullAttribute;
using NotNullWhenAttribute = System.Diagnostics.CodeAnalysis.NotNullWhenAttribute;

public static class QuickLog
{
    public static bool WarnIfAccessNull<T>(
        [NotNullWhen(false)] T? obj,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string callerFilePath = "")
        where T : class
    {
        if (obj == null)
        {
            Debug.LogWarning($"Attempting to access a reference of type `{typeof(T).FullName}` in function `{callerName}` on file `{callerFilePath}` when it is null!");
            return true;
        }

        return false;
    }

    public static bool WarnIfAccessNull<T>(
        [NotNullWhen(false)] T? obj,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string callerFilePath = "")
        where T : struct
    {
        return WarnIfAccessNoValue(obj, callerName, callerFilePath);
    }

    public static bool WarnIfAccessNoValue<T>(
        [NotNullWhen(false)] T? obj,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string callerFilePath = "")
        where T : struct
    {
        if (!obj.HasValue)
        {
            Debug.LogWarning($"Attempting to access a value of type `{typeof(T).FullName}` in function `{callerName}` on file `{callerFilePath}` when it has no value!");
            return true;
        }

        return false;
    }

    public static bool ErrorIfAccessNull<T>(
    [NotNullWhen(false)] T? obj,
    [CallerMemberName] string callerName = "",
    [CallerFilePath] string callerFilePath = "")
    where T : class
    {
        if (obj == null)
        {
            Debug.LogError($"Attempting to access a reference of type `{typeof(T).FullName}` in function `{callerName}` on file `{callerFilePath}` when it is null!");
            return true;
        }

        return false;
    }

    public static bool ErrorIfAccessNull<T>(
        [NotNullWhen(false)] T? obj,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string callerFilePath = "")
        where T : struct
    {
        return ErrorIfAccessNoValue(obj, callerName, callerFilePath);
    }

    public static bool ErrorIfAccessNoValue<T>(
        [NotNullWhen(false)] T? obj,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string callerFilePath = "")
        where T : struct
    {
        if (!obj.HasValue)
        {
            Debug.LogError($"Attempting to access a value of type `{typeof(T).FullName}` in function `{callerName}` on file `{callerFilePath}` when it has no value!");
            return true;
        }

        return false;
    }

    public static bool AssertIfAccessNull<T>(
    [NotNullWhen(false)] T? obj,
    [CallerMemberName] string callerName = "",
    [CallerFilePath] string callerFilePath = "")
    where T : class
    {
        if (obj == null)
        {
            Debug.LogAssertion($"Attempting to access a reference of type `{typeof(T).FullName}` in function `{callerName}` on file `{callerFilePath}` when it is null!");
            return true;
        }

        return false;
    }

    public static bool AssertIfAccessNull<T>(
        [NotNullWhen(false)] T? obj,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string callerFilePath = "")
        where T : struct
    {
        return AssertIfAccessNoValue(obj, callerName, callerFilePath);
    }

    public static bool AssertIfAccessNoValue<T>(
        [NotNullWhen(false)] T? obj,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string callerFilePath = "")
        where T : struct
    {
        if (!obj.HasValue)
        {
            Debug.LogAssertion($"Attempting to access a value of type `{typeof(T).FullName}` in function `{callerName}` on file `{callerFilePath}` when it has no value!");
            return true;
        }

        return false;
    }

    public static bool AssertIfUnityObjectNull<TMonoBehaviour, TObject>(
        [DisallowNull] TMonoBehaviour monoBehaviour,
        [NotNullWhen(false)] TObject? obj,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string callerFilePath = "")
        where TMonoBehaviour : UnityEngine.MonoBehaviour
        where TObject : UnityEngine.Object
    {
        if (obj == null)
        {
            Debug.LogAssertion($"Component `{typeof(TMonoBehaviour).FullName}` of Game Object `{monoBehaviour.name}` has an Unity Engine's Object of type `{typeof(TObject).FullName}` is null in function `{callerName}` on file `{callerFilePath}`.");
            return true;
        }

        return false;
    }
}
