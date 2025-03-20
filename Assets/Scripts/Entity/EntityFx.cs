#nullable enable

namespace Game;

using System.Collections;
using UnityEngine;

public abstract class EntityFx : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0.05F, 1.0F)]
    public float FlashDuration { get; private set; } = 0.2F;

    [field: SerializeReference]
    public Material HitMaterial { get; private set; } = null!;

    public Material OriginalMaterial { get; private set; } = null!;

    public abstract EntityController EntityController { get; }

    public SpriteRenderer SpriteRenderer => this.EntityController.SpriteRenderer;

    public void FlashFx()
    {
        this.StartCoroutine(this.FlashFxLogic());
    }

    protected void Awake()
    {
        this.OriginalMaterial = this.SpriteRenderer.material;
    }

    private IEnumerator FlashFxLogic()
    {
        this.SpriteRenderer.material = this.HitMaterial;
        var currentColor = this.SpriteRenderer.color;

        this.SpriteRenderer.color = Color.white;
        yield return new WaitForSeconds(this.FlashDuration);

        this.SpriteRenderer.material = this.OriginalMaterial;
        this.SpriteRenderer.color = currentColor;
    }
}
