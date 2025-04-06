#nullable enable

namespace Game;

using UnityEngine;

public abstract class EntitySkillManager : MonoBehaviour
{
    public abstract EntityController EntityController { get; }
}
