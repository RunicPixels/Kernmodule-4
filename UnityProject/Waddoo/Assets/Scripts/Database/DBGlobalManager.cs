using UnityEngine;

namespace Database
{
    public class DBGlobalManager : MonoBehaviour
    {
        public static DBGlobalManager Instance { private set; get; }
    
        public DBUserManager UserManager { private set; get; }
        public DBConnection Connection { private set; get; }


        // Start is called before the first frame update
        private void Awake()
        {
            CreateSingleton();
            SetupConnections();    
        }
    
        private void CreateSingleton()
        {
            if(Instance != null) Destroy(GetComponent<DBGlobalManager>());
            Instance = this;
        }
    
        private void SetupConnections()
        {
            UserManager = GetComponent<DBUserManager>();
            Connection = GetComponent<DBConnection>();
        }


    }
}
