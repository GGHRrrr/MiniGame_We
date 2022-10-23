
using System.Collections.Generic;
using System.Linq;

namespace MEEC.ExportedConfigs{
public partial class PhoneMessageHankModel {

	public static List<PhoneMessageHankModel> Configs = new List<PhoneMessageHankModel>()
	{
		new PhoneMessageHankModel(1, 1, "2030年9月17日", 1, 0),
		new PhoneMessageHankModel(2, 3, "请问有人在吗？", 1, 0),
		new PhoneMessageHankModel(3, 3, "我迫切的需求帮助。", 1, 0),
		new PhoneMessageHankModel(4, 3, "如果看到了此条消息，请立刻回复我。", 1, 0),
		new PhoneMessageHankModel(5, 1, "2030年9月19日", 2, 0),
		new PhoneMessageHankModel(6, 3, "收到请回复，谢谢。", 2, 0),
		new PhoneMessageHankModel(7, 3, "我需要你的帮助朋友，哪怕仅仅告诉我这里发生了什么也好。", 2, 0),
		new PhoneMessageHankModel(8, 1, "2030年9月21日", 3, 0),
		new PhoneMessageHankModel(9, 3, "看见我的留言请一定回复我。", 3, 0),
		new PhoneMessageHankModel(10, 3, "我目前的处境十分糟糕，在了无人迹城市之中穿行让我无所适从。", 3, 0),
		new PhoneMessageHankModel(11, 3, "如果你知道相关情况的情报，请及时与我交流。", 3, 0),
		new PhoneMessageHankModel(12, 1, "2030年9月26日", 4, 0),
		new PhoneMessageHankModel(13, 3, "寂寞啊，就是有人说话时，没人在听。", 4, 0),
		new PhoneMessageHankModel(14, 3, "可到了有人在听的时候，却没话说了。", 4, 0),
		new PhoneMessageHankModel(15, 1, "2030年9月29日", 5, 1),
		new PhoneMessageHankModel(16, 2, "诶，我一直在线哦。", 5, 0),
		new PhoneMessageHankModel(17, 2, "怎么了杰克，搞得神经兮兮仿佛百十年没见过人一样。", 5, 0),
		new PhoneMessageHankModel(18, 3, "太好了，终于有人回复我消息了！", 5, 0),
		new PhoneMessageHankModel(19, 3, "我现在迫切需要得到你的帮助。", 5, 0),
		new PhoneMessageHankModel(20, 3, "城市究竟发生了什么？为什么我醒来后这座城市变得空无一人？", 5, 0),
		new PhoneMessageHankModel(21, 2, "你在说什么啊杰克？上次的大迁徙你不是和你的家人一起离开了吗？", 5, 0),
		new PhoneMessageHankModel(22, 2, "你看看，路线图我还保存着呢。", 5, 0),
		new PhoneMessageHankModel(23, 2, "你一定是太累了，有什么话下次再说。", 5, 0),
		new PhoneMessageHankModel(24, 3, "等等，我不是杰克。", 5, 0),
		new PhoneMessageHankModel(25, 3, "还有，你知道人们为什么当时要迁徙吗？", 5, 0),
		new PhoneMessageHankModel(26, 1, "2030年9月30日", 6, 2),
		new PhoneMessageHankModel(27, 3, "在吗？", 6, 0),
		new PhoneMessageHankModel(28, 3, "我想问问杰克的家人······现在的处境如何呢？", 6, 0),
		new PhoneMessageHankModel(29, 2, "家人吗······", 6, 0),
		new PhoneMessageHankModel(30, 2, "迁徙前倒是经常与你的家人见面，迁徙后我还真不清楚情况。", 6, 0),
		new PhoneMessageHankModel(31, 2, "这年头难啊，工作不顺心、家里不放心······", 6, 0),
		new PhoneMessageHankModel(32, 3, "这样嘛······", 6, 0),
		new PhoneMessageHankModel(33, 3, "那为什么要迁徙呢？", 6, 0),
		new PhoneMessageHankModel(34, 2, "不聊了，该工作了。", 6, 0),
		new PhoneMessageHankModel(35, 2, "你也是，找点正经事干干，别天天一惊一乍的。", 6, 0),
		new PhoneMessageHankModel(36, 3, "你为什么要回避迁徙的问题呢？", 6, 0),
		new PhoneMessageHankModel(37, 3, "那次迁徙，究竟发生了什么······", 6, 0),
		new PhoneMessageHankModel(38, 1, "2030年10月2日", 7, 3),
		new PhoneMessageHankModel(39, 3, "你还记得前往下一座城市的路上发生了什么吗？", 7, 0),
		new PhoneMessageHankModel(40, 3, "比如，美景、险情？", 7, 0),
		new PhoneMessageHankModel(41, 2, "倒像是一次愉快的旅行。无需背上过多的累赘，也不必承载过多的回忆。穿过乡镇，穿过荒原，来到下一座城市开始新生活。或许在此前我也做过这样的美梦呢。", 7, 0),
		new PhoneMessageHankModel(42, 3, "这么说来，我也曾向往过这样的旅行。", 7, 0),
		new PhoneMessageHankModel(43, 2, "但我们终究追赶不上狂奔的现实。", 7, 0),
		new PhoneMessageHankModel(44, 1, "2030年10月6日", 8, 4),
		new PhoneMessageHankModel(45, 3, "可以和我谈谈这座城市吗？", 8, 0),
		new PhoneMessageHankModel(46, 3, "它一定，足够的迷人。", 8, 0),
		new PhoneMessageHankModel(47, 2, "也许······", 8, 0),
		new PhoneMessageHankModel(48, 2, "但你应该能猜出来，这里发生了什么，不是么？", 8, 0),
		new PhoneMessageHankModel(49, 2, "请一路先前，找寻旅途的意义。", 8, 0),
	};

