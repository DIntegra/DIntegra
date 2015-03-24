using System;
using System.Collections.Generic;
using System.Text;

namespace DIntegra.TU
{
    /// <summary>
    /// различные консатнты
    /// </summary>
    internal static class Constants
    {
        internal static class XMLConvertion
        {
            internal static String RootNodeName { get { return "Credentials"; } }

            internal static String CredNodeName { get { return "Cred"; } }

            public static string NickNameAttributename { get { return "Name"; } }

            public static string LoginAttributename { get { return "Login"; } }

            public static string PasswordAttributename { get { return "Password"; } }
        }
    }
}
