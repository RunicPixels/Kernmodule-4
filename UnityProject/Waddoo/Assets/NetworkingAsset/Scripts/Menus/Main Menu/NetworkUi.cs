using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace AXNGames.Networking
{ 
    public class NetworkUi : MonoBehaviour
    {
        public Button joinButton;
        public Button hostButton;
		public Button hostButton2;
        public GameObject hostPanel;
        public Text ipAddressText;
		private string ip;

        public void HostWaddoo()
        {
			string broadcastData = "Waddoo Lobby"; // Lobby that contains waddoo
			CustomNetworkDiscovery.Instance.SetBroadcastData(broadcastData);
            CustomNetworkDiscovery.Instance.InitializeNetworkDiscovery();
            CustomNetworkDiscovery.Instance.StartBroadcasting();
			// start with 4 allowed connections
			NetworkManager.singleton.maxConnections = 5;
            NetworkManager.singleton.StartHost();
        }
		
        public void HostWaddis()
        {
			string broadcastData = "test";
			CustomNetworkDiscovery.Instance.SetBroadcastData(broadcastData);
			// start with 40 allowed connections
            CustomNetworkDiscovery.Instance.InitializeNetworkDiscovery();
            CustomNetworkDiscovery.Instance.StartBroadcasting();
			NetworkManager.singleton.maxConnections = 40;
            NetworkManager.singleton.StartHost();
        }

        public void ReceiveGameBroadcast()
        {
            CustomNetworkDiscovery.Instance.InitializeNetworkDiscovery();
			CustomNetworkDiscovery.Instance.ReceiveBroadcast();
        }

        public void JoinGame()
        {
            NetworkManager.singleton.networkAddress = ip;
            NetworkManager.singleton.StartClient();
            CustomNetworkDiscovery.Instance.StopBroadcasting();
        }

        public void OnReceiveBroadcast(string fromIp, string data)
        {
            hostButton.gameObject.SetActive(false);
			hostButton2.gameObject.SetActive(false);
            joinButton.gameObject.SetActive(false);

            ipAddressText.text = "Kamer 1";
			ip = fromIp;
            hostPanel.SetActive(true);
        }

        void Start()
        {
            CustomNetworkDiscovery.Instance.onServerDetected += OnReceiveBroadcast;
        }

        void OnDestroy()
        {
            CustomNetworkDiscovery.Instance.onServerDetected -= OnReceiveBroadcast;
        }
    }

}
