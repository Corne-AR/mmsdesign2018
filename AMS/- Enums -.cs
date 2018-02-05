using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS
{
    public enum EditMode
    {
        New,
        Edit,
        Normal,
        Current
    }

    public enum WorkMode
    {
        Demo,
        Local,
        Network
    }

    public enum ReportMail
    {
        Ask,
        SendNow,
        SendNowNoPreview,
        PreviewWindow,
        PreviewPDF
    }

    public enum MessageType
    {
        Normal,
        Question,
        QuestionInput,
        Delay,
        DelayNoButton,
        Warning,
        WarningQuestion,
        Error
    }

    public enum MessageOut
    {
        YesOk,
        No,
        Cancel
    }
}
