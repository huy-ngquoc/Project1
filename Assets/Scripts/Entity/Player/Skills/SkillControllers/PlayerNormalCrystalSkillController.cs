#nullable enable

namespace Game
{
    using UnityEngine;

    public class PlayerNormalCrystalSkillController : PlayerCrystalSkillController
    {
        private Transform? selectedEnemyTransform = null;

        public bool CanMove { get; private set; } = true;

        public float MoveSpeed { get; private set; } = 0;

        public void SetupCrystal(PlayerController playerController, float crystalDuration, float moveSpeed, Transform? selectedEnemyTransform)
        {
            base.SetupCrystal(playerController, crystalDuration);

            this.CanMove = true;
            this.MoveSpeed = moveSpeed;
            this.selectedEnemyTransform = selectedEnemyTransform;
        }

        public override void CrystalFinishing()
        {
            base.CrystalFinishing();

            this.CanMove = false;
        }

        protected override void OnPlayerCrystalSkillControllerUpdate()
        {
            if (this.CanMove && (this.selectedEnemyTransform != null))
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, this.selectedEnemyTransform.position, this.MoveSpeed * Time.deltaTime);

                if (Vector2.Distance(this.transform.position, this.selectedEnemyTransform.position) < 1)
                {
                    this.CrystalFinishing();
                }
            }
        }
    }
}
