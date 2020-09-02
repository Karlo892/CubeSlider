using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{

    public PlayerMovement movement;
    public Text speedTxt;
    public double rtSpeed;

    // Update is called once per frame
    void Update()
    {
        rtSpeed = movement.rb.velocity.magnitude * 3.6;
        string finalSpeed = rtSpeed.ToString("0.0");
        speedTxt.text = finalSpeed + " KM/H";
    }
}