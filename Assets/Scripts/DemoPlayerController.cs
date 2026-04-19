using UnityEngine;
using Utilities;

public class DemoPlayerController : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0) {
			rb.linearVelocity += (Input.GetAxis("Horizontal") * transform.right.V2() * Time.deltaTime * 15);
		}
        if(Input.GetAxis("Vertical") != 0) {
			rb.linearVelocity += (Input.GetAxis("Vertical") * transform.up.V2() * Time.deltaTime * 15);
		}
    }
}
