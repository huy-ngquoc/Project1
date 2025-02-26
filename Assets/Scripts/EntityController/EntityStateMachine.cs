#nullable enable

namespace Game;

partial class EntityController
{
    protected abstract partial class EntityStateMachine
    {
        private readonly EntityController entityController;

        private EntityState? currentState = null;
        private EntityState? stateToChangeTo = null;

        protected EntityStateMachine(EntityController entityController)
        {
            this.entityController = entityController;
        }

        public void UpdateState()
        {
            this.currentState?.Update();

            while (this.stateToChangeTo != null)
            {
                this.currentState?.Exit();
                this.currentState = this.stateToChangeTo;
                this.stateToChangeTo = null;
                this.currentState.Enter();

                // TODO: should we update state right after changing?
                // this.currentState.Update();
            }
        }

        public void AnimationFinishTrigger() => this.currentState?.AnimationFinishTrigger();

        protected void ChangeState(EntityState newState)
        {
            this.stateToChangeTo = newState;
        }

        protected bool HasStateToChangeTo()
        {
            return this.stateToChangeTo != null;
        }

        protected void CancelChangingState()
        {
            this.stateToChangeTo = null;
        }
    }
}