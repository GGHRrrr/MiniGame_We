
using System.Collections.Generic;
using System.Linq;

namespace MEEC.ExportedConfigs{
public partial class PhoneMessageAricModel {

	public static List<PhoneMessageAricModel> Configs = new List<PhoneMessageAricModel>()
	{
		new PhoneMessageAricModel(1, 1, "2030年9月17日", 1, 0),
		new PhoneMessageAricModel(2, 3, "在吗？能接收到我的信息吗？", 1, 0),
		new PhoneMessageAricModel(3, 3, "我急切需要您的帮助。", 1, 0),
		new PhoneMessageAricModel(4, 3, "如果看到了我的消息，请一定要回复我。", 1, 0),
		new PhoneMessageAricModel(5, 1, "2030年9月18日", 2, 0),
		new PhoneMessageAricModel(6, 3, "能收到我的消息吗？", 2, 0),
		new PhoneMessageAricModel(7, 3, "如果你真的接收到了我的信息，请一定要马上回复我。", 2, 0),
		new PhoneMessageAricModel(8, 1, "2030年9月20日", 3, 0),
		new PhoneMessageAricModel(9, 3, "也许你真的没有接收到我的信息······", 3, 0),
		new PhoneMessageAricModel(10, 3, "但我希望你还是可以，能发消息给我，哪怕一条也好······", 3, 0),
		new PhoneMessageAricModel(11, 1, "2030年9月25日", 4, 0),
		new PhoneMessageAricModel(12, 3, "看来你是不会给我回消息了。", 4, 0),
		new PhoneMessageAricModel(13, 3, "也许，把你当成一个倾诉对象也挺不错？", 4, 0),
		new PhoneMessageAricModel(14, 3, "比如，今天早饭你吃了什么？", 4, 0),
		new PhoneMessageAricModel(15, 1, "2030年9月30日", 5, 1),
		new PhoneMessageAricModel(16, 2, "今天来了点牛排配上产自法国波尔多的拉菲，工作日第一天嘛人总得犒劳一下自己。", 5, 0),
		new PhoneMessageAricModel(17, 2, "哥俩什么时候出来叙叙旧，好些日子没见到你了。", 5, 0),
		new PhoneMessageAricModel(18, 3, "不好意思。我不是你兄弟，我在城市中捡到了这台设备并向你寻求帮助，你可以帮一帮我嘛？", 5, 0),
		new PhoneMessageAricModel(19, 3, "我得知了这里曾经发生过一次大迁徙，城市中的人们全部向另一座城市迁移了。", 5, 0),
		new PhoneMessageAricModel(20, 3, "你还记得当时更详细的情况吗？", 5, 0),
		new PhoneMessageAricModel(21, 2, "啥？", 5, 0),
		new PhoneMessageAricModel(22, 2, "你喝酒喝糊涂了？", 5, 0),
		new PhoneMessageAricModel(23, 2, "我在镇子里的小餐馆等你，哥俩好好叙叙旧。", 5, 0),
		new PhoneMessageAricModel(24, 2, "地址发你了，记得看。", 5, 0),
		new PhoneMessageAricModel(25, 3, "喂！", 5, 0),
		new PhoneMessageAricModel(26, 3, "我没喝醉，我也根本不是你的兄弟！", 5, 0),
		new PhoneMessageAricModel(27, 1, "2030年10月3日", 6, 2),
		new PhoneMessageAricModel(28, 3, "小餐馆？我应该快到了。", 6, 0),
		new PhoneMessageAricModel(29, 3, "就在乡镇里对吧。不过看这情况，这家店多半是不开了啊。", 6, 0),
		new PhoneMessageAricModel(30, 2, "哪八辈子就关门歇业了。", 6, 0),
		new PhoneMessageAricModel(31, 2, "怎么想到这家店了？之前我们去你还嫌这家菜不对你胃口。", 6, 0),
		new PhoneMessageAricModel(32, 3, "······", 6, 0),
		new PhoneMessageAricModel(33, 3, "你又说在这里等我，又说这里早已经歇业，我不明白你的意思。", 6, 0),
		new PhoneMessageAricModel(34, 3, "你在耍我？", 6, 0),
		new PhoneMessageAricModel(35, 2, "你是不是误会了什么？", 6, 0),
		new PhoneMessageAricModel(36, 2, "我实在是，没明白你的意思。", 6, 0),
		new PhoneMessageAricModel(37, 3, "你······", 6, 0),
		new PhoneMessageAricModel(38, 1, "2030年10月4日", 7, 3),
		new PhoneMessageAricModel(39, 3, "上次你去那家小餐馆，是什么时候？", 7, 0),
		new PhoneMessageAricModel(40, 3, "我在那里拿到了一张车票，是你留给你的兄弟的吗？", 7, 0),
		new PhoneMessageAricModel(41, 2, "对的，当时我的兄弟没来，估计是碰上事了。", 7, 0),
		new PhoneMessageAricModel(42, 2, "我给他留了一张车票。", 7, 0),
		new PhoneMessageAricModel(43, 3, "留给他的？", 7, 0),
		new PhoneMessageAricModel(44, 2, "也许。", 7, 0),
	};

