#nullable enable

namespace Game;

[System.AttributeUsage(System.AttributeTargets.Field)]
public sealed class ReadOnlyInInspectorAttribute : UnityEngine.PropertyAttribute
{
}