using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSceneController : MonoBehaviour
{
    public Player player;
    public GameCamera gameCamera;
    public Text mineralsText;
    public Text messageText;

    public GameObject station1;
    public GameObject station2;

    public GameObject rock;

    // Start is called before the first frame update
    void Start()
    {
        messageText.text = "";
        StartCoroutine(TutorialRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        mineralsText.text = "Minerals: " + player.Minerals;
    }

    private IEnumerator TutorialRoutine()
    {
        messageText.text = "We need to activate the space stations.";

        yield return new WaitForSeconds(3.0f);
        gameCamera.target = station1;
        yield return new WaitForSeconds(2.0f);
        gameCamera.target = station2;
        yield return new WaitForSeconds(2.0f);

        messageText.text = "Get minerals from rocks!";

        gameCamera.target = rock;
        yield return new WaitForSeconds(3.0f);

        gameCamera.target = player.gameObject;
        messageText.text = "";

    }
}
