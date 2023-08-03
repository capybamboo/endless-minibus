using UnityEngine;

struct Position
{
    public float positionX; 
    public float positionY;
    public float positionZ;
    public float rotationX;
    public float rotationY;
    public float rotationZ;

    public Position(
            float positionX, float positionY, float positionZ,
            float rotationX, float rotationY, float rotationZ
        )
    {
        this.positionX = positionX;
        this.positionY = positionY;
        this.positionZ = positionZ;

        this.rotationX = rotationX;
        this.rotationY = rotationY;
        this.rotationZ = rotationZ;
    }
    public Vector3 getPositionVector()
    {
        return new Vector3(positionX, positionY, positionZ);
    }

    public Quaternion getRotationVector()
    {
        return Quaternion.Euler(rotationX, rotationY, rotationZ);
    }
}

public class CutsceneReturn : MonoBehaviour
{
    private Position _mainMenuPosition = new Position(-0.465f, 2.079f, 2.256f, -8.7f, -67.42f, 1.002f);
    private Position _settingsPosition = new Position(-23.8f, 2.24f, 26.43f, 0f, -90f, 0f);

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (transform.transform.position == _settingsPosition.getPositionVector()) 
            {
                CutsceneManager.Instance.StartCutscene("to_main_menu");

            }
        }
    }
}
