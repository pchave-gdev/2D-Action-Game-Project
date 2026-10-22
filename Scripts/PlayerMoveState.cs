using Godot;
using System;

class PlayerMoveState : State
{
    public override int getStateName()
    {
        return (int)StateName.Moving;
    }

    public override void EnterState()
    {
        
    }

    public override void EnterState(State fromState)
    {
        GD.Print("It was in " + fromState.getStateName().ToString() + " now is in " + stateName.ToString());
    }

    public override void ExitState(State toState)
    {
        GD.Print("Go to " + toState.getStateName().ToString());
    }
}
