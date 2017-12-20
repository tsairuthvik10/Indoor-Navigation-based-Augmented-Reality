using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class camgyro : MonoBehaviour {
	public GameObject webPlane;
	public GameObject camParent;
	public GameObject left;
	public GameObject up;
	public GameObject right;
	public GameObject down;
	public GameObject hiddenl;
	public GameObject hiddenu;
	public GameObject hiddenr;
	public GameObject hiddend;
	public List<String> path;

//	public Text output_text;
	// Use this for initialization
	void Start () {
		left = GameObject.FindGameObjectWithTag("lkc");
		up = GameObject.FindGameObjectWithTag("ukc");
		right = GameObject.FindGameObjectWithTag("rkc");
		down = GameObject.FindGameObjectWithTag("dkc");
		hiddenr = GameObject.FindGameObjectWithTag("hiddenRight");
		hiddenl = GameObject.FindGameObjectWithTag("hiddenLeft");
		hiddenu = GameObject.FindGameObjectWithTag("hiddenUp");
		hiddend = GameObject.FindGameObjectWithTag("hiddenDown");
		

		
		camParent = new GameObject("CamParent");
		camParent.transform.position = this.transform.position;
		this.transform.parent = camParent.transform;
		camParent.transform.Rotate(Vector3.down, 90);
		
		Input.gyro.enabled = true;
		
		WebCamTexture webcamTexture = new WebCamTexture();
		webPlane.GetComponent<MeshRenderer>().material.mainTexture = webcamTexture;
		webcamTexture.Play();
		
		
		
		left.SetActive(false);
		up.SetActive(false);
		right.SetActive(false);
		down.SetActive(false);

	//	output_text.text= "HII";
	//	output_text.text = "changescene";
	//	output_text.text = QRReader.changescene.sourceID;
		Graph g = new Graph();
		g.add_vertex("Apple", new Dictionary<String, int>() {{"Banana", 5}, {"Donut", 5}});
		g.add_vertex("Banana", new Dictionary<String, int>() {{"Apple", 5}, {"Cranberry", 5}});
		g.add_vertex("Cranberry", new Dictionary<String, int>() {{"Banana", 5}, {"Eggplant", 5}});
		g.add_vertex("Donut", new Dictionary<String, int>() {{"Apple",5},{"Fudge", 5}});
		g.add_vertex("Eggplant", new Dictionary<String, int>() {{"Cranberry",5},{"Horanberry", 5}});
		g.add_vertex("Fudge", new Dictionary<String, int>() {{"Donut", 5}, {"Guava", 5}});
		g.add_vertex("Guava", new Dictionary<String, int>() {{"Horanberry", 5}, {"Fudge", 5}});
		g.add_vertex("Horanberry", new Dictionary<String, int>() {{"Eggplant", 5}, {"Guava", 5}});

		path = g.shortest_path(changescene.sourceID, Outputobject.destinationID);
		path.Reverse();
		path.Insert(0, changescene.sourceID);
	//	output_text.text = "path calculated";
	//	output_text.text = Outputobject.destinationID;
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion rotFix = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
		this.transform.localRotation = rotFix;
		left.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
		right.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
		down.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
		up.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
		
		
			
		if ( !(changescene.sourceID.Equals(Outputobject.destinationID)) ){
			
				if(path[0] == "Apple" && path[1] == "Banana"){
				
					
					right.SetActive(true);
					right.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
					
				}
				
				if(path[0] == "Banana" && path[1] == "Cranberry"){
					//right.SetActive(false);
				right.SetActive(true);
					
					right.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
					
					
				}
				
			if(path[0] == "Cranberry" && path[1] == "Eggplant"){
					//up.SetActive(false);
					up.SetActive(true);
					
					up.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));		
					
				}
				
			if(path[0] == "Eggplant" && path[1] == "Horanberry"){
					down.SetActive(false);
					up.SetActive(true);
					
					up.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
					
					
				}
			if(path[0] == "Horanberry" && path[1] == "Guava"){
					
					left.SetActive(true);
					left.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
				}
			if(path[0] == "Guava" && path[1] == "Fudge"){
					
					left.SetActive(true);
					left.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
				}
			if(path[0] == "Fudge" && path[1] == "Donut"){
					
					down.SetActive(true);
					down.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
				}
			if(path[0] == "Donut" && path[1] == "Apple"){
					
					down.SetActive(true);
					down.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
				}
			if(path[0] == "Apple" && path[1] == "Donut"){
					
					up.SetActive(true);
					up.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
				}
			if(path[0] == "Donut" && path[1] == "Fudge"){
					
					up.SetActive(true);
					up.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
				}
			if(path[0] == "Fudge" && path[1] == "Guava"){
					
					right.SetActive(true);
					right.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
				}
			if(path[0] == "Guava" && path[1] == "Horanberry"){
					
					right.SetActive(true);
					right.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
				}
			if(path[0] == "Horanberry" && path[1] == "Eggplant"){
					
					down.SetActive(true);
					down.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
				}
			if(path[0] == "Eggplant" && path[1] == "Cranberry"){
					
					down.SetActive(true);
					down.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
				}
			if(path[0] == "Cranberry" && path[1] == "Banana"){
					
					left.SetActive(true);
					left.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
				}
			if(path[0] == "Banana" && path[1] == "Apple"){
					
					left.SetActive(true);
					left.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 6.0f));
				}
				right.transform.LookAt(hiddenr.transform);
				left.transform.LookAt(hiddenl.transform);
				up.transform.LookAt(hiddenu.transform);
				down.transform.LookAt(hiddend.transform);
				//output_text.text="running";
				//up.transform.Rotate(0,0,90);
				//down.transform.Rotate(0,0,-90);
				up.transform.Rotate(0,90,60);
				down.transform.Rotate(0,90,-120);
				left.transform.Rotate(0,0,-20);
				right.transform.Rotate(0,0,-20);
				//i++;	
			}
			else {
				SceneManager.LoadScene("end");
				changescene.i = -1;
			}
			/*right.transform.LookAt(hiddenr.transform);
			left.transform.LookAt(hiddenl.transform);
			up.transform.LookAt(hiddenu.transform);
			down.transform.LookAt(hiddend.transform);
			output_text.text="running";
			up.transform.Rotate(0,90,90);
			down.transform.Rotate(0,90,-90);
			left.transform.Rotate(0,0,-10);
			right.transform.Rotate(0,0,-10);
		*/
	}

}
class Graph
    {
        Dictionary<String, Dictionary<String, int>> vertices = new Dictionary<String, Dictionary<String, int>>();

        public void add_vertex(String name, Dictionary<String, int> edges)
        {
            vertices[name] = edges;
        }

        public List<String> shortest_path(String start, String finish)
        {
            var previous = new Dictionary<String, String>();
            var distances = new Dictionary<String, int>();
            var nodes = new List<String>();

            List<String> path = null;

            foreach (var vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }

                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == finish)
                {
                    path = new List<String>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in vertices[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            return path;
        }
    }

