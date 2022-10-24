using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MEEC.ExportedConfigs;

public class PhoneModel : BaseManager<PhoneModel>
{
    public PhoneData MPhoneData = new PhoneData();
    private bool hasInit = false;
    private PhoneMessageBlock tempPhoneMessageBlock = new PhoneMessageBlock();

    public void Init()
    {
        if(hasInit) return;
        foreach (var item in PhoneLogModel.Configs)
        {
            PhoneLogs logsdata = new PhoneLogs();
            logsdata.date = item.Time;
            logsdata.log = item.LogContext;
            logsdata.title = item.Title;
            logsdata.interID = item.LogInter;
            MPhoneData.logs.Add(logsdata);
            if(logsdata.interID > 0) 
                MPhoneData.logDic.Add(logsdata.interID,logsdata);
        }
        
        PhoneMessageWindow data = new PhoneMessageWindow();
        data.name = "Alice";
        for (int i = 0; i < PhoneMessageAliceModel.Configs.Count; i++)
        {
            PhoneMessageAliceModel item = PhoneMessageAliceModel.Configs[i];
            if (i == 0)
            {
                tempPhoneMessageBlock = new PhoneMessageBlock();
                tempPhoneMessageBlock.InterID = item.MessageInter;
            }
            else if (item.TimeID != PhoneMessageAliceModel.Configs[i - 1].TimeID)
            {
                data.messageBlocks.Add(tempPhoneMessageBlock);
                if(tempPhoneMessageBlock.InterID > 0)
                    data.messageBlocksDic.Add(tempPhoneMessageBlock.InterID,tempPhoneMessageBlock);
                tempPhoneMessageBlock = new PhoneMessageBlock();
                tempPhoneMessageBlock.InterID = item.MessageInter;
            }

            PhoneMessage messageData = new PhoneMessage();
            messageData.messagesContext =MessageChange(item.MessageContext);
            messageData.messageType = (MessageType)(item.Type - 1);
            tempPhoneMessageBlock.messages.Add(messageData);

            if (i == PhoneMessageAliceModel.Configs.Count - 1)
            {
                data.messageBlocks.Add(tempPhoneMessageBlock);
                if(tempPhoneMessageBlock.InterID > 0) 
                    data.messageBlocksDic.Add(tempPhoneMessageBlock.InterID,tempPhoneMessageBlock);
                MPhoneData.users.Add(data);
                MPhoneData.userDic.Add(data.name,data);
            }
        }
        
        data = new PhoneMessageWindow();
        data.name = "Aric";
        for (int i = 0; i < PhoneMessageAricModel.Configs.Count; i++)
        {
            PhoneMessageAricModel item = PhoneMessageAricModel.Configs[i];
            if (i == 0)
            {
                tempPhoneMessageBlock = new PhoneMessageBlock();
                tempPhoneMessageBlock.InterID = item.MessageInter;
            }
            else if (item.TimeID != PhoneMessageAricModel.Configs[i - 1].TimeID)
            {
                data.messageBlocks.Add(tempPhoneMessageBlock);
                if(tempPhoneMessageBlock.InterID > 0)
                    data.messageBlocksDic.Add(tempPhoneMessageBlock.InterID,tempPhoneMessageBlock);
                tempPhoneMessageBlock = new PhoneMessageBlock();
                tempPhoneMessageBlock.InterID = item.MessageInter;
            }

            PhoneMessage messageData = new PhoneMessage();
            messageData.messagesContext =MessageChange(item.MessageContext);
            messageData.messageType = (MessageType)(item.Type - 1);
            tempPhoneMessageBlock.messages.Add(messageData);

            if (i == PhoneMessageAricModel.Configs.Count - 1)
            {
                data.messageBlocks.Add(tempPhoneMessageBlock);
                if(tempPhoneMessageBlock.InterID > 0) 
                    data.messageBlocksDic.Add(tempPhoneMessageBlock.InterID,tempPhoneMessageBlock);
                MPhoneData.users.Add(data);
                MPhoneData.userDic.Add(data.name,data);
            }
        }
        
        data = new PhoneMessageWindow();
        data.name = "Hank";
        for (int i = 0; i < PhoneMessageHankModel.Configs.Count; i++)
        {
            PhoneMessageHankModel item = PhoneMessageHankModel.Configs[i];
            if (i == 0)
            {
                tempPhoneMessageBlock = new PhoneMessageBlock();
                tempPhoneMessageBlock.InterID = item.MessageInter;
            }
            else if (item.TimeID != PhoneMessageHankModel.Configs[i - 1].TimeID)
            {
                data.messageBlocks.Add(tempPhoneMessageBlock);
                if(tempPhoneMessageBlock.InterID > 0)
                    data.messageBlocksDic.Add(tempPhoneMessageBlock.InterID,tempPhoneMessageBlock);
                tempPhoneMessageBlock = new PhoneMessageBlock();
                tempPhoneMessageBlock.InterID = item.MessageInter;
            }

            PhoneMessage messageData = new PhoneMessage();
            messageData.messagesContext =MessageChange(item.MessageContext);
            messageData.messageType = (MessageType)(item.Type - 1);
            tempPhoneMessageBlock.messages.Add(messageData);

            if (i == PhoneMessageHankModel.Configs.Count - 1)
            {
                data.messageBlocks.Add(tempPhoneMessageBlock);
                if(tempPhoneMessageBlock.InterID > 0) 
                    data.messageBlocksDic.Add(tempPhoneMessageBlock.InterID,tempPhoneMessageBlock);
                MPhoneData.users.Add(data);
                MPhoneData.userDic.Add(data.name,data);
            }
        }

        tempPhoneMessageBlock = null;
        hasInit = true;
    }

    string MessageChange(string input)
    {
        for (int i = 15; i < input.Length; i += 16)
                input = input.Insert(i, "\n");
        return input;
    }
    
}
