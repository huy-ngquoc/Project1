#nullable enable

namespace Game
{
    using UnityEngine;
    using UnityEngine.UI;

    public sealed class HealthBarUI : MonoBehaviour
    {
        [field: SerializeField]
        [field: ResolveComponentInParent]
        private EntityController entityController = null!;

        [field: SerializeField]
        [field: ResolveComponent]
        private RectTransform rectTransform = null!;

        [field: SerializeField]
        [field: ResolveComponentInChildren]
        private Slider slider = null!;

        private EntityStats EntityStats => this.entityController.EntityStats;

        private void Start()
        {
            this.UpdateHealthUI();
        }

        private void OnEnable()
        {
            this.entityController.OnFlipped += this.FlipUI;
            this.EntityStats.OnHealthChanged += this.UpdateHealthUI;
        }

        private void OnDisable()
        {
            this.entityController.OnFlipped -= this.FlipUI;
            this.EntityStats.OnHealthChanged -= this.UpdateHealthUI;
        }

        private void FlipUI() => this.rectTransform.Rotate(0, 180, 0);

        private void UpdateHealthUI()
        {
            this.slider.maxValue = this.EntityStats.MaxHealth;
            this.slider.value = this.EntityStats.CurrentHealth;
        }
    }
}
