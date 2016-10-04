using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HemisphereControllerTable2 : MonoBehaviour
{
    public GameObject Hemisphere;
    public GameObject LeftCamera;
    public GameObject RightCamera;
    public Renderer rend;
    private GlobalVariables vars;
    private Texture[] textures;

    public bool isLeft;
    public bool isRight;
    private float LeftBound;
    private float RightBound;
    private bool play;
    private float initialPositionX;
    private float mx;
    private float bx;
    private int index = 0;

    void Start()
    {
        // Imports global parameters
        vars = Hemisphere.GetComponent<GlobalVariables>();

        LeftBound = -(vars.RigLength / 2.0f * 2.54f) / 100.0f;
        RightBound = (vars.RigLength / 2.0f * 2.54f) / 100.0f;

        // Contstrains the rig length to 66% of original length for smoothness (this is not physically accurate, use sparingly) 
        if (vars.ConstrainToSmooth)
        {
            LeftBound = -(vars.RigLength / 2.0f * 2.54f) / 150.0f;
            RightBound = (vars.RigLength / 2.0f * 2.54f) / 150.0f;
        }

        // Importing the images as textures
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        textures = Resources.LoadAll<Texture>("Table2");
        play = true;

        // Sets initial image to center one
        rend.material.SetTexture("_EmissionMap", textures[Mathf.FloorToInt(textures.Length - 1)]);

        // For linear interpolation
        mx = (textures.Length - 1) / (RightBound - LeftBound);
        bx = -mx * LeftBound;

        // Centers and rotates the hemisphere to face the camera, fixes it a z distance away
        transform.position = new Vector3(LeftCamera.transform.position.x, LeftCamera.transform.position.y, LeftCamera.transform.position.z + vars.zDistance);
        transform.eulerAngles = new Vector3(0, LeftCamera.transform.eulerAngles.y, 180);
        
        initialPositionX = LeftCamera.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            play = !play;

        if (isLeft && play)
        {
            // Performs interpolation to calculate index
            index = Mathf.FloorToInt(mx * (LeftCamera.transform.position.x - initialPositionX) + bx) - vars.LeftEyeOffset;
            if (index >= 0 && index + vars.LeftEyeOffset + vars.RightEyeOffset <= textures.Length - 1)
            {
                rend.material.SetTexture("_EmissionMap", textures[index]);
            }
        }

        if (isRight && play)
        {
            // Performs interpolation to calculate index
            index = Mathf.FloorToInt(mx * (RightCamera.transform.position.x - initialPositionX) + bx) + vars.RightEyeOffset;
            if (index - vars.RightEyeOffset - vars.LeftEyeOffset >= 0 && index <= textures.Length - 1)
            {
                rend.material.SetTexture("_EmissionMap", textures[index]);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
