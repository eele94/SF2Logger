using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SF2Logger
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Relay relay = new Relay("79.110.88.183", 27932, "127.0.0.1", 27932);
            relay.serverReceivedData += Relay_serverReceivedData;
            relay.clientReceivedData += Relay_clientReceivedData;

            File.WriteAllText(Path.GetTempPath() + "/outz.sf2", "");
            File.WriteAllText(Path.GetTempPath() + "/inz.sf2", "");
        }

        private void Relay_clientReceivedData(object sender, SF2EventArgs e)
        {
            List<byte[]> bytes = Splitter.GetPackets(e.Data);
            Console.WriteLine("packet count: " + bytes.Count);

            File.AppendAllText(Path.GetTempPath() + "/inz.sf2", BitConverter.ToString(e.Data) + Environment.NewLine);

            List<SF2Packet> packets = new List<SF2Packet>();

            foreach(byte[] b in bytes)
            {
                packets.Add(new SF2Packet(b));
            }

            this.Invoke((MethodInvoker)delegate {

                ListViewItem lvi = CreateListViewItem(e.Server, new SF2Packet(e.Data));
                listViewLogs.Items.Add(lvi);
                /*foreach (SF2Packet packet in packets)
                {
                    ListViewItem lvi = CreateListViewItem(e.Server, packet);
                    listViewLogs.Items.Add(lvi);
                }*/
            });
        }

        private void Relay_serverReceivedData(object sender, SF2EventArgs e)
        {
            List<byte[]> bytes = Splitter.GetPackets(e.Data);
            Console.WriteLine("packet count: " + bytes.Count);

            File.AppendAllText(Path.GetTempPath() + "/outz.sf2", BitConverter.ToString(e.Data) + Environment.NewLine);

            List<SF2ServerPacket> packets = new List<SF2ServerPacket>();

            foreach (byte[] b in bytes)
            {
                packets.Add(new SF2ServerPacket(b));
            }

            this.Invoke((MethodInvoker)delegate {

                ListViewItem lvi = CreateListViewItem(e.Server, new SF2ServerPacket(e.Data));
                listViewLogs.Items.Add(lvi);

                /*foreach (SF2ServerPacket packet in packets)
                {
                    ListViewItem lvi = CreateListViewItem(e.Server, packet);
                    listViewLogs.Items.Add(lvi);
                }*/
                
            });
        }

        private ListViewItem CreateListViewItem(string server, SF2ServerPacket packet)
        {
            ListViewItem lvi = new ListViewItem(server);
            lvi.SubItems.Add(packet.Length.ToString());
            lvi.SubItems.Add(packet.Bytes.Length.ToString());
            lvi.SubItems.Add(getMeaning(packet.ID.ToString()));
            lvi.SubItems.Add(getMeaning(packet.Sub.ToString()));
            lvi.SubItems.Add(BitConverter.ToString(packet.Bytes));

            return lvi;
        }

        private ListViewItem CreateListViewItem(string server, SF2Packet packet)
        {
            ListViewItem lvi = new ListViewItem(server);
            lvi.SubItems.Add(packet.Length.ToString());
            lvi.SubItems.Add(packet.Bytes.Length.ToString());
            lvi.SubItems.Add(getMeaning(packet.ID.ToString()));
            lvi.SubItems.Add(" X ");
            lvi.SubItems.Add(BitConverter.ToString(packet.Bytes));

            lvi.BackColor = Color.Aqua;

            return lvi;
        }

        private string getMeaning(string input)
        {
            switch (input)
            {
                case "0": return "SRV_FAIL";
                case "1": return "SRV_1";
                case "2": return "SRV_2";
                case "101": return "LOGIN";
                case "105": return "MESSAGE";
                case "108": return "CREATE_ROOM";
                case "116": return "CHANGE_ROOM";
                case "190": return "USER_INFO";
                case "211": return "RECENT_WIN";
                case "249": return "EVENTS";
                case "304": return "FRIEND_STATS";
                case "305": return "FRIEND_CLAN_STATS";
                case "315": return "FRIEND_REQUEST";
            }
            return input;
        }

        public static string byteStringToString(string input)
        {
            input = input.Replace(" ", "");

            string str = "";
            byte[] data = input.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();

            foreach (byte b in data)
            {
                int num = Convert.ToInt32(b);

                if ((num >= 48 && num <= 57) || (num >= 65 && num <= 122)) str += (char)num;
                else str += '?';
            }

            return str;
        }

        private void listViewLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string byteString = listViewLogs.SelectedItems[0].SubItems[5].Text;
                textBoxInfo.Text = byteString;

                textBoxPlainText.Text = byteStringToString(byteString);
            }
            catch { }
        }

        private void buttonSaveBinary_Click(object sender, EventArgs e)
        {
            try
            {
                string byteString = listViewLogs.SelectedItems[0].SubItems[5].Text;
                byteString = byteString.Replace(" ", "");

                byte[] data = byteString.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();

                Random rand = new Random();

                string path = Path.GetTempPath() + "/" + rand.Next(0, 999999) + ".bin";

                using (FileStream fs = File.Create(path, data.Length, FileOptions.None))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, data);
                }

                Process.Start("explorer.exe", Path.GetTempPath());
            }
            catch { }
        }

        private void textBoxInfo_Click(object sender, EventArgs e)
        {
            textBoxInfo.SelectAll();
        }
    }
}
