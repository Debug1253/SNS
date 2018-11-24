using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sns.Player
{
    public enum State
    {
        Await,
        Run,
        Jump,
    }

    public class PlayerModel
    {
        private float moveSpeed;
        private float jumpPower;
        private Rigidbody2D rigid;
        public State state;

        public PlayerModel(Rigidbody2D rigid, float moveSpeed, float jumpPower)
        {
            this.rigid = rigid;
            this.moveSpeed = moveSpeed;
            this.jumpPower = jumpPower;
        }

        public void Move(float amount)
        {
            var velocity = new Vector2(amount * moveSpeed, rigid.velocity.y);
            var dir = amount > 0 ? 0 : Mathf.PI * Mathf.Rad2Deg;
            rigid.velocity = velocity;
            rigid.transform.localEulerAngles = Vector3.up * dir;
        }

        public void Jump()
        {
            // FIXME: 무한점프 방지
            rigid.velocity += Vector2.up * jumpPower;
        }

        public void SetState(State state)
        {
            this.state = state;
        }
    }
}