using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;

namespace GeekyTool.LoggingManager
{
    /// <summary> 
    /// This is an advanced useage, where you want to intercept the logging messages and devert them somewhere 
    /// besides ETW. 
    /// </summary> 
    sealed class StorageFileEventListener : EventListener
    {
        /// <summary> 
        /// Storage file to be used to write logs 
        /// </summary> 
        private StorageFile storageFile = null;

        /// <summary> 
        /// Name of the current event listener 
        /// </summary> 
        private string name;

        /// <summary> 
        /// The format to be used by logging. 
        /// </summary> 
        private string m_Format = "{0:yyyy-MM-dd HH\\:mm\\:ss\\:ffff}\tType: {1}\tId: {2}\tMessage: '{3}'";

        private SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);

        public StorageFileEventListener(string name)
        {
            this.name = name;

            Debug.WriteLine("StorageFileEventListener for {0} has name {1}", GetHashCode(), name);

            AssignLocalFile();
        }

        private async void AssignLocalFile()
        {
            storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(name.Replace(" ", "_") + ".log",
                                                                                      CreationCollisionOption.OpenIfExists);
        }

        private async void WriteToFile(IEnumerable<string> lines)
        {
            await semaphoreSlim.WaitAsync();

            await Task.Run(async () =>
            {
                try
                {
                    await FileIO.AppendLinesAsync(storageFile, lines);
                }
                catch (Exception ex)
                {
                    // TODO: 
                }
                finally
                {
                    semaphoreSlim.Release();
                }
            });
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (storageFile == null) return;

            var lines = new List<string>();

            var newFormatedLine = string.Format(m_Format, DateTime.Now, eventData.Level, eventData.EventId, eventData.Payload[0]);

            Debug.WriteLine(newFormatedLine);

            lines.Add(newFormatedLine);

            WriteToFile(lines);
        }
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            Debug.WriteLine("OnEventSourceCreated for Listener {0} - {1} got eventSource {2}", GetHashCode(), name, eventSource.Name);
        }
    }
}
