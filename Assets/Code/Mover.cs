using UnityEngine;

namespace TAMK.VCSExample
{
	public class Mover : MonoBehaviour
	{
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
			bool jump = Input.GetButtonDown("Jump");

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
