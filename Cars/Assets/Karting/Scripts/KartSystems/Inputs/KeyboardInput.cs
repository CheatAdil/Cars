using UnityEngine;

namespace KartGame.KartSystems {

    public class KeyboardInput : BaseInput
    {
        public string TurnInputName = "Horizontal";
        public string AccelerateButtonName = "Accelerate";
        public string BrakeButtonName = "Brake";



        [SerializeField] private bool FakeInput;
        [SerializeField] private bool forward;
        [SerializeField] private float turn;
        [SerializeField] private bool brake;
        [SerializeField] private bool AI;
        [SerializeField] private Transform sensor_L;
        [SerializeField] private Transform sensor_R;
        [SerializeField] private Transform[] target;
        [SerializeField] private int target_id;
        [SerializeField] private bool Looping;

        private Transform self;
        private void Start()
        {
            self = GetComponent<Transform>();
            if (self == null) AI = false;
            if (AI) 
            {
                forward = true;
            }

            for (int i = 0; i < target.Length; i++) 
            {
                if (i != target_id) 
                {
                    target[i].GetComponent<BoxCollider>().enabled = false;
                }
            }

        }

        public override InputData GenerateInput() {
            if (AI)
            {
                return new InputData
                {
                    Accelerate = true,
                    Brake = false,
                    TurnInput = CalculateTurn()
                };
            }
            else if (FakeInput) 
            {
                return new InputData
                {
                    Accelerate = forward,
                    Brake = brake,
                    TurnInput = turn
                };
            }
            return new InputData
            {
                Accelerate = Input.GetButton(AccelerateButtonName),
                Brake = Input.GetButton(BrakeButtonName),
                TurnInput = Input.GetAxis("Horizontal")
            };
        }
        private float CalculateTurn() 
        {
            Vector3 targ = Vector3.Scale(target[target_id].position , new Vector3(1, 0, 1));
            float d1 = Vector3.Distance(sensor_L.position, targ);
            float d2 = Vector3.Distance(sensor_R.position, targ);
            float dif = d1 - d2;
            if (dif > 0.1) 
            {
                if (dif > 0.2)
                {
                    return 1;
                }
                else return 0.5f;
            }
            else if (dif < -0.1) 
            {
                if (dif < -0.2) 
                {
                    return -1;
                }
                else return -0.5f;
            }
            return 0;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Target") 
            {
                NextTarget();
            }
        }
        private void NextTarget() 
        {
            target[target_id].GetComponent<BoxCollider>().enabled = false;
            target_id += 1;
            if (target_id > target.Length - 1) 
            {
                if (Looping) target_id = 0;
                else Destroy(this.gameObject);
            }
            target[target_id].GetComponent<BoxCollider>().enabled = true;
        }
    }
}
