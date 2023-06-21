using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_Instance;//���ϼ� ����
    public static Managers Instance { get { Init(); return s_Instance; } }

    InputManager _input = new InputManager();
    public static InputManager Input { get { return Instance._input; } }

    void Start()
    {
        Init();
    }


    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_Instance = go.GetComponent<Managers>();
        }


    }
}
