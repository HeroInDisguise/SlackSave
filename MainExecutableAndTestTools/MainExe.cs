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
            var T3SlackAPI = new T3SlackUserFunctions("xoxp-281094624947-438069752295-573475946977-22eee5081f8f4ffb21dc582fad44e15e");

            var UserList = new ContainerSlackUserList();

            try
            {
                Task<ContainerSlackUserList> task1 = T3SlackAPI.GetUserListFromSlack();
                task1.Wait();
                UserList = task1.Result;

                var result = task1.Result;
                for (int i = 0; i < result.Members.Count; i++)
                {
                    string name = result.Members[i].Name;
                    string id = result.Members[i].Id;
                    string real_name = result.Members[i].RealName;

                    Console.WriteLine(i);
                    Console.WriteLine(real_name);
                    Console.WriteLine(name);
                    Console.WriteLine(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.ReadKey();
            }

            try
            {
                Task<ContainerSlackConversationList> task2 = T3SlackAPI.GetConversationListFromSlack();
                task2.Wait();

                var result2 = task2.Result;
                for (int i = 0; i < result2.Ims.Count; i++)
                {
                    string user = result2.Ims[i].User;
                    string id = result2.Ims[i].Id;

                    Console.WriteLine(i);
                    Console.WriteLine(user);
                    Console.WriteLine(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.ReadKey();
            }

            try
            {
                Task task3 = T3SlackAPI.SendMessage(channel: UserList.Members[18].Id, message: "Getestet seist Du");
                task3.Wait();
            }
                //FileStream file = FileReader.ReadFile(@"C:\Users\f.held\Desktop\Held-Docs\codecode.jpg");

                //Task task4 = T3SlackAPI.SendMessage(channel: result.Members[18].Id, message: "Getestet seist Du", filepath: @"C:\Users\f.held\Desktop\Held-Docs\codecode.jpg", attachment: file);
                //task4.Wait();

                //Task<ContainerSlackIncomingMessage> task5 = T3SlackAPI.GetMessagesFromChannel(channel: result2.Ims[12].Id, ammountMessagesToGet: 5);
                //task5.Wait();

                //var result3 = task5.Result;

                //for (int i = 0; i < result3.Messages.Count; i++)
                //{
                //    string user = result3.Messages[i].User;
                //    string text = result3.Messages[i].Text;
                //    Console.WriteLine("Message " + (i + 1));
                //    Console.WriteLine(user);
                //    Console.WriteLine(text);

                //    if (result3.Messages[i].Attachments != null)
                //    {
                //        string attachments = result3.Messages[i].Attachments[0].ThumbUrl.ToString();
                //        string attachmentsText = result3.Messages[i].Attachments[0].Text;
                //        Console.WriteLine(attachmentsText);
                //        Console.WriteLine(attachments);
                //    }
                //}
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.ReadKey();
            }
            finally
            {
                Console.WriteLine("Well, this seems to work! :)");
            }
        }
    }    
}