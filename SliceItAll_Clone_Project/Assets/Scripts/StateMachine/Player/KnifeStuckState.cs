using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeStuckState : PlayerBaseState
{
    public KnifeStuckState(PlayerStateMachine stateMachine): base(stateMachine){}

    public override void Enter()
    {
        _stateMachine.Rigidbody.isKinematic = true;
        _stateMachine.InputReader.TouchEvent += OnTap;
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
        _stateMachine.KnifeScript.HitPlatform = false;
        _stateMachine.SwitchState(new KnifeSpinningState(_stateMachine));
    }
}
