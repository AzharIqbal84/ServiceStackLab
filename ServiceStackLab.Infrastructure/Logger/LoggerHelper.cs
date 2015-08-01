using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ServiceStackLab.Infrastructure.Logger
{
   public  class LoggerHelper
    {
        private static readonly Logger Log = new Logger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly JavaScriptSerializer JsonSerializer = new JavaScriptSerializer();


        public static void LogInitMethod(string path, string verb)
        {
            Log.Info(string.Format("Path: {0} - Verb: {1} started", path, verb));
        }
        public static void LogEndMethod(string path, string verb)
        {
            Log.Info(string.Format("Path: {0} - Verb: {1} Finished", path, verb));
        }

        # region   Info  

        public static void Info(string method, string message)
        {
            Log.Info(string.Format("Method: {0} - Message: {1}", method, message));
        }

        public static void Info(string method, Exception exception)
        {
            Log.Info(method, exception);
        }

        public static void Infor(string method, Exception exception, object request)
        {
            Log.Info(string.Format("Method {0} - request: {1}", method, JsonSerializer.Serialize(request)), exception);
        }
        #endregion 

        # region   Debug

        public static void Debug(string method, string message)
        {
            Log.Debug(string.Format("Method: {0} - Message: {1}", method, message));
        }

        public static void Debug(string method, Exception exception)
        {
            Log.Debug(method, exception);
        }

        public static void Debug(string method, Exception exception, object request)
        {
            Log.Debug(string.Format("Method {0} - request: {1}", method, JsonSerializer.Serialize(request)), exception);
        }
        #endregion 

        # region   Error

        public static void Error(string method, string message)
        {
            Log.Error(string.Format("Method: {0} - Message: {1}", method, message));
        }

        public static void Error(string method, Exception exception)
        {
            Log.Error(method, exception);
        }

        public static void Error(string method, Exception exception, object request)
        {
            Log.Error(string.Format("Method {0} - request: {1}", method, JsonSerializer.Serialize(request)), exception);
        }
        #endregion

        #region   Warn

        public static void Warn(string method, string message)
        {
            Log.Warn(string.Format("Method: {0} - Message: {1}", method, message));
        }

        public static void Warn(string method, Exception exception)
        {
            Log.Warn(method, exception);
        }

        public static void Warn(string method, Exception exception, object request)
        {
            Log.Warn(string.Format("Method {0} - request: {1}", method, JsonSerializer.Serialize(request)), exception);
        }
        #endregion 

        # region   Fatal

        public static void Fatal(string method, string message)
        {
            Log.Fatal(string.Format("Method: {0} - Message: {1}", method, message));
        }

        public static void Fatal(string method, Exception exception)
        {
            Log.Fatal(method, exception);
        }

        public static void Fatal(string method, Exception exception, object request)
        {
            Log.Fatal(string.Format("Method {0} - request: {1}", method, JsonSerializer.Serialize(request)), exception);
        }
        #endregion

        public static string FormatException(Exception e)
        {
            try
            {
                var stackTrace = new StackTrace();
                var stackFrames = stackTrace.GetFrames();
                var method = "Method name not available";

                if (stackFrames != null)
                {
                    var callingFrame = stackFrames[1];
                    method = callingFrame.GetMethod().Name;
                }
                return string.Format(
                    "Error in method: {0} :{1}",
                    method,
                    e.Message);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
