using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;

    private int finId1 = -1; //id finger for cancel touch event
    private int finId2 = -1;

    public float forwardForce = 2000f;	// Variable that determines the forward force
	public float sidewaysForce = 500f;  // Variable that determines the sideways force

    // We marked this as "Fixed"Update because we
    // are using it to mess with physics.
    void Start()
    {
        Input.multiTouchEnabled = true; //enabled Multitouch
    }

    void FixedUpdate ()
	{
		// Add a forward force
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))	// If the player is pressing the "d" key
		{
			// Add a force to the right
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))  // If the player is pressing the "a" key
		{
			// Add a force to the left
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

        //First check count of touch
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                //For left half screen
                if (touch.phase == TouchPhase.Began && touch.position.x <= Screen.width && finId1 == -1)
                {
                    //Do something: start other function
                    finId1 = touch.fingerId; //store Id finger
                    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

                }
                //For right half screen
                if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width && finId2 == -1)
                {
                    //Do something
                    finId2 = touch.fingerId;
                    rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
                if (touch.phase == TouchPhase.Ended)
                { //correct end of touch
                    if (touch.fingerId == finId1)
                    { //check id finger for end touch
                        finId1 = -1;
                    }
                    else if (touch.fingerId == finId2)
                    {
                        finId2 = -1;
                    }
                }
            }
        }

        if (rb.position.y < -1f)
		{
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
