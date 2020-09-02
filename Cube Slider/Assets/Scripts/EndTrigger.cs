using UnityEngine;

public class EndTrigger : MonoBehaviour {

	public GameManager gameManager;
    public GameObject Spedometar;

    void OnTriggerEnter ()
	{
		gameManager.CompleteLevel();
        Spedometar.SetActive(false);
    }

}
