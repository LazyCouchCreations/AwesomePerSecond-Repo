using UnityEngine;

public class _Cursor : MonoBehaviour {

	private Vector2 worldMousePos;
	
	private void Update()
	{
		Cursor.visible = false;
		worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3(worldMousePos.x, worldMousePos.y);
	}


}
