using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Vector3 OpenPosition;
    private bool open;

    public IEnumerator OpenUp()
    {
        if (!open)                                                                                  // If true, then door will open in new transform position in the vector 3 axis.
        { 
            while (transform.position != OpenPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, OpenPosition, 0.25f);

                if (Vector3.Distance(transform.position, OpenPosition) <= 0.25f)
                {
                    transform.position = OpenPosition;
                    open = true;
                }
                yield return null;
            }
            if (OpenPosition != null) {                                                          // Will wait for 5 seconds before destroying door object.
                yield return new WaitForSeconds(.1f);
                Destroy(gameObject);
                }
            }
              
         }
     }

    



