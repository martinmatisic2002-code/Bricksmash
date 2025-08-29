using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public Rigidbody2D MyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MyRigidBody.velocity = Vector.
    }
}


// Kod za micanje lijevo i desno. Igrac se mora pomaknuti za odreðenu duljinu. Igrac se zalijepi na zid kada dode u kontakt sa njim na ovaj naèin.
// Kada igrac stisne gumb za gore, lik poleti dok ne dode u kontat sa platformom ili granicom.

// je li igrac na horizontalnoj ili vertikalnoj površini > je li igrac stisnuo da se pomakne u stranu relatvno za svoju površinu ili je stisuno da skoæi