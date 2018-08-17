using UnityEngine;

public class _Cursor : MonoBehaviour {

	public Texture2D cursorTexture;

	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
	}
}
