#nullable enable

namespace Game
{
    using System.Collections.Generic;
    using UnityEngine;

    public sealed class PlayerMultiCrystalSkill : PlayerCrystalSkill
    {
        [field: SerializeField]
        private List<GameObject> crystalRemaining = new();

        [field: SerializeField]
        [field: Range(2, 10)]
        public byte StacksAmount { get; private set; } = 1;

        [field: SerializeField]
        [field: Range(1, 12)]
        public float MultiStackCooldown { get; private set; } = 4;

        [field: SerializeField]
        [field: Range(0.1F, 4)]
        public float UseTimeWindow { get; private set; } = 1;

        [field: SerializeField]
        [field: Range(0.5F, 10)]
        public float MoveSpeed { get; private set; } = 4;

        protected override void CastLogic()
        {
            this.PlayerController.InputHandler.CancelCrystalAction();

            if (this.crystalRemaining.Count <= 0)
            {
                this.RefillCrystal();
            }

            if (this.crystalRemaining.Count >= this.StacksAmount)
            {
                this.Invoke(nameof(this.ResetMultiCrystalAbility), this.UseTimeWindow);
            }

            var crystalToSpawn = this.crystalRemaining[^1];
            var newCrystal = Object.Instantiate(crystalToSpawn, this.transform.position, Quaternion.identity);
            this.crystalRemaining.RemoveAt(this.crystalRemaining.Count - 1);

            if (!newCrystal.TryGetComponent<PlayerMultiCrystalSkillController>(out var crystalSkillController))
            {
                Object.Destroy(newCrystal);
            }
            else
            {
                var closestEnemyTransform = this.PlayerSkillManager.FindClosestEnemyTransform(newCrystal.transform.position);
                crystalSkillController.SetupCrystal(this.PlayerController, this.CrystalDuration, this.MoveSpeed, closestEnemyTransform);
            }

            if (this.crystalRemaining.Count > 0)
            {
                this.Cooldown = 0;
            }
            else
            {
                this.Cooldown = this.MultiStackCooldown;
                this.RefillCrystal();
            }
        }

        private void RefillCrystal()
        {
            if (this.crystalRemaining.Count >= this.StacksAmount)
            {
                return;
            }

            var amountToAdd = this.StacksAmount - this.crystalRemaining.Count;
            this.crystalRemaining.Capacity = this.StacksAmount;

            for (var i = 0; i < amountToAdd; ++i)
            {
                this.crystalRemaining.Add(this.CrystalPrefab);
            }
        }

        private void ResetMultiCrystalAbility()
        {
            if (this.CooldownTimer > 0)
            {
                return;
            }

            this.CooldownTimer = this.MultiStackCooldown;
            this.RefillCrystal();
        }
    }
}
