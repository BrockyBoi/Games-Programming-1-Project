using UnityEngine;
using System.Collections;

public class BuyBuildingCanvas : MonoBehaviour
{
    Plot selectedPlot;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPlot(Plot p)
    {
        selectedPlot = p;
    }

    public void build(string s)
    {
        selectedPlot.build(s);
    }
}
