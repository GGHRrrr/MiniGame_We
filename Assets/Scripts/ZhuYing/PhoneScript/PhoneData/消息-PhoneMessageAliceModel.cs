
using System.Collections.Generic;
using System.Linq;

namespace MEEC.ExportedConfigs{
public partial class PhoneMessageAliceModel {

	public static List<PhoneMessageAliceModel> PhoneLogsData = new List<PhoneMessageAliceModel>()
	{
		new PhoneMessageAliceModel(1, 1, "47743", 1, 0),
		new PhoneMessageAliceModel(2, 3, "在吗在吗？如果在的话请立刻回复我的消息。", 1, 0),
		new PhoneMessageAliceModel(3, 3, "我的处境十分的特殊，希望能得到你的帮助。", 1, 0),
		new PhoneMessageAliceModel(4, 1, "47744", 2, 0),
		new PhoneMessageAliceModel(5, 3, "可以接收到我的信息吗？", 2, 0),
		new PhoneMessageAliceModel(6, 3, "如果收到了我的消息，请及时的回复我。", 2, 0),
		new PhoneMessageAliceModel(7, 3, "我目前处于城市之中，希望你能为我指明方向。", 2, 0),
		new PhoneMessageAliceModel(8, 1, "47748", 3, 0),
		new PhoneMessageAliceModel(9, 3, "在最近几日的搜查过程中，除了遇上一些仍在继续工作的机器人，我对现实的了解情况几乎毫无进展。", 3, 0),
		new PhoneMessageAliceModel(10, 3, "就连仅存的机器人中，也不同程度地出现了损坏与磨损。", 3, 0),
		new PhoneMessageAliceModel(11, 3, "你们应该已经离开很久了吧。", 3, 0),
		new PhoneMessageAliceModel(12, 3, "为什么离开的如此匆忙？", 3, 0),
		new PhoneMessageAliceModel(13, 1, "47753", 4, 0),
		new PhoneMessageAliceModel(14, 3, "很多家庭的房屋中依旧保持着原有的样子，很多带有纪念意义的照片、收藏品也并没有被带走。", 4, 0),
		new PhoneMessageAliceModel(15, 3, "一切都是那么的自然······", 4, 0),
		new PhoneMessageAliceModel(16, 3, "也许是旅行？", 4, 0),
		new PhoneMessageAliceModel(17, 3, "当然，不过是玩笑话罢了。", 4, 0),
		new PhoneMessageAliceModel(18, 1, "47758", 5, 1),
		new PhoneMessageAliceModel(19, 2, "旅行？你要和我一起去嘛？", 5, 0),
		new PhoneMessageAliceModel(20, 2, "再过几天可是我们的纪念日，亲爱的难道不给我准备个惊喜嘛？", 5, 0),
		new PhoneMessageAliceModel(21, 2, "啊，你居然说这个是玩笑话！我要生气了。", 5, 0),
		new PhoneMessageAliceModel(22, 3, "对不起我不是你的男朋友。", 5, 0),
		new PhoneMessageAliceModel(23, 3, "你可以帮帮我吗？我的处境十分的糟糕。", 5, 0),
		new PhoneMessageAliceModel(24, 2, "什么，这可不好笑！", 5, 0),
		new PhoneMessageAliceModel(25, 2, "我啊，已经计划好了，我们可以去体验一下荒漠风情。", 5, 0),
		new PhoneMessageAliceModel(26, 3, "喂！我真的没开玩笑！", 5, 0),
		new PhoneMessageAliceModel(27, 2, "位置我发给你了，我们到时候见。", 5, 0),
		new PhoneMessageAliceModel(28, 3, "？？？", 5, 0),
		new PhoneMessageAliceModel(29, 1, "47761", 6, 2),
		new PhoneMessageAliceModel(30, 3, "荒漠中有什么，特别值得去的地方嘛？", 6, 0),
		new PhoneMessageAliceModel(31, 3, "比如，必去的旅行观赏点？", 6, 0),
		new PhoneMessageAliceModel(32, 2, "我想想。", 6, 0),
		new PhoneMessageAliceModel(33, 2, "荒漠中的独栋小屋？那里倒是非常的有名诶。", 6, 0),
		new PhoneMessageAliceModel(34, 2, "一起在火堆旁欣赏荒漠落日，相拥而眠。", 6, 0),
		new PhoneMessageAliceModel(35, 2, "等等，你不会想给我个惊喜吧。", 6, 0),
		new PhoneMessageAliceModel(36, 2, "我很期待哦。", 6, 0),
		new PhoneMessageAliceModel(37, 3, "我不是你的爱人······", 6, 0),
		new PhoneMessageAliceModel(38, 3, "但我祝你们玩的开心。", 6, 0),
	};

