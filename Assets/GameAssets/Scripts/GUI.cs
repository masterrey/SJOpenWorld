using UnityEngine;

public class GUI : MonoBehaviour
{
    public void Awake()
    {
        Cursor.visible = false;
    }
  
    public void Update()
    {
        TestScreenCursorLock();
    }

    private void TestScreenCursorLock()
    {
        if (!Screen.lockCursor && Input.GetMouseButtonDown(0))
        {
            Screen.lockCursor = true;
        }
    }
}