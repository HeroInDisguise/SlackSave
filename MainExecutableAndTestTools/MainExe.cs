using System;
using System.Threading.Tasks;
using BPSSlack;
using BPSSlack.JsonSlackObjects;
using System.IO;
using TestTools;

namespace MainExecutableAndTestTools
{
    class MainExe
    {
        static void Main(string[] args)
        {
            var T3SlackAPI = new T3SlackUserFunctions("xoxp-281094624947-438069752295-566089497859-108e9cf287941bbfb6292dc4db35c158");
            try
            {
                Task<ContainerSlackUserList> task1 = T3SlackAPI.GetUserListFromSlack();
                task1.Wait();

                var result = task1.Result;
                for (int i = 0; i < result.members.Count; i++)
                {
                    string name = result.members[i].name;
                    string id = result.members[i].id;
                    string real_name = result.members[i].real_name;

                    Console.WriteLine(i);
                    Console.WriteLine(real_name);
                    Console.WriteLine(name);
                    Console.WriteLine(id);
                }

                Task<ContainerSlackConversationList> task2 = T3SlackAPI.GetConversationListFromSlack();
                task2.Wait();

                var result2 = task2.Result;
                for (int i = 0; i < result2.Ims.Count; i++)
                {
                    string user = result2.Ims[i].user;
                    string id = result2.Ims[i].id;

                    Console.WriteLine(i);
                    Console.WriteLine(user);
                    Console.WriteLine(id);
                }

                Task task3 = T3SlackAPI.SendMessage(channel: result.members[18].id, message: "Getestet seist Du");
                task3.Wait();

                FileStream file = FileReader.ReadFile(@"C:\Users\f.held\Desktop\Held-Docs\codecode.jpg");

                Task task4 = T3SlackAPI.SendMessage(channel: result.members[18].id, message: "Getestet seist Du", filepath: @"C:\Users\f.held\Desktop\Held-Docs\codecode.jpg", attachment: file);
                task4.Wait();

                Task<ContainerSlackIncomingMessage> task5 = T3SlackAPI.GetMessagesFromChannel(channel: result2.Ims[12].id, ammountMessagesToGet: 5);
                task5.Wait();

                var result3 = task5.Result;

                for (int i = 0; i < result3.messages.Count; i++)
                {
                    string user = result3.messages[i].user;
                    string text = result3.messages[i].text;
                    Console.WriteLine("Message " + (i + 1));
                    Console.WriteLine(user);
                    Console.WriteLine(text);

                    if (result3.messages[i].attachments != null)
                    {
                        string attachments = result3.messages[i].attachments[0].thumb_url;
                        string attachmentsText = result3.messages[i].attachments[0].text;
                        Console.WriteLine(attachmentsText);
                        Console.WriteLine(attachments);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
    }    
}