	public PhoneMessageHankModel() { }
	public PhoneMessageHankModel(int id, int type, string messageContext, int timeID, int messageInter)
	{
		this.Id = id;
		this.Type = type;
		this.MessageContext = messageContext;
		this.TimeID = timeID;
		this.MessageInter = messageInter;
	}

	public virtual PhoneMessageHankModel MergeFrom(PhoneMessageHankModel source)
	{
		this.Id = source.Id;
		this.Type = source.Type;
		this.MessageContext = source.MessageContext;
		this.TimeID = source.TimeID;
		this.MessageInter = source.MessageInter;
		return this;
	}

	public virtual PhoneMessageHankModel Clone()
	{
		var config = new PhoneMessageHankModel();
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
		protected static Dictionary<int, PhoneMessageHankModel[]> _tempRecordsDictById = new Dictionary<int, PhoneMessageHankModel[]>();
		public static PhoneMessageHankModel[] GetConfigsById(int Id)
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
		protected static Dictionary<int, PhoneMessageHankModel[]> _tempRecordsDictByType = new Dictionary<int, PhoneMessageHankModel[]>();
		public static PhoneMessageHankModel[] GetConfigsByType(int Type)
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
		protected static Dictionary<string, PhoneMessageHankModel[]> _tempRecordsDictByMessageContext = new Dictionary<string, PhoneMessageHankModel[]>();
		public static PhoneMessageHankModel[] GetConfigsByMessageContext(string MessageContext)
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
		protected static Dictionary<int, PhoneMessageHankModel[]> _tempRecordsDictByTimeID = new Dictionary<int, PhoneMessageHankModel[]>();
		public static PhoneMessageHankModel[] GetConfigsByTimeID(int TimeID)
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
		protected static Dictionary<int, PhoneMessageHankModel[]> _tempRecordsDictByMessageInter = new Dictionary<int, PhoneMessageHankModel[]>();
		public static PhoneMessageHankModel[] GetConfigsByMessageInter(int MessageInter)
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
