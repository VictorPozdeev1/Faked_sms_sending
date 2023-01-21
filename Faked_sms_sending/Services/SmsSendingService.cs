﻿using Faked_sms_sending.Models;
using System.Security.Cryptography;

namespace Faked_sms_sending.Services;

public interface ISmsSendingService
{
    SentSms SendSms(SmsToSend smsToSend);
}

public class SmsSendingService : ISmsSendingService
{
    public SentSms SendSms(SmsToSend smsToSend)
    {
        var sendingStatuses = Enum.GetValues<SmsSendingStatus>();
        var randomSendingStatus = sendingStatuses[RandomNumberGenerator.GetInt32(sendingStatuses.Length)];
        return new SentSms()
        {
            Text = smsToSend.Text,
            ReceiverPhoneNo = smsToSend.ReceiverPhoneNo,
            SenderName = smsToSend.SenderName,

            SendingDateTime = DateTime.UtcNow,
            SendingStatus = randomSendingStatus
        };
    }
}
