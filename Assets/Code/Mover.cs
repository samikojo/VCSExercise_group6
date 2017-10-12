using UnityEngine;

namespace TAMK.VCSExample
{
	public class Mover : MonoBehaviour
	{
		[SerializeField]
		private float _speed = 5;
		[SerializeField]
		private float _rotationSpeed = 30;
		[SerializeField]
		private float _jumpForce = 100;

		private bool _isGrounded = true;
		private Rigidbody _rigidbody;

		void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		void Update()
		{
			var horizontal = Input.GetAxis("Horizontal");
			var vertical = Input.GetAxis("Vertical");
			var turn = Input.GetAxis("Turn");
			bool jump = Input.GetButtonDown("Jump");

			Move(new Vector3(horizontal, 0, vertical));
			Turn(turn);
			if (jump)
			{
				Jump();
			}
		}

		private void Jump()
		{
			if (_isGrounded)
			{
				_rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
			}
		}
		
		private void Move(Vector3 input)
		{
			Vector3 movementVector = input * _speed;
			transform.Translate(movementVector * Time.deltaTime);
		}
		
		private void Turn(float turn)
		{
			transform.Rotate(Vector3.up * _rotationSpeed * turn * Time.deltaTime);
		}
		
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
			{
				_isGrounded = true;
			}
		}

		private void OnCollisionExit(Collision collision)
		{
			if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
			{
				_isGrounded = false;
			}
		}
	}
}
