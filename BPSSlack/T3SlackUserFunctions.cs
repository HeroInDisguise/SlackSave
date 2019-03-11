using BPSSlack.JsonSlackObjects;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BPSSlack
{/// <summary>
/// Dies ist die Klasse die alle fünf Funktionen enthält die vom User genutzt werden können.
/// </summary>
    public class T3SlackUserFunctions
    {
        private string _token = null;

        public T3SlackUserFunctions(string token)
        {
            _token = token;
        }
        /// <summary>
        /// Nachricht nur mit Text oder mit Anhang senden. Für den erfolgreichen Upload eines Anhangs ist ein Dateiname zwingend notwendig, 
        /// deshalb wird der Dateipfad benötigt - um dort den Dateinamen auszulesen.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="message"></param>
        /// <param name="filepath"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public async Task<bool> SendMessage(string channel, string message = null, string filepath = null, FileStream attachment = null)
        {
            if (filepath == null)
            {                
                var content = T3SlackInternalFunctions.CreateMessageContent(token: _token, channel: channel, message: message);
                using (var Client = new HttpClient())
                {
                    var uri = "https://slack.com/api/chat.postMessage";

                    var response = await Client.PostAsync(requestUri: uri, content: content);
                    var isValid = response.IsSuccessStatusCode;
                    return isValid;
                }      
            }
            else
            {               
                var content = T3SlackInternalFunctions.CreateMessageContent(token: _token, channel: channel, message: message, filepath: filepath, attachment: attachment);
                using (var Client = new HttpClient())
                {
                    var uri = "	https://slack.com/api/files.upload";

                    var response = await Client.PostAsync(requestUri: uri, content: content);
                    var isValid = response.IsSuccessStatusCode;
                    return isValid;
                }
            }
        }
        /// <summary>
        /// Funktion um die UserListe abzurufen
        /// </summary>
        /// <returns></returns>
        public async Task<ContainerSlackUserList> GetUserListFromSlack()
        {
            string uri = "https://slack.com/api/users.list";

            var content = T3SlackInternalFunctions.CreateMessageContent(token: _token);
            using (var Client = new HttpClient())
            {
                var response = await Client.PostAsync(requestUri: uri, content: content);
                var isValid = response.IsSuccessStatusCode;
                string answerContent = await response.Content.ReadAsStringAsync();
                var fileResponse = JsonConvert.DeserializeObject<ContainerSlackUserList>(value: answerContent);
                return fileResponse;
            }
        }
        /// <summary>
        /// Funktion um Channelliste abzurufen
        /// </summary>
        /// <returns></returns>
        public async Task<ContainerSlackChannelList> GetChannelListFromSlack()
        {
            string uri = "https://slack.com/api/conversations.list";

            var content = T3SlackInternalFunctions.CreateMessageContent(token: _token);
            using (var Client = new HttpClient())
            {
                var response = await Client.PostAsync(requestUri: uri, content: content);
                var isValid = response.IsSuccessStatusCode;
                string answerContent = await response.Content.ReadAsStringAsync();
                var fileResponse = JsonConvert.DeserializeObject<ContainerSlackChannelList>(value: answerContent);
                return fileResponse;
            }
        }
        /// <summary>
        /// Funktion um Nachrichten von einem Channel/Unterhaltung abzurufen
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="ammountMessagesToGet"></param>
        /// <returns></returns>
        public async Task<ContainerSlackIncomingMessage> GetMessagesFromChannel(string channel, int ammountMessagesToGet)
        {
            string uri = "https://slack.com/api/conversations.history";

            var content = T3SlackInternalFunctions.CreateMessageContent(token: _token, channel: channel, ammountMessages: ammountMessagesToGet);
            using (var Client = new HttpClient())
            {
                var response = await Client.PostAsync(requestUri: uri, content: content);
                var isValid = response.IsSuccessStatusCode;
                string answerContent = await response.Content.ReadAsStringAsync();
                var fileResponse = JsonConvert.DeserializeObject<ContainerSlackIncomingMessage>(value: answerContent);
                return fileResponse;
            }
        }
        /// <summary>
        /// Funktion zum abrufen von Unterhaltungen zwischen Usern - nicht zu verwechseln mit den Usern selbst! Jede Unterhaltung hat eine eigene ID!
        /// </summary>
        /// <returns></returns>
        public async Task<ContainerSlackConversationList> GetConversationListFromSlack()
        {
            string uri = "https://slack.com/api/im.list";

            var content = T3SlackInternalFunctions.CreateMessageContent(token: _token);
            using (var Client = new HttpClient())
            {
                var response = await Client.PostAsync(requestUri: uri, content: content);
                var isValid = response.IsSuccessStatusCode;
                string answerContent = await response.Content.ReadAsStringAsync();
                var fileResponse = JsonConvert.DeserializeObject<ContainerSlackConversationList>(value: answerContent);
                return fileResponse;
            }
        }
    }
}