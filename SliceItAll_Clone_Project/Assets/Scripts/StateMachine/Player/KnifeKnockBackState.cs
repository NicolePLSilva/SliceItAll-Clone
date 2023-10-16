using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeKnockBackState : PlayerBaseState
{
    public KnifeKnockBackState(PlayerStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
        _stateMachine.InputReader.TouchEvent += OnTap;
        KnockBack();
    }

    public override void InProgress(float deltaTime)
    {

    }

    public override void Exit()
    {
        _stateMachine.InputReader.TouchEvent -= OnTap;
    }

    public void OnTap()
    {
        _stateMachine.Handler.Hit = false;
        _stateMachine.SwitchState(new KnifeSpinningState(_stateMachine));
    }

    public void KnockBack()
    {
        _stateMachine.Rigidbody.velocity = Vector3.zero;
        _stateMachine.Rigidbody.AddForce((Vector3.back + Vector3.up) * (_stateMachine.Force), ForceMode.Impulse );
        _stateMachine.KnifeScript.HandlerGravityCoroutine(0.2f);        

    }
}
