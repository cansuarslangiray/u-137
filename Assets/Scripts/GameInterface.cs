using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInterface : MonoBehaviour
{
    private Air _air;
    private Earth _earth;
    private Fire _fire;
    private Water _water;
    
    // Start is called before the first frame update
    void Start()
    {
        _air = GetComponent<Air>();
        _earth = GetComponent<Earth>();
        _fire = GetComponent<Fire>();
        _water = GetComponent<Water>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUIAccordingToForm()
    {
        
    }
    
}
