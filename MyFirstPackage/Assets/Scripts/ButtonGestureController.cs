using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonGestureController : GestureController {

    public Canvas canvas;
    private Button[] buttons;
    public static int opcionMenu;

    // Use this for initialization
    void Start()
    {
        base.StartConstructor();
        buttons = canvas.GetComponentsInChildren<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        base.VerifyOnUpdate();
        foreach (Button button in buttons)
        {

            float px = button.GetComponent<RectTransform>().localPosition.x;
            float py = button.GetComponent<RectTransform>().localPosition.y;
            float pWidth = button.GetComponent<RectTransform>().rect.width;
            float pHeight = button.GetComponent<RectTransform>().rect.height;

            //					Debug.Log ("Button " + cont);
            //					Debug.Log ("px " + px);
            //					Debug.Log ("py " + py);
            //					Debug.Log ("pWidth " + pWidth);
            //					Debug.Log ("pHeight " + pHeight);
            //					Debug.Log ("Mouse x: " + this.HandCursor.transform.localPosition.x);
            //					Debug.Log ("Mouse y: " + this.HandCursor.transform.localPosition.y);
            //					cont++;
            if (this.transform.localPosition.x >= (px - pWidth / 2) &&
               this.transform.localPosition.x <= (px + pWidth / 2) &&
               this.transform.localPosition.y >= (py - pHeight / 2) &&
               this.transform.localPosition.y <= (py + pHeight / 2))

                if (closesHand)
                {
                    if (button == buttons[0])//Con Vidas
                    {

                        opcionMenu = 0;
                        if (VariablesGlobales.volverAlMenu)
                        {
                            SceneManager.LoadScene("Menu");
                            VariablesGlobales.volverAlMenu = false;
                            return;
                        }
                        SceneManager.LoadScene("DemoScene");


                    }
                    else if (button == buttons[1]) //Scores
                    {
                        opcionMenu = 2;
                        SceneManager.LoadScene("Score");
                        VariablesGlobales.volverAlMenu = true;
                    }
                }
        }
    }
}
