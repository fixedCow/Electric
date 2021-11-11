using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class WorkerFSM : MonoBehaviour
{
    public enum State
    {
        Die,
        Idle,
        Rest,
        Work,
        Picked
    }
    public Animator[] appearanceGroup = new Animator[2];
    public Animator animator;

    public Worker info;
    [ShowInInspector] private State state;

    private void Start()
    {
        // SetWorkerAppearanceByAge();
        SetState(State.Idle);
        TransFSMState(State.Idle);
    }

    private void SetWorkerAppearanceByAge()
    {
        animator = (1 <= info.GetAge() && info.GetAge() <= 3) ? appearanceGroup[0] : appearanceGroup[1];
    }
    public void SetPosition(Vector2 pos) => transform.position = pos;
    public void SetState(State _state) => state = _state;
    private void TransFSMState(State _state)
    {
        string str = "FSM";
        switch (_state)
        {
            case State.Die:
                str += "Die";
                break;
            case State.Idle:
                str += "Idle";
                break;
            case State.Rest:
                str += "Rest";
                break;
            case State.Work:
                str += "Work";
                break;
            case State.Picked:
                str += "Picked";
                break;
            default:
                str += "Idle";
                break;
        }
        StartCoroutine(str);
    }
    private IEnumerator FSMDie()
    {
        // ENTER

        // ACTION
        while (true)
        {
            yield return null;

            // CONDITION
            if (state != State.Die)
            {
                break;
            }
        }
        // EXIT
        TransFSMState(state);
    }
    private IEnumerator FSMIdle()
    {
        // ENTER

        // ACTION
        while (true)
        {
            yield return null;

            // CONDITION
            if (state != State.Idle)
            {
                break;
            }
        }
        // EXIT
        TransFSMState(state);
    }
    private IEnumerator FSMRest()
    {
        // ENTER

        // ACTION
        while (true)
        {
            yield return null;

            // CONDITION
            if (true)
            {
                state = State.Idle;
                break;
            }
        }
        // EXIT
        TransFSMState(state);
    }
    private IEnumerator FSMWork()
    {
        // ENTER
        float _value = 0;
        // ACTION
        while (true)
        {
            yield return null;
            _value += Time.deltaTime;
            if (_value > 1)
            {
                info.AddHealth(-1);
                _value = 0;
            }

            // CONDITION
            if (info.GetHealth() == 0)
            {
                state = State.Die;
                break;
            }
            else if (state != State.Work)
            {
                break;
            }
        }
        // EXIT
        TransFSMState(state);
    }
    private IEnumerator FSMPicked()
    {
        // ENTER

        // ACTION
        while (true)
        {
            yield return null;

            // CONDITION
            if (state != State.Picked)
            {
                break;
            }
        }
        // EXIT
        TransFSMState(state);
    }
}
