#nullable enable

namespace Game;

using UnityEngine;

partial class EntityController
{
    partial class EntityStateMachine
    {
        protected abstract class EntityState
        {
            protected EntityState(EntityStateMachine entityStateMachine, string animationBoolName)
            {
                this.EntityStateMachine = entityStateMachine;
                this.AnimationBoolName = animationBoolName;
            }

            public string AnimationBoolName { get; }

            public float StateTimer { get; protected set; } = 0;

            public bool TriggerCalled { get; protected set; } = false;

            protected EntityStateMachine EntityStateMachine { get; }

            protected EntityController EntityController => this.EntityStateMachine.entityController;

            public void Enter()
            {
                this.TriggerCalled = false;

                var animator = this.EntityController.Animator;
                if (animator != null)
                {
                    animator.SetBool(this.AnimationBoolName, true);
                }

                this.OnEntityStateEnter();
            }

            public void Update()
            {
                if (this.StateTimer > Time.deltaTime)
                {
                    this.StateTimer -= Time.deltaTime;
                }
                else
                {
                    this.StateTimer = 0;
                }

                this.OnEntityStateUpdate();
            }

            public void Exit()
            {
                var animator = this.EntityController.Animator;
                if (animator != null)
                {
                    animator.SetBool(this.AnimationBoolName, false);
                }

                this.OnEntityStateExit();
            }

            public void AnimationFinishTrigger() => this.TriggerCalled = true;

            protected virtual void OnEntityStateEnter()
            {
                // Leave this method blank
                // The derived classes can decide if they override this method
            }

            protected virtual void OnEntityStateUpdate()
            {
                // Leave this method blank
                // The derived classes can decide if they override this method
            }

            protected virtual void OnEntityStateExit()
            {
                // Leave this method blank
                // The derived classes can decide if they override this method
            }
        }
    }
}