	public PhoneMessageAricModel() { }
	public PhoneMessageAricModel(int id, int type, string messageContext, int timeID, int messageInter)
	{
		this.Id = id;
		this.Type = type;
		this.MessageContext = messageContext;
		this.TimeID = timeID;
		this.MessageInter = messageInter;
	}

	public virtual PhoneMessageAricModel MergeFrom(PhoneMessageAricModel source)
	{
		this.Id = source.Id;
		this.Type = source.Type;
		this.MessageContext = source.MessageContext;
		this.TimeID = source.TimeID;
		this.MessageInter = source.MessageInter;
		return this;
	}

	public virtual PhoneMessageAricModel Clone()
	{
		var config = new PhoneMessageAricModel();
		config.MergeFrom(this);
		return config;
	}

	
	/// <summary>
	/// 消息ID(显示顺序)
	/// </summary>
	public int Id;
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
		protected static Dictionary<int, PhoneMessageAricModel[]> _tempRecordsDictById = new Dictionary<int, PhoneMessageAricModel[]>();
		public static PhoneMessageAricModel[] GetConfigsById(int Id)
		{
			if (_tempRecordsDictById.ContainsKey(Id))
			{
				return _tempRecordsDictById.GetValueOrDefault(Id);
			}
			else
			{
				var records = Configs.Where(c => c.Id == Id).ToArray();
				_tempRecordsDictById.Add(Id, records);
				return records;
			}
		}
		protected static Dictionary<int, PhoneMessageAricModel[]> _tempRecordsDictByType = new Dictionary<int, PhoneMessageAricModel[]>();
		public static PhoneMessageAricModel[] GetConfigsByType(int Type)
		{
			if (_tempRecordsDictByType.ContainsKey(Type))
			{
				return _tempRecordsDictByType.GetValueOrDefault(Type);
			}
			else
			{
				var records = Configs.Where(c => c.Type == Type).ToArray();
				_tempRecordsDictByType.Add(Type, records);
				return records;
			}
		}
		protected static Dictionary<string, PhoneMessageAricModel[]> _tempRecordsDictByMessageContext = new Dictionary<string, PhoneMessageAricModel[]>();
		public static PhoneMessageAricModel[] GetConfigsByMessageContext(string MessageContext)
		{
			if (_tempRecordsDictByMessageContext.ContainsKey(MessageContext))
			{
				return _tempRecordsDictByMessageContext.GetValueOrDefault(MessageContext);
			}
			else
			{
				var records = Configs.Where(c => c.MessageContext == MessageContext).ToArray();
				_tempRecordsDictByMessageContext.Add(MessageContext, records);
				return records;
			}
		}
		protected static Dictionary<int, PhoneMessageAricModel[]> _tempRecordsDictByTimeID = new Dictionary<int, PhoneMessageAricModel[]>();
		public static PhoneMessageAricModel[] GetConfigsByTimeID(int TimeID)
		{
			if (_tempRecordsDictByTimeID.ContainsKey(TimeID))
			{
				return _tempRecordsDictByTimeID.GetValueOrDefault(TimeID);
			}
			else
			{
				var records = Configs.Where(c => c.TimeID == TimeID).ToArray();
				_tempRecordsDictByTimeID.Add(TimeID, records);
				return records;
			}
		}
		protected static Dictionary<int, PhoneMessageAricModel[]> _tempRecordsDictByMessageInter = new Dictionary<int, PhoneMessageAricModel[]>();
		public static PhoneMessageAricModel[] GetConfigsByMessageInter(int MessageInter)
		{
			if (_tempRecordsDictByMessageInter.ContainsKey(MessageInter))
			{
				return _tempRecordsDictByMessageInter.GetValueOrDefault(MessageInter);
			}
			else
			{
				var records = Configs.Where(c => c.MessageInter == MessageInter).ToArray();
				_tempRecordsDictByMessageInter.Add(MessageInter, records);
				return records;
			}
		}

#endregion uid map

#region 生成fk.get/set










#endregion 生成fk.get/set
}
}
