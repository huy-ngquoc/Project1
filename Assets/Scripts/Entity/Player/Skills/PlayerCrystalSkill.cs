#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerCrystalSkill : PlayerSkill
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        private PlayerSkillManager playerSkillManager = null!;

        [field: SerializeField]
        private GameObject crystalPrefab = null!;

        private GameObject? currentCrystal = null;

        [field: SerializeField]
        [field: Range(0.5F, 5)]
        public float CrystalDuration { get; private set; } = 1.5F;

        [field: Header("Explosive crystal")]
        [field: SerializeField]
        public bool CanExplode { get; private set; } = false;

        [field: Header("Moving crystal")]
        [field: SerializeField]
        public bool CanMoveToEnemy { get; private set; } = false;

        [field: SerializeField]
        [field: Range(0.5F, 10)]
        public float MoveSpeed { get; private set; } = 4;

        public override PlayerSkillManager PlayerSkillManager => this.playerSkillManager;

        protected override void CastLogic()
        {
            this.PlayerController.InputHandler.CancelCrystalAction();

            if (this.currentCrystal == null)
            {
                this.CreateCrystal();
                return;
            }

            if (!this.currentCrystal.TryGetComponent<PlayerCrystalSkillController>(out var crystalSkillController))
            {
                Object.Destroy(this.currentCrystal);
                this.currentCrystal = null;
            }
            else if (crystalSkillController.CanMove)
            {
                // Do nothing...
            }
            else if (crystalSkillController.IsFinishing)
            {
                this.currentCrystal = null;
            }
            else
            {
                (this.currentCrystal.transform.position, this.transform.position) = (this.transform.position, this.currentCrystal.transform.position);
                crystalSkillController.CrystalFinishing();
                this.currentCrystal = null;
            }
        }

        private void CreateCrystal()
        {
            this.currentCrystal = Object.Instantiate(this.crystalPrefab, this.transform.position, Quaternion.identity);
            if (!this.currentCrystal.TryGetComponent<PlayerCrystalSkillController>(out var crystalSkillController))
            {
                Object.Destroy(this.currentCrystal);
                this.currentCrystal = null;
            }
            else
            {
                var closestEnemyTransform = this.PlayerSkillManager.FindClosestEnemyTransform(this.currentCrystal.transform.position);
                crystalSkillController.SetupCrystal(this.PlayerController, this.CrystalDuration, this.CanExplode, this.CanMoveToEnemy, this.MoveSpeed, closestEnemyTransform);
            }
        }
    }
}
