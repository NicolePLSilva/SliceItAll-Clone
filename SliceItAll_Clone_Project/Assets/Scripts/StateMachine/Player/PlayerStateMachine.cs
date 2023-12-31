using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader{ get; private set;}
    [field: SerializeField] public Rigidbody Rigidbody{ get; private set;}
    [field: SerializeField] public Transform MyTransform{ get; private set;}
    [field: SerializeField] public float Force{ get; private set;}
    [field: SerializeField] public float Torque{ get; private set;}
    [field: SerializeField] public float HorizontalMovementForce{ get; private set;}
    [field: SerializeField] public float VerticalMovementForce{ get; private set;}

    [field: SerializeField] public float DelayGravityTime {get; private set;} = 0.5f;
    [field: SerializeField] public float RotationDuration {get; private set;} = 1.1f;

    [field: SerializeField] public KnifeScript KnifeScript{ get; private set;}
    [field: SerializeField] public HandlerScript Handler{ get; private set;}

    void Start()
    {
        SwitchState(new KnifeStuckState(this));
    }

    

}
