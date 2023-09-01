using KIM;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace KIM
{
    public class NonAttackableFish : Fish
    {
        //public enum State { State_Idle = 0, State_Move, State_Hit, State_Escape, State_Die }
        //StateMachine<State, NonAttackableFish> stateMachine;

        private void Awake()
        {
            StartCoroutine(MoveRoutine());
            //stateMachine = new StateMachine<State, NonAttackableFish>(this);
            //stateMachine.AddState(State.State_Idle, new IdleState(this, stateMachine));

        }

        //#region FishState
        //private abstract class NonAttackableFishState : StateBase<State, NonAttackableFish>
        //{
        //    protected GameObject gameObject => owner.gameObject;
        //    protected FishData data => owner.data;
        //    protected int curHp => owner.curHp;
        //    protected float curLength => owner.curLength;
        //    protected float curWeight => owner.curWeight;

        //    protected NonAttackableFishState(NonAttackableFish owner, StateMachine<State, NonAttackableFish> stateMachine) : base(owner, stateMachine)
        //    {

        //    }
        //}

        //private class IdleState : NonAttackableFishState
        //{
        //    public IdleState(NonAttackableFish owner, StateMachine<State, NonAttackableFish> stateMachine) : base(owner, stateMachine)
        //    {

        //    }

        //    public override void Enter()
        //    {

        //    }

        //    public override void Exit()
        //    {

        //    }

        //    public override void Setup()
        //    {

        //    }

        //    public override void Transition()
        //    {

        //    }

        //    public override void Update()
        //    {

        //    }
        //}
        //#endregion

        private void Update()
        {
            transform.Translate(moveDir.normalized * Time.deltaTime);

        }

        IEnumerator MoveRoutine()
        {
            while (true)
            {
                moveDir = GetRandVector();
                Debug.Log(moveDir);
                //Move();

                yield return new WaitForSeconds(Random.Range(3f,5f));
            }
        }

        // Boids �˰��� ����غ���
        // ���� : ���� �Ÿ� �� ��ü���� ��� ��ġ�� �̵�
        // �и� : ���� �Ÿ� �� �ٸ� ��ü�� ��ġ�°��� ����
        // ���� : ���� �Ÿ� �� ��ä���� ��� �������� �����δ�
        // ���� ���ؾ���(������Ʈ �����Ÿ� ���� ���� �����ؼ� ȸ�Ǳ⵿�ϵ���)
        protected void Move()
        {
            
            // ���� �ִ��� ����
            if (WallDetect())
            {
                Ray ray = new Ray();
                ray.origin = this.transform.position;
                ray.direction = this.transform.position;
                RaycastHit hit;
                // ǥ������ �����ɽ�Ʈ�� ���� RaycastHit�� ���Ѵ�
                Physics.Raycast(ray, out hit, data.WallRecognitionRange, 1 << 14);

                // �� ǥ���� �븻���Ϳ� ��������� �����ʳ븻���͸� �����Ͽ�
                // ���� ����� ������, ������ �������� ����
                moveDir = Vector3.Dot(hit.normal, transform.right) >= 0 ?
                    transform.right / 2 : -transform.right / 2;

                // �� ǥ���� �븻���Ϳ� ��������� ���� ���͸� �����Ͽ�
                // ���� ����� ��, ������ �Ʒ��� ����
                moveDir += Vector3.Dot(hit.normal, transform.up) >= 0 ?
                    transform.up / 2 : -transform.up / 2;

                moveDir = moveDir.normalized;
            }

        }
        protected void Die()
        {
        }

        //protected override void Move()
        //{
        //    base.Move();
        //}
    }
}