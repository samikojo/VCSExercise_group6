using UnityEngine;

namespace TAMK.VCSExample
{
	public class Mover : MonoBehaviour
	{
		[SerializeField]
		private float _speed = 5;
		[SerializeField]
		private float _rotationSpeed = 30;

		void Update()
		{
			var horizontal = Input.GetAxis("Horizontal");
			var vertical = Input.GetAxis("Vertical");
			var turn = Input.GetAxis("Turn");

			Move(new Vector3(horizontal, 0, vertical));
			Turn(turn);
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
	}
}
