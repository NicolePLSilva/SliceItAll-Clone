using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpinningState : PlayerBaseState
{
    private bool requestSpin;

    private float CanStickTimer = .35f;

    public KnifeSpinningState(PlayerStateMachine stateMachine): base(stateMachine){}

    public override void Enter()
    {
        _stateMachine.InputReader.TouchEvent += OnSpin;
    }

    public override void InProgress(float deltaTime)
    {
        HitHandlerCheck();
        CalculateSpin();
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
        requestSpin = true;

    }

    private void CalculateSpin()
    {
        if(requestSpin)
        {

            Vector3 force = new Vector3( 0f, _stateMachine.HorizontalMovementForce , _stateMachine.VerticalMovementForce ); 
            float yForce = Mathf.Sqrt(_stateMachine.VerticalMovementForce * -2 * Physics.gravity.y );
            float zForce = Mathf.Sqrt(_stateMachine.HorizontalMovementForce * -2 * Physics.gravity.y );
            _stateMachine.Rigidbody.velocity = Vector3.zero; 
            _stateMachine.Rigidbody.AddForce(new Vector3(0, yForce,zForce), ForceMode.Impulse);
            
            _stateMachine.KnifeScript.HandlerCoroutines(_stateMachine.DelayGravityTime, _stateMachine.RotationDuration);


            requestSpin = false;
        }
      
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
