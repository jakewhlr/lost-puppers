using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour {
    private GameObject cursor;
    private GameObject[] menu_items;
    private int current_position;

	void Start () {
        menu_items = GameObject.FindGameObjectsWithTag("MenuButton");

        if( menu_items != null ) {
            current_position = 1; // this is kind of arbitrary, should probably improve
            cursor = Instantiate(Resources.Load("Menu Cursor")) as GameObject;
        } else {
            Debug.Log("No menu buttons found");
            this.enabled = false;
        }
    }
	
	void Update () {
        cursor.GetComponent<Transform>().position = GetButtonPosition();
        CheckInput();
	}

    void CheckInput() {
        if( Input.GetKeyDown(KeyCode.UpArrow) ) {
            MoveCursor(-1);
        } else if( Input.GetKeyDown(KeyCode.DownArrow) ) {
            MoveCursor(1);
        } else if( Input.GetKeyDown(KeyCode.Return) ) {
            ExecuteButton(menu_items[current_position]);
        }
    }

    void ExecuteButton(GameObject button) {
        if( button.name == "Start Button" ) {
            SceneManager.LoadScene("Level 1");
        } else if (button.name == "Option Button") {
            Debug.Log("Executing option button");
        } else if (button.name == "Exit Button") {
            ExitGame();
        } else {
            Debug.Log("Unknown button");
        }
    }

    void StartGame() {

    }

    void GotoOptions() {

    }

    void ExitGame() {
        Application.Quit();
    }

    Vector2 GetButtonPosition() {
        float y_position = menu_items[current_position].GetComponent<Transform>().position.y;
        return new Vector2(0.675f, y_position);
    }

    void MoveCursor(int magnitude) {
        current_position = ((current_position + magnitude) % menu_items.Length + menu_items.Length) % menu_items.Length;
    }
}
