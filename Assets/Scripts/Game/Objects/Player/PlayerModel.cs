using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sns.Player
{
    public class PlayerModel
    {
        private float moveSpeed;
        private float jumpPower;
        private Vector3 dir;
        private Rigidbody2D rigid;
        private bool isGround = false;

        public PlayerModel(Rigidbody2D rigid, float moveSpeed, float jumpPower)
        {
            this.rigid = rigid;
            this.moveSpeed = moveSpeed;
            this.jumpPower = jumpPower;
        }

		// NOTE: 명령패턴을 쓸까 말까 고민 중
        public void Move(float amount)
        {
            var velocity = new Vector2(amount * moveSpeed, rigid.velocity.y);
            rigid.velocity = velocity;
            SetDir(amount);
        }

        public void Jump()
        {
            if (!isGround)
                return;

            rigid.velocity += Vector2.up * jumpPower;
            isGround = false;
        }

        public void Landing()
        {
            this.isGround = true;
        }

        private void SetDir(float amount)
        {
            if (amount > 0)
                dir = Vector3.up * 0;
            else if (amount < 0)
                dir = Vector3.up * Mathf.PI * Mathf.Rad2Deg;

            rigid.transform.localEulerAngles = dir;
        }
    }
}