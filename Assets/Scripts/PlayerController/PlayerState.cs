#nullable enable

namespace Game;

using Input = UnityEngine.Input;
using Time = UnityEngine.Time;

partial class PlayerController
{
    partial class PlayerStateMachine
    {
        private abstract class PlayerState
        {
            protected PlayerState(PlayerStateMachine stateMachine, string animationBoolName)
            {
                this.StateMachine = stateMachine;
                this.AnimationBoolName = animationBoolName;
            }

            public static sbyte InputY
            {
                get
                {
                    var inputY = Input.GetAxisRaw("Vertical");
                    if (inputY > 0)
                    {
                        return 1;
                    }
                    else if (inputY < 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            public static sbyte InputX
            {
                get
                {
                    var inputX = Input.GetAxisRaw("Horizontal");
                    if (inputX > 0)
                    {
                        return 1;
                    }
                    else if (inputX < 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            public string AnimationBoolName { get; }

            public float StateTimer { get; protected set; } = 0;

            public bool TriggerCalled { get; private set; } = false;

            protected PlayerStateMachine StateMachine { get; }

            protected PlayerController Player => this.StateMachine.player;

            public void Enter()
            {
                this.TriggerCalled = false;
                if (this.Player.Animator != null)
                {
                    this.Player.Animator.SetBool(this.AnimationBoolName, true);
                }

                this.OnEnter();
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

                if (this.Player.Animator != null)
                {
                    this.Player.Animator.SetFloat("VelocityY", this.Player.Rigidbody2D.UnityAccessVal(r => r.linearVelocityY, 0));
                }

                this.OnUpdate();
            }

            public void Exit()
            {
                if (this.Player.Animator != null)
                {
                    this.Player.Animator.SetBool(this.AnimationBoolName, false);
                }

                this.OnExit();
            }

            public void AnimationFinishTrigger()
            {
                this.TriggerCalled = true;
            }

            protected virtual void OnEnter()
            {
                // Leave this method blank
                // The derived classes can decide if they override this method
            }

            protected virtual void OnUpdate()
            {
                // Leave this method blank
                // The derived classes can decide if they override this method
            }

            protected virtual void OnExit()
            {
                // Leave this method blank
                // The derived classes can decide if they override this method
            }
        }
    }
}
