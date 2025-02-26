#nullable enable

namespace Game;

using UnityEngine;

partial class PlayerController
{
    partial class PlayerStateMachine
    {
        private abstract class PlayerGroundedState : PlayerState
        {
            protected PlayerGroundedState(PlayerStateMachine stateMachine, string animationBoolName)
                : base(stateMachine, animationBoolName)
            {
            }

            protected sealed override void OnPlayerStateEnter()
            {
                this.OnGroundedEnter();
            }

            protected virtual void OnGroundedEnter()
            {
                // Leave this method blank
                // The derived classes can decide if they override this method
            }

            protected sealed override void OnPlayerStateUpdate()
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    this.PlayerStateMachine?.ChangeState(this.PlayerStateMachine.jumpState);
                    return;
                }

                this.OnGroundedUpdate();
            }

            protected virtual void OnGroundedUpdate()
            {
                // Leave this method blank
                // The derived classes can decide if they override this method
            }

            protected sealed override void OnPlayerStateExit()
            {
                this.OnGroundedExit();
            }

            protected virtual void OnGroundedExit()
            {
                // Leave this method blank
                // The derived classes can decide if they override this method
            }
        }
    }
}
