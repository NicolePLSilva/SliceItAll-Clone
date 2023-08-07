using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpinningState : PlayerBaseState
{
    private float CanStickTimer = .35f;
    public KnifeSpinningState(PlayerStateMachine stateMachine): base(stateMachine){}

    public override void Enter()
    {
        _stateMachine.InputReader.TouchEvent += OnSpin;
    }

    public override void InProgress(float deltaTime)
    {
        HitHandlerCheck();
        CanStickTimer -= Time.deltaTime;
        if(CanStickTimer > 0) { return; } 
        HitPlatformCheck();
    }

    public override void Exit()
    {
        _stateMachine.InputReader.TouchEvent -= OnSpin;
    }

    public void OnSpin()
    {
        _stateMachine.Rigidbody.isKinematic = false;
        CanStickTimer = .35f;
        CalculateSpin();

    }

    private void CalculateSpin()
    {
        Vector3 movement = new(0f, _stateMachine.VerticalMovementForce,
                _stateMachine.HorizontalMovementForce);
        float force = _stateMachine.Force;
        float Torque = _stateMachine.Torque;
        _stateMachine.Rigidbody.AddForce(movement * force, ForceMode.Impulse);
        _stateMachine.Rigidbody.AddRelativeTorque(Torque, 0f, 0f, ForceMode.Impulse);
        _stateMachine.KnifeScript.CanSpin = true;
        _stateMachine.Rigidbody.AddForce(Vector3.down * force, ForceMode.Acceleration);
    }

    private void HitPlatformCheck()
    {
        if(!_stateMachine.KnifeScript.HitPlatform) { return; }
        _stateMachine.SwitchState(new KnifeStuckState(_stateMachine));
    }

     private void HitHandlerCheck()
    {
        if(!_stateMachine.Handler.Hit) { return; }
        _stateMachine.SwitchState(new KnifeKnockBackState(_stateMachine));
    }

}