	public PhoneMessageAliceModel() { }
	public PhoneMessageAliceModel(int iD, int type, string messageContext, int timeID, int messageInter)
	{
		this.ID = iD;
		this.Type = type;
		this.MessageContext = messageContext;
		this.TimeID = timeID;
		this.MessageInter = messageInter;
	}

	public virtual PhoneMessageAliceModel MergeFrom(PhoneMessageAliceModel source)
	{
		this.ID = source.ID;
		this.Type = source.Type;
		this.MessageContext = source.MessageContext;
		this.TimeID = source.TimeID;
		this.MessageInter = source.MessageInter;
		return this;
	}

	public virtual PhoneMessageAliceModel Clone()
	{
		var config = new PhoneMessageAliceModel();
		config.MergeFrom(this);
		return config;
	}

	
	/// <summary>
	/// 消息ID(显示顺序)
	/// </summary>
	public int ID;
	/// <summary>
	/// 消息类型
	/// 1为时间
	/// 2为对方发送的消息
	/// 3为我方发送的消息
	/// </summary>
	public int Type;
	/// <summary>
	/// 消息内容
	/// </summary>
	public string MessageContext;
	/// <summary>
	/// 消息隶属时间（时间消息ID）
	/// 以时间为消息的大单位，一串收发消息属于一个时间，时间填自己ID
	/// </summary>
	public int TimeID;
	/// <summary>
	/// 消息接入点（程序中出现新消息的标志，对于原有消息填0，其余为每个新消息单独标记一个数字）
	/// [只有时间类的消息需要填，其余填0]
	/// </summary>
	public int MessageInter;

	
#region get字段





#endregion

#region uid map
		protected static Dictionary<int, PhoneMessageAliceModel[]> _tempRecordsDictByID = new Dictionary<int, PhoneMessageAliceModel[]>();
		public static PhoneMessageAliceModel[] GetConfigsByID(int ID)
		{
			if (_tempRecordsDictByID.ContainsKey(ID))
			{
				return _tempRecordsDictByID.GetValueOrDefault(ID);
			}
			else
			{
				var records = PhoneLogsData.Where(c => c.ID == ID).ToArray();
				_tempRecordsDictByID.Add(ID, records);
				return records;
			}
		}
		protected static Dictionary<int, PhoneMessageAliceModel[]> _tempRecordsDictByType = new Dictionary<int, PhoneMessageAliceModel[]>();
		public static PhoneMessageAliceModel[] GetConfigsByType(int Type)
		{
			if (_tempRecordsDictByType.ContainsKey(Type))
			{
				return _tempRecordsDictByType.GetValueOrDefault(Type);
			}
			else
			{
				var records = PhoneLogsData.Where(c => c.Type == Type).ToArray();
				_tempRecordsDictByType.Add(Type, records);
				return records;
			}
		}
		protected static Dictionary<string, PhoneMessageAliceModel[]> _tempRecordsDictByMessageContext = new Dictionary<string, PhoneMessageAliceModel[]>();
		public static PhoneMessageAliceModel[] GetConfigsByMessageContext(string MessageContext)
		{
			if (_tempRecordsDictByMessageContext.ContainsKey(MessageContext))
			{
				return _tempRecordsDictByMessageContext.GetValueOrDefault(MessageContext);
			}
			else
			{
				var records = PhoneLogsData.Where(c => c.MessageContext == MessageContext).ToArray();
				_tempRecordsDictByMessageContext.Add(MessageContext, records);
				return records;
			}
		}
		protected static Dictionary<int, PhoneMessageAliceModel[]> _tempRecordsDictByTimeID = new Dictionary<int, PhoneMessageAliceModel[]>();
		public static PhoneMessageAliceModel[] GetConfigsByTimeID(int TimeID)
		{
			if (_tempRecordsDictByTimeID.ContainsKey(TimeID))
			{
				return _tempRecordsDictByTimeID.GetValueOrDefault(TimeID);
			}
			else
			{
				var records = PhoneLogsData.Where(c => c.TimeID == TimeID).ToArray();
				_tempRecordsDictByTimeID.Add(TimeID, records);
				return records;
			}
		}
		protected static Dictionary<int, PhoneMessageAliceModel[]> _tempRecordsDictByMessageInter = new Dictionary<int, PhoneMessageAliceModel[]>();
		public static PhoneMessageAliceModel[] GetConfigsByMessageInter(int MessageInter)
		{
			if (_tempRecordsDictByMessageInter.ContainsKey(MessageInter))
			{
				return _tempRecordsDictByMessageInter.GetValueOrDefault(MessageInter);
			}
			else
			{
				var records = PhoneLogsData.Where(c => c.MessageInter == MessageInter).ToArray();
				_tempRecordsDictByMessageInter.Add(MessageInter, records);
				return records;
			}
		}

#endregion uid map

#region 生成fk.get/set










#endregion 生成fk.get/set
}
}
