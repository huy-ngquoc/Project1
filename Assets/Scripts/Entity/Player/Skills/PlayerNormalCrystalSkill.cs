#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerNormalCrystalSkill : PlayerCrystalSkill
    {
        private GameObject? currentCrystal = null;

        [field: SerializeField]
        [field: Range(0.5F, 10)]
        public float MoveSpeed { get; private set; } = 4;

        protected override void CastLogic()
        {
            this.PlayerController.InputHandler.CancelCrystalAction();

            if (this.currentCrystal == null)
            {
                this.CreateCrystal();
                return;
            }

            if (!this.currentCrystal.TryGetComponent<PlayerNormalCrystalSkillController>(out var crystalSkillController))
            {
                Object.Destroy(this.currentCrystal);
                this.currentCrystal = null;
                return;
            }

            if (crystalSkillController.IsFinishing)
            {
                this.currentCrystal = null;
            }
        }

        private void CreateCrystal()
        {
            this.currentCrystal = Object.Instantiate(this.CrystalPrefab, this.transform.position, Quaternion.identity);
            if (!this.currentCrystal.TryGetComponent<PlayerNormalCrystalSkillController>(out var crystalSkillController))
            {
                Object.Destroy(this.currentCrystal);
                this.currentCrystal = null;
                return;
            }

            var closestEnemyTransform = this.PlayerSkillManager.FindClosestEnemyTransform(this.currentCrystal.transform.position);
            crystalSkillController.SetupCrystal(this.PlayerController, this.CrystalDuration, this.MoveSpeed, closestEnemyTransform);
        }
    }
}
