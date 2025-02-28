#nullable enable

namespace Game;

/// <summary>
/// The field is displayed as read-only in the Inspector if it's serialized by Unity.
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Field)]
public sealed class ReadOnlyInInspectorAttribute : UnityEngine.PropertyAttribute
{
}