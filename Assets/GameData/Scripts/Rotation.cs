using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotSpeed;
    public bool collided;
    float initialY;
    Player player;
    private Vector2 xClamp = new Vector2(-60f, 60f);
    private Vector2 zClamp = new Vector2(-60f, 60f);

    void Start()
    {
        initialY = transform.eulerAngles.z;
        player = GetComponent<Player>();
    }
    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetMouseButton(0))
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
            rotX = rotX * Time.deltaTime;
           transform.Rotate(new Vector3(0, rotX, 0), Space.World);

        }

#elif UNITY_ANDROID

		if(Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			    float rotX = touchDeltaPosition.x* rotSpeed/18* Mathf.Deg2Rad;
			    float rotY = touchDeltaPosition.y* rotSpeed/18* Mathf.Deg2Rad;		
        
                rotX = rotX * Time.deltaTime;
                transform.Rotate(new Vector3(0, rotX, 0), Space.World);

			//Vector3 pos = new Vector3 (rotX*Time.deltaTime, 0,rotY*Time.deltaTime);		
			//transform.Rotate(pos, Space.World);			
		}	
#endif

        if (!player.myrotate)
        {
           
             //   transform.eulerAngles = new Vector3(0, ClampAngle(transform.eulerAngles.y, zClamp.x, zClamp.y), 0);
           
        }
            
        //   ClampedAngle(zClamp.x, zClamp.y, this.gameObject);

    }
    public void ClampedAngle(float min, float max, GameObject obj)
    {
        Vector3 charAngle = obj.transform.eulerAngles;
        charAngle.y = (charAngle.y > 180) ? charAngle.y - 360 : charAngle.y;
        charAngle.y = Mathf.Clamp(charAngle.y, min, max);
        gameObject.transform.rotation = Quaternion.Euler(0,charAngle.y,0);
    }
    static float ClampAngle(float angle, float min, float max)
    {
        if (min < 0 && max > 0 && (angle > max || angle < min))
        {
            angle -= 360;
            if (angle > max || angle < min)
            {
                if (Mathf.Abs(Mathf.DeltaAngle(angle, min)) < Mathf.Abs(Mathf.DeltaAngle(angle, max))) return min;
                else return max;
            }
        }
        else if (min > 0 && (angle > max || angle < min))
        {
            angle += 360;
            if (angle > max || angle < min)
            {
                if (Mathf.Abs(Mathf.DeltaAngle(angle, min)) < Mathf.Abs(Mathf.DeltaAngle(angle, max))) return min;
                else return max;
            }
        }

        if (angle < min) return min;
        else if (angle > max) return max;
        else return angle;
    }

}
