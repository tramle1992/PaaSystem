using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Common.Infrastructure.Logging
{
    class Log4NetLogger : ILogger
    {
        private const string MainLogName = "Main";



        /// <summary>
        /// Constructor (Configure Logger)
        /// </summary>
        public Log4NetLogger()
        {
            XmlConfigurator.Configure();
        }



        /// <summary>
        /// Is debug enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        bool ILogger.IsDebugEnabled(string logType)
        {
            return LogManager.GetLogger(logType).IsDebugEnabled;
        }

        /// <summary>
        /// Is info enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        bool ILogger.IsInfoEnabled(string logType)
        {
            return LogManager.GetLogger(logType).IsInfoEnabled;
        }

        /// <summary>
        /// Is warning enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        bool ILogger.IsWarnEnabled(string logType)
        {
            return LogManager.GetLogger(logType).IsWarnEnabled;
        }

        /// <summary>
        /// Is error enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        bool ILogger.IsErrorEnabled(string logType)
        {
            return LogManager.GetLogger(logType).IsErrorEnabled;
        }

        /// <summary>
        /// Is fatal enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        bool ILogger.IsFatalEnabled(string logType)
        {
            return LogManager.GetLogger(logType).IsFatalEnabled;
        }

        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Debug(string message, Exception exception = null)
        {
            LogManager.GetLogger("Main").Debug(message, exception);
        }

        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="logType">log type or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Debug(string logType, string message, Exception exception = null)
        {
            LogManager.GetLogger(logType).Debug(message, exception);
        }

        /// <summary>
        /// Log info message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Info(string message, Exception exception = null)
        {
            LogManager.GetLogger(MainLogName).Info(message, exception);
        }

        /// <summary>
        /// Log info message
        /// </summary>
        /// <param name="logType">log type or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Info(string logType, string message, Exception exception = null)
        {
            LogManager.GetLogger(logType).Info(message, exception);
        }

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Warn(string message, Exception exception = null)
        {
            LogManager.GetLogger(MainLogName).Warn(message, exception);
        }

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="logType">log type or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Warn(string logType, string message, Exception exception = null)
        {
            LogManager.GetLogger(logType).Warn(message, exception);
        }

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Error(string message, Exception exception = null)
        {
            LogManager.GetLogger(MainLogName).Error(message, exception);
        }

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="logType">log type or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Error(string logType, string message, Exception exception = null)
        {
            LogManager.GetLogger(logType).Error(message, exception);
        }

        /// <summary>
        /// Log fatal message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Fatal(string message, Exception exception = null)
        {
            LogManager.GetLogger(MainLogName).Fatal(message, exception);
        }

        /// <summary>
        /// Log fatal message
        /// </summary>
        /// <param name="logType">log type or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Fatal(string logType, string message, Exception exception = null)
        {
            LogManager.GetLogger(logType).Fatal(message, exception);
        }
    }
}
