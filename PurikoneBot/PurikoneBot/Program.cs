using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;

using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Discord;

using System.IO;

namespace PurikoneBot
{
    public class Program
    {
        public static DiscordSocketClient client;
        public static CommandService commands;
        public static IServiceProvider services;

        public List<ulong> YOYAKU_1 = new List<ulong>();
        public List<ulong> YOYAKU_2 = new List<ulong>();
        public List<ulong> YOYAKU_3 = new List<ulong>();
        public List<ulong> YOYAKU_4 = new List<ulong>();
        public List<ulong> YOYAKU_5 = new List<ulong>();

        public List<ulong> DAMAGE_1 = new List<ulong>();
        public List<ulong> DAMAGE_2 = new List<ulong>();
        public List<ulong> DAMAGE_3 = new List<ulong>();
        public List<ulong> DAMAGE_4 = new List<ulong>();
        public List<ulong> DAMAGE_5 = new List<ulong>();

        public string[] BossName = new string[5] { "", "", "", "", "" };

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        //BOT召喚のメイン処理
        public async Task MainAsync()
        {
            client = new DiscordSocketClient();
            commands = new CommandService();
            services = new ServiceCollection().BuildServiceProvider();
            client.MessageReceived += CommandRecieved;

            string token = "NjM3NzQ4ODQzNDUwMjA0MjEx.Xdg7HA.GpGORgSb7AI5-YnW0OgBTCwcZyo";

            /*StreamReader sr = new StreamReader("purikone.txt", Encoding.GetEncoding("Shift_JIS"));
            while (sr.EndOfStream == false)
            {
                String setting = sr.ReadLine();
                if (setting.IndexOf("tokenID=") >= 0)
                {
                    token = setting.Substring(8);
                }
                else if (setting.IndexOf("BOSS1=") >= 0)
                {
                    BossName[0] = setting.Substring(6);
                }
                else if (setting.IndexOf("BOSS2=") >= 0)
                {
                    BossName[1] = setting.Substring(6);
                }
                else if (setting.IndexOf("BOSS3=") >= 0)
                {
                    BossName[2] = setting.Substring(6);
                }
                else if (setting.IndexOf("BOSS4=") >= 0)
                {
                    BossName[3] = setting.Substring(6);
                }
                else if (setting.IndexOf("BOSS5=") >= 0)
                {
                    BossName[4] = setting.Substring(6);
                }
            }
            */
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), services);
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await Task.Delay(-1);
        }

        //命令を受けてからの処理
        private async Task CommandRecieved(SocketMessage messageParam)
        {
            try
            {
                var message = messageParam as SocketUserMessage;
                Console.WriteLine("{0} {1}:{2}", message.Channel.Name, message.Author.Username, message);
                string chat_message = "";

                if (message == null) { return; }
                // コメントがユーザーかBotかの判定
                if (message.Author.IsBot) { return; }

                int argPos = 0;

                // コマンドかどうか判定（今回は、「！」で判定）
                if (!(message.HasCharPrefix('！', ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))) { return; }

                var context = new CommandContext(client, message);


                //◆予約◆
                if (message.Content.Split(',')[0] == "！予約")
                {
                    //ボス１の予約を追加
                    if (message.Content.Split(',')[1] == BossName[0])
                    {
                        if (message.Content.Split(',').Length <= 2) { DAMAGE_1.Add(0); } else { DAMAGE_1.Add(ulong.Parse(message.Content.Split(',')[2])); }
                        YOYAKU_1.Add(message.Author.Id);
                        chat_message += BossName[0] + "の予約を受け付けました。" + "\n";
                        chat_message += "現在の予約状況です。" + "\n";
                        for (int i = 0; i < YOYAKU_1.Count(); i = ++i)
                        {
                            var a = await messageParam.Channel.GetUserAsync(YOYAKU_1[i]);
                            chat_message += a.Username;
                            if (DAMAGE_1[i] == 0)
                            {
                                chat_message += "\n";
                            }
                            else
                            {
                                chat_message += "：" + DAMAGE_1[i] + "万予想" + "\n";
                            }

                        }
                    }
                    //ボス２の予約を追加
                    else if (message.Content.Split(',')[1] == BossName[1])
                    {
                        if (message.Content.Split(',').Length <= 2) { DAMAGE_2.Add(0); } else { DAMAGE_2.Add(ulong.Parse(message.Content.Split(',')[2])); }
                        YOYAKU_2.Add(message.Author.Id);
                        chat_message += BossName[1] + "の予約を受け付けました。" + "\n";
                        chat_message += "現在の予約状況です。" + "\n";
                        for (int i = 0; i < YOYAKU_2.Count(); i = ++i)
                        {
                            var a = await messageParam.Channel.GetUserAsync(YOYAKU_2[i]);
                            chat_message += a.Username;
                            if (DAMAGE_2[i] == 0)
                            {
                                chat_message += "\n";
                            }
                            else
                            {
                                chat_message += "：" + DAMAGE_2[i] + "万予想" + "\n";
                            }

                        }
                    }
                    //ボス３の予約を追加
                    else if (message.Content.Split(',')[1] == BossName[2])
                    {
                        if (message.Content.Split(',').Length <= 2) { DAMAGE_3.Add(0); } else { DAMAGE_3.Add(ulong.Parse(message.Content.Split(',')[2])); }
                        YOYAKU_3.Add(message.Author.Id);
                        chat_message += BossName[2] + "の予約を受け付けました。" + "\n";
                        chat_message += "現在の予約状況です。" + "\n";
                        for (int i = 0; i < YOYAKU_3.Count(); i = ++i)
                        {
                            var a = await messageParam.Channel.GetUserAsync(YOYAKU_3[i]);
                            chat_message += a.Username;
                            if (DAMAGE_3[i] == 0)
                            {
                                chat_message += "\n";
                            }
                            else
                            {
                                chat_message += "：" + DAMAGE_3[i] + "万予想" + "\n";
                            }

                        }
                    }
                    //ボス４の予約を追加
                    else if (message.Content.Split(',')[1] == BossName[3])
                    {
                        if (message.Content.Split(',').Length <= 2) { DAMAGE_4.Add(0); } else { DAMAGE_4.Add(ulong.Parse(message.Content.Split(',')[2])); }
                        YOYAKU_4.Add(message.Author.Id);
                        chat_message += BossName[3] + "の予約を受け付けました。" + "\n";
                        chat_message += "現在の予約状況です。" + "\n";
                        for (int i = 0; i < YOYAKU_4.Count(); i = ++i)
                        {
                            var a = await messageParam.Channel.GetUserAsync(YOYAKU_4[i]);
                            chat_message += a.Username;
                            if (DAMAGE_4[i] == 0)
                            {
                                chat_message += "\n";
                            }
                            else
                            {
                                chat_message += "：" + DAMAGE_4[i] + "万予想" + "\n";
                            }

                        }
                    }
                    //ボス５の予約を追加
                    else if (message.Content.Split(',')[1] == BossName[4])
                    {
                        if (message.Content.Split(',').Length <= 2) { DAMAGE_5.Add(0); } else { DAMAGE_5.Add(ulong.Parse(message.Content.Split(',')[2])); }
                        YOYAKU_5.Add(message.Author.Id);
                        chat_message += BossName[4] + "の予約を受け付けました。" + "\n";
                        chat_message += "現在の予約状況です。" + "\n";
                        for (int i = 0; i < YOYAKU_5.Count(); i = ++i)
                        {
                            var a = await messageParam.Channel.GetUserAsync(YOYAKU_5[i]);
                            chat_message += a.Username;
                            if (DAMAGE_5[i] == 0)
                            {
                                chat_message += "\n";
                            }
                            else
                            {
                                chat_message += "：" + DAMAGE_5[i] + "万予想" + "\n";
                            }

                        }
                    }
                    else
                    {
                        chat_message += "ボスの名前が間違っています。";
                    }
                    await messageParam.Channel.SendMessageAsync(chat_message);
                }


                //◆予約一覧◆
                if (message.Content.Split(',')[0] == "！予約一覧")
                {
                    chat_message += "予約状況を確認します。" + "\n";
                    chat_message += "-----------------------------------------" + "\n";
                    chat_message += BossName[0] + "\n";
                    for (int i = 0; i < YOYAKU_1.Count(); i = ++i)
                    {
                        var a = await messageParam.Channel.GetUserAsync(YOYAKU_1[i]);
                        chat_message += a.Username;
                        if (DAMAGE_1[i] == 0)
                        {
                            chat_message += "\n";
                        }
                        else
                        {
                            chat_message += "：" + DAMAGE_1[i] + "万予想" + "\n";
                        }

                    }
                    chat_message += "-----------------------------------------" + "\n";
                    chat_message += BossName[1] + "\n";
                    for (int i = 0; i < YOYAKU_2.Count(); i = ++i)
                    {
                        var a = await messageParam.Channel.GetUserAsync(YOYAKU_2[i]);
                        chat_message += a.Username;
                        if (DAMAGE_2[i] == 0)
                        {
                            chat_message += "\n";
                        }
                        else
                        {
                            chat_message += "：" + DAMAGE_2[i] + "万予想" + "\n";
                        }

                    }
                    chat_message += "-----------------------------------------" + "\n";
                    chat_message += BossName[2] + "\n";
                    for (int i = 0; i < YOYAKU_3.Count(); i = ++i)
                    {
                        var a = await messageParam.Channel.GetUserAsync(YOYAKU_3[i]);
                        chat_message += a.Username;
                        if (DAMAGE_3[i] == 0)
                        {
                            chat_message += "\n";
                        }
                        else
                        {
                            chat_message += "：" + DAMAGE_3[i] + "万予想" + "\n";
                        }

                    }
                    chat_message += "-----------------------------------------" + "\n";
                    chat_message += BossName[3] + "\n";
                    for (int i = 0; i < YOYAKU_4.Count(); i = ++i)
                    {
                        var a = await messageParam.Channel.GetUserAsync(YOYAKU_4[i]);
                        chat_message += a.Username;
                        if (DAMAGE_4[i] == 0)
                        {
                            chat_message += "\n";
                        }
                        else
                        {
                            chat_message += "：" + DAMAGE_4[i] + "万予想" + "\n";
                        }

                    }
                    chat_message += "-----------------------------------------" + "\n";
                    chat_message += BossName[4] + "\n";
                    for (int i = 0; i < YOYAKU_5.Count(); i = ++i)
                    {
                        var a = await messageParam.Channel.GetUserAsync(YOYAKU_5[i]);
                        chat_message += a.Username;
                        if (DAMAGE_5[i] == 0)
                        {
                            chat_message += "\n";
                        }
                        else
                        {
                            chat_message += "：" + DAMAGE_5[i] + "万予想" + "\n";
                        }

                    }
                    chat_message += "-----------------------------------------" + "\n";
                    await messageParam.Channel.SendMessageAsync(chat_message);
                }

                //◆予約削除◆
                if (message.Content.Split(',')[0] == "！予約削除")
                {
                    int line = 0;
                    //ボス１の予約を削除
                    if (message.Content.Split(',')[1] == BossName[0])
                    {
                        if (YOYAKU_1.Contains(message.Author.Id) == true)
                        {
                            line = YOYAKU_1.FindLastIndex(obj => obj == message.Author.Id);
                            YOYAKU_1.RemoveAt(line);
                            DAMAGE_1.RemoveAt(line);
                            chat_message += BossName[0] + "の予約を取り消しました。" + "\n";
                        }
                        else
                        {
                            await messageParam.Channel.SendMessageAsync("予約の取り消しに失敗しました。");
                        }
                    }
                    //ボス２の予約を削除
                    else if (message.Content.Split(',')[1] == BossName[1])
                    {
                        if (YOYAKU_2.Contains(message.Author.Id) == true)
                        {
                            line = YOYAKU_2.FindLastIndex(obj => obj == message.Author.Id);
                            YOYAKU_2.RemoveAt(line);
                            DAMAGE_2.RemoveAt(line);
                            chat_message += BossName[1] + "の予約を取り消しました。" + "\n";
                        }
                        else
                        {
                            await messageParam.Channel.SendMessageAsync("予約の取り消しに失敗しました。");
                        }
                    }
                    //ボス３の予約を削除
                    else if (message.Content.Split(',')[1] == BossName[2])
                    {
                        if (YOYAKU_3.Contains(message.Author.Id) == true)
                        {
                            line = YOYAKU_3.FindLastIndex(obj => obj == message.Author.Id);
                            YOYAKU_3.RemoveAt(line);
                            DAMAGE_3.RemoveAt(line);
                            chat_message += BossName[2] + "の予約を取り消しました。" + "\n";
                        }
                        else
                        {
                            await messageParam.Channel.SendMessageAsync("予約の取り消しに失敗しました。");
                        }
                    }
                    //ボス４の予約を削除
                    else if (message.Content.Split(',')[1] == BossName[3])
                    {
                        if (YOYAKU_4.Contains(message.Author.Id) == true)
                        {
                            line = YOYAKU_4.FindLastIndex(obj => obj == message.Author.Id);
                            YOYAKU_4.RemoveAt(line);
                            DAMAGE_4.RemoveAt(line);
                            chat_message += BossName[3] + "の予約を取り消しました。" + "\n";
                        }
                        else
                        {
                            await messageParam.Channel.SendMessageAsync("予約の取り消しに失敗しました。");
                        }
                    }
                    //ボス５の予約を削除
                    else if (message.Content.Split(',')[1] == BossName[4])
                    {
                        if (YOYAKU_5.Contains(message.Author.Id) == true)
                        {
                            line = YOYAKU_5.FindLastIndex(obj => obj == message.Author.Id);
                            YOYAKU_5.RemoveAt(line);
                            DAMAGE_5.RemoveAt(line);
                            chat_message += BossName[4] + "の予約を取り消しました。" + "\n";
                            chat_message += "現在の予約状況です。" + "\n";
                        }
                        else
                        {
                            chat_message += "予約の取り消しに失敗しました。" + "\n";
                        }
                    }
                    else
                    {
                        chat_message += "ボスの名前が間違っています。" + "\n";
                    }
                    await messageParam.Channel.SendMessageAsync(chat_message);
                }

                //◆予約ボス削除◆
                if (message.Content.Split(',')[0] == "！予約ボス削除")
                {
                    //ボス１の予約を削除
                    if (message.Content.Split(',')[1] == BossName[0])
                    {
                        YOYAKU_1.Clear();
                        DAMAGE_1.Clear();
                        await messageParam.Channel.SendMessageAsync(BossName[0] + "の予約を全て削除しました。");
                    }
                    //ボス２の予約を削除
                    else if (message.Content.Split(',')[1] == BossName[1])
                    {
                        YOYAKU_2.Clear();
                        DAMAGE_2.Clear();
                        await messageParam.Channel.SendMessageAsync(BossName[1] + "の予約を全て削除しました。");
                    }
                    //ボス３の予約を削除
                    else if (message.Content.Split(',')[1] == BossName[2])
                    {
                        YOYAKU_3.Clear();
                        DAMAGE_3.Clear();
                        await messageParam.Channel.SendMessageAsync(BossName[2] + "の予約を全て削除しました。");
                    }
                    //ボス４の予約を削除
                    else if (message.Content.Split(',')[1] == BossName[3])
                    {
                        YOYAKU_4.Clear();
                        DAMAGE_4.Clear();
                        await messageParam.Channel.SendMessageAsync(BossName[3] + "の予約を全て削除しました。");
                    }
                    //ボス５の予約を削除
                    else if (message.Content.Split(',')[1] == BossName[4])
                    {
                        YOYAKU_5.Clear();
                        DAMAGE_5.Clear();
                        await messageParam.Channel.SendMessageAsync(BossName[4] + "の予約を全て削除しました。");
                    }
                }

                //◆予約全削除◆
                if (message.Content.Split(',')[0] == "！予約全削除")
                {
                    YOYAKU_1.Clear();
                    YOYAKU_2.Clear();
                    YOYAKU_3.Clear();
                    YOYAKU_4.Clear();
                    YOYAKU_5.Clear();
                    DAMAGE_1.Clear();
                    DAMAGE_2.Clear();
                    DAMAGE_3.Clear();
                    DAMAGE_4.Clear();
                    DAMAGE_5.Clear();
                    await messageParam.Channel.SendMessageAsync("全ての予約を削除しました。");
                }


                //◆撃破◆
                if (message.Content.Split(',')[0] == "！撃破")
                {
                    if (message.Content.Split(',')[1] == BossName[0])
                    {
                        chat_message += "次のボスは" + BossName[1] + "です。" + "\n";
                        foreach (ulong id in YOYAKU_2)
                        {
                            chat_message += "<@!" + id + "> 出番です。" + "\n";
                        }
                    }
                    else if (message.Content.Split(',')[1] == BossName[1])
                    {
                        chat_message += "次のボスは" + BossName[2] + "です。" + "\n";
                        foreach (ulong id in YOYAKU_3)
                        {
                            chat_message += "<@!" + id + "> 出番です。" + "\n";
                        }
                    }
                    else if (message.Content.Split(',')[1] == BossName[2])
                    {
                        chat_message += "次のボスは" + BossName[3] + "です。" + "\n";
                        foreach (ulong id in YOYAKU_4)
                        {
                            chat_message += "<@!" + id + "> 出番です。" + "\n";
                        }
                    }
                    else if (message.Content.Split(',')[1] == BossName[3])
                    {
                        chat_message += "次のボスは" + BossName[4] + "です。" + "\n";
                        foreach (ulong id in YOYAKU_5)
                        {
                            chat_message += "<@!" + id + "> 出番です。" + "\n";
                        }
                    }
                    else if (message.Content.Split(',')[1] == BossName[4])
                    {
                        chat_message += "次のボスは" + BossName[0] + "です。" + "\n";
                        foreach (ulong id in YOYAKU_1)
                        {
                            chat_message += "<@!" + id + "> 出番です。" + "\n";
                        }
                    }
                    else
                    {
                        chat_message += "ボスの名前が間違っています。" + "\n";
                    }
                    await messageParam.Channel.SendMessageAsync(chat_message);
                }

                //◆ヘルプ◆
                if (message.Content.Split(',')[0] == "！ヘルプ")
                {
                    chat_message += "BOTに命令できるコマンドは、！予約、！予約一覧、！予約削除、！予約ボス削除、！予約全削除、！撃破の６つです。" + "\n";
                    chat_message += "予約は命令の後に,で区切ってボス名,予想ダメを入力してください。" + "\n";
                    chat_message += "予約削除は命令の後に,で区切ってボス名を入力してください。自身の予約が削除できます。" + "\n";
                    chat_message += "予約ボス削除は命令の後に,で区切ってボス名を入力してください。そのボスの予約を全て削除します。" + "\n";
                    chat_message += "撃破は命令の後に,で区切ってボス名を入力してください。次のボスを予約している人にメンションを送ります。" + "\n";
                    chat_message += "予約全削除、予約一覧は命令の後に入力は必要ありません。";
                    await messageParam.Channel.SendMessageAsync(chat_message);
                }
            }
            catch
            {
                await messageParam.Channel.SendMessageAsync("コマンドの内容を読み取れませんでした。");
            }
        }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
