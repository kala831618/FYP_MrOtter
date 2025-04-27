using System.IO.Ports;
using UnityEngine;

public class UltrasonicListener : MonoBehaviour {
    SerialPort stream;
    public string port = "/dev/cu.usbserial-120";
    public int baudRate = 9600;
    
    public float sensor1Distance;
    public float sensor2Distance;
    
    void Start() {
        stream = new SerialPort(port, baudRate);
        stream.ReadTimeout = 50;
        stream.Open();
    }
    
    void Update() {
        if (stream.IsOpen) {
            try {
                string data = stream.ReadLine();
                
                // Parse distance data
                if(data.StartsWith("S1:") && data.Contains("S2:")) {
                    string[] parts = data.Split(',');
                    sensor1Distance = float.Parse(parts[0].Substring(3));
                    sensor2Distance = float.Parse(parts[1].Substring(3));
                    
                    Debug.Log($"Sensor 1: {sensor1Distance} cm, Sensor 2: {sensor2Distance} cm");
                }
                
                // Check for play command
                if(data.Contains("PLAY")) {
                    StartGame();
                }
                
            } catch (System.Exception ex) {
                Debug.LogWarning(ex.Message);
            }
        }
    }
    
    void StartGame() {
        Debug.Log("Both sensors triggered - starting game!");
        // Your game start logic here
    }
    
    void OnApplicationQuit() {
        if (stream != null && stream.IsOpen)
            stream.Close();
    }
}