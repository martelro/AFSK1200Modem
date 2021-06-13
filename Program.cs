using System;

namespace ReadWave
{
    class Program
    {        
        static void Main(string[] args)
        {
            //AFSK1200ModemTest.Test3();
            Console.WriteLine("Starting test {0}", 3);

            ax25.Packet packet;
            ax25.AFSK1200Modulator mod;
            float[] samples;
            //ax25.AFSK1200Demodulator dem;

            mod = new ax25.AFSK1200Modulator(44100);
            mod.txDelayMs = 500;
            //dem = new ax25.AFSK1200Demodulator(44100, 1, 0, new TestConsole("T3>> {0}"));
            //ax25.AFSK1200Demodulator dem = new ax25.Afsk1200Demodulator(44100, 1, 6, new Packet2Console("MO>> {0}"));

            packet = new ax25.Packet(
                "LAECTC", "KJ6BBX", new String[] { "WIDE1-1", "WIDE2-2" },
                ax25.Packet.AX25_CONTROL_APRS, ax25.Packet.AX25_PROTOCOL_NO_LAYER_3,
                System.Text.Encoding.ASCII.GetBytes(@"=5533.00N\03733.00Ek000/000 /A=00010 AFSK Test")
                );

            mod.GetSamples(packet, out samples);
            //dem.AddSamples(samples, samples.Length);

            // PLAY
            WaveStream.PlaySamples(44100, samples, false);

            // SAVE
            WaveStream.SaveWav16BitMono(@"test3.wav", 44100, samples);

            Console.WriteLine("Test {0} done", 3);
        }

        //static void agwe_client_FrameReceived(object sender, AgwpePort.AgwpeEventArgs e)
        //{
        //    // AGWPE Config and Information Frames
        //    // Read AX25 Unproto (UI) frames and data sent from a remote packet radio station
        //    if (e.FrameHeader.DataKind == ((byte)'U'))
        //    {
        //        AgwpePort.AgwpeMoniUnproto md = (AgwpePort.AgwpeMoniUnproto)e.FrameData;
        //        string cmd = md.AX25CallFrom + "WE>>" + md.AX25CallTo.Replace(" Via ", ",").Replace(" ", "") + ":" + System.Text.Encoding.GetEncoding(1251).GetString(md.AX25Data);
        //        Console.WriteLine("{0}{1} {2}", "A", DateTime.UtcNow.ToString("HHmmss"), cmd);
        //    };
        //}        
    }  
}
