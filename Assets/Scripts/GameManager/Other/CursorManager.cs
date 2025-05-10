using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Vector2 hotSpot = new Vector2(0, 0);

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    private void Update()
    {
        
    }
}
