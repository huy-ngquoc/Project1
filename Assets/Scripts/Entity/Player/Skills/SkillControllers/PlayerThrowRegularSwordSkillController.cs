#nullable enable

namespace Game
{
    public sealed class PlayerThrowRegularSwordSkillController : PlayerThrowSwordSkillController
    {
        protected override void OnSwordHitEnemy(EnemyController enemyController)
        {
            this.StuckIntoObject(enemyController.transform);
        }
    }
}
