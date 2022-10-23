
using System.Collections.Generic;
using System.Linq;

namespace MEEC.ExportedConfigs{
public partial class PhoneLogModel {

	public static List<PhoneLogModel> Configs = new List<PhoneLogModel>()
	{
		new PhoneLogModel(1, "搜索", "2030年9月17日", "      我居然在角落里发现了这个！除了短时间的信号微弱外，使用起来基本上没什么影响。应该是之前的主人留下的吧。在接下来的日子里，我或许可以尝试联系其中的联系人，并记录日志。今天就先补写一下从醒来到现在所经历的一些事情吧。", 0),
		new PhoneLogModel(2, "醒来", "2030年9月17日", "       我已经记不太清这是醒来的第几天了。当时只觉得头痛欲裂、疲软无力，过了好久才缓过神来。我被关在一个类似休眠舱的容器中，容器受到了撞击而造成了破坏，若非如此，可能我还将持续地沉睡下去，所幸身体并无大碍。经过推断，我应该是被关在了某个实验室之中，而醒来之前的记忆早已残缺，无法忆起。我搜索着四周，找到了它，一个飞行机器人。它因撞击容器而部分损坏，仅能发出”yi~yi~“的声响，我便将其取名为yiyi。好在实验室中还剩有不少的工具与零件，经过简单的维修，它便恢复了功能，可以进行基本的对话和运动。也许，将它作为伙伴，是个不错的选择？", 0),
		new PhoneLogModel(3, "调查", "2030年9月23日", "       接下来的几天依旧是在城市之中调查，但却鲜有收获。实验室外的场景大多残破不堪，已无人烟。人们似乎离开这里已经很久了，即便如此我依旧认为理论上还有人类存在的可能，也许只是我还没有探寻到。Yiyi倒是个旅途中不错的伙伴，一些基本的指令它都可以轻易做到，一些简单的对话在荒无人烟的场景下倒也让我觉得不太孤单。但手机发出的信息一直无人回应，这似乎是个不太好的信号。", 0),
		new PhoneLogModel(4, "希望", "2030年9月29日", "       今天突然收到了信息回复！经过简单的交谈，我已经对现状有了大致的了解。他们应该在很久之前撤离了这座城市，但具体的原因和时间并没有告知。而根据他提供的路线，我们需要穿过这片城市，来到下一座城市，也许这一切的发生原因我会在那里找到答案，甚至有可能找到其他的人。路途中的情况尚不明朗，但有了大致的路线规划，想必会轻松很多。ps：在聊天过程中，他将我认作杰克，想必是这台设备之前的主人。面对着我的追问，感到困惑倒也可以理解······但总有种，很怪的感觉。", 0),
		new PhoneLogModel(5, "启程", "2030年9月30日", "        又收到了一些消息，但能够获得的有效信息其实并不是很多。对面的人似乎对我的处境并不是很信任，觉得我是喝醉了甚至疯了。他们的回答同样让人摸不着头脑······就好像，我与他们并非处于同一片时空。至于那次大迁徙的具体情况，依旧是尚不明朗，甚至他们似乎在刻意的回避着这个问题。今天已经顺利抵达了城市边境，按照地图上所给出的路线，通过这座哨站后即可前往乡镇。希望，一切顺利。", 1),
		new PhoneLogModel(6, "不适", "2030年10月1日", "        大挑战······费劲千辛万苦总算离开这座城市了。这一路的情况还真是复杂，电路失效、断路、身份证明······人们匆匆离开了这座城市，却留下了一堆属于他们的独有的回忆。这一切都太不真实了，不论是我的处境，亦或是所受到的信息，都带有时光扭曲造成的不适。下一站乡镇，会遇到什么呢······", 2),
		new PhoneLogModel(7, "恍惚", "2030年10月4日", "       乡镇的情况比我想象中还要好上那么一点。如果不是为了前往城市寻找不知道还在不在的其他人，我还真挺愿意在这里过上一段时间。信息中的小餐馆，早已人去楼空，也仅仅留下两个机器人在此守望。“他”给我留下了一张车票，倒是帮了我大忙，走这么长的距离前往荒漠那我可真不敢想。他们究竟有没有最后见上一面对我来说已经不太重要了，但恍恍惚惚中，我好像······在走着别人曾经的路。", 3),
		new PhoneLogModel(8, "交错", "2030年10月6日", "        我找到了那座独栋公寓······大概。当我抵达的时候，那里仅仅剩下残破的小屋，隐约能看出昔日的模样。我在那里找到了他们爱的遗产，一封信，信中满是对未来的的期许与爱情的承诺。我烧了它······迫不得已但心事重重。我无从得知他们的命运，爱人也好，兄弟也罢，我明白他们与我并非来自同一片时空，我们的联系也不过是设备上的几句闲聊、路途上的些许指引。模棱两可、相互矛盾的对话并不是你我之间的错误，而是身份的隔阂、时间的交错。我期待、却也忧虑，下一站是城市，而那扇“门”后究竟是什么，答案很快就要揭晓了。", 4),
	};

