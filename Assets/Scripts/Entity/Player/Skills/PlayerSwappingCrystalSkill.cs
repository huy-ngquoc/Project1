#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerSwappingCrystalSkill : PlayerCrystalSkill
    {
        private GameObject? currentCrystal = null;

        protected override void CastLogic()
        {
            this.PlayerController.InputHandler.CancelCrystalAction();

            if (this.currentCrystal == null)
            {
                this.CreateCrystal();
                return;
            }

            if (!this.currentCrystal.TryGetComponent<PlayerSwappingCrystalSkillController>(out var crystalSkillController))
            {
                Object.Destroy(this.currentCrystal);
                this.currentCrystal = null;
                return;
            }

            if (crystalSkillController.IsFinishing)
            {
                this.currentCrystal = null;
                return;
            }

            (this.currentCrystal.transform.position, this.PlayerController.transform.position) = (this.PlayerController.transform.position, this.currentCrystal.transform.position);
            crystalSkillController.CrystalFinishing();
            this.currentCrystal = null;
        }

        private void CreateCrystal()
        {
            this.currentCrystal = Object.Instantiate(this.CrystalPrefab, this.transform.position, Quaternion.identity);
            if (!this.currentCrystal.TryGetComponent<PlayerSwappingCrystalSkillController>(out var crystalSkillController))
            {
                Object.Destroy(this.currentCrystal);
                this.currentCrystal = null;
                return;
            }

            crystalSkillController.SetupCrystal(this.PlayerController, this.CrystalDuration);
        }
    }
}
