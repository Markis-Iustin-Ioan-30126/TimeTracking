using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackingClient
{
    class AuthenticationWrapper
    {
        public string name { get; set; }
        public string password { get; set; }

        public AuthenticationWrapper(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
    }
}