	public PhoneLogModel() { }
	public PhoneLogModel(int id, string title, string time, string logContext, int logInter)
	{
		this.Id = id;
		this.Title = title;
		this.Time = time;
		this.LogContext = logContext;
		this.LogInter = logInter;
	}

	public virtual PhoneLogModel MergeFrom(PhoneLogModel source)
	{
		this.Id = source.Id;
		this.Title = source.Title;
		this.Time = source.Time;
		this.LogContext = source.LogContext;
		this.LogInter = source.LogInter;
		return this;
	}

	public virtual PhoneLogModel Clone()
	{
		var config = new PhoneLogModel();
		config.MergeFrom(this);
		return config;
	}

	
	/// <summary>
	/// 日志ID
	/// </summary>
	public int Id;
	/// <summary>
	/// 标题
	/// </summary>
	public string Title;
	/// <summary>
	/// 时间
	/// </summary>
	public string Time;
	/// <summary>
	/// 日志内容
	/// </summary>
	public string LogContext;
	/// <summary>
	/// 日志接入点（程序中出现新日志的标志，对于原有日志填0，其余为每个新日志单独标记一个数字）
	/// </summary>
	public int LogInter;

	
#region get字段





#endregion

#region uid map
		protected static Dictionary<int, PhoneLogModel[]> _tempRecordsDictById = new Dictionary<int, PhoneLogModel[]>();
		public static PhoneLogModel[] GetConfigsById(int Id)
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
		protected static Dictionary<string, PhoneLogModel[]> _tempRecordsDictByTitle = new Dictionary<string, PhoneLogModel[]>();
		public static PhoneLogModel[] GetConfigsByTitle(string Title)
		{
			if (_tempRecordsDictByTitle.ContainsKey(Title))
			{
				return _tempRecordsDictByTitle.GetValueOrDefault(Title);
			}
			else
			{
				var records = Configs.Where(c => c.Title == Title).ToArray();
				_tempRecordsDictByTitle.Add(Title, records);
				return records;
			}
		}
		protected static Dictionary<string, PhoneLogModel[]> _tempRecordsDictByTime = new Dictionary<string, PhoneLogModel[]>();
		public static PhoneLogModel[] GetConfigsByTime(string Time)
		{
			if (_tempRecordsDictByTime.ContainsKey(Time))
			{
				return _tempRecordsDictByTime.GetValueOrDefault(Time);
			}
			else
			{
				var records = Configs.Where(c => c.Time == Time).ToArray();
				_tempRecordsDictByTime.Add(Time, records);
				return records;
			}
		}
		protected static Dictionary<string, PhoneLogModel[]> _tempRecordsDictByLogContext = new Dictionary<string, PhoneLogModel[]>();
		public static PhoneLogModel[] GetConfigsByLogContext(string LogContext)
		{
			if (_tempRecordsDictByLogContext.ContainsKey(LogContext))
			{
				return _tempRecordsDictByLogContext.GetValueOrDefault(LogContext);
			}
			else
			{
				var records = Configs.Where(c => c.LogContext == LogContext).ToArray();
				_tempRecordsDictByLogContext.Add(LogContext, records);
				return records;
			}
		}
		protected static Dictionary<int, PhoneLogModel[]> _tempRecordsDictByLogInter = new Dictionary<int, PhoneLogModel[]>();
		public static PhoneLogModel[] GetConfigsByLogInter(int LogInter)
		{
			if (_tempRecordsDictByLogInter.ContainsKey(LogInter))
			{
				return _tempRecordsDictByLogInter.GetValueOrDefault(LogInter);
			}
			else
			{
				var records = Configs.Where(c => c.LogInter == LogInter).ToArray();
				_tempRecordsDictByLogInter.Add(LogInter, records);
				return records;
			}
		}

#endregion uid map

#region 生成fk.get/set










#endregion 生成fk.get/set
}
}
