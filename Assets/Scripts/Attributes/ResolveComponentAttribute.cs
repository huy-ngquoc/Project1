#nullable enable

namespace Game;

using System;
using UnityEngine;

/// <summary>
/// Automatically assigns a component to the field, similar to GetComponent().
/// If no matching component is found or multiple components of the field's type exist on the GameObject,
/// the field is null and an error is logged.
/// The field is displayed as read-only in the Inspector if it's serialized by Unity.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public sealed class ResolveComponentAttribute : PropertyAttribute
{
}
