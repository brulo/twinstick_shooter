using UnityEngine;
using System.Collections;

// this is a simple first test for StateMachine. 
// 3 states are used to repeatively print numbers counting from one to three.
// each print is 3 seconds apart
public class StateMachineTester : MonoBehaviour, IStateMachineImplementor< StateMachineTester.State >
{
    StateMachine<StateMachineTester.State> stateMachine;

    // set up all the possible states
    public enum State
    {
        One,
        Two,
        Three,
        Count,  // State.Count gives you the number of states
        None,   // pass this state to the StateMachine constructor.
    }
    
    float timeToWait = 3f;

    void Start()
    {
        // create an instances and set "this" to be the StateMachine's implementor
        stateMachine = new StateMachine< State >( this, true );
    }

    public void UpdateState( State state )
    {
        switch( state )
        {
            case State.One:
            {
                if( stateMachine.GetCurrentStateTime() > timeToWait )
                {
                    stateMachine.SetNextState( State.Two );
                }
                break;
            }

            case State.Two:
            {
                if( stateMachine.GetCurrentStateTime() > timeToWait )
                {
                    stateMachine.SetNextState( State.Three );
                }
                break;
            }

            case State.Three:
            {
                if( stateMachine.GetCurrentStateTime() > timeToWait )
                {
                    stateMachine.SetNextState( State.One );
                }
                break;
            }
        }
    }
    
    public void InitState( State state )
    {
        switch( state )
        {
            case State.One:
            {
                Debug.Log( "InitState State.One" );
                break;
            }

            case State.Two:
            {
                Debug.Log( "InitState State.Two" );
                break;
            }

            case State.Three:
            {
                Debug.Log( "InitState State.Three" );
                break;
            }
        }
    }

    public void ExitState( State state )
    {
        switch( state )
        {
            case State.One:
            {
                Debug.Log( "ExitState State.One" );
                break;
            }

            case State.Two:
            {
                Debug.Log( "ExitState State.Two" );
                break;
            }

            case State.Three:
            {
                Debug.Log( "ExitState State.Three" );
                break;
            }
        }       
    }

    void Update()
    {
       stateMachine.Update( Time.deltaTime );
    }
}
