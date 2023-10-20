using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.Logging
{
    interface ILogger
    {
        /// <summary>
        /// Is debug enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        bool IsDebugEnabled(string logType = null);

        /// <summary>
        /// Is info enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        bool IsInfoEnabled(string logType = null);

        /// <summary>
        /// Is warning enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        bool IsWarnEnabled(string logType = null);

        /// <summary>
        /// Is error enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        bool IsErrorEnabled(string logType = null);

        /// <summary>
        /// Is fatal enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        bool IsFatalEnabled(string logType = null);

        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        void Debug(string message, Exception exception = null);

        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        void Debug(string logType, string message, Exception exception = null);

        /// <summary>
        /// Log info message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        void Info(string message, Exception exception = null);

        /// <summary>
        /// Log info message
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        void Info(string logType, string message, Exception exception = null);

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        void Warn(string message, Exception exception = null);

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        void Warn(string logType, string message, Exception exception = null);

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        void Error(string message, Exception exception = null);

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        void Error(string logType, string message, Exception exception = null);

        /// <summary>
        /// Log fatal message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        void Fatal(string message, Exception exception = null);

        /// <summary>
        /// Log fatal message
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        void Fatal(string logType, string message, Exception exception = null);
    }
}
