using System;

public enum StateName
{
	Moving = 0,
	Jumping = 1,
	Atacking = 2
}

abstract class State
{
	public abstract int getStateName();

	public abstract void EnterState();
	public abstract void EnterState(State fromState);
	public abstract void ExitState(State toState);
}
