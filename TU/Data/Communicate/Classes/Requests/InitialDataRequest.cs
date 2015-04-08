using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIntegra.TU.Communicate.Classes.Requests
{
    public class InitialDataRequest : TUCommunicator
    {
        public InitialDataRequest(Credentials cred, Engine engine)
            : base(cred, engine)
        {
        }

        protected override string RequestData
        {
            get
            {
                return "password=cea5049c4d475516e27028e25646f2ab&user_id=3215692&timestamp=1428424254&hash=2b3e80f84acd79e7b8811c26992cb098&message=getUserAccount";
            }
        }


        protected override string RequestUrl
        {
            get
            {
                return "http://mobile.tyrantonline.com/api.php?message=getUserAccount&user_id=" + this.Credentials.Login;
            }
        }

    }
}

/*

POST http://mobile.tyrantonline.com/api.php?message=getUserAccount&user_id=3215692&timestamp=1428424254 HTTP/1.1
Host: mobile.tyrantonline.com
Connection: keep-alive
Content-Length: 571
content-type: application/x-www-form-urlencoded
x-unity-version: 4.6.3f1
Referer: http://chat.kongregate.com/gamez/0020/8033/live/tymob-v1_30_3.unity3d?kongregate_game_version=1427393183
User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36
Accept-Encoding: gzip, deflate
Accept-Language: en-US,en;q=0.8

password=cea5049c4d475516e27028e25646f2ab&user_id=3215692&timestamp=1428424254&hash=2b3e80f84acd79e7b8811c26992cb098&message=getUserAccount&unity=4.6.3f1&client_version=45&device_type=Intel(R)+Core(TM)+i7-2600+CPU+%40+3.40GHz+(16329+MB)&os_version=Windows+8.1++(6.3.9600)+64bit&platform=Web&kong_id=14907260&kong_token=677fe2de7f3429f0f4a6215110843963f02f71e52cc28984caf5dcd8a8c50949&kong_name=deathintegra&data_usage=0&os_version=Windows+8.1++(6.3.9600)+64bit&udid=66d05d651fe853733d6b5400d636bda7fca6500f&device_type=Intel(R)+Core(TM)+i7-2600+CPU+%40+3.40GHz+(16329+MB)
 
 */