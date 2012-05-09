using System;
using System.Web;
using Funq;
using ServiceStack.WebHost.Endpoints;

namespace ServiceStackTest
{
    public class Global : HttpApplication
    {
        //Initialize your application singleton
        protected void Application_Start(object sender, EventArgs e)
        {
            new HelloAppHost().Init();
        }

        private void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        private void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }

        private void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
        }

        private void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }

        #region Nested type: HelloAppHost

        public class HelloAppHost : AppHostBase
        {
            //Tell Service Stack the name of your application and where to find your web services
            public HelloAppHost() : base("Hello Web Services", typeof (HelloService).Assembly)
            {
            }

            public override void Configure(Container container)
            {
                //register user-defined REST-ful urls
                Routes
                    .Add<Hello>("/hello")
                    .Add<Hello>("/hello/{Name}")
                    .Add<Dog>("/dog")
                    .Add<Product>("product/{ProductId}");
            }
        }

        #endregion
    }
}