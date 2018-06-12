using SassyMQ.DEMO.Lib;
using SassyMQ.DEMO.Lib.RabbitMQ;
using SassyMQ.DEMO.Lib.RMQActors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammerWinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Programmer = new SMQProgrammer();
            this.Programmer.ReplyTo += Programmer_ReplyTo;
        }

        private void Programmer_ReplyTo(object sender, SassyMQ.Lib.RabbitMQ.PayloadEventArgs<DEMOPayload> e)
        {
            if (e.Payload.IsLexiconTerm(LexiconTermEnum.programmer_hello_world))
            {
                MessageBox.Show("Got reply from the world: " + e.Payload.Content);
            }
        }

        public SMQProgrammer Programmer { get; }

        private void button1_Click(object sender, EventArgs e)
        {
            var payload = this.Programmer.CreatePayload();
            payload.Content = textBox1.Text;
            this.Programmer.ProgrammerHello(payload);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.Programmer.Disconnect();
        }
    }
}
