using UnityEngine;

namespace TAMK.VCSExample
{
	public class Mover : MonoBehaviour
	{
		[SerializeField]
		private float _speed = 5;

		void Update()
		{
			var horizontal = Input.GetAxis("Horizontal");
			var vertical = Input.GetAxis("Vertical");

			Move(new Vector3(horizontal, 0, vertical));
		}

		private void Move(Vector3 input)
		{
			Vector3 movementVector = input * _speed;
			transform.Translate(movementVector * Time.deltaTime);
		}
	}
}
