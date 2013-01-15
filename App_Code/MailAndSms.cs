using System;
using System.Net;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Threading;
using System.ComponentModel;
using System.IO.Ports;
/// <summary>
/// Summary description for MailAndSms
/// </summary>
public class MailAndSms
{
    public bool SendEmail(string from, string to, string subject, string body)
    {
        //smtp host and port for gmail
        string host = "smtp.gmail.com";
        int port = 587;

        //compose email
        MailMessage msg = new MailMessage(from, to, subject, body);

        //create smtp client
        SmtpClient smtp = new SmtpClient();

        //set username and password of your email account
        string username = "mysocial.mooo.com.81@gmail.com";
        string password = "Its@NewPass";
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;


        smtp.Credentials = new NetworkCredential(username, password);
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;

        try
        {
            //Send email
            smtp.Send(msg);
        }
        catch (Exception exp)
        {
            return false;
        }
        return true;
    }




    /************************************************************************************
     * 
     *                                         SMS
     * 
     * ***********************************************************************************/
     private SerialPort SMSPort;

     public MailAndSms(string COMMPORT)
        {
            SMSPort = new SerialPort();
            SMSPort.PortName = COMMPORT;
            SMSPort.BaudRate = 9600;
            SMSPort.Parity = Parity.None;
            SMSPort.DataBits = 8;
            SMSPort.StopBits = StopBits.One;
            SMSPort.Handshake = Handshake.RequestToSend;
            SMSPort.DtrEnable = true;
            SMSPort.RtsEnable = true;
            SMSPort.NewLine = System.Environment.NewLine;
           
        }

        public string ExecCommand(SerialPort port, string command, int responseTimeout, string errorMessage)
        {
            try
            {

                port.DiscardOutBuffer();
                port.DiscardInBuffer();
                
                port.Write(command + "\r");

                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   

        public bool sendMsg( string PhoneNo, string Message)
        {
            bool isSend = false;
            SerialPort port = SMSPort;
            try
            {
                string recievedData = ExecCommand(port, "AT", 300, "No phone connected");
                recievedData = ExecCommand(port, "AT+CMGF=1", 300,
                    "Failed to set message format.");
                String command = "AT+CMGS=\"" + PhoneNo + "\"";
                recievedData = ExecCommand(port, command, 300,
                    "Failed to accept phoneNo");
                command = Message + char.ConvertFromUtf32(26) + "\r";
                recievedData = ExecCommand(port, command, 3000,
                    "Failed to send message"); //3 seconds
                if (recievedData.EndsWith("\r\nOK\r\n"))
                {
                    isSend = true;
                }
                else if (recievedData.Contains("ERROR"))
                {
                    isSend = false;
                }
                return isSend;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

        public void Open()
        {
            if (SMSPort.IsOpen == false)
            {
                SMSPort.Open();
              
            }
        }

        public void Close()
        {
            if (SMSPort.IsOpen == true)
            {
                SMSPort.Close();
            }
        }

}
