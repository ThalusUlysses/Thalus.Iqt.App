using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Thalus.Contracts
{
    public interface IProvideCodedResult
    {
        /// <summary>
        ///  Gets the code of the result according to <see cref="StatusCode"/>
        /// </summary>
        int Code { get; }

        /// <summary>
        /// Get s the success value True=Successful, otherwise false
        /// </summary>
        bool Success { get; }
    }

    public interface ITraceEntry
    {
        int ThreadId { get; }

        TraceCategories Category { get; }

        IText Text { get; }

        object Data { get; }

        DateTime Utc { get; }

        DateTime Local { get; }

        int Line { get; }

        string Scope { get; }

        string FileName { get; }

        string CallerMember { get; }

        string[] Attributes { get; }
    }

    public interface ITraceWriterConfiguration
    {
        string TraceWriterId { get; }
        string DotNetName { get; }

        IDictionary<string, object> Parameters { get; }

        string[] TraceForAttributes { get; }
        TraceCategories Categories { get; }

    }

    public interface ITraceWriter
    {
        string TraceWriterId { get; }
        void SetConfiguration(ITraceWriterConfiguration config);
        ITraceWriterConfiguration GetConfiguration();
        void Trace(ITraceEntry e);
    }

    [Flags]
    public enum TraceCategories { Fatal = 0, Error = 1, Warning = 2, Info = 4, Debug = 8 }

    public interface ITrace
    {
        void Error(string invariant, string localized = null, string locale = null, object data = null, string[] attributes = null, [CallerMemberName]string caller = null, [CallerFilePath]string file = null, [CallerLineNumber] int line = -1);
        void Warning(string invariant, string localized = null, string locale = null, object data = null, string[] attributes = null, [CallerMemberName]string caller = null, [CallerFilePath]string file = null, [CallerLineNumber] int line = -1);
        void Info(string invariant, string localized = null, string locale = null, object data = null, string[] attributes = null, [CallerMemberName]string caller = null, [CallerFilePath]string file = null, [CallerLineNumber] int line = -1);
        void Debug(string invariant, string localized = null, string locale = null, object data = null, string[] attributes = null, [CallerMemberName]string caller = null, [CallerFilePath]string file = null, [CallerLineNumber] int line = -1);
        void Fatal(string invariant, string localized = null, string locale = null, object data = null, string[] attributes = null, [CallerMemberName]string caller = null, [CallerFilePath]string file = null, [CallerLineNumber] int line = -1);
        void TraceEntry(ITraceEntry dto);
        void TraceEntry(ITraceEntry[] dto);
    }

    public interface ITraceService
    {
        ITrace Get(string scope = "default", params string[] attributes);
    }

    /// <summary>
    /// Publishes the public members of <see cref="IConfigurationService"/> such like
    /// <see cref="Get(string, Action{IConfiguration})"/>. It exposes the configuration service
    /// capabilites such like getting / setting configuration
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets the configuration by id and subscribes to changes
        /// </summary>
        /// <param name="id">Pass the id you like to get the configuration for</param>
        /// <param name="callback">Pass the update configuration callback, to ge notified for changes</param>
        /// <returns>Returns a result of type <see cref="IResult"/> that indicates if the execution was successful</returns>
        IResult Get(string id, Action<IConfiguration> callback = null);

        /// <summary>
        /// Sets the configuration by its id. Please note that this action my case another configuration update.
        /// </summary>
        /// <param name="id">Pass the id you like to get the configuration for</param>
        /// <param name="data">Pass the configuration data you like to store >/param>
        /// <returns>Returns a result of type<see cref="IResult"/> that indicates if the execution was successful</returns>        
        IResult Set(string id, object data);

        /// <summary>
        /// Unsubscribes aconfiguration change delegate
        /// </summary>
        /// <param name="id">Pass the id you like to unsubscribe for configuration updates</param>
        /// <returns>Returns a result of type<see cref="IResult"/> that indicates if the execution was successful</returns>   
        IResult Unsubscribe(string id);
    }

    public interface IConfiguration
    {
        string Id { get; }

        object Item { get; }
    }

    public class ConfigurationDTO : IConfiguration
    {
        public string Id { get; set; }

        public object Item { get; set; }
    }

    public interface IServiceLocator
    {
        TType Get<TType>(params object[] items) where TType : class;
    }
}


