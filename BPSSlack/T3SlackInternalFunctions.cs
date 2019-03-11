using System.IO;
using System.Net.Http;

namespace BPSSlack
{/// <summary>
/// Dies ist die Klasse die alle internen Funktionen enthält die von den User-Funktionen aufgerufen werden.
/// </summary>
    internal static class T3SlackInternalFunctions
    {
        /// <summary>
        /// Funktion um Inhalt für simple "Get"-Anfragen zu erstellen( Channel- und Userliste)
        /// </summary>
        /// <param name="token"></param>
        /// <param name="ammountMessages"></param>
        /// <returns></returns>
        internal  static MultipartFormDataContent CreateMessageContent(string token)
        {            
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(token), "token");            
            return content;
        }

        /// <summary>
        /// Funktion um Inhalte für einfache Textnachricht zu erstellen
        /// </summary>
        /// <param name="token"></param>
        /// <param name="channel"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static MultipartFormDataContent CreateMessageContent(string token, string channel, string message)
        {            
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(token), "token");
            content.Add(new StringContent(channel), "channel");
            content.Add(new StringContent(message), "text");
            content.Add(new StringContent("true"), "as_user");
            return content;
        }

        /// <summary>
        /// Funktion um Inhalte für Nachricht mit Anhang und Text zu erstellen
        /// </summary>
        /// <param name="token"></param>
        /// <param name="channel"></param>
        /// <param name="filepath"></param>
        /// <param name="attachment"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static MultipartFormDataContent CreateMessageContent(string token, string channel, string filepath, FileStream attachment, string message = null)
        {
            var file = new StreamContent(attachment);            
            var content = new MultipartFormDataContent();
            content.Add(file, "file", Path.GetFileName(filepath));
            content.Add(new StringContent(token), "token");
            content.Add(new StringContent(channel), "channels");
            if (message != null)
                content.Add(new StringContent(message), "initial_comment");            
            return content;
        }

        /// <summary>
        /// Funktion um Inhalte für Abfrage von Nachrichten eines Channels zu erstellen
        /// </summary>
        /// <param name="token"></param>
        /// <param name="channel"></param>
        /// <param name="ammountMessages"></param>
        /// <returns></returns>
        internal static MultipartFormDataContent CreateMessageContent(string token, string channel, int ammountMessages)
        {          
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(token), "token");
            content.Add(new StringContent(channel), "channel");
            content.Add(new StringContent(ammountMessages.ToString()), "limit");
            return content;
        }
    }
}