using UnityEngine;
using UnityEngine.Assertions;
using System;

// a monobehaviour that wants to use a state machine should implement this interface
public interface IStateMachineImplementor<StateType>
{
    void UpdateState( StateType state );
    void InitState( StateType state );
    void ExitState( StateType state );
}

// a monobehaviour that wants to use a StateMachine should also have a member instance of it
public class StateMachine<StateType> where StateType : IComparable
{
    IStateMachineImplementor<StateType> implementor = null;
    StateType currentState = default( StateType );
    StateType nextState = default( StateType );
    StateType previousState;
    bool goToNextState = false;
    bool implementorIsUpdating = false;
    float currentStateTime = 0f;
    
    public float GetCurrentStateTime() 
    {
        // if the implementor isnt updating, then currentStateTime is unreliable.
        Assert.IsTrue( implementorIsUpdating );
        return currentStateTime; 
    }
    
    public StateMachine( IStateMachineImplementor<StateType> implementor, bool implementorIsUpdating )
    {
        this.implementor = implementor;
        this.implementorIsUpdating = implementorIsUpdating;
    }

    // will switch to this new state on next update,
    // unless implementor is not updating or you want to change state immediately
    public void SetNextState( StateType state, bool changeStateImmediately = false )
    {
        nextState = state;
        goToNextState = true;
        
        if( !implementorIsUpdating || changeStateImmediately )
        {
            Update( 0f );
        }
    }
    
    // StateMachine is not a monobehaviour, so this does not get called automatically. 
    // make sure you are calling this in the implementors Update() if you set 
    // immplementorIsUpdating to true. 
    public void Update( float deltaTime )
    {
        if( implementor == null )
            return;

        if( goToNextState )
        {
            goToNextState = false;
            
            if( currentState.CompareTo( nextState ) != 0 )  // if states are not equal
            {
                currentStateTime = 0f;
                implementor.ExitState( currentState );

                previousState = currentState;
                currentState = nextState; 
                
                implementor.InitState( currentState );
            }
            else
            {
                Debug.LogWarning( 
                    "[ StateMachine ] Attempted to go to nextState, but currentState was already nextState!" );
            }
        }
        else
        {
            currentStateTime += deltaTime;
            implementor.UpdateState( currentState );
        }
    }

}
