using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    private VisualElement frame;
    private Label timer;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        var ui_document = GetComponent<UIDocument>();
        var rootVisualElement = ui_document.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame");
        timer = frame.Q<Label>("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timer.text = Mathf.Ceil(time).ToString();
    }
}
