#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerThrowPeirceSwordSkillController : PlayerThrowSwordSkillController
    {
        [field: Header("Pierce info")]

        public int PierceAmount { get; private set; } = 0;

        public void SetupPierce(int pierceAmount)
        {
            this.PierceAmount = pierceAmount;
        }

        protected override void OnSwordHitEnemy(EnemyController enemyController)
        {
            if (this.PierceAmount > 0)
            {
                --this.PierceAmount;
                return;
            }

            this.StuckIntoObject(enemyController.transform);
        }
    }
}
