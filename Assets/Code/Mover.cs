using UnityEngine;

namespace TAMK.VCSExample
{
	public class Mover : MonoBehaviour
	{
		[SerializeField]
		private float _rotationSpeed = 30;

		void Update()
		{
			var turn = Input.GetAxis("Turn");

			Turn(turn);
		}

		private void Turn(float turn)
		{
			transform.Rotate(Vector3.up * _rotationSpeed * turn * Time.deltaTime);
		}
	}
}
