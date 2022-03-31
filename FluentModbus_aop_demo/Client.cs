using System;

namespace FluentModbus_aop_demo
{
    public class Client
    {
        public string ReadCoils(string message)
        {
            /**
             * send request like
             1byte	1byte	2bytes		2bytes		2bytes
             01	    06	    00	01	    00	32	    A8	3D
             * receive response like
             1byte	1byte	2bytes		2bytes		2bytes
             01	    06	    00	01	    00	32	    A8	3D
             */

            var requestMessage = message;
            requestMessage = RequestHandler(requestMessage);
            RequestEventHandler.Invoke(this, requestMessage);
            // todo: send request and read response
            var responseMessage = requestMessage;
            requestMessage = ResponseHandler(responseMessage);
            ResponseEventHandler.Invoke(this, responseMessage);

            return responseMessage;
        }

        public EventHandler<string> RequestEventHandler { get; set; }
        public Func<string, string> RequestHandler { get; set; }
        public EventHandler<string> ResponseEventHandler { get; set; }
        public Func<string, string> ResponseHandler { get; set; }
    }
}