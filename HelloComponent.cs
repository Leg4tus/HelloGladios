using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HelloGladios
{
    public class HelloComponent : MonoBehaviour
    {
       void Awake()
        {
            SceneManager.activeSceneChanged += SceneChanged;
            MultiplayerModMessageManager.RegisterServerMessageHandler(new HelloNetworkMessage().GetMessageId(), OnHelloWorldServerNetworkMessage);
            MultiplayerModMessageManager.RegisterClientMessageHandler(new HelloNetworkMessage().GetMessageId(), OnHelloWorldClientNetworkMessage);
        }

        void OnDestroy()
        {
            SceneManager.activeSceneChanged -= SceneChanged;
        }


        void Update()
        {
            
            if(Input.GetKeyDown("1"))
            {
                Debug.Log("1 pressed");
                SendHelloToServer(1);//send hello just to server
            }
            if (Input.GetKeyDown("2"))
            {
                Debug.Log("2 pressed");
                SendHelloToServer(2);//send hello to everyone
            }
        }


        private void SceneChanged(Scene arg0, Scene arg1)
        {
            HelloClass.DisplayMessage();
        }

       
        void SendHelloToServer(int helloValue)
        {
            MultiplayerModMessageManager.SendToServer(new HelloNetworkMessage { value = helloValue });
        }

        void SendHelloToAll(int helloValue)
        {
            MultiplayerModMessageManager.SendToAllClients(new HelloNetworkMessage { value = helloValue });
        }


        private void OnHelloWorldServerNetworkMessage(byte[] arg1, Mirror.NetworkConnection connection)
        {

            HelloNetworkMessage message = MultiplayerModMessageManager.Deserialize<HelloNetworkMessage>(arg1);

            if (message.value == 2)
            {
                //relay the message to clients
                SendHelloToAll(message.value);
            }
            else
            {
                //display only on server
                GeneralManager.DisplaySystemMessageInChat($"Hello server {message.value}");
            }
        }
        private void OnHelloWorldClientNetworkMessage(byte[] arg1)
        {
            HelloNetworkMessage message = MultiplayerModMessageManager.Deserialize<HelloNetworkMessage>(arg1);
            
            GeneralManager.DisplaySystemMessageInChat($"Hello all {message.value}");
            
        }
    }
}
