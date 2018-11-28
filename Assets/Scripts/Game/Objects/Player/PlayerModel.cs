using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sns.Player
{
    public class PlayerModel
    {
        private float moveSpeed;
        private float jumpPower;
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
            var dir = amount > 0 ? 0 : Mathf.PI * Mathf.Rad2Deg;
            rigid.transform.localPosition += Vector3.right * amount * moveSpeed * Time.deltaTime;
            rigid.transform.localEulerAngles = Vector3.up * dir;
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
    }
}