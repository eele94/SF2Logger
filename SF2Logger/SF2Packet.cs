using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public enum SRV_TYPES
{
    FAIL = 0,
    MESSAGE = 1,
    CONFIRM = 2
}

public enum CLN_TYPES
{
    LOGIN_ATTEMPT = 101,
    MESSAGE = 105,
    CREATE_ROOM = 108,
    CHANGE_ROOM_SETTINGS = 116,
    REQ_RECENT_WIN = 211,
    REQ_EVENTS = 249,
    ADD_FRIEND = 315,
    REQ_FRIEND_STATS = 304,
    REQ_FRIEND_CLAN = 305
}


class SF2Packet
{
    public byte[] Bytes { get; set; }
    public ushort Length { get; set; }
    public int ID { get; set; }

    public SF2Packet(byte[] bytes)
    {
        this.Bytes = bytes;
        this.Length = getLength(bytes);
        this.ID = getID(bytes);
    }

    public static ushort getLength(byte[] data)
    {
        if (data.Length < 2) return ushort.MaxValue;

        byte[] blength = new byte[2];
        Array.Copy(data, blength, 2);
        blength.Reverse();
        return BitConverter.ToUInt16(blength, 0);
    }

    public static ushort getID(byte[] data)
    {
        if (data.Length < 4) return ushort.MaxValue;

        byte[] blength = new byte[2];
        Array.Copy(data, 2, blength, 0, 2);
        blength.Reverse();
        return BitConverter.ToUInt16(blength, 0);
    }

    public static ushort getSub(byte[] data)
    {
        if (data.Length < 6) return ushort.MaxValue;

        byte[] blength = new byte[2];
        Array.Copy(data, 4, blength, 0, 2);
        blength.Reverse();
        return BitConverter.ToUInt16(blength, 0);
    }

    public override string ToString()
    {
        string bytes = Regex.Replace(BitConverter.ToString(this.Bytes), "-", "");
        string length = this.Length.ToString();
        string id = this.ID.ToString();

        while (length.Length < 5) length += ' ';
        while (id.Length < 5) id += ' ';

        return String.Format("{0} | {1} |   X   | {2}", length, id, bytes);
    }

}

class SF2ServerPacket : SF2Packet
{
    public ushort Sub { get; set; }
    public SF2ServerPacket(byte[] bytes)
        : base(bytes)
    {
        this.Sub = getSub(bytes);
    }

    public override string ToString()
    {
        string bytes = Regex.Replace(BitConverter.ToString(this.Bytes), "-", "");
        string length = this.Length.ToString();
        string id = this.ID.ToString();
        string sub = this.Sub.ToString();

        while (length.Length < 5) length += ' ';
        while (id.Length < 5) id += ' ';
        while (sub.Length < 5) sub += ' ';

        return String.Format("{0} | {1} | {2} | {3}", length, id, sub, bytes);
    }
}

public class Splitter
{
    public static List<byte[]> GetPackets(byte[] input)
    {
        byte[] bytes = input;
        List<byte[]> Packets = new List<byte[]>();

        short newLength = getLength(bytes);
        if (newLength == input.Length) return new List<byte[]> { input };

        while (newLength > 0)
        {

            try
            {
                if (bytes.Length < newLength) newLength = (short)bytes.Length;

                byte[] packet = new byte[newLength];
                Array.Copy(bytes, packet, newLength);

                Packets.Add(packet);

                byte[] newBytes = new byte[bytes.Length - newLength];
                Array.Copy(bytes, newLength, newBytes, 0, (bytes.Length - newLength));
                bytes = newBytes;

                newLength = getLength(bytes);

                while (newLength < 0)
                {
                    byte[] newLengthBytes = new byte[bytes.Length - 1];
                    Array.Copy(bytes, 1, newLengthBytes, 0, newLengthBytes.Length);
                    bytes = newLengthBytes;

                    newLength = getLength(bytes);
                }
            }
            catch { newLength = 0; }
        }
        return Packets;
    }

    public static short getLength(byte[] data)
    {
        if (data.Length < 2) return -1;

        byte[] blength = new byte[2];
        Array.Copy(data, blength, 2);
        return BitConverter.ToInt16(blength, 0);
    }
}