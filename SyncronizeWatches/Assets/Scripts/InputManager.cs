using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    [System.Serializable]
    public class ButtonData
    {
        public string name;
        public KeyCode key;
        public bool press;
        public bool down;
        public bool release;
        public bool up;
        public bool tap;
        public float timeDown;
    }

    public float tapTime = 0.2f;
    public float inputDelay;

    [SerializeField]
    private List<ButtonData> buttonData = new List<ButtonData>();

    public Dictionary<string, ButtonData> buttons = new Dictionary<string, ButtonData>();

    // Use this for initialization
    void Start()
    {

    }

    public void Init()
    {

        for (int i = 0; i < buttonData.Count; i++)
        {
            if (!buttons.ContainsKey(buttonData[i].name))
            {
                buttons.Add(buttonData[i].name, buttonData[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateButtonData();
    }

    public void UpdateButtonData()
    {
        foreach (ButtonData btn in buttonData)
        {
            if (btn.down)
            {
                btn.timeDown += Time.deltaTime;
            }


            if (btn.release)
            {
                btn.release = false;
            }

            if (btn.tap)
            {
                btn.tap = false;
            }

            if (Input.GetKeyUp(btn.key))
            {
                btn.down = false;
                btn.release = true;
                btn.up = true;
                if (btn.down && btn.timeDown <= tapTime)
                {
                    btn.tap = true;
                }

                btn.timeDown = 0;
            }

            if (btn.press)
            {
                btn.press = false;
            }

            if (Input.GetKeyDown(btn.key))
            {
                if (!btn.down)
                {
                    btn.up = false;
                    btn.release = false;
                    btn.down = true;
                    btn.press = true;
                    btn.timeDown = 0;
                }
            }
        }
    }
}
