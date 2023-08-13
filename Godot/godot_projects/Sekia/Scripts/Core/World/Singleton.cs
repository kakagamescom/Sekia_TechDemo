namespace ET
{
	public interface ISingletonReverseDispose
	{

	}

	public abstract class ASingleton : DisposeObject
	{
		/// <summary>
		/// 初始化
		/// </summary>
		internal abstract void Register();
	}

	public abstract class Singleton<T> : ASingleton where T : Singleton<T>
	{
		private bool isDisposed;

		private static T instance;

		public static T Instance
		{
			get
			{
				return instance;
			}
			private set
			{
				instance = value;
			}
		}

		internal override void Register()
		{
			Instance = (T)this;
		}

		public bool IsDisposed()
		{
			return this.isDisposed;
		}

		protected virtual void Destroy()
		{

		}

		public override void Dispose()
		{
			if (this.isDisposed)
			{
				return;
			}

			this.isDisposed = true;

			this.Destroy();

			Instance = null;
		}
	}
}
