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

        //BOT�����̃��C������
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

        //���߂��󂯂Ă���̏���
        private async Task CommandRecieved(SocketMessage messageParam)
        {
            try
            {
                var message = messageParam as SocketUserMessage;
                Console.WriteLine("{0} {1}:{2}", message.Channel.Name, message.Author.Username, message);
                string chat_message = "";

                if (message == null) { return; }
                // �R�����g�����[�U�[��Bot���̔���
                if (message.Author.IsBot) { return; }

                int argPos = 0;

                // �R�}���h���ǂ�������i����́A�u�I�v�Ŕ���j
                if (!(message.HasCharPrefix('�I', ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))) { return; }

                var context = new CommandContext(client, message);


                //���\��
                if (message.Content.Split(',')[0] == "�I�\��")
                {
                    //�{�X�P�̗\���ǉ�
                    if (message.Content.Split(',')[1] == BossName[0])
                    {
                        if (message.Content.Split(',').Length <= 2) { DAMAGE_1.Add(0); } else { DAMAGE_1.Add(ulong.Parse(message.Content.Split(',')[2])); }
                        YOYAKU_1.Add(message.Author.Id);
                        chat_message += BossName[0] + "�̗\����󂯕t���܂����B" + "\n";
                        chat_message += "���݂̗\��󋵂ł��B" + "\n";
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
                                chat_message += "�F" + DAMAGE_1[i] + "���\�z" + "\n";
                            }

                        }
                    }
                    //�{�X�Q�̗\���ǉ�
                    else if (message.Content.Split(',')[1] == BossName[1])
                    {
                        if (message.Content.Split(',').Length <= 2) { DAMAGE_2.Add(0); } else { DAMAGE_2.Add(ulong.Parse(message.Content.Split(',')[2])); }
                        YOYAKU_2.Add(message.Author.Id);
                        chat_message += BossName[1] + "�̗\����󂯕t���܂����B" + "\n";
                        chat_message += "���݂̗\��󋵂ł��B" + "\n";
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
                                chat_message += "�F" + DAMAGE_2[i] + "���\�z" + "\n";
                            }

                        }
                    }
                    //�{�X�R�̗\���ǉ�
                    else if (message.Content.Split(',')[1] == BossName[2])
                    {
                        if (message.Content.Split(',').Length <= 2) { DAMAGE_3.Add(0); } else { DAMAGE_3.Add(ulong.Parse(message.Content.Split(',')[2])); }
                        YOYAKU_3.Add(message.Author.Id);
                        chat_message += BossName[2] + "�̗\����󂯕t���܂����B" + "\n";
                        chat_message += "���݂̗\��󋵂ł��B" + "\n";
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
                                chat_message += "�F" + DAMAGE_3[i] + "���\�z" + "\n";
                            }

                        }
                    }
                    //�{�X�S�̗\���ǉ�
                    else if (message.Content.Split(',')[1] == BossName[3])
                    {
                        if (message.Content.Split(',').Length <= 2) { DAMAGE_4.Add(0); } else { DAMAGE_4.Add(ulong.Parse(message.Content.Split(',')[2])); }
                        YOYAKU_4.Add(message.Author.Id);
                        chat_message += BossName[3] + "�̗\����󂯕t���܂����B" + "\n";
                        chat_message += "���݂̗\��󋵂ł��B" + "\n";
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
                                chat_message += "�F" + DAMAGE_4[i] + "���\�z" + "\n";
                            }

                        }
                    }
                    //�{�X�T�̗\���ǉ�
                    else if (message.Content.Split(',')[1] == BossName[4])
                    {
                        if (message.Content.Split(',').Length <= 2) { DAMAGE_5.Add(0); } else { DAMAGE_5.Add(ulong.Parse(message.Content.Split(',')[2])); }
                        YOYAKU_5.Add(message.Author.Id);
                        chat_message += BossName[4] + "�̗\����󂯕t���܂����B" + "\n";
                        chat_message += "���݂̗\��󋵂ł��B" + "\n";
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
                                chat_message += "�F" + DAMAGE_5[i] + "���\�z" + "\n";
                            }

                        }
                    }
                    else
                    {
                        chat_message += "�{�X�̖��O���Ԉ���Ă��܂��B";
                    }
                    await messageParam.Channel.SendMessageAsync(chat_message);
                }


                //���\��ꗗ��
                if (message.Content.Split(',')[0] == "�I�\��ꗗ")
                {
                    chat_message += "�\��󋵂��m�F���܂��B" + "\n";
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
                            chat_message += "�F" + DAMAGE_1[i] + "���\�z" + "\n";
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
                            chat_message += "�F" + DAMAGE_2[i] + "���\�z" + "\n";
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
                            chat_message += "�F" + DAMAGE_3[i] + "���\�z" + "\n";
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
                            chat_message += "�F" + DAMAGE_4[i] + "���\�z" + "\n";
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
                            chat_message += "�F" + DAMAGE_5[i] + "���\�z" + "\n";
                        }

                    }
                    chat_message += "-----------------------------------------" + "\n";
                    await messageParam.Channel.SendMessageAsync(chat_message);
                }

                //���\��폜��
                if (message.Content.Split(',')[0] == "�I�\��폜")
                {
                    int line = 0;
                    //�{�X�P�̗\����폜
                    if (message.Content.Split(',')[1] == BossName[0])
                    {
                        if (YOYAKU_1.Contains(message.Author.Id) == true)
                        {
                            line = YOYAKU_1.FindLastIndex(obj => obj == message.Author.Id);
                            YOYAKU_1.RemoveAt(line);
                            DAMAGE_1.RemoveAt(line);
                            chat_message += BossName[0] + "�̗\����������܂����B" + "\n";
                        }
                        else
                        {
                            await messageParam.Channel.SendMessageAsync("�\��̎������Ɏ��s���܂����B");
                        }
                    }
                    //�{�X�Q�̗\����폜
                    else if (message.Content.Split(',')[1] == BossName[1])
                    {
                        if (YOYAKU_2.Contains(message.Author.Id) == true)
                        {
                            line = YOYAKU_2.FindLastIndex(obj => obj == message.Author.Id);
                            YOYAKU_2.RemoveAt(line);
                            DAMAGE_2.RemoveAt(line);
                            chat_message += BossName[1] + "�̗\����������܂����B" + "\n";
                        }
                        else
                        {
                            await messageParam.Channel.SendMessageAsync("�\��̎������Ɏ��s���܂����B");
                        }
                    }
                    //�{�X�R�̗\����폜
                    else if (message.Content.Split(',')[1] == BossName[2])
                    {
                        if (YOYAKU_3.Contains(message.Author.Id) == true)
                        {
                            line = YOYAKU_3.FindLastIndex(obj => obj == message.Author.Id);
                            YOYAKU_3.RemoveAt(line);
                            DAMAGE_3.RemoveAt(line);
                            chat_message += BossName[2] + "�̗\����������܂����B" + "\n";
                        }
                        else
                        {
                            await messageParam.Channel.SendMessageAsync("�\��̎������Ɏ��s���܂����B");
                        }
                    }
                    //�{�X�S�̗\����폜
                    else if (message.Content.Split(',')[1] == BossName[3])
                    {
                        if (YOYAKU_4.Contains(message.Author.Id) == true)
                        {
                            line = YOYAKU_4.FindLastIndex(obj => obj == message.Author.Id);
                            YOYAKU_4.RemoveAt(line);
                            DAMAGE_4.RemoveAt(line);
                            chat_message += BossName[3] + "�̗\����������܂����B" + "\n";
                        }
                        else
                        {
                            await messageParam.Channel.SendMessageAsync("�\��̎������Ɏ��s���܂����B");
                        }
                    }
                    //�{�X�T�̗\����폜
                    else if (message.Content.Split(',')[1] == BossName[4])
                    {
                        if (YOYAKU_5.Contains(message.Author.Id) == true)
                        {
                            line = YOYAKU_5.FindLastIndex(obj => obj == message.Author.Id);
                            YOYAKU_5.RemoveAt(line);
                            DAMAGE_5.RemoveAt(line);
                            chat_message += BossName[4] + "�̗\����������܂����B" + "\n";
                            chat_message += "���݂̗\��󋵂ł��B" + "\n";
                        }
                        else
                        {
                            chat_message += "�\��̎������Ɏ��s���܂����B" + "\n";
                        }
                    }
                    else
                    {
                        chat_message += "�{�X�̖��O���Ԉ���Ă��܂��B" + "\n";
                    }
                    await messageParam.Channel.SendMessageAsync(chat_message);
                }

                //���\��{�X�폜��
                if (message.Content.Split(',')[0] == "�I�\��{�X�폜")
                {
                    //�{�X�P�̗\����폜
                    if (message.Content.Split(',')[1] == BossName[0])
                    {
                        YOYAKU_1.Clear();
                        DAMAGE_1.Clear();
                        await messageParam.Channel.SendMessageAsync(BossName[0] + "�̗\���S�č폜���܂����B");
                    }
                    //�{�X�Q�̗\����폜
                    else if (message.Content.Split(',')[1] == BossName[1])
                    {
                        YOYAKU_2.Clear();
                        DAMAGE_2.Clear();
                        await messageParam.Channel.SendMessageAsync(BossName[1] + "�̗\���S�č폜���܂����B");
                    }
                    //�{�X�R�̗\����폜
                    else if (message.Content.Split(',')[1] == BossName[2])
                    {
                        YOYAKU_3.Clear();
                        DAMAGE_3.Clear();
                        await messageParam.Channel.SendMessageAsync(BossName[2] + "�̗\���S�č폜���܂����B");
                    }
                    //�{�X�S�̗\����폜
                    else if (message.Content.Split(',')[1] == BossName[3])
                    {
                        YOYAKU_4.Clear();
                        DAMAGE_4.Clear();
                        await messageParam.Channel.SendMessageAsync(BossName[3] + "�̗\���S�č폜���܂����B");
                    }
                    //�{�X�T�̗\����폜
                    else if (message.Content.Split(',')[1] == BossName[4])
                    {
                        YOYAKU_5.Clear();
                        DAMAGE_5.Clear();
                        await messageParam.Channel.SendMessageAsync(BossName[4] + "�̗\���S�č폜���܂����B");
                    }
                }

                //���\��S�폜��
                if (message.Content.Split(',')[0] == "�I�\��S�폜")
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
                    await messageParam.Channel.SendMessageAsync("�S�Ă̗\����폜���܂����B");
                }


                //�����j��
                if (message.Content.Split(',')[0] == "�I���j")
                {
                    if (message.Content.Split(',')[1] == BossName[0])
                    {
                        chat_message += "���̃{�X��" + BossName[1] + "�ł��B" + "\n";
                        foreach (ulong id in YOYAKU_2)
                        {
                            chat_message += "<@!" + id + "> �o�Ԃł��B" + "\n";
                        }
                    }
                    else if (message.Content.Split(',')[1] == BossName[1])
                    {
                        chat_message += "���̃{�X��" + BossName[2] + "�ł��B" + "\n";
                        foreach (ulong id in YOYAKU_3)
                        {
                            chat_message += "<@!" + id + "> �o�Ԃł��B" + "\n";
                        }
                    }
                    else if (message.Content.Split(',')[1] == BossName[2])
                    {
                        chat_message += "���̃{�X��" + BossName[3] + "�ł��B" + "\n";
                        foreach (ulong id in YOYAKU_4)
                        {
                            chat_message += "<@!" + id + "> �o�Ԃł��B" + "\n";
                        }
                    }
                    else if (message.Content.Split(',')[1] == BossName[3])
                    {
                        chat_message += "���̃{�X��" + BossName[4] + "�ł��B" + "\n";
                        foreach (ulong id in YOYAKU_5)
                        {
                            chat_message += "<@!" + id + "> �o�Ԃł��B" + "\n";
                        }
                    }
                    else if (message.Content.Split(',')[1] == BossName[4])
                    {
                        chat_message += "���̃{�X��" + BossName[0] + "�ł��B" + "\n";
                        foreach (ulong id in YOYAKU_1)
                        {
                            chat_message += "<@!" + id + "> �o�Ԃł��B" + "\n";
                        }
                    }
                    else
                    {
                        chat_message += "�{�X�̖��O���Ԉ���Ă��܂��B" + "\n";
                    }
                    await messageParam.Channel.SendMessageAsync(chat_message);
                }

                //���w���v��
                if (message.Content.Split(',')[0] == "�I�w���v")
                {
                    chat_message += "BOT�ɖ��߂ł���R�}���h�́A�I�\��A�I�\��ꗗ�A�I�\��폜�A�I�\��{�X�폜�A�I�\��S�폜�A�I���j�̂U�ł��B" + "\n";
                    chat_message += "�\��͖��߂̌��,�ŋ�؂��ă{�X��,�\�z�_������͂��Ă��������B" + "\n";
                    chat_message += "�\��폜�͖��߂̌��,�ŋ�؂��ă{�X������͂��Ă��������B���g�̗\�񂪍폜�ł��܂��B" + "\n";
                    chat_message += "�\��{�X�폜�͖��߂̌��,�ŋ�؂��ă{�X������͂��Ă��������B���̃{�X�̗\���S�č폜���܂��B" + "\n";
                    chat_message += "���j�͖��߂̌��,�ŋ�؂��ă{�X������͂��Ă��������B���̃{�X��\�񂵂Ă���l�Ƀ����V�����𑗂�܂��B" + "\n";
                    chat_message += "�\��S�폜�A�\��ꗗ�͖��߂̌�ɓ��͕͂K�v����܂���B";
                    await messageParam.Channel.SendMessageAsync(chat_message);
                }
            }
            catch
            {
                await messageParam.Channel.SendMessageAsync("�R�}���h�̓��e��ǂݎ��܂���ł����B");
